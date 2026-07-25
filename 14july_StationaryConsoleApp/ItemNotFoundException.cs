namespace StationeryStoreApp
{
    /// <summary>
    /// Thrown when a search, update, delete, or purchase operation cannot find the requested item.
    /// </summary>
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() : base("Item not found.") { }

        public ItemNotFoundException(string message) : base(message) { }
    }
}
