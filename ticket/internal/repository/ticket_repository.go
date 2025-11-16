package repository

import (
	"buy_ticket/ticket/internal/domain"
	"context"

	"github.com/jackc/pgx/v5"
)

type TicketRepository interface {
	CreateTicket(ctx context.Context, tx pgx.Tx, eventId string, ticket domain.Ticket) error
}

type ticketRepository struct {
	db *pgx.Conn
}

func NewTicketRepository(db *pgx.Conn) TicketRepository {
	return &ticketRepository{
		db: db,
	}
}

func (r *ticketRepository) CreateTicket(ctx context.Context, tx pgx.Tx, eventId string, ticket domain.Ticket) error {
	query := "INSERT INTO tickets (id, name, value, quantity, event_id) VALUES ($1, $2, $3, $4, $5) RETURNING id"
	var id string
	err := tx.QueryRow(
		ctx,
		query,
		ticket.Id,
		ticket.Name,
		ticket.Value,
		ticket.Quantity,
		eventId).Scan(&id)
	return err
}
