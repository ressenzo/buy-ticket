package handlers

import (
	"buy_ticket/ticket/internal/service"
	"net/http"

	"github.com/gin-gonic/gin"
)

type ticketHandler struct {
	service service.TicketService
}

func NewTicketHandler(service service.TicketService) *ticketHandler {
	return &ticketHandler{
		service: service,
	}
}

func (h *ticketHandler) RegisterRoutes(r *gin.Engine) {
	r.GET("/ping", func(ctx *gin.Context) {
		ctx.JSON(http.StatusOK, gin.H{
			"status": "pong",
		})
	})
}
