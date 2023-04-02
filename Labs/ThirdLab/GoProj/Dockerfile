# Use the Golang builder image as a parent image
FROM golang AS builder

# Set the working directory to /app
WORKDIR /app

# Copy the current directory contents into the container at /app
COPY . .

# Build the project with CGO disabled, to create a statically linked binary
RUN CGO_ENABLED=0 go build -ldflags "-w -s -extldflags '-static'" -o build/fizzbuzz

# Use a scratch image as a base for the final image, which will not have any OS or libraries
FROM scratch

# Copy the binary from the builder image to the final image
COPY --from=builder /app/build/fizzbuzz /

# Copy the HTML template from the builder image to the final image
COPY --from=builder /app/templates/index.html /templates/

# Expose the port that the server will listen on
EXPOSE 8080

# Run the server when the container launches
CMD ["/fizzbuzz", "serve"]