namespace StationeryStoreApp
{
    /// <summary>
    /// Thrown when a purchase quantity exceeds the available stock quantity.
    /// </summary>
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException() : base("Insufficient stock for this purchase.") { }

        public InsufficientStockException(string message) : base(message) { }
    }
}
