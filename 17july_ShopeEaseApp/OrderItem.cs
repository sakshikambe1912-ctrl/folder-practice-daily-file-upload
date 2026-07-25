namespace ShopEaseApp
{
    /// <summary>
    /// A single line item frozen into an Order at checkout time.
    /// </summary>
    public class OrderItem
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal LineTotal => Price * Quantity;

        public OrderItem(string productName, decimal price, int quantity)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }
    }
}
