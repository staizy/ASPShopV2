namespace ASPShopV2.Models
{
    public class ProductInfo
    {
        public ProductInfo(Product product, double price, DateOnly dateReceipt, DateOnly expireDate, int count)
        {
            Product = product;
            Price = price;
            DateReceipt = dateReceipt;
            ExpireDate = expireDate;
            Count = count;
        }

        public ProductInfo() { }

        public int Id { get; set; }
        public Product Product { get; set; }
        /// <summary>
        /// Цена товара с учетом наценки
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Дата поступления товара в магазин
        /// </summary>
        public DateOnly DateReceipt { get; set; }
        /// <summary>
        /// Дата истечения срока годности
        /// </summary>
        public DateOnly ExpireDate { get; set; }
        /// <summary>
        /// Количество товара в магазине
        /// </summary>
        public int Count { get; set; }
    }
}
