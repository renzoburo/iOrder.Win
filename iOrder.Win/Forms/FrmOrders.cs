namespace iOrder.Win.Forms
{
    using System.Data.Entity;
    using System.Linq;
    using System.Windows.Forms;
    using DbAccess.Contexts.iOrder;

    public partial class FrmOrders : Form
    {
        iOrderContext orderContext = new iOrderContext();

        public FrmOrders()
        {
            InitializeComponent();
        }

        private void FrmOrdersLoad(object sender, System.EventArgs e)
        {
            orderContext = new iOrderContext();

            orderContext.Orders.Load();
            orderContext.Products.Load();

            orderBindingSource.DataSource = orderContext.Orders.Local.ToBindingList();

            orderDetailDataGridView.DataError += OrderDetailDataGridViewDataError;
            orderDetailDataGridViewProductColumn.DataSource = orderContext.Products.Local.ToBindingList();
        }

        private void OrderDetailDataGridViewDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void orderBindingNavigatorSaveItemClick(object sender, System.EventArgs e)
        {
            Validate();

            foreach (var orderDetail in orderContext.OrderDetails.Local.ToList())
            {
                if (orderDetail.Order == null)
                    orderContext.OrderDetails.Remove(orderDetail);
            }

            orderContext.SaveChanges();

            orderDataGridView.Refresh();
            orderDetailDataGridView.Refresh();
        }

        private void FrmOrdersFormClosing(object sender, FormClosingEventArgs e)
        {
            orderContext.Dispose();
        }
    }
}
