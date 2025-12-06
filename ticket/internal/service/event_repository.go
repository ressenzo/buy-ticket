package service

type EventRepository interface {
	GetEvent(eventId string) (*Event, error)
}
