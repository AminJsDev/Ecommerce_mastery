namespace EM.Domain.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public long Quantity { get; set; }
        public float Price { get; set; }
        public bool IsDeleted { get; set; }



        public long CardCategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
