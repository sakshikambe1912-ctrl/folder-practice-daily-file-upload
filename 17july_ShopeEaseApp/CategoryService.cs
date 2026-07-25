namespace ShopEaseApp
{
    /// <summary>
    /// Module 3: Category Management.
    /// </summary>
    public class CategoryService
    {
        private readonly List<Category> categories = new();
        private int nextCategoryId = 1;

        public CategoryService()
        {
            foreach (var name in new[] { "Electronics", "Books", "Fashion", "Sports", "Furniture", "Groceries" })
                categories.Add(new Category(nextCategoryId++, name));
        }

        public void AddCategory(string name) => categories.Add(new Category(nextCategoryId++, name));

        public bool DeleteCategory(int categoryId)
        {
            var category = categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (category == null) return false;
            categories.Remove(category);
            return true;
        }

        public bool UpdateCategory(int categoryId, string newName)
        {
            var category = categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (category == null) return false;
            category.CategoryName = newName;
            return true;
        }

        public void DisplayAll()
        {
            Console.WriteLine("Categories:");
            foreach (var category in categories)
                Console.WriteLine($"{category.CategoryId}. {category.CategoryName}");
        }
    }
}
