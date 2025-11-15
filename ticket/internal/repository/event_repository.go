package repository

import (
	"net/http"
)

type EventRepository interface {
	GetEvent(eventId string) (*Event, error)
}

type eventRepository struct {
	client  *http.Client
	baseUrl string
}

func NewEventRepository(baseUrl string) EventRepository {
	return &eventRepository{
		client:  &http.Client{},
		baseUrl: baseUrl,
	}
}

func (r *eventRepository) GetEvent(eventId string) (*Event, error) {
	return nil, nil
}
