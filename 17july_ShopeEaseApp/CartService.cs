namespace ShopEaseApp
{
    /// <summary>
    /// Module 4: Shopping Cart. Operates on a given customer's Cart list.
    /// </summary>
    public class CartService
    {
        private const decimal GstPercent = 18m;

        public void AddToCart(Customer customer, Product product, int quantity)
        {
            var existing = customer.Cart.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (existing != null)
                existing.Quantity += quantity;
            else
                customer.Cart.Add(new CartItem(product, quantity));
        }

        public bool RemoveItem(Customer customer, int productId)
        {
            var item = customer.Cart.FirstOrDefault(c => c.Product.ProductId == productId);
            if (item == null) return false;
            customer.Cart.Remove(item);
            return true;
        }

        public bool UpdateQuantity(Customer customer, int productId, int newQuantity)
        {
            var item = customer.Cart.FirstOrDefault(c => c.Product.ProductId == productId);
            if (item == null) return false;
            item.Quantity = newQuantity;
            return true;
        }

        public void ClearCart(Customer customer) => customer.Cart.Clear();

        public void ApplyCoupon(Customer customer, string couponCode)
        {
            // Simple simulated coupons.
            customer.ActiveCouponPercent = couponCode.Trim().ToUpper() switch
            {
                "SAVE10" => 10m,
                "SAVE20" => 20m,
                _ => 0m
            };
        }

        public void DisplayCart(Customer customer)
        {
            if (customer.Cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"{"Item",-15}{"Price",-10}{"Qty",-6}{"Line Total",-12}");
            Console.WriteLine(new string('-', 50));
            foreach (var item in customer.Cart)
                Console.WriteLine($"{item.Product.Name,-15}{item.Product.Price,-10:0}{item.Quantity,-6}{item.LineTotal,-12:0}");
        }

        /// <summary>
        /// Computes (subtotal, discount, gst, grandTotal) for the current cart,
        /// combining each product's own discount with any applied coupon.
        /// </summary>
        public (decimal subTotal, decimal discount, decimal gst, decimal grandTotal) ViewTotal(Customer customer)
        {
            decimal subTotal = customer.Cart.Sum(c => c.LineTotal);

            decimal productDiscount = customer.Cart.Sum(c => c.LineTotal * c.Product.Discount / 100m);
            decimal couponDiscount = subTotal * customer.ActiveCouponPercent / 100m;
            decimal totalDiscount = productDiscount + couponDiscount;

            decimal afterDiscount = subTotal - totalDiscount;
            decimal gst = afterDiscount * GstPercent / 100m;
            decimal grandTotal = afterDiscount + gst;

            return (subTotal, totalDiscount, gst, grandTotal);
        }

        public void DisplayTotal(Customer customer)
        {
            var (subTotal, discount, gst, grandTotal) = ViewTotal(customer);
            Console.WriteLine($"Total       : {subTotal:0}");
            Console.WriteLine($"Discount    : {discount:0}");
            Console.WriteLine($"GST ({GstPercent}%) : {gst:0}");
            Console.WriteLine($"Grand Total : {grandTotal:0}");
        }
    }
}
