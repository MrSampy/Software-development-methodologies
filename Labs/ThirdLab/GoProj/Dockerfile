# Use Golang as a base image and name it "builder" stage
FROM golang AS builder

# Set the working directory to /app
WORKDIR /app

# Copy the go module files to the container and download the dependencies
COPY go.mod go.sum ./
RUN go mod download

# Copy the rest of the application source code to the container and build it
COPY . .
RUN CGO_ENABLED=0 go build -ldflags "-w -s -extldflags '-static'" -o build/fizzbuzz

# Create a new base image from scratch
FROM scratch

# Copy the compiled binary from the "builder" stage to the root directory of the new image
COPY --from=builder /app/build/fizzbuzz /

# Copy the index.html template to the /templates directory in the new image
COPY --from=builder /app/templates/index.html /templates/

# Expose port 8080
EXPOSE 8080

# Start the server by running the compiled binary and serving the application
CMD ["/fizzbuzz", "serve"]