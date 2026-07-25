namespace StationeryStoreApp
{
    /// <summary>
    /// Thrown when a quantity of zero or less is supplied.
    /// </summary>
    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException() : base("Quantity must be greater than 0.") { }

        public InvalidQuantityException(string message) : base(message) { }
    }
}
