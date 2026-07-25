namespace StationeryStoreApp
{
    /// <summary>
    /// Module 5: List Collection — all items live in memory, no database.
    /// All operations happen on this List&lt;StationeryItem&gt;.
    /// </summary>
    public class StationeryStore
    {
        private readonly List<StationeryItem> items = new();

        // ---------- Module 6: Add Item ----------
        public void AddItem(StationeryItem newItem)
        {
            if (items.Any(i => i.ItemId == newItem.ItemId))
                throw new DuplicateItemException();

            // Price/Quantity are already validated by the StationeryItem property setters.
            items.Add(newItem);
        }

        // ---------- Module 7: Display Items ----------
        public void DisplayAllItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("No items in the store.");
                return;
            }

            Console.WriteLine($"{"ID",-6}{"Name",-15}{"Category",-12}{"Brand",-12}{"Price",-10}{"Quantity",-8}");
            Console.WriteLine(new string('-', 63));
            foreach (var item in items)
            {
                item.DisplayDetails();
            }
        }

        // ---------- Module 8: Search Item ----------
        public StationeryItem SearchById(int itemId)
        {
            var item = items.FirstOrDefault(i => i.ItemId == itemId);
            if (item == null)
                throw new ItemNotFoundException();
            return item;
        }

        public StationeryItem SearchByName(string itemName)
        {
            var item = items.FirstOrDefault(i => string.Equals(i.ItemName, itemName, StringComparison.OrdinalIgnoreCase));
            if (item == null)
                throw new ItemNotFoundException();
            return item;
        }

        // ---------- Module 9: Update Item ----------
        public void UpdateItem(int itemId, decimal? newPrice, int? newQuantity, string? newBrand)
        {
            var item = SearchById(itemId); // throws ItemNotFoundException if missing

            if (newPrice.HasValue)
                item.Price = newPrice.Value;       // validated in setter

            if (newQuantity.HasValue)
                item.Quantity = newQuantity.Value;  // validated in setter

            if (!string.IsNullOrWhiteSpace(newBrand))
                item.Brand = newBrand;
        }

        // ---------- Module 10: Delete Item ----------
        public void DeleteItem(int itemId)
        {
            var item = SearchById(itemId); // throws ItemNotFoundException if missing
            items.Remove(item);
        }

        // ---------- Module 11: Purchase Item ----------
        public void PurchaseItem(int itemId, int purchaseQuantity)
        {
            var item = SearchById(itemId); // throws ItemNotFoundException if missing

            if (purchaseQuantity > item.Quantity)
                throw new InsufficientStockException();

            item.UpdateQuantity(-purchaseQuantity);

            var bill = new Bill(item, purchaseQuantity);
            bill.GenerateBill();
        }

        // ---------- Module 12: Low Stock ----------
        public List<StationeryItem> GetLowStockItems(int threshold = 5)
        {
            return items.Where(i => i.Quantity < threshold).ToList();
        }

        // ---------- Module 13: Sorting ----------
        public void SortByPrice(bool descending = false)
        {
            items.Sort((a, b) => a.Price.CompareTo(b.Price));
            if (descending) items.Reverse();
        }

        public void SortByName(bool descending = false)
        {
            var sorted = descending
                ? items.OrderByDescending(i => i.ItemName).ToList()
                : items.OrderBy(i => i.ItemName).ToList();

            items.Clear();
            items.AddRange(sorted);
        }

        public void SortByQuantity(bool descending = false)
        {
            var sorted = descending
                ? items.OrderByDescending(i => i.Quantity).ToList()
                : items.OrderBy(i => i.Quantity).ToList();

            items.Clear();
            items.AddRange(sorted);
        }
    }
}
