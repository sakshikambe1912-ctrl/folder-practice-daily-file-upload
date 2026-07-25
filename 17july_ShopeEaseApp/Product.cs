namespace ShopEaseApp
{
    /// <summary>
    /// Module 2: Product Management.
    /// </summary>
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public decimal Discount { get; set; }   // percentage, e.g. 10 = 10%
        public double Rating { get; set; }

        public Product(int productId, string name, string category, string description,
                        decimal price, int quantity, string brand, decimal discount, double rating)
        {
            ProductId = productId;
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Quantity = quantity;
            Brand = brand;
            Discount = discount;
            Rating = rating;
        }

        public void DisplayRow()
        {
            Console.WriteLine($"{ProductId,-6}{Name,-12}{Category,-12}{Brand,-10}{Price,-10:0}{Quantity,-6}{Discount + "%",-8}{Rating,-6}");
        }

        public void DisplayFullDetails()
        {
            Console.WriteLine($"Product Id  : {ProductId}");
            Console.WriteLine($"Name        : {Name}");
            Console.WriteLine($"Category    : {Category}");
            Console.WriteLine($"Description : {Description}");
            Console.WriteLine($"Price       : {Price:0}");
            Console.WriteLine($"Quantity    : {Quantity}");
            Console.WriteLine($"Brand       : {Brand}");
            Console.WriteLine($"Discount    : {Discount}%");
            Console.WriteLine($"Rating      : {Rating}");
        }
    }
}
