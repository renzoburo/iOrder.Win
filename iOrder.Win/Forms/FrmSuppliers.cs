namespace iOrder.Win.Forms
{
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
            Validate();

            orderContext.SaveChanges();

            supplierDataGridView.Refresh();
        }

        private void FrmSuppliersFormClosing(object sender, FormClosingEventArgs e)
        {
            orderContext.Dispose();
        }
    }
}
