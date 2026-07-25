namespace ShopEaseApp
{
    /// <summary>
    /// Module 5: Order Module + Module 7: Order History.
    /// </summary>
    public class OrderService
    {
        private readonly CartService cartService;
        private readonly PaymentService paymentService;
        private int nextOrderId = 5001;

        public OrderService(CartService cartService, PaymentService paymentService)
        {
            this.cartService = cartService;
            this.paymentService = paymentService;
        }

        // ---------- Checkout / Confirm Address / Select Payment / Place Order ----------
        public Order? PlaceOrder(Customer customer, string confirmedAddress, string paymentMethod)
        {
            if (customer.Cart.Count == 0)
                return null; // nothing to order

            var (subTotal, discount, gst, grandTotal) = cartService.ViewTotal(customer);

            var items = customer.Cart
                .Select(c => new OrderItem(c.Product.Name, c.Product.Price, c.Quantity))
                .ToList();

            string paymentStatus = paymentService.Simulate(paymentMethod);

            var order = new Order(
                nextOrderId++, customer.Name, confirmedAddress, items,
                subTotal, discount, gst, grandTotal, paymentMethod, paymentStatus);

            customer.OrderHistory.Add(order);

            // Order placed: clear cart and any applied coupon.
            cartService.ClearCart(customer);
            customer.ActiveCouponPercent = 0m;

            return order;
        }

        // ---------- Module 7: View Previous Orders ----------
        public void DisplayOrderHistory(Customer customer)
        {
            if (customer.OrderHistory.Count == 0)
            {
                Console.WriteLine("No previous orders.");
                return;
            }

            foreach (var order in customer.OrderHistory)
                order.DisplaySummary();
        }

        // ---------- Module 7: Search Order ----------
        public Order? SearchOrder(Customer customer, int orderId) =>
            customer.OrderHistory.FirstOrDefault(o => o.OrderId == orderId);

        // ---------- Module 7: Cancel Order ----------
        public bool CancelOrder(Customer customer, int orderId)
        {
            var order = SearchOrder(customer, orderId);
            if (order == null || order.IsCancelled)
                return false;

            order.IsCancelled = true;
            return true;
        }

        // ---------- Module 7: Download Invoice ----------
        public string GenerateInvoiceText(Order order)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("========== ShopEase Invoice ==========");
            sb.AppendLine($"Order Id      : {order.OrderId}");
            sb.AppendLine($"Date          : {order.OrderDate:dd-MMM-yyyy HH:mm}");
            sb.AppendLine($"Customer Name : {order.CustomerName}");
            sb.AppendLine($"Address       : {order.Address}");
            sb.AppendLine("---------------------------------------");
            sb.AppendLine($"{"Item",-15}{"Qty",-6}{"Price",-10}{"Line Total",-12}");
            foreach (var item in order.Items)
                sb.AppendLine($"{item.ProductName,-15}{item.Quantity,-6}{item.Price,-10:0}{item.LineTotal,-12:0}");
            sb.AppendLine("---------------------------------------");
            sb.AppendLine($"Total         : {order.Total:0}");
            sb.AppendLine($"Discount      : {order.Discount:0}");
            sb.AppendLine($"GST           : {order.Gst:0}");
            sb.AppendLine($"Grand Total   : {order.GrandTotal:0}");
            sb.AppendLine($"Payment       : {order.PaymentMethod} ({order.PaymentStatus})");
            sb.AppendLine($"Status        : {(order.IsCancelled ? "Cancelled" : "Confirmed")}");
            sb.AppendLine("========================================");
            return sb.ToString();
        }

        public string DownloadInvoice(Order order)
        {
            string invoiceText = GenerateInvoiceText(order);
            string fileName = $"Invoice_{order.OrderId}.txt";
            File.WriteAllText(fileName, invoiceText);
            return fileName;
        }
    }
}
