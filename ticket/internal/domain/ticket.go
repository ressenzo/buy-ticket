package domain

type Ticket struct {
	Id       string  `json:"id"`
	Name     string  `json:"name"`
	Value    float32 `json:"value"`
	Quantity int     `json:"quantity"`
}
