package service

import (
	"buy_ticket/ticket/internal/domain"
	"buy_ticket/ticket/internal/repository"
	"context"
	"errors"
	"testing"

	"github.com/jackc/pgx/v5"
	"github.com/stretchr/testify/mock"
)

type MockEventRepository struct {
	mock.Mock
}

func (m *MockEventRepository) GetEvent(eventId string) (*repository.Event, error) {
	args := m.Called(eventId)
	return args.Get(0).(*repository.Event), args.Error(1)
}

type MockTicketRepository struct {
	mock.Mock
}

func (m *MockTicketRepository) CreateTicket(ctx context.Context, tx pgx.Tx, eventId string, ticket domain.Ticket) error {
	args := m.Called(ctx, tx, eventId, ticket)
	return args.Error(0)
}

func TestCreateTickets(t *testing.T) {
	eventRepo := new(MockEventRepository)
	ticketRepo := new(MockTicketRepository)

	service := NewTicketService(eventRepo, ticketRepo, &pgx.Conn{})

	t.Run("event id is empty", func(t *testing.T) {
		ticketGroup := domain.TicketGroup{}

		result, got := service.CreateTickets(context.Background(), ticketGroup)
		expected := "event id can not be empty"

		if result != nil {
			t.Error("result should be null")
		}

		if got.Error() != expected {
			t.Errorf("expected = %s; got = %s", expected, got)
		}
	})

	t.Run("tickets len is equal to 0", func(t *testing.T) {
		ticketGroup := domain.TicketGroup{
			EventId: "12345678",
		}

		result, got := service.CreateTickets(context.Background(), ticketGroup)
		expected := "it is necessary to have, at least, 1 ticket"

		if result != nil {
			t.Error("result should be null")
		}

		if got.Error() != expected {
			t.Errorf("expected = %s; got = %s", expected, got)
		}
	})

	t.Run("event does not exist", func(t *testing.T) {
		eventRepo := new(MockEventRepository)
		service := NewTicketService(eventRepo, ticketRepo, &pgx.Conn{})

		eventId := "12345678"
		ticketGroup := domain.TicketGroup{
			EventId: eventId,
			Tickets: []domain.Ticket{
				{Id: "1234"},
			},
		}

		expected := "event does not exist"
		eventRepo.On("GetEvent", eventId).Return((*repository.Event)(nil), nil)
		result, got := service.CreateTickets(context.Background(), ticketGroup)

		if result != nil {
			t.Error("result should be null")
		}

		if got.Error() != expected {
			t.Errorf("expected = %s; got = %s", expected, got)
		}
	})

	t.Run("get event returns error", func(t *testing.T) {
		eventRepo := new(MockEventRepository)
		service := NewTicketService(eventRepo, ticketRepo, &pgx.Conn{})

		eventId := "12345678"
		ticketGroup := domain.TicketGroup{
			EventId: eventId,
			Tickets: []domain.Ticket{
				{Id: "1234"},
			},
		}

		expected := "error to get event"
		eventRepo.On("GetEvent", eventId).Return((*repository.Event)(nil), errors.New(expected))
		result, got := service.CreateTickets(context.Background(), ticketGroup)

		if result != nil {
			t.Error("result should be null")
		}

		if got.Error() != expected {
			t.Errorf("expected = %s; got = %s", expected, got)
		}
	})
}
