using Thunders.TechTest.ApiService.Domain.Entities;

namespace Thunders.TechTest.Tests.Entities;

public class EntityTests
{
    [Fact]
    public void SetId_ShouldGenerateNewGuid()
    {
        // Arrange
        var entity = new Entity();

        // Act
        entity.SetId();

        // Assert
        Assert.NotEqual(Guid.Empty, entity.Id);
    }

    [Fact]
    public void SetCreation_ShouldSetCreatedAtToDateTime()
    {
        // Arrange
        var entity = new Entity();

        // Act
        entity.SetCreation();

        // Assert
        Assert.NotEqual(default, entity.CreatedAt);
    }

    [Fact]
    public void SetUpdate_ShouldSetUpdatedAtToDateTime()
    {
        // Arrange
        var entity = new Entity();

        // Act
        entity.SetUpdate();

        // Assert
        Assert.NotEqual(default, entity.UpdatedAt);
        Assert.NotNull(entity.UpdatedAt);
    }

    [Fact]
    public void SetDeletion_ShouldSetDeletedAtAndUpdateUpdatedAt()
    {
        // Arrange
        var entity = new Entity();

        // Act
        entity.SetDeletion();

        // Assert
        Assert.NotEqual(default, entity.DeletedAt);
        Assert.NotEqual(default, entity.UpdatedAt);
        Assert.NotNull(entity.DeletedAt);
        Assert.NotNull(entity.UpdatedAt);
    }

    [Fact]
    public void ToString_ShouldReturnValidJsonRepresentation()
    {
        // Arrange
        var entity = new Entity();
        entity.SetId();
        entity.SetCreation();
        entity.SetUpdate();
        entity.SetDeletion();

        // Act
        var json = entity.ToString();

        // Assert
        Assert.NotNull(json);
        Assert.Contains(entity.Id.ToString(), json);
    }
}