using NSubstitute;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Enums;
using Thunders.TechTest.ApiService.Models.Reports;
using Thunders.TechTest.ApiService.Repositories;
using Thunders.TechTest.ApiService.Services;

namespace Thunders.TechTest.Tests.Services
{
    public class ReportServiceTests
    {
        private readonly IReportRepository _repositoryMock;
        private readonly ReportService _reportService;

        public ReportServiceTests()
        {
            _repositoryMock = Substitute.For<IReportRepository>();
            _reportService = new ReportService(_repositoryMock);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnAddedReport()
        {
            // Arrange
            var report = new Report
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                ReportType = ReportType.HourlyRevenueByCity,
                Params = "{\"key\": \"value\"}"
            };

            _repositoryMock.AddAsync(report).Returns(report);

            // Act
            var result = await _reportService.AddAsync(report);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(report, result);
            await _repositoryMock.Received(1).AddAsync(report);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnUpdatedReport()
        {
            // Arrange
            var report = new Report
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                ReportType = ReportType.HourlyRevenueByCity,
                Params = "{\"key\": \"value\"}"
            };

            _repositoryMock.UpdateAsync(report).Returns(report);

            // Act
            var result = await _reportService.UpdateAsync(report);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(report, result);
            await _repositoryMock.Received(1).UpdateAsync(report);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnReport_WhenReportExists()
        {
            // Arrange
            var reportId = Guid.NewGuid();
            var expectedReport = new Report
            {
                Id = reportId,
                CreatedAt = DateTime.Now,
                ReportType = ReportType.VehicleCountByTollBooth,
                Params = "{\"key\": \"value\"}"
            };

            _repositoryMock.GetByIdAsync(reportId).Returns(expectedReport);

            // Act
            var result = await _reportService.GetByIdAsync(reportId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedReport, result);
            await _repositoryMock.Received(1).GetByIdAsync(reportId);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenReportDoesNotExist()
        {
            // Arrange
            var reportId = Guid.NewGuid();

            _repositoryMock.GetByIdAsync(reportId).Returns((Report?)null);

            // Act
            var result = await _reportService.GetByIdAsync(reportId);

            // Assert
            Assert.Null(result);
            await _repositoryMock.Received(1).GetByIdAsync(reportId);
        }

        [Fact]
        public async Task GetRevenueReportByHourAndCityWithCacheAsync_ShouldReturnReport()
        {
            // Arrange
            var reportParams = new HourlyRevenueParams
            {
                StartDate = DateTime.Now.AddHours(-1),
                EndDate = DateTime.Now
            };

            var expectedReports = new List<RevenueReportByHourAndCity>
            {
                new("City1", 10, 100),
                new("City2", 11, 200)
            };

            _repositoryMock.GetRevenueReportByHourAndCityWithCacheAsync(reportParams).Returns(expectedReports);

            // Act
            var result = await _reportService.GetRevenueReportByHourAndCityWithCacheAsync(reportParams);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedReports, result);
            await _repositoryMock.Received(1).GetRevenueReportByHourAndCityWithCacheAsync(reportParams);
        }

        [Fact]
        public async Task GetTopTollBoothsByRevenueWithCacheAsync_ShouldReturnReport()
        {
            // Arrange
            var reportParams = new TopTollBoothsParams
            {
                Month = 4,
                Year = 2023,
                TopCount = 3
            };

            var expectedReports = new List<TollBoothRevenueReport>
            {
                new("Toll1", 5000),
                new("Toll2", 3000)
            };

            _repositoryMock.GetTopTollBoothsByRevenueWithCacheAsync(reportParams).Returns(expectedReports);

            // Act
            var result = await _reportService.GetTopTollBoothsByRevenueWithCacheAsync(reportParams);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedReports, result);
            await _repositoryMock.Received(1).GetTopTollBoothsByRevenueWithCacheAsync(reportParams);
        }

        [Fact]
        public async Task GetVehicleTypeCountByTollBoothWithCacheAsync_ShouldReturnReport()
        {
            // Arrange
            var reportParams = new VehicleCountParams
            {
                TollBooth = "Main Plaza",
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = DateTime.Now
            };

            var expectedReports = new List<VehicleTypeCountReport>
            {
                new(VehicleType.Car, 10),
                new(VehicleType.Truck, 5)
            };

            _repositoryMock.GetVehicleTypeCountByTollBoothWithCacheAsync(reportParams).Returns(expectedReports);

            // Act
            var result = await _reportService.GetVehicleTypeCountByTollBoothWithCacheAsync(reportParams);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedReports, result);
            await _repositoryMock.Received(1).GetVehicleTypeCountByTollBoothWithCacheAsync(reportParams);
        }
    }
}