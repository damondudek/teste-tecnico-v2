namespace Thunders.TechTest.ApiService.Models.Reports
{
    public record RevenueReportByHourAndCity
    {
        public string City { get; set; }
        public int Hour { get; set; }
        public decimal TotalRevenue { get; set; }

        public RevenueReportByHourAndCity(string city, int hour, decimal totalRevenue)
        {
            City = city;
            Hour = hour;
            TotalRevenue = totalRevenue;
        }
    }
}