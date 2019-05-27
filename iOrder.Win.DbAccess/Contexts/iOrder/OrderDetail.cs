namespace iOrder.Win.DbAccess.Contexts.iOrder
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    [Table("OrderDetails", Schema = "Order")]
    public partial class OrderDetail
    {
        public int OrderDetailID { get; set; }

        public int? OrderID { get; set; }

        public virtual Order Order { get; set; }

        public int? ProductID { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        [Range(typeof(Int32), "1", "999", ErrorMessage = "Quantity should be between 1 and 999")]
        public int Quantity { get; set; }
    }
}
