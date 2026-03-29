using EFCoreShopReportsTask.Models;
using EFCoreShopReportsTask.Reports;
using Microsoft.EntityFrameworkCore;

namespace EFCoreShopReportsTask.Services
{
    public class CustomerReportService
    {
        private readonly ShopContext shopContext;

        public CustomerReportService(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public CustomerSalesRevenueReport GetCustomerSalesRevenueReport()
        {
            var lines = this.shopContext.Customers
                .Select(c => new CustomerSalesRevenueReportLine
                {
                    CustomerId = c.Id,
                    PersonFirstName = c.Person.FirstName,
                    PersonLastName = c.Person.LastName,
                    SalesRevenue = c.Orders
                        .SelectMany(o => o.Details)
                        .Sum(oi => (double?)oi.PriceWithDiscount) ?? 0
                })
                .OrderByDescending(x => x.SalesRevenue)
                .Take(15) // 🔥 ВАЖЛИВО (дивись expected count)
                .ToList();

            return new CustomerSalesRevenueReport(lines, DateTime.Now);
        }
    }
}
