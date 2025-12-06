package utils

import (
	"net/http"

	"github.com/gin-gonic/gin"
)

const (
	CONTENT_TYPE_KEY   string = "Content-Type"
	CONTENT_TYPE_VALUE string = "application/json"
)

func InternalError(c *gin.Context) {
	addHeader(c)
	c.JSON(http.StatusInternalServerError, gin.H{
		"message": "Something internally went wrong",
		"code":    http.StatusInternalServerError,
	})
}

func Error(c *gin.Context, code int, message string) {
	addHeader(c)
	c.JSON(code, gin.H{
		"message": message,
		"code":    code,
	})
}

func Success(c *gin.Context, code int, data any) {
	addHeader(c)
	c.JSON(code, gin.H{
		"content": data,
	})
}

func addHeader(c *gin.Context) {
	c.Header(CONTENT_TYPE_KEY, CONTENT_TYPE_VALUE)
}
