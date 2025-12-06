package handlers

import (
	"buy_ticket/ticket/internal/domain"
	"buy_ticket/ticket/internal/handlers/dto"
	"buy_ticket/ticket/internal/service"
	"buy_ticket/ticket/internal/utils"
	"context"
	"fmt"
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

	r.POST("/api/tickets", h.CreateTickets)
}

func (h *ticketHandler) CreateTickets(ctx *gin.Context) {
	var ticketGroupDto dto.TicketGroupDto
	if err := ctx.ShouldBindJSON(&ticketGroupDto); err != nil {
		utils.Error(
			ctx,
			http.StatusBadRequest,
			"invalid format for body")
		fmt.Println(err.Error())
		return
	}

	ticketGroup := domain.TicketGroup{
		EventId: ticketGroupDto.EventId,
	}
	ticketGroup.Tickets = make(
		[]domain.Ticket,
		0,
		len(ticketGroupDto.Tickets))
	for _, t := range ticketGroupDto.Tickets {
		ticket := domain.Ticket{
			Name:     t.Name,
			Value:    t.Value,
			Quantity: t.Quantity,
		}
		ticketGroup.Tickets = append(ticketGroup.Tickets, ticket)
	}

	result, err := h.service.CreateTickets(
		context.Background(),
		ticketGroup)
	if err != nil {
		utils.Error(
			ctx,
			http.StatusBadRequest,
			err.Error())
		return
	}

	utils.Success(ctx, http.StatusCreated, result)
}
