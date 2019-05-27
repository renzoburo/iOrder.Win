namespace iOrder.Win.DbAccess.Contexts.iOrder
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Helpers;

    [Table("Suppliers", Schema = "Fulfillment")]
    public partial class Supplier
    {
        private ObservableListSource<Order> orders = new ObservableListSource<Order>();

        public int SupplierID { get; set; }

        [Required]
        [StringLength(32)]
        public string SupplierCode { get; set; }

        [Required]
        [StringLength(64)]
        public string SupplierName { get; set; }

        [StringLength(512)]
        public string SupplierDescription { get; set; }

        public virtual ObservableListSource<Order> Orders
        {
            get => orders ?? (orders = new ObservableListSource<Order>());
            set => orders = value;
        }
    }
}
