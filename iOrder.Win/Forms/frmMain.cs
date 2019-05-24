namespace iOrder.Win.Forms
{
    using System.Windows.Forms;

    public partial class FrmMain : Form
    {
        private FrmOrders orderForm;

        private FrmOrders OrderForm
        {
            get
            {
                if (orderForm == null || orderForm.IsDisposed)
                    orderForm = new FrmOrders {MdiParent = this};
                return orderForm;
            }
        }

        private FrmProducts productForm;

        private FrmProducts ProductForm
        {
            get
            {
                if (productForm == null || productForm.IsDisposed)
                    productForm = new FrmProducts { MdiParent = this };
                return productForm;
            }
        }

        private FrmSuppliers supplierForm;

        private FrmSuppliers SupplierForm
        {
            get
            {
                if (supplierForm == null || supplierForm.IsDisposed)
                    supplierForm = new FrmSuppliers { MdiParent = this };
                return supplierForm;
            }
        }

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMainLoad(object sender, System.EventArgs e)
        {
        }

        private void exitToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            Close();
        }

        private void ordersToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            OrderForm.Show();
            OrderForm.WindowState = FormWindowState.Maximized;
        }

        private void productsToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            ProductForm.Show();
            ProductForm.WindowState = FormWindowState.Maximized;
        }

        private void suppliersToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            SupplierForm.Show();
            SupplierForm.WindowState = FormWindowState.Maximized;
        }
    }
}
