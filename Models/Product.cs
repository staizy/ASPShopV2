namespace ASPShopV2.Models
{
    public class Product
    {
        public Product(string name, string description, double price, string pathImg)
        {
            Name = name;
            Description = description;
            Price = price;
            PathImg = pathImg;                    
        }

        public Product() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Себестоимость продукта
        /// </summary>
        public double Price { get; set; }
        public string PathImg { get; set; }

        public override string ToString() 
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price} \n Image path: {PathImg} \n Desc: {Description}";
        }

        
    }
}