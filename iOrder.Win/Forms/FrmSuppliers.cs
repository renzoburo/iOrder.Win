namespace iOrder.Win.Forms
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Text;
    using System.Windows.Forms;
    using DbAccess.Contexts.iOrder;

    public partial class FrmSuppliers : Form
    {
        iOrderContext orderContext = new iOrderContext();

        public FrmSuppliers()
        {
            InitializeComponent();
        }

        private void FrmSuppliersLoad(object sender, System.EventArgs e)
        {
            orderContext = new iOrderContext();

            orderContext.Suppliers.Load();

            supplierBindingSource.DataSource = orderContext.Suppliers.Local.ToBindingList();
        }

        private void supplierBindingNavigatorSaveItemClick(object sender, System.EventArgs e)
        {
            try
            {
                Validate();

                orderContext.SaveChanges();

                supplierDataGridView.Refresh();
            }
            catch (DbEntityValidationException validationException)
            {
                var sBuilder = new StringBuilder();
                foreach (var entityValidationError in validationException.EntityValidationErrors)
                {
                    sBuilder.AppendLine($"{entityValidationError.Entry.Entity.GetType().Name} has the following errors:");
                    foreach (var validationError in entityValidationError.ValidationErrors)
                    {
                        sBuilder.AppendLine($" - Property: {validationError.PropertyName} Value: {entityValidationError.Entry.CurrentValues.GetValue<object>(validationError.PropertyName)} Error: {validationError.ErrorMessage}");
                    }
                }
                MessageBox.Show(sBuilder.ToString(), "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmSuppliersFormClosing(object sender, FormClosingEventArgs e)
        {
            orderContext.Dispose();
        }
    }
}
