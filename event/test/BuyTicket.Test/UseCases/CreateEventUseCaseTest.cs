using BuyTicket.Application.Commons;
using BuyTicket.Application.CreateEvent;
using BuyTicket.Application.Factories.Interfaces;
using BuyTicket.Domain.Commons;
using BuyTicket.Domain.Entities.Interfaces;
using BuyTicket.Infrastructure.Repositories.Interfaces;
using BuyTicket.Test.Builders;
using Microsoft.Extensions.Logging;
using Moq;

namespace BuyTicket.Test.UseCases;

public class CreateEventUseCaseTest
{
    private readonly CreateEventUseCase _useCase;
    private readonly Mock<ILogger<CreateEventUseCase>> _logger;
    private readonly Mock<IEventFactory> _eventFactory;
    private readonly Mock<IEventRepository> _eventRepository;

    private readonly Mock<IEvent> _event;

    public CreateEventUseCaseTest()
    {
        _logger = new();
        _eventFactory = new();
        _eventRepository = new();
        _useCase = new(
            _logger.Object,
            _eventFactory.Object,
            _eventRepository.Object);
        _event = new();
        _event
            .Setup(x => x.IsValid())
            .Returns(true);
        _eventFactory.Setup(x => x.Construct(It.IsAny<CreateEventRequest>()))
            .Returns(_event.Object);
    }

    [Fact]
    public async Task WhenEventIsInvalid_ShouldReturnValidationError()
    {
        // Arrange
        var request = new CreateEventRequestBuilder()
            .Build();
        _event
            .Setup(x => x.Errors)
            .Returns([Error.DateBefore]);
        _event
            .Setup(x => x.IsValid())
            .Returns(false);
        _eventFactory.Setup(x => x.Construct(It.IsAny<CreateEventRequest>()))
            .Returns(_event.Object);

        // Act
        var result = await _useCase.CreateEvent(request, CancellationToken.None);

        // Assert
        result.ResultType.ShouldBe(ResultType.VALIDATION_ERROR);
        _eventRepository.Verify(x => x.CreateEvent(
            It.IsAny<IEvent>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task WhenEventIsValid_ShouldCreateNewOneAndReturnSuccess()
    {
        // Arrange
        var request = new CreateEventRequestBuilder()
            .Build();

        // Act
        var result = await _useCase.CreateEvent(request, CancellationToken.None);

        // Assert
        result.ResultType.ShouldBe(ResultType.SUCCESS);
        _eventRepository.Verify(x => x.CreateEvent(
            It.IsAny<IEvent>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }
}
