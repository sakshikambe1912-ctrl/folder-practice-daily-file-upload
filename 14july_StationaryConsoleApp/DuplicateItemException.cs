namespace StationeryStoreApp
{
    /// <summary>
    /// Thrown when an item with the same Item Id already exists in the store.
    /// </summary>
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException() : base("An item with this Item Id already exists.") { }

        public DuplicateItemException(string message) : base(message) { }
    }
}
