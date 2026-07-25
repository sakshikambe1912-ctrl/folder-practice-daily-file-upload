namespace AbcMotorsApp
{
    public static class Program
    {
        private static readonly VehicleStore Store = new();

        public static void Main()
        {
            Login();
            SeedSampleData();
            RunMainMenu();
        }

        // ---------- Module 1: User Login ----------
        private static void Login()
        {
            Console.Write("Enter Employee Name: ");
            string employeeName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Employee ID: ");
            string employeeId = Console.ReadLine() ?? string.Empty;

            Console.WriteLine($"Welcome {employeeName}");
        }

        // ---------- Module 2: Main Menu ----------
        private static void RunMainMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("==============================");
                Console.WriteLine("        ABC MOTORS");
                Console.WriteLine("   Vehicle Management System");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. View All Vehicles");
                Console.WriteLine("3. Search Vehicle");
                Console.WriteLine("4. Update Vehicle Price");
                Console.WriteLine("5. Delete Vehicle");
                Console.WriteLine("6. Calculate Discount");
                Console.WriteLine("7. Show Vehicle Details");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1": AddVehicleFlow(); break;
                    case "2": Store.DisplayAllVehicles(); break;
                    case "3": SearchVehicleFlow(); break;
                    case "4": UpdatePriceFlow(); break;
                    case "5": DeleteVehicleFlow(); break;
                    case "6": CalculateDiscountFlow(); break;
                    case "7": ShowVehicleDetailsFlow(); break;
                    case "8":
                        Console.WriteLine("Thank you for using ABC Motors System.");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // ---------- Module 3: Add Vehicle ----------
        private static void AddVehicleFlow()
        {
            Console.Write("Vehicle ID : ");
            int vehicleId = ReadInt();

            Console.Write("Vehicle Name : ");
            string vehicleName = Console.ReadLine() ?? string.Empty;

            Console.Write("Vehicle Type : ");
            string vehicleType = Console.ReadLine() ?? string.Empty;

            Console.Write("Brand : ");
            string brand = Console.ReadLine() ?? string.Empty;

            Console.Write("Price : ");
            decimal price = ReadDecimal();

            Console.Write("Year : ");
            int year = ReadInt();

            var vehicle = new Vehicle(vehicleId, vehicleName, vehicleType, brand, price, year);
            Store.AddVehicle(vehicle);

            Console.WriteLine("Vehicle added successfully.");
        }

        // ---------- Module 5: Search Vehicle ----------
        private static void SearchVehicleFlow()
        {
            Console.Write("Enter Vehicle ID: ");
            int vehicleId = ReadInt();

            var vehicle = Store.FindById(vehicleId);
            if (vehicle == null)
            {
                Console.WriteLine("Vehicle not found.");
                return;
            }

            vehicle.DisplayFullDetails();
        }

        // ---------- Module 6: Update Price ----------
        private static void UpdatePriceFlow()
        {
            Console.Write("Enter Vehicle ID: ");
            int vehicleId = ReadInt();

            Console.Write("Enter New Price: ");
            decimal newPrice = ReadDecimal();

            bool updated = Store.UpdatePrice(vehicleId, newPrice);
            Console.WriteLine(updated ? "Vehicle price updated successfully." : "Vehicle ID does not exist.");
        }

        // ---------- Module 7: Delete Vehicle ----------
        private static void DeleteVehicleFlow()
        {
            Console.Write("Enter Vehicle ID: ");
            int vehicleId = ReadInt();

            bool deleted = Store.DeleteVehicle(vehicleId);
            Console.WriteLine(deleted ? "Vehicle deleted successfully." : "Vehicle not available.");
        }

        // ---------- Module 8: Calculate Discount ----------
        private static void CalculateDiscountFlow()
        {
            Console.Write("Enter Vehicle ID: ");
            int vehicleId = ReadInt();

            var vehicle = Store.FindById(vehicleId);
            if (vehicle == null)
            {
                Console.WriteLine("Vehicle not found.");
                return;
            }

            decimal discountPercent = vehicle.VehicleType.Trim().ToLower() switch
            {
                "car" => 10m,
                "bike" => 5m,
                "truck" => 12m,
                _ => 0m
            };

            decimal discountAmount = vehicle.Price * discountPercent / 100m;
            decimal finalPrice = vehicle.Price - discountAmount;

            Console.WriteLine($"Vehicle Price : {vehicle.Price:0}");
            Console.WriteLine($"Discount      : {discountAmount:0}");
            Console.WriteLine($"Final Price   : {finalPrice:0}");
        }

        // ---------- Module 9: Show Vehicle Details (by type) ----------
        private static void ShowVehicleDetailsFlow()
        {
            Console.Write("Enter Vehicle Type (Car/Bike/Truck): ");
            string type = Console.ReadLine() ?? string.Empty;

            switch (type.Trim().ToLower())
            {
                case "car":
                    Console.WriteLine("Car is a four wheeler.");
                    Console.WriteLine("Suitable for family.");
                    break;

                case "bike":
                    Console.WriteLine("Bike is fuel efficient.");
                    Console.WriteLine("Suitable for city rides.");
                    break;

                case "truck":
                    Console.WriteLine("Truck is used for transportation.");
                    Console.WriteLine("Heavy load vehicle.");
                    break;

                default:
                    Console.WriteLine("Unknown vehicle type.");
                    break;
            }
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
            Store.AddVehicle(new Vehicle(101, "City", "Car", "Honda", 1500000m, 2025));
            Store.AddVehicle(new Vehicle(102, "Pulsar", "Bike", "Bajaj", 140000m, 2024));
        }
    }
}
