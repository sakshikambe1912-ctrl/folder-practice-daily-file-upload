namespace StationeryStoreApp
{
    /// <summary>
    /// Thrown when a price of zero or less is supplied.
    /// </summary>
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException() : base("Price must be greater than 0.") { }

        public InvalidPriceException(string message) : base(message) { }
    }
}
