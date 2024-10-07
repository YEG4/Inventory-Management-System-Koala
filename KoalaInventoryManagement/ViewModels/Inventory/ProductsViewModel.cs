namespace KoalaInventoryManagement.ViewModels.Inventory
{
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int? CurrentStock { get; set; }
        public int? MinimumStock { get; set; }
        public int? MaximumStock { get; set; }

        public string SupplierName { get; set; }
        public string CategoryName { get; set; }
        public string WarehouseLocation { get; set; }
    }
}
