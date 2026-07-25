namespace StationeryStoreApp
{
    /// <summary>
    /// Parent class for all stationery items. Inherits Product for the abstraction
    /// requirement (CalculateDiscount) and is itself the base class that
    /// Notebook, Pen, and Marker extend (Inheritance).
    /// </summary>
    public class StationeryItem : Product
    {
        // Encapsulation: private fields exposed only through validated properties.
        private int itemId;
        private string itemName;
        private string category;
        private decimal price;
        private int quantity;
        private string brand;

        public int ItemId
        {
            get => itemId;
            set => itemId = value;
        }

        public string ItemName
        {
            get => itemName;
            set => itemName = value;
        }

        public string Category
        {
            get => category;
            set => category = value;
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (value <= 0)
                    throw new InvalidPriceException();
                price = value;
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                // Spec: InvalidQuantityException is thrown when Quantity <= 0
                // (Module 6 requires Quantity > 0 when adding an item).
                if (value <= 0)
                    throw new InvalidQuantityException();
                quantity = value;
            }
        }

        public string Brand
        {
            get => brand;
            set => brand = value;
        }

        public StationeryItem(int itemId, string itemName, string category, decimal price, int quantity, string brand)
        {
            this.itemId = itemId;
            this.itemName = itemName;
            this.category = category;
            Price = price;       // goes through validation
            Quantity = quantity; // goes through validation
            this.brand = brand;
        }

        /// <summary>
        /// Polymorphism: base implementation; overridden by each child class.
        /// </summary>
        public virtual void DisplayDetails()
        {
            Console.WriteLine($"{ItemId,-6}{ItemName,-15}{Category,-12}{Brand,-12}{Price,-10:0.00}{Quantity,-8}");
        }

        /// <summary>
        /// Increases or decreases the stock quantity by the given amount (can be negative for a sale).
        /// </summary>
        public void UpdateQuantity(int change)
        {
            int newQuantity = quantity + change;
            if (newQuantity < 0)
                throw new InvalidQuantityException("Resulting quantity cannot be negative.");
            quantity = newQuantity;
        }

        /// <summary>
        /// Abstraction: base StationeryItem has no discount of its own;
        /// concrete children (Notebook, Pen, Marker) override this.
        /// </summary>
        public override decimal CalculateDiscount()
        {
            return 0m;
        }
    }
}
