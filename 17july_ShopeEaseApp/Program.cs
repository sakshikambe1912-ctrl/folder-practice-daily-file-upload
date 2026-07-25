namespace ShopEaseApp
{
    public static class Program
    {
        private static readonly AuthService Auth = new();
        private static readonly ProductService Products = new();
        private static readonly CategoryService Categories = new();
        private static readonly CartService Cart = new();
        private static readonly PaymentService Payment = new();
        private static readonly OrderService Orders = new(Cart, Payment);

        public static void Main()
        {
            SeedSampleData();
            RunTopMenu();
        }

        // ---------- Top Level Menu ----------
        private static void RunTopMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("==============================");
                Console.WriteLine("           ShopEase");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Admin Login");
                Console.WriteLine("2. Customer Register");
                Console.WriteLine("3. Customer Login");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                switch (Console.ReadLine())
                {
                    case "1": AdminLoginFlow(); break;
                    case "2": RegisterFlow(); break;
                    case "3": CustomerLoginFlow(); break;
                    case "4":
                        Console.WriteLine("Thank you for using ShopEase.");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // =====================================================
        // MODULE 1: AUTHENTICATION
        // =====================================================
        private static void AdminLoginFlow()
        {
            Console.Write("Admin Username: ");
            string username = Console.ReadLine() ?? string.Empty;
            Console.Write("Admin Password: ");
            string password = Console.ReadLine() ?? string.Empty;

            if (Auth.AdminLogin(username, password))
            {
                Console.WriteLine("Admin login successful.");
                RunAdminMenu();
            }
            else
            {
                Console.WriteLine("Invalid admin credentials.");
            }
        }

        private static void RegisterFlow()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.Write("Choose Username: ");
            string username = Console.ReadLine() ?? string.Empty;
            Console.Write("Choose Password: ");
            string password = Console.ReadLine() ?? string.Empty;
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? string.Empty;
            Console.Write("Phone: ");
            string phone = Console.ReadLine() ?? string.Empty;
            Console.Write("Address: ");
            string address = Console.ReadLine() ?? string.Empty;

            bool registered = Auth.Register(name, username, password, email, phone, address);
            Console.WriteLine(registered ? "Registration successful." : "Username already taken.");
        }

        private static void CustomerLoginFlow()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine() ?? string.Empty;
            Console.Write("Password: ");
            string password = Console.ReadLine() ?? string.Empty;

            var customer = Auth.Login(username, password);
            if (customer == null)
            {
                Console.WriteLine("Invalid username or password.");
                return;
            }

            Console.WriteLine($"Welcome {customer.Name}!");
            RunCustomerMenu(customer);
        }

        // =====================================================
        // ADMIN MENU: MODULE 2 (Products) + MODULE 3 (Categories)
        // =====================================================
        private static void RunAdminMenu()
        {
            bool inAdmin = true;

            while (inAdmin)
            {
                Console.WriteLine();
                Console.WriteLine("---------- Admin Menu ----------");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Search Product");
                Console.WriteLine("5. View All Products");
                Console.WriteLine("6. Add Category");
                Console.WriteLine("7. Update Category");
                Console.WriteLine("8. Delete Category");
                Console.WriteLine("9. View Categories");
                Console.WriteLine("10. Logout");
                Console.Write("Enter your choice: ");

                switch (Console.ReadLine())
                {
                    case "1": AddProductFlow(); break;
                    case "2": UpdateProductFlow(); break;
                    case "3": DeleteProductFlow(); break;
                    case "4": SearchProductFlow(); break;
                    case "5": Products.DisplayAll(); break;
                    case "6": AddCategoryFlow(); break;
                    case "7": UpdateCategoryFlow(); break;
                    case "8": DeleteCategoryFlow(); break;
                    case "9": Categories.DisplayAll(); break;
                    case "10":
                        Console.WriteLine("Admin logged out.");
                        inAdmin = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private static void AddProductFlow()
        {
            Console.Write("Product Id: "); int id = ReadInt();
            Console.Write("Name: "); string name = Console.ReadLine() ?? string.Empty;
            Console.Write("Category: "); string category = Console.ReadLine() ?? string.Empty;
            Console.Write("Description: "); string description = Console.ReadLine() ?? string.Empty;
            Console.Write("Price: "); decimal price = ReadDecimal();
            Console.Write("Quantity: "); int quantity = ReadInt();
            Console.Write("Brand: "); string brand = Console.ReadLine() ?? string.Empty;
            Console.Write("Discount %: "); decimal discount = ReadDecimal();
            Console.Write("Rating: "); double rating = ReadDouble();

            Products.AddProduct(new Product(id, name, category, description, price, quantity, brand, discount, rating));
            Console.WriteLine("Product added successfully.");
        }

        private static void UpdateProductFlow()
        {
            Console.Write("Enter Product Id: "); int id = ReadInt();

            Console.Write("New Price (blank to skip): ");
            decimal? price = decimal.TryParse(Console.ReadLine(), out var p) ? p : null;

            Console.Write("New Quantity (blank to skip): ");
            int? quantity = int.TryParse(Console.ReadLine(), out var q) ? q : null;

            Console.Write("New Discount % (blank to skip): ");
            decimal? discount = decimal.TryParse(Console.ReadLine(), out var d) ? d : null;

            Console.Write("New Description (blank to skip): ");
            string description = Console.ReadLine() ?? string.Empty;

            bool updated = Products.UpdateProduct(id, price, quantity, discount, description);
            Console.WriteLine(updated ? "Product updated successfully." : "Product not found.");
        }

        private static void DeleteProductFlow()
        {
            Console.Write("Enter Product Id: "); int id = ReadInt();
            bool deleted = Products.DeleteProduct(id);
            Console.WriteLine(deleted ? "Product deleted successfully." : "Product not found.");
        }

        private static void SearchProductFlow()
        {
            Console.WriteLine("Search by: 1. Product Id  2. Name");
            string choice = Console.ReadLine() ?? string.Empty;

            if (choice == "1")
            {
                Console.Write("Enter Product Id: "); int id = ReadInt();
                var product = Products.FindById(id);
                if (product == null) Console.WriteLine("Product not found.");
                else product.DisplayFullDetails();
            }
            else
            {
                Console.Write("Enter Name: "); string name = Console.ReadLine() ?? string.Empty;
                var results = Products.SearchByName(name);
                if (results.Count == 0) Console.WriteLine("Product not found.");
                else results.ForEach(p => p.DisplayFullDetails());
            }
        }

        private static void AddCategoryFlow()
        {
            Console.Write("Category Name: "); string name = Console.ReadLine() ?? string.Empty;
            Categories.AddCategory(name);
            Console.WriteLine("Category added successfully.");
        }

        private static void UpdateCategoryFlow()
        {
            Console.Write("Category Id: "); int id = ReadInt();
            Console.Write("New Name: "); string name = Console.ReadLine() ?? string.Empty;
            bool updated = Categories.UpdateCategory(id, name);
            Console.WriteLine(updated ? "Category updated successfully." : "Category not found.");
        }

        private static void DeleteCategoryFlow()
        {
            Console.Write("Category Id: "); int id = ReadInt();
            bool deleted = Categories.DeleteCategory(id);
            Console.WriteLine(deleted ? "Category deleted successfully." : "Category not found.");
        }

        // =====================================================
        // CUSTOMER MENU: MODULE 4 (Cart) + MODULE 5 (Orders)
        // + MODULE 6 (Payment) + MODULE 7 (Order History)
        // =====================================================
        private static void RunCustomerMenu(Customer customer)
        {
            bool loggedIn = true;

            while (loggedIn)
            {
                Console.WriteLine();
                Console.WriteLine("---------- Customer Menu ----------");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Add to Cart");
                Console.WriteLine("3. Remove from Cart");
                Console.WriteLine("4. Update Cart Quantity");
                Console.WriteLine("5. Clear Cart");
                Console.WriteLine("6. View Cart / Total");
                Console.WriteLine("7. Apply Coupon");
                Console.WriteLine("8. Checkout (Place Order)");
                Console.WriteLine("9. View Order History");
                Console.WriteLine("10. Search Order");
                Console.WriteLine("11. Cancel Order");
                Console.WriteLine("12. Download Invoice");
                Console.WriteLine("13. Update Profile");
                Console.WriteLine("14. Change Password");
                Console.WriteLine("15. Logout");
                Console.Write("Enter your choice: ");

                switch (Console.ReadLine())
                {
                    case "1": Products.DisplayAll(); break;
                    case "2": AddToCartFlow(customer); break;
                    case "3": RemoveFromCartFlow(customer); break;
                    case "4": UpdateCartQuantityFlow(customer); break;
                    case "5": Cart.ClearCart(customer); Console.WriteLine("Cart cleared."); break;
                    case "6": Cart.DisplayCart(customer); Cart.DisplayTotal(customer); break;
                    case "7": ApplyCouponFlow(customer); break;
                    case "8": CheckoutFlow(customer); break;
                    case "9": Orders.DisplayOrderHistory(customer); break;
                    case "10": SearchOrderFlow(customer); break;
                    case "11": CancelOrderFlow(customer); break;
                    case "12": DownloadInvoiceFlow(customer); break;
                    case "13": UpdateProfileFlow(customer); break;
                    case "14": ChangePasswordFlow(customer); break;
                    case "15":
                        Console.WriteLine("Logged out.");
                        loggedIn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private static void AddToCartFlow(Customer customer)
        {
            Console.Write("Enter Product Id: "); int id = ReadInt();
            var product = Products.FindById(id);
            if (product == null) { Console.WriteLine("Product not found."); return; }

            Console.Write("Enter Quantity: "); int quantity = ReadInt();
            Cart.AddToCart(customer, product, quantity);
            Console.WriteLine("Item added to cart.");
        }

        private static void RemoveFromCartFlow(Customer customer)
        {
            Console.Write("Enter Product Id to remove: "); int id = ReadInt();
            bool removed = Cart.RemoveItem(customer, id);
            Console.WriteLine(removed ? "Item removed." : "Item not found in cart.");
        }

        private static void UpdateCartQuantityFlow(Customer customer)
        {
            Console.Write("Enter Product Id: "); int id = ReadInt();
            Console.Write("Enter New Quantity: "); int quantity = ReadInt();
            bool updated = Cart.UpdateQuantity(customer, id, quantity);
            Console.WriteLine(updated ? "Quantity updated." : "Item not found in cart.");
        }

        private static void ApplyCouponFlow(Customer customer)
        {
            Console.Write("Enter Coupon Code: "); string code = Console.ReadLine() ?? string.Empty;
            Cart.ApplyCoupon(customer, code);
            Console.WriteLine(customer.ActiveCouponPercent > 0
                ? $"Coupon applied: {customer.ActiveCouponPercent}% off."
                : "Invalid coupon code.");
        }

        private static void CheckoutFlow(Customer customer)
        {
            if (customer.Cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }

            Console.WriteLine($"Confirm delivery address [{customer.Address}]. Press Enter to keep, or type a new one:");
            string input = Console.ReadLine() ?? string.Empty;
            string address = string.IsNullOrWhiteSpace(input) ? customer.Address : input;

            Console.WriteLine("Select Payment: 1. Credit Card  2. Debit Card  3. UPI  4. Cash On Delivery");
            string paymentMethod = (Console.ReadLine() ?? string.Empty) switch
            {
                "1" => "Credit Card",
                "2" => "Debit Card",
                "3" => "UPI",
                "4" => "Cash On Delivery",
                _ => "Cash On Delivery"
            };

            var order = Orders.PlaceOrder(customer, address, paymentMethod);
            if (order == null)
            {
                Console.WriteLine("Could not place order.");
                return;
            }

            Console.WriteLine("Order placed successfully!");
            Console.WriteLine(Orders.GenerateInvoiceText(order));
        }

        private static void SearchOrderFlow(Customer customer)
        {
            Console.Write("Enter Order Id: "); int id = ReadInt();
            var order = Orders.SearchOrder(customer, id);
            if (order == null) Console.WriteLine("Order not found.");
            else Console.WriteLine(Orders.GenerateInvoiceText(order));
        }

        private static void CancelOrderFlow(Customer customer)
        {
            Console.Write("Enter Order Id to cancel: "); int id = ReadInt();
            bool cancelled = Orders.CancelOrder(customer, id);
            Console.WriteLine(cancelled ? "Order cancelled." : "Order not found or already cancelled.");
        }

        private static void DownloadInvoiceFlow(Customer customer)
        {
            Console.Write("Enter Order Id: "); int id = ReadInt();
            var order = Orders.SearchOrder(customer, id);
            if (order == null) { Console.WriteLine("Order not found."); return; }

            string fileName = Orders.DownloadInvoice(order);
            Console.WriteLine($"Invoice saved as {fileName}");
        }

        private static void UpdateProfileFlow(Customer customer)
        {
            Console.Write("New Name (blank to skip): "); string name = Console.ReadLine() ?? string.Empty;
            Console.Write("New Email (blank to skip): "); string email = Console.ReadLine() ?? string.Empty;
            Console.Write("New Phone (blank to skip): "); string phone = Console.ReadLine() ?? string.Empty;
            Console.Write("New Address (blank to skip): "); string address = Console.ReadLine() ?? string.Empty;

            Auth.UpdateProfile(customer, name, email, phone, address);
            Console.WriteLine("Profile updated.");
        }

        private static void ChangePasswordFlow(Customer customer)
        {
            Console.Write("Old Password: "); string oldPassword = Console.ReadLine() ?? string.Empty;
            Console.Write("New Password: "); string newPassword = Console.ReadLine() ?? string.Empty;

            bool changed = Auth.ChangePassword(customer, oldPassword, newPassword);
            Console.WriteLine(changed ? "Password changed successfully." : "Old password is incorrect.");
        }

        // ---------- Helpers ----------
        private static int ReadInt()
        {
            int.TryParse(Console.ReadLine(), out int value);
            return value;
        }

        private static decimal ReadDecimal()
        {
            decimal.TryParse(Console.ReadLine(), out decimal value);
            return value;
        }

        private static double ReadDouble()
        {
            double.TryParse(Console.ReadLine(), out double value);
            return value;
        }

        private static void SeedSampleData()
        {
            Products.AddProduct(new Product(1001, "Laptop", "Electronics", "Dell Inspiron", 65000m, 20, "Dell", 10m, 4.6));
            Products.AddProduct(new Product(1002, "Mouse", "Electronics", "Wireless Mouse", 700m, 50, "Logitech", 5m, 4.3));
            Products.AddProduct(new Product(1003, "Keyboard", "Electronics", "Mechanical Keyboard", 2500m, 30, "HP", 8m, 4.4));
        }
    }
}
