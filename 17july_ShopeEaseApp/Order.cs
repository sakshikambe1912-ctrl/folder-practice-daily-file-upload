namespace ShopEaseApp
{
    /// <summary>
    /// Module 5: Order Module + Module 6: Payment Module.
    /// </summary>
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal Gst { get; set; }
        public decimal GrandTotal { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }   // Success / Failed / Pending
        public bool IsCancelled { get; set; }

        public Order(int orderId, string customerName, string address, List<OrderItem> items,
                      decimal total, decimal discount, decimal gst, decimal grandTotal,
                      string paymentMethod, string paymentStatus)
        {
            OrderId = orderId;
            OrderDate = DateTime.Now;
            CustomerName = customerName;
            Address = address;
            Items = items;
            Total = total;
            Discount = discount;
            Gst = gst;
            GrandTotal = grandTotal;
            PaymentMethod = paymentMethod;
            PaymentStatus = paymentStatus;
            IsCancelled = false;
        }

        public void DisplaySummary()
        {
            Console.WriteLine($"Order Id : {OrderId}   Date : {OrderDate:dd-MMM-yyyy}   Status : {(IsCancelled ? "Cancelled" : PaymentStatus)}");
            Console.WriteLine($"Grand Total : {GrandTotal:0}");
        }
    }
}
