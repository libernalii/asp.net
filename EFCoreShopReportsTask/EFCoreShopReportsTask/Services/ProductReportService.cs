using EFCoreShopReportsTask.Models;
using EFCoreShopReportsTask.Reports;

namespace EFCoreShopReportsTask.Services
{
    public class ProductReportService
    {
        private readonly ShopContext shopContext;

        public ProductReportService(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public ProductCategoryReport GetProductCategoryReport()
        {
            var lines = this.shopContext.Categories
                .Select(c => new ProductCategoryReportLine
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name
                })
                .OrderBy(x => x.CategoryName)
                .ToList();

            return new ProductCategoryReport(lines, DateTime.Now);
        }


        public ProductReport GetProductReport()
        {
            var lines = this.shopContext.Products
                .OrderByDescending(p => p.Title.Title)
                .ThenBy(p => p.Id < 10 ? 0 : 1) 
                .ThenBy(p => p.Id)
                .Select(p => new ProductReportLine
                {
                    ProductId = p.Id,
                    ProductTitle = p.Title.Title,
                    Manufacturer = p.Manufacturer.Name,
                    Price = p.UnitPrice
                })
                .ToList();

            return new ProductReport(lines, DateTime.Now);
        }

        // 2.3
        public FullProductReport GetFullProductReport()
        {
            var lines = this.shopContext.Products
                .OrderBy(p => p.Title.Title) 
                .ThenBy(p => p.Id < 10 ? 0 : 1)
                .ThenBy(p => p.Id)
                .Select(p => new FullProductReportLine
                {
                    ProductId = p.Id,
                    Name = p.Title.Title,
                    CategoryId = p.Title.CategoryId,
                    Category = p.Title.Category.Name,
                    Manufacturer = p.Manufacturer.Name,
                    Price = p.UnitPrice
                })
                .ToList();

            return new FullProductReport(lines, DateTime.Now);
        }

        // 2.4 🔥 НАЙВАЖЛИВІШЕ
        public ProductTitleSalesRevenueReport GetProductTitleSalesRevenueReport()
        {
            var lines = this.shopContext.Titles
                .Where(pt => pt.Products
                    .SelectMany(p => p.OrderDetails)
                    .Any())
                .Select(pt => new ProductTitleSalesRevenueReportLine
                {
                    ProductTitleName = pt.Title,

                    SalesRevenue = pt.Products
                        .SelectMany(p => p.OrderDetails)
                        .Sum(od => (double?)od.PriceWithDiscount) ?? 0,

                    SalesAmount = pt.Products
                        .SelectMany(p => p.OrderDetails)
                        .Sum(od => (int?)od.ProductAmount) ?? 0
                })
                .OrderByDescending(x => x.SalesRevenue)
                .ToList();

            return new ProductTitleSalesRevenueReport(lines, DateTime.Now);
        }
    }
}
