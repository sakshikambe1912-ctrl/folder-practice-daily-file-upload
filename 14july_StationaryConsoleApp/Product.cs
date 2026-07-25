namespace StationeryStoreApp
{
    /// <summary>
    /// Abstraction: every sellable product must know how to calculate its own discount.
    /// </summary>
    public abstract class Product
    {
        /// <summary>
        /// Each concrete product type implements its own discount rule.
        /// </summary>
        /// <returns>Discount as a percentage (e.g. 10 means 10%).</returns>
        public abstract decimal CalculateDiscount();
    }
}
