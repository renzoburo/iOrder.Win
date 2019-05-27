namespace iOrder.Win.Forms
{
    using System;
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
            orderContext.Suppliers.Load();

            orderBindingSource.DataSource = orderContext.Orders.Local.ToBindingList();

            orderDataGridViewSupplierColumn.DataSource = orderContext.Suppliers.Local.ToBindingList();
            orderDetailDataGridViewProductColumn.DataSource = orderContext.Products.Local.ToBindingList();
        }

        private void orderBindingNavigatorSaveItemClick(object sender, System.EventArgs e)
        {
            try
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmOrdersFormClosing(object sender, FormClosingEventArgs e)
        {
            orderContext.Dispose();
        }
    }
}
