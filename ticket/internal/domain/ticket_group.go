package domain

type TicketGroup struct {
	Tickets []Ticket `json:"tickets"`
	EventId string   `json:"eventId"`
}
