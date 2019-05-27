namespace iOrder.Win.DbAccess.Contexts.iOrder
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Helpers;

    [Table("Products", Schema = "Fulfillment")]
    public partial class Product
    {
        private ObservableListSource<OrderDetail> orderDetails = new ObservableListSource<OrderDetail>();

        public int ProductID { get; set; }

        [Required]
        [StringLength(32)]
        public string ProductCode { get; set; }

        [Required]
        [StringLength(128)]
        public string ProducttName { get; set; }

        [StringLength(2048)]
        public string ProductDescription { get; set; }

        [StringLength(1024)]
        public string ImageUrl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Price { get; set; }

        public virtual ObservableListSource<OrderDetail> OrderDetails
        {
            get => orderDetails ?? (orderDetails = new ObservableListSource<OrderDetail>());
            set => orderDetails = value;
        }
    }
}
