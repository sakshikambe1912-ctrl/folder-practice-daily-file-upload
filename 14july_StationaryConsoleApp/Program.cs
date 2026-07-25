namespace StationeryStoreApp
{
    public static class Program
    {
        private static readonly StationeryStore Store = new();

        public static void Main()
        {
            // ---------- Module 1: User Login ----------
            try
            {
                AuthService.Login();
            }
            catch (LoginFailedException ex)
            {
                Console.WriteLine($"Custom Exception: LoginFailedException - {ex.Message}");
                return; // exit application after failed login
            }

            SeedSampleData();
            RunMainMenu();
        }

        // ---------- Module 2: Main Menu ----------
        private static void RunMainMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("     Stationery Store Management System");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("1. Add Stationery Item");
                Console.WriteLine("2. Display All Items");
                Console.WriteLine("3. Search Item");
                Console.WriteLine("4. Update Item");
                Console.WriteLine("5. Delete Item");
                Console.WriteLine("6. Purchase Item");
                Console.WriteLine("7. View Low Stock Items");
                Console.WriteLine("8. Sort Items");
                Console.WriteLine("9. Exit");
                Console.Write("Enter Choice: ");

                string choice = Console.ReadLine() ?? string.Empty;

                try
                {
                    switch (choice)
                    {
                        case "1": AddItemFlow(); break;
                        case "2": Store.DisplayAllItems(); break;
                        case "3": SearchItemFlow(); break;
                        case "4": UpdateItemFlow(); break;
                        case "5": DeleteItemFlow(); break;
                        case "6": PurchaseItemFlow(); break;
                        case "7": LowStockFlow(); break;
                        case "8": SortItemsFlow(); break;
                        case "9":
                            Console.WriteLine("Thank You");
                            Console.WriteLine("Visit Again");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (InvalidPriceException ex)
                {
                    Console.WriteLine($"Custom Exception: InvalidPriceException - {ex.Message}");
                }
                catch (InvalidQuantityException ex)
                {
                    Console.WriteLine($"Custom Exception: InvalidQuantityException - {ex.Message}");
                }
                catch (DuplicateItemException ex)
                {
                    Console.WriteLine($"Custom Exception: DuplicateItemException - {ex.Message}");
                }
                catch (ItemNotFoundException ex)
                {
                    Console.WriteLine($"Custom Exception: ItemNotFoundException - {ex.Message}");
                }
                catch (InsufficientStockException ex)
                {
                    Console.WriteLine($"Custom Exception: InsufficientStockException - {ex.Message}");
                }
            }
        }

        // ---------- Module 6: Add Item ----------
        private static void AddItemFlow()
        {
            Console.Write("Enter Item Id: ");
            int itemId = ReadInt();

            Console.Write("Enter Name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Category (Notebook/Pen/Marker/Other): ");
            string category = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Price: ");
            decimal price = ReadDecimal();

            Console.Write("Enter Quantity: ");
            int quantity = ReadInt();

            StationeryItem item;

            switch (category.Trim().ToLower())
            {
                case "notebook":
                    Console.Write("Enter Pages: ");
                    int pages = ReadInt();
                    Console.Write("Enter Paper Type: ");
                    string paperType = Console.ReadLine() ?? string.Empty;
                    item = new Notebook(itemId, name, category, price, quantity, brand, pages, paperType);
                    break;

                case "pen":
                    Console.Write("Enter Ink Color: ");
                    string inkColor = Console.ReadLine() ?? string.Empty;
                    Console.Write("Enter Pen Type: ");
                    string penType = Console.ReadLine() ?? string.Empty;
                    item = new Pen(itemId, name, category, price, quantity, brand, inkColor, penType);
                    break;

                case "marker":
                    Console.Write("Permanent? (Y/N): ");
                    bool permanent = (Console.ReadLine() ?? string.Empty).Trim().ToUpper() == "Y";
                    item = new Marker(itemId, name, category, price, quantity, brand, permanent);
                    break;

                default:
                    item = new StationeryItem(itemId, name, category, price, quantity, brand);
                    break;
            }

            Store.AddItem(item);
            Console.WriteLine("Item added successfully.");
        }

        // ---------- Module 8: Search Item ----------
        private static void SearchItemFlow()
        {
            Console.WriteLine("Search by: 1. Item Id  2. Item Name");
            Console.Write("Enter Choice: ");
            string choice = Console.ReadLine() ?? string.Empty;

            StationeryItem item;
            if (choice == "1")
            {
                Console.Write("Enter Item Id: ");
                item = Store.SearchById(ReadInt());
            }
            else
            {
                Console.Write("Enter Item Name: ");
                item = Store.SearchByName(Console.ReadLine() ?? string.Empty);
            }

            item.DisplayDetails();
        }

        // ---------- Module 9: Update Item ----------
        private static void UpdateItemFlow()
        {
            Console.Write("Enter Item Id to update: ");
            int itemId = ReadInt();

            Console.Write("New Price (leave blank to skip): ");
            string priceInput = Console.ReadLine() ?? string.Empty;
            decimal? newPrice = decimal.TryParse(priceInput, out var p) ? p : null;

            Console.Write("New Quantity (leave blank to skip): ");
            string qtyInput = Console.ReadLine() ?? string.Empty;
            int? newQuantity = int.TryParse(qtyInput, out var q) ? q : null;

            Console.Write("New Brand (leave blank to skip): ");
            string newBrand = Console.ReadLine() ?? string.Empty;

            Store.UpdateItem(itemId, newPrice, newQuantity, newBrand);
            Console.WriteLine("Item updated successfully.");
        }

        // ---------- Module 10: Delete Item ----------
        private static void DeleteItemFlow()
        {
            Console.Write("Enter Item Id to delete: ");
            int itemId = ReadInt();

            Console.Write("Delete ? (Y/N): ");
            string confirm = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();

            if (confirm == "Y")
            {
                Store.DeleteItem(itemId);
                Console.WriteLine("Item deleted successfully.");
            }
            else
            {
                Console.WriteLine("Delete cancelled.");
            }
        }

        // ---------- Module 11: Purchase Item ----------
        private static void PurchaseItemFlow()
        {
            Console.Write("Enter Item Id: ");
            int itemId = ReadInt();

            Console.Write("Enter Quantity: ");
            int quantity = ReadInt();

            Store.PurchaseItem(itemId, quantity);
        }

        // ---------- Module 12: Low Stock ----------
        private static void LowStockFlow()
        {
            var lowStock = Store.GetLowStockItems();
            if (lowStock.Count == 0)
            {
                Console.WriteLine("No low stock items.");
                return;
            }

            Console.WriteLine("Low Stock Items (Quantity < 5):");
            foreach (var item in lowStock)
            {
                item.DisplayDetails();
            }
        }

        // ---------- Module 13: Sorting ----------
        private static void SortItemsFlow()
        {
            Console.WriteLine("Sort by: 1. Price  2. Name  3. Quantity");
            Console.Write("Enter Choice: ");
            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1": Store.SortByPrice(); break;
                case "2": Store.SortByName(); break;
                case "3": Store.SortByQuantity(); break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            Console.WriteLine("Items sorted.");
            Store.DisplayAllItems();
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

        private static void SeedSampleData()
        {
            try
            {
                Store.AddItem(new Notebook(1, "Classmate Notebook", "Notebook", 60m, 20, "Classmate", 200, "Ruled"));
                Store.AddItem(new Pen(2, "Gel Pen", "Pen", 10m, 3, "Reynolds", "Blue", "Gel"));
                Store.AddItem(new Marker(3, "Whiteboard Marker", "Marker", 25m, 15, "Camlin", false));
            }
            catch (Exception)
            {
                // ignore seed errors
            }
        }
    }
}
