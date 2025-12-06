package service

import "buy_ticket/ticket/internal/domain"

type TicketRepository interface {
	CreateTicket(eventId string, ticket domain.Ticket) error
}
