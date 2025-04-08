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
            Plaza = "Main Plaza",
            City = "São Paulo",
            State = "SP",
            AmountPaid = 25.75m,
            UsageDateTime = System.DateTime.Now,
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
}