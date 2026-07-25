namespace StationeryStoreApp
{
    public class Notebook : StationeryItem
    {
        public int Pages { get; set; }
        public string PaperType { get; set; }

        public Notebook(int itemId, string itemName, string category, decimal price, int quantity, string brand,
                         int pages, string paperType)
            : base(itemId, itemName, category, price, quantity, brand)
        {
            Pages = pages;
            PaperType = paperType;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"      Pages: {Pages}, Paper Type: {PaperType}");
        }

        // Notebook discount: 10%
        public override decimal CalculateDiscount() => 10m;
    }
}
