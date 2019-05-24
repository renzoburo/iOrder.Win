namespace iOrder.Win.DbAccess.Contexts.iOrder
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrderDetails", Schema = "Order")]
    public partial class OrderDetail
    {
        public int OrderDetailID { get; set; }

        public int? OrderID { get; set; }

        public virtual Order Order { get; set; }

        public int? ProductID { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
