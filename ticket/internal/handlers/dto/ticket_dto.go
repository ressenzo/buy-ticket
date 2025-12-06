package dto

type TicketDto struct {
	Name     string  `json:"name"`
	Value    float32 `json:"value"`
	Quantity int     `json:"quantity"`
}
