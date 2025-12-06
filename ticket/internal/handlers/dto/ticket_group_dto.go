package dto

type TicketGroupDto struct {
	Tickets []TicketDto `json:"tickets"`
	EventId string      `json:"eventId"`
}
