namespace AbcMotorsApp
{
    /// <summary>
    /// Holds all vehicles in memory (List&lt;Vehicle&gt;, no database) and
    /// implements Add / Display / Search / Update / Delete / Discount.
    /// </summary>
    public class VehicleStore
    {
        private readonly List<Vehicle> vehicles = new();

        // ---------- Module 3: Add Vehicle ----------
        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        // ---------- Module 4: Display Vehicles ----------
        public void DisplayAllVehicles()
        {
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles found.");
                return;
            }

            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"{"ID",-6}{"Name",-12}{"Brand",-12}{"Type",-10}{"Price",-12}{"Year",-6}");
            Console.WriteLine(new string('-', 70));
            foreach (var vehicle in vehicles)
            {
                vehicle.DisplayRow();
            }
        }

        // ---------- Module 5: Search Vehicle ----------
        public Vehicle? FindById(int vehicleId)
        {
            return vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);
        }

        // ---------- Module 6: Update Price ----------
        public bool UpdatePrice(int vehicleId, decimal newPrice)
        {
            var vehicle = FindById(vehicleId);
            if (vehicle == null)
                return false;

            vehicle.Price = newPrice;
            return true;
        }

        // ---------- Module 7: Delete Vehicle ----------
        public bool DeleteVehicle(int vehicleId)
        {
            var vehicle = FindById(vehicleId);
            if (vehicle == null)
                return false;

            vehicles.Remove(vehicle);
            return true;
        }
    }
}
