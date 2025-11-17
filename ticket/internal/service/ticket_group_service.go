package service

import (
	"buy_ticket/ticket/internal/domain"
	"buy_ticket/ticket/internal/repository"
	"context"
	"errors"
	"fmt"

	"github.com/google/uuid"
	"github.com/jackc/pgx/v5"
)

type TicketService interface {
	CreateTickets(ctx context.Context, ticketGroup domain.TicketGroup) (*domain.TicketGroup, error)
}

type ticketService struct {
	eventRepository  repository.EventRepository
	ticketRepository repository.TicketRepository
	db               *pgx.Conn
}

func NewTicketService(eventRepository repository.EventRepository, ticketRepository repository.TicketRepository, db *pgx.Conn) TicketService {
	return &ticketService{
		eventRepository:  eventRepository,
		ticketRepository: ticketRepository,
		db:               db,
	}
}

func (s *ticketService) CreateTickets(ctx context.Context, ticketGroup domain.TicketGroup) (*domain.TicketGroup, error) {
	if ticketGroup.EventId == "" {
		return nil, errors.New("event id can not be empty")
	}

	if len(ticketGroup.Tickets) == 0 {
		return nil, errors.New("it is necessary to have, at least, 1 ticket")
	}

	event, err := s.eventRepository.GetEvent(ticketGroup.EventId)
	if err != nil {
		return nil, err
	}
	if event == nil {
		return nil, errors.New("event does not exist")
	}

	tx, err := s.db.Begin(context.Background())
	if err != nil {
		return nil, fmt.Errorf("%v", err)
	}

	defer func() {
		if err != nil {
			tx.Rollback(ctx)
		} else {
			err = tx.Commit(ctx)
		}
	}()

	for _, ticket := range ticketGroup.Tickets {
		ticket.Id = uuid.New().String()[0:8]
		err = s.ticketRepository.CreateTicket(ctx, tx, ticketGroup.EventId, ticket)
		if err != nil {
			return nil, fmt.Errorf("could not create ticket: %v", err)
		}
	}

	return &ticketGroup, err
}
