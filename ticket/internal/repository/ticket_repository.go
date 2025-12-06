package repository

import (
	"buy_ticket/ticket/internal/domain"
	"buy_ticket/ticket/internal/service"
	"context"

	"github.com/jackc/pgx/v5"
)

type ticketRepository struct {
	db *pgx.Conn
}

func NewTicketRepository(db *pgx.Conn) service.TicketRepository {
	return &ticketRepository{
		db: db,
	}
}

func (r *ticketRepository) CreateTicket(eventId string, ticket domain.Ticket) error {
	query := "INSERT INTO tickets (id, name, value, quantity, event_id) VALUES ($1, $2, $3, $4, $5) RETURNING id"
	var id string
	err := r.db.QueryRow(
		context.Background(),
		query,
		ticket.Id,
		ticket.Name,
		ticket.Value,
		ticket.Quantity,
		eventId).Scan(&id)
	return err
}
