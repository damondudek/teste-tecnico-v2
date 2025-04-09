using NSubstitute;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Enums;
using Thunders.TechTest.ApiService.Repositories;
using Thunders.TechTest.ApiService.Services;

namespace Thunders.TechTest.Tests.Services;

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
            UpdatedAt = null,
            DeletedAt = null,
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
    public async Task GetByIdAsync_ShouldReturnReport_WhenReportExists()
    {
        // Arrange
        var reportId = Guid.NewGuid();
        var expectedReport = new Report
        {
            Id = reportId,
            CreatedAt = DateTime.Now,
            UpdatedAt = null,
            DeletedAt = null,
            ReportType = ReportType.VehicleCountByTollBooth,
            Params = "{\"key\": \"value\"}"
        };

        _repositoryMock.GetByIdAsync(reportId).Returns(expectedReport);

        // Act
        var result = await _reportService.GetByIdAsync(reportId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedReport, result);
        Assert.Equal(reportId, result.Id);
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
}