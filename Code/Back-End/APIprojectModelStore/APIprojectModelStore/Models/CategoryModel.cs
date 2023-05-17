namespace APIModelStore.Models
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public int? ParentID { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public string? Flag { get; set; }
    }
}
