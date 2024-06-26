namespace WebApiLessons.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public decimal Price { get; set; }

        public virtual ProductGroup ProductGroup { get; set; }
        public virtual ICollection<Storage> Storages { get; set; }
    }
}
