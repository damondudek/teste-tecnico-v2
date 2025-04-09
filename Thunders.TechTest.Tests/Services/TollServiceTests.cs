using NSubstitute;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Enums;
using Thunders.TechTest.ApiService.Repositories;
using Thunders.TechTest.ApiService.Services;

namespace Thunders.TechTest.Tests.Services;

public class TollServiceTests
{
    private readonly ITollRepository _repositoryMock;
    private readonly TollService _tollService;

    public TollServiceTests()
    {
        _repositoryMock = Substitute.For<ITollRepository>();
        _tollService = new TollService(_repositoryMock);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnAddedToll()
    {
        // Arrange
        var toll = new Toll
        {
            TollBooth = "Main TollBooth",
            City = "São Paulo",
            State = "SP",
            AmountPaid = 25.75m,
            UsageDateTime = DateTime.Now,
            VehicleType = VehicleType.Car
        };

        _repositoryMock.AddAsync(toll).Returns(toll);

        // Act
        var result = await _tollService.AddAsync(toll);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(toll, result);
        await _repositoryMock.Received(1).AddAsync(toll);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnToll_WhenTollExists()
    {
        // Arrange
        var tollId = Guid.NewGuid();
        var expectedToll = new Toll
        {
            Id = tollId,
            TollBooth = "Main TollBooth",
            City = "São Paulo",
            State = "SP",
            AmountPaid = 25.75m,
            UsageDateTime = DateTime.Now,
            VehicleType = VehicleType.Car
        };

        _repositoryMock.GetByIdAsync(tollId).Returns(expectedToll);

        // Act
        var result = await _tollService.GetByIdAsync(tollId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedToll, result);
        Assert.Equal(tollId, result.Id);
        await _repositoryMock.Received(1).GetByIdAsync(tollId);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenTollDoesNotExist()
    {
        // Arrange
        var tollId = Guid.NewGuid();

        _repositoryMock.GetByIdAsync(tollId).Returns((Toll?)null);

        // Act
        var result = await _tollService.GetByIdAsync(tollId);

        // Assert
        Assert.Null(result);
        await _repositoryMock.Received(1).GetByIdAsync(tollId);
    }
}