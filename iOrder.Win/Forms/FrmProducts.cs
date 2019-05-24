namespace iOrder.Win.Forms
{
    using System.Data.Entity;
    using System.Windows.Forms;
    using DbAccess.Contexts.iOrder;

    public partial class FrmProducts : Form
    {
        iOrderContext orderContext = new iOrderContext();

        public FrmProducts()
        {
            InitializeComponent();
        }

        private void FrmProductsLoad(object sender, System.EventArgs e)
        {
            orderContext = new iOrderContext();

            orderContext.Products.Load();
            orderContext.Suppliers.Load();

            productDataGridView.DataSource = orderContext.Products.Local.ToBindingList();

            productDataGridView.DataError += ProductDataGridViewDataError;
            productDataGridViewSupplierColumn.DataSource = orderContext.Suppliers.Local.ToBindingList();
        }

        private void ProductDataGridViewDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void productDataGridViewCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = productDataGridView[e.ColumnIndex, e.RowIndex];

            if (cell.OwningColumn.DataPropertyName.Equals("ImageUrl"))
            {
                var cellValue = cell.Value?.ToString();
                using (var openDialog = new OpenFileDialog())
                {
                    openDialog.FileName = cellValue;
                    if (openDialog.ShowDialog() == DialogResult.OK)
                    {
                        productDataGridView[e.ColumnIndex, e.RowIndex].Value = openDialog.FileName;
                    }
                }
            }
                
        }

        private void FrmProductsFormClosing(object sender, FormClosingEventArgs e)
        {
            orderContext.Dispose();
        }

        private void productBindingNavigatorSaveItem_Click_1(object sender, System.EventArgs e)
        {
            Validate();

            orderContext.SaveChanges();

            productDataGridView.Refresh();
        }
    }
}
