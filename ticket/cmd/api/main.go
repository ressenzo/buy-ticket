package main

import (
	"buy_ticket/ticket/cmd/config"
	"buy_ticket/ticket/cmd/handlers"
	"buy_ticket/ticket/internal/repository"
	"buy_ticket/ticket/internal/service"
	"log"

	"github.com/gin-gonic/gin"
)

func main() {
	conn := config.GetDb()
	if conn == nil {
		log.Fatalf("Error initializing database: %v", conn)
	}

	eventRepository := repository.NewEventRepository("http://localhost:5001")
	ticketRepository := repository.NewTicketRepository(conn)
	ticketService := service.NewTicketService(eventRepository, ticketRepository, conn)
	ticketHandler := handlers.NewTicketHandler(ticketService)

	router := gin.Default()
	ticketHandler.RegisterRoutes(router)

	log.Println("Running on :8080")
	router.Run(":8080")
}
