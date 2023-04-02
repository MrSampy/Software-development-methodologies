# Use the official Golang image as a builder stage
FROM golang AS builder

# Set the working directory inside the container to /app
WORKDIR /app

# Copy the go.mod and go.sum files into the container
COPY go.mod go.sum ./

# Download the Go module dependencies
RUN go mod download

# Copy the rest of the application source code into the container
COPY . .

# Build the application and create a binary called fizzbuzz in the /app/build directory
RUN go build -o build/fizzbuzz

# Use the distroless/base image as the final image
FROM gcr.io/distroless/base

# Copy the fizzbuzz binary from the builder stage into the final image
COPY --from=builder /app/build/fizzbuzz /

# Copy the index.html template file from the builder stage into the final image
COPY --from=builder /app/templates/index.html /templates/

# Expose port 8080 so that it can be accessed from outside the container
EXPOSE 8080

# Start the application by running the /fizzbuzz command with the serve argument
CMD ["/fizzbuzz", "serve"]