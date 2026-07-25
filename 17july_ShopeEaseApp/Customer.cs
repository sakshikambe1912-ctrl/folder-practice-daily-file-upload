namespace ShopEaseApp
{
    /// <summary>
    /// Module 1: User Authentication (Customer side).
    /// Also holds this customer's cart and order history in memory.
    /// </summary>
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public List<CartItem> Cart { get; set; } = new();
        public List<Order> OrderHistory { get; set; } = new();
        public decimal ActiveCouponPercent { get; set; } = 0m;

        public Customer(int customerId, string name, string username, string password,
                         string email, string phone, string address)
        {
            CustomerId = customerId;
            Name = name;
            Username = username;
            Password = password;
            Email = email;
            Phone = phone;
            Address = address;
        }
    }
}
