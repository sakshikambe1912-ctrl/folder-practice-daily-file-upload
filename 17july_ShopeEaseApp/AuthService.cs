namespace ShopEaseApp
{
    /// <summary>
    /// Module 1: User Authentication.
    /// </summary>
    public class AuthService
    {
        private const string AdminUsername = "admin";
        private const string AdminPassword = "admin123";

        private readonly List<Customer> customers = new();
        private int nextCustomerId = 1;

        // ---------- Customer: Register ----------
        public bool Register(string name, string username, string password, string email, string phone, string address)
        {
            if (customers.Any(c => c.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                return false; // username already taken

            var customer = new Customer(nextCustomerId++, name, username, password, email, phone, address);
            customers.Add(customer);
            return true;
        }

        // ---------- Customer: Login ----------
        public Customer? Login(string username, string password)
        {
            return customers.FirstOrDefault(c =>
                c.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && c.Password == password);
        }

        // ---------- Customer: Update Profile ----------
        public void UpdateProfile(Customer customer, string name, string email, string phone, string address)
        {
            if (!string.IsNullOrWhiteSpace(name)) customer.Name = name;
            if (!string.IsNullOrWhiteSpace(email)) customer.Email = email;
            if (!string.IsNullOrWhiteSpace(phone)) customer.Phone = phone;
            if (!string.IsNullOrWhiteSpace(address)) customer.Address = address;
        }

        // ---------- Customer: Change Password ----------
        public bool ChangePassword(Customer customer, string oldPassword, string newPassword)
        {
            if (customer.Password != oldPassword)
                return false;

            customer.Password = newPassword;
            return true;
        }

        // ---------- Admin Login ----------
        public bool AdminLogin(string username, string password)
        {
            return username == AdminUsername && password == AdminPassword;
        }
    }
}
