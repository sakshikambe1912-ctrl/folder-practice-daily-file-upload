namespace ShopEaseApp
{
    /// <summary>
    /// Module 4: Shopping Cart — one line in a customer's cart.
    /// </summary>
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal LineTotal => Product.Price * Quantity;
    }
}
