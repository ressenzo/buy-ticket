package repository

import (
	"buy_ticket/ticket/internal/service"
	"encoding/json"
	"errors"
	"io"
	"net/http"
)

type eventRepository struct {
	client  *http.Client
	baseUrl string
}

func NewEventRepository(baseUrl string) service.EventRepository {
	return &eventRepository{
		client:  &http.Client{},
		baseUrl: baseUrl,
	}
}

const (
	ApiUrl = "http://localhost:5025/api/events"
)

func (r *eventRepository) GetEvent(eventId string) (*service.Event, error) {

	urlRequest := ApiUrl + "/id/" + eventId
	resp, err := http.Get(urlRequest)
	if err != nil {
		return nil, err
	}

	if resp.StatusCode == http.StatusNotFound {
		return nil, errors.New("event not found")
	}

	defer resp.Body.Close()

	body, err := io.ReadAll(resp.Body)
	if err != nil {
		return nil, err
	}

	var event service.Event
	json.Unmarshal(body, &event)
	return &event, nil
}
