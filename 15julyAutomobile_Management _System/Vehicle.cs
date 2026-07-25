namespace AbcMotorsApp
{
    /// <summary>
    /// Module 3: Vehicle Details — holds the data for a single vehicle.
    /// </summary>
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string VehicleType { get; set; }   // Car, Bike, Truck
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int ManufacturingYear { get; set; }

        public Vehicle(int vehicleId, string vehicleName, string vehicleType, string brand, decimal price, int manufacturingYear)
        {
            VehicleId = vehicleId;
            VehicleName = vehicleName;
            VehicleType = vehicleType;
            Brand = brand;
            Price = price;
            ManufacturingYear = manufacturingYear;
        }

        /// <summary>
        /// Module 4: Display Vehicles — one row of the table.
        /// </summary>
        public void DisplayRow()
        {
            Console.WriteLine($"{VehicleId,-6}{VehicleName,-12}{Brand,-12}{VehicleType,-10}{Price,-12:0}{ManufacturingYear,-6}");
        }

        /// <summary>
        /// Module 5: Search Vehicle — full detail view.
        /// </summary>
        public void DisplayFullDetails()
        {
            Console.WriteLine($"Vehicle ID   : {VehicleId}");
            Console.WriteLine($"Vehicle Name : {VehicleName}");
            Console.WriteLine($"Vehicle Type : {VehicleType}");
            Console.WriteLine($"Brand        : {Brand}");
            Console.WriteLine($"Price        : {Price:0}");
            Console.WriteLine($"Year         : {ManufacturingYear}");
        }
    }
}
