package config

import (
	"context"
	"log"

	"github.com/jackc/pgx/v5"
)

func GetDb() *pgx.Conn {
	dbUrl := "postgres://admin:admin123@localhost:5432/buy_ticket_ticket"
	conn, err := pgx.Connect(context.Background(), dbUrl)
	if err != nil {
		log.Fatal(err)
	}

	if err = conn.Ping(context.Background()); err != nil {
		log.Fatal("Could not connect to database: ", err)
	}
	log.Println("Successfully connected to PostgreSQL!")

	return conn
}
