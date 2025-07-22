using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Repositories;
using Xunit;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant.Tests;

public class UpdateRestaurantCommandHandlerTests
{
    private Mock<ILogger<UpdateRestaurantCommandHandler>> _logger;
    private Mock<IMapper> _mapper;
    private Mock<IRestaurantsRepository> _restaurantRepositoryMock;
    private Mock<IRestaurantAuthorizationService> _restaurantAuthorizeMock;
    private UpdateRestaurantCommandHandler _handler;

    public UpdateRestaurantCommandHandlerTests()
    {
        _logger = new Mock<ILogger<UpdateRestaurantCommandHandler>>();
        _mapper = new Mock<IMapper>();
        _restaurantRepositoryMock = new Mock<IRestaurantsRepository>();
        _restaurantAuthorizeMock = new Mock<IRestaurantAuthorizationService>();

        _handler = new UpdateRestaurantCommandHandler(_logger.Object,
            _mapper.Object,
            _restaurantRepositoryMock.Object,
            _restaurantAuthorizeMock.Object);

    }

    [Fact()]
    public async Task Handle_WithValidRequest_ShouldUpdateRestaurants()
    {
        //arrange
        var restaurantId = 1;

        var restaurant = new Restaurant()
        {
            Id = restaurantId,
            Name = "Test",
            Description = "Test",
        };

        var command = new UpdateRestaurantCommand()
        {
            Id = restaurantId,
            Name = "New Test",
            Description = "New Description",
            HasDelivery = true,
        };

        _restaurantRepositoryMock.Setup(r => r.GetByIdAsync(restaurantId))
            .ReturnsAsync(restaurant);

        _restaurantAuthorizeMock.Setup(r => r.Authorize(restaurant, ResourceOperation.Update))
            .Returns(true);

        //act

        await _handler.Handle(command, CancellationToken.None);

        //assert

        _restaurantRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once());

        _mapper.Verify(r => r.Map(command, restaurant), Times.Once());
    }

    [Fact]
    public async Task Handle_WithNonExistingRestaurant_ShouldThrowNotFoundException()
    {
        // Arrange
        var restaurantId = 2;
        var request = new UpdateRestaurantCommand
        {
            Id = restaurantId
        };

        _restaurantRepositoryMock.Setup(r => r.GetByIdAsync(restaurantId))
                .ReturnsAsync((Restaurant?)null);

        // act

        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // assert
        await act.Should().ThrowAsync<NotFoundException>()
                .WithMessage($"Restaurant with id: {restaurantId} doesn't exist");
    }

    [Fact]
    public async Task Handle_WithUnauthorizedUser_ShouldThrowForbidException()
    {
        // Arrange
        var restaurantId = 3;
        var request = new UpdateRestaurantCommand
        {
            Id = restaurantId
        };

        var existingRestaurant = new Restaurant
        {
            Id = restaurantId
        };

        _restaurantRepositoryMock
            .Setup(r => r.GetByIdAsync(restaurantId))
                .ReturnsAsync(existingRestaurant);

        _restaurantAuthorizeMock
            .Setup(a => a.Authorize(existingRestaurant, ResourceOperation.Update))
                .Returns(false);

        // act

        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ForbidException>();
    }
}