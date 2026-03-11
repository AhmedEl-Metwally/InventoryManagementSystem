using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Application.DTOS;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Specifications;
using MediatR;

namespace InventoryManagementSystem.Application.Features.InventoryDashboardQuery
{
    public class GetInventoryDashboardHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetInventoryDashboardQuery, Result<InventoryDashboardDto>>
    {
        public async Task<Result<InventoryDashboardDto>> Handle(GetInventoryDashboardQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync();
            var salesTransactions = await _unitOfWork.GetRepository<Transaction, int>().ListAsync(new SalesTransactionsSpecification());
            var activeAlerts = await _unitOfWork.GetRepository<LowStockAlert, int>().ListAsync(new ActiveLowStockAlertsSpecifications());

            var suppliers = await _unitOfWork.GetRepository<Supplier, int>().GetAllAsync();
            var categories = await _unitOfWork.GetRepository<Category, int>().GetAllAsync();

            var topSellingProducts = salesTransactions
                .GroupBy(T => T.ProductId)
                .Select(P => new ProductPerformanceDto 
                {
                    ProductId = P.Key,
                    ProductName = products.FirstOrDefault(N => N.Id == P.Key)?.Name ?? "Unknown Product",
                    TotalSoldQuantity = P.Sum(Q => Q.Quantity),
                    TotalRevenue = P.Sum(R => R.TotalAmount)
                })
                .OrderByDescending(P => P.TotalSoldQuantity)
                .Take(5)
                .ToList();

            var report = new InventoryDashboardDto
            {
                //Products
                TotalProducts = products.Count(),
                TotalStockQuantity = products.Sum(P => P.QuantityInStock),
                TotalInventoryValue = products.Sum(P => P.QuantityInStock * P.Price),
                //Transaction
                TotalSalesRevenue = salesTransactions.Sum(T => T.TotalAmount),
                TotalSalesCount = salesTransactions.Count(),
                TopSellingProducts = topSellingProducts,
                //LowStockAlerts
                CurrentLowStockAlerts = activeAlerts.Count(),
                //Suppliers and Categories
                TotalSuppliers = suppliers.Count(),
                TotalCategories = categories.Count(),
            };
            return Result<InventoryDashboardDto>.Success(report);
        }
    }
}
