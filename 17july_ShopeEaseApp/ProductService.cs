namespace ShopEaseApp
{
    /// <summary>
    /// Module 2: Product Management (Admin).
    /// </summary>
    public class ProductService
    {
        private readonly List<Product> products = new();

        public void AddProduct(Product product) => products.Add(product);

        public bool UpdateProduct(int productId, decimal? price, int? quantity, decimal? discount, string? description)
        {
            var product = FindById(productId);
            if (product == null) return false;

            if (price.HasValue) product.Price = price.Value;
            if (quantity.HasValue) product.Quantity = quantity.Value;
            if (discount.HasValue) product.Discount = discount.Value;
            if (!string.IsNullOrWhiteSpace(description)) product.Description = description;
            return true;
        }

        public bool DeleteProduct(int productId)
        {
            var product = FindById(productId);
            if (product == null) return false;
            products.Remove(product);
            return true;
        }

        public Product? FindById(int productId) => products.FirstOrDefault(p => p.ProductId == productId);

        public List<Product> SearchByName(string name) =>
            products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

        public List<Product> ViewAll() => products;

        public void DisplayAll()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }

            Console.WriteLine(new string('-', 75));
            Console.WriteLine($"{"ID",-6}{"Name",-12}{"Category",-12}{"Brand",-10}{"Price",-10}{"Qty",-6}{"Disc",-8}{"Rating",-6}");
            Console.WriteLine(new string('-', 75));
            foreach (var product in products)
                product.DisplayRow();
        }
    }
}
