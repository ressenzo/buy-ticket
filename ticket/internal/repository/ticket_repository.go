package repository

import (
	"buy_ticket/ticket/internal/domain"
	"database/sql"
)

type TicketRepository interface {
	CreateTicket(ticket domain.Ticket) error
}

type ticketRepository struct {
	db *sql.DB
}

func NewTicketRepository(db *sql.DB) TicketRepository {
	return &ticketRepository{
		db: db,
	}
}

func (r *ticketRepository) CreateTicket(ticket domain.Ticket) error {
	return nil
}
