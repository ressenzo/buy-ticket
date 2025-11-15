package service

import (
	"buy_ticket/ticket/internal/domain"
	"buy_ticket/ticket/internal/repository"
	"database/sql"
)

type TicketService interface {
	CreateTickets(ticketGroup domain.TicketGroup) error
}

type ticketService struct {
	eventRepository  repository.EventRepository
	ticketRepository repository.TicketRepository
	db               *sql.DB
}

func NewTicketService(eventRepository repository.EventRepository, ticketRepository repository.TicketRepository, db *sql.DB) TicketService {
	return &ticketService{
		eventRepository:  eventRepository,
		ticketRepository: ticketRepository,
		db:               db,
	}
}

func (s *ticketService) CreateTickets(ticketGroup domain.TicketGroup) error {
	return nil
}
