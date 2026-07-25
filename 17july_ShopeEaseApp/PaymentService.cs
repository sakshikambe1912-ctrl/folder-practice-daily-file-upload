namespace ShopEaseApp
{
    /// <summary>
    /// Module 6: Payment Module (simulation only — no real payment gateway).
    /// </summary>
    public class PaymentService
    {
        public string Simulate(string paymentMethod)
        {
            // Cash On Delivery is confirmed only on physical delivery, so it stays Pending.
            // Card / UPI are simulated as immediately successful.
            return paymentMethod.Trim().ToLower() switch
            {
                "cash on delivery" or "cod" => "Pending",
                "credit card" or "debit card" or "upi" => "Success",
                _ => "Failed"
            };
        }
    }
}
