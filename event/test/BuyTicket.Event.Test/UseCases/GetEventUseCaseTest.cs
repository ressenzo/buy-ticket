using BuyTicket.Event.Application.Commons;
using BuyTicket.Event.Application.GetEvent;
using BuyTicket.Event.Domain.Entities.Interfaces;
using BuyTicket.Event.Infrastructure.Repositories.Interfaces;
using BuyTicket.Event.Test.Builders;
using Microsoft.Extensions.Logging;
using Moq;

namespace BuyTicket.Event.Test.UseCases;

public class GetEventUseCaseTest
{
    private readonly GetEventUseCase _useCase;
    private readonly Mock<ILogger<GetEventUseCase>> _logger;
    private readonly Mock<IEventRepository> _eventRepository;

    public GetEventUseCaseTest()
    {
        _logger = new();
        _eventRepository = new();
        _useCase = new(
            _logger.Object,
            _eventRepository.Object);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task WhenIdIsInvalid_ShouldReturnValidationError(
        string? id)
    {
        // Act
        var result = await _useCase.GetEvent(id!, CancellationToken.None);

        // Assert
        result.ResultType.ShouldBe(ResultType.VALIDATION_ERROR);
        _eventRepository.Verify(x => x.GetEvent(
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task WhenIdIsValidAndEventIsNotFound_ShouldReturnNotFound()
    {
        // Arrange
        var id = "12345678";

        // Act
        var result = await _useCase.GetEvent(id!, CancellationToken.None);

        // Assert
        result.ResultType.ShouldBe(ResultType.NOT_FOUND);
        _eventRepository.Verify(x => x.GetEvent(
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }
    
    [Fact]
    public async Task WhenIdIsValidAndEventIsFound_ShouldReturnSuccess()
    {
        // Arrange
        var id = "12345678";
        var @event = new EventBuilder()
            .Build();
        _eventRepository
            .Setup(x => x.GetEvent(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(@event);

        // Act
        var result = await _useCase.GetEvent(id!, CancellationToken.None);
        
        // Assert
        result.ResultType.ShouldBe(ResultType.SUCCESS);
        _eventRepository.Verify(x => x.GetEvent(
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }
}
