namespace StationeryStoreApp
{
    /// <summary>
    /// Module 11: Purchase Item — generates a bill for a purchase.
    /// Implements IBill (Interface requirement).
    /// </summary>
    public class Bill : IBill
    {
        private const decimal GstPercent = 18m;

        private readonly StationeryItem item;
        private readonly int purchaseQuantity;

        public Bill(StationeryItem item, int purchaseQuantity)
        {
            this.item = item;
            this.purchaseQuantity = purchaseQuantity;
        }

        public void GenerateBill()
        {
            decimal subTotal = item.Price * purchaseQuantity;
            decimal discountPercent = item.CalculateDiscount();
            decimal discountAmount = subTotal * discountPercent / 100m;
            decimal afterDiscount = subTotal - discountAmount;
            decimal gstAmount = afterDiscount * GstPercent / 100m;
            decimal total = afterDiscount + gstAmount;

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"{"Item",-15}{"Price",-10}{"Quantity",-10}{"Discount",-12}{"GST",-10}{"Total",-10}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"{item.ItemName,-15}{item.Price,-10:0.00}{purchaseQuantity,-10}{discountPercent + "%",-12}{GstPercent + "%",-10}{total,-10:0.00}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Sub Total     : {subTotal:0.00}");
            Console.WriteLine($"Discount ({discountPercent}%) : -{discountAmount:0.00}");
            Console.WriteLine($"GST ({GstPercent}%)       : +{gstAmount:0.00}");
            Console.WriteLine($"Grand Total   : {total:0.00}");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
