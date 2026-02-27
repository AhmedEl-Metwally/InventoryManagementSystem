namespace InventoryManagementSystem.Application.DTOS
{
    public record InventoryDashboardDto
    {
        //Product 
        public int TotalProducts { get; init; }
        public int TotalStockQuantity { get; init; }
        public decimal TotalInventoryValue { get; init; }

        //Transaction
        public decimal TotalSalesRevenue { get; init; }
        public int TotalSalesCount { get; init; }

        //Alerts accounts
        public int CurrentLowStockAlerts { get; init; }

        //Suppliers and Categories
        public int TotalSuppliers { get; init; }
        public int TotalCategories { get; init; }
    }
}
