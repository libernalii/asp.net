namespace EFCoreShopReportsTask.Reports
{
    public sealed class ProductReport : ReportBase<ProductReportLine>
    {
        public ProductReport(IList<ProductReportLine> lines, DateTime reportGenerationDate)
            : base(lines, reportGenerationDate)
        {
        }
    }
}
