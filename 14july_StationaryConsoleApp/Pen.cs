namespace StationeryStoreApp
{
    public class Pen : StationeryItem
    {
        public string InkColor { get; set; }
        public string PenType { get; set; }

        public Pen(int itemId, string itemName, string category, decimal price, int quantity, string brand,
                    string inkColor, string penType)
            : base(itemId, itemName, category, price, quantity, brand)
        {
            InkColor = inkColor;
            PenType = penType;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"      Ink Color: {InkColor}, Pen Type: {PenType}");
        }

        // Pen discount: 5%
        public override decimal CalculateDiscount() => 5m;
    }
}
