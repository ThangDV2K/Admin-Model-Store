namespace APIprojectModelStore.Models
{
    public class ProductsModel
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal? PriceListed { get; set; }
        public int? Sale { get; set; }
        public string? Avatar { get; set; }
        public int? Version { get; set; }
        public string? Weight { get; set; }
        public string? Height { get; set; }
        public string? Material { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }  
        public int? LastModifiedBy { get; set; }
        public string? Flag { get; set; }

    }
}
