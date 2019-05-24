namespace iOrder.Win.DbAccess.Contexts.iOrder
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Helpers;

    [Table("Orders", Schema = "Order")]
    public partial class Order
    {
        private readonly ObservableListSource<OrderDetail> orderDetails = new ObservableListSource<OrderDetail>();

        public Order()
        {
            OrderDate = DateTime.Now;
        }

        public int OrderID { get; set; }

        [Required]
        [StringLength(32)]
        public string OrderCode { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public virtual ObservableListSource<OrderDetail> OrderDetails => orderDetails;
    }
}
