# Use a Golang image as the build environment
FROM golang AS builder

# Set the working directory to /app
WORKDIR /app

# Copy the current directory contents into the container at /app
COPY . .

# Build the project
RUN go build -o build/fizzbuzz

# Use distroless as the base image
FROM gcr.io/distroless/base

# Copy the binary from the builder stage
COPY --from=builder /app/build/fizzbuzz /

# Copy the templates directory from the builder stage
COPY --from=builder /app/templates/index.html /templates/

# Expose port 8080
EXPOSE 8080

# Run the binary
CMD ["/fizzbuzz", "serve"]