namespace StationeryStoreApp
{
    public class Marker : StationeryItem
    {
        public bool Permanent { get; set; }

        public Marker(int itemId, string itemName, string category, decimal price, int quantity, string brand,
                       bool permanent)
            : base(itemId, itemName, category, price, quantity, brand)
        {
            Permanent = permanent;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"      Permanent: {(Permanent ? "Yes" : "No")}");
        }

        // Marker discount: 8%
        public override decimal CalculateDiscount() => 8m;
    }
}
