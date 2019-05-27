namespace iOrder.Win.Forms
{
    using System;
    using System.Data.Entity;
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
