# Use an official Golang runtime as a parent image
FROM golang:latest

# Set the working directory to /app
WORKDIR /app

# Copy the current directory contents into the container at /app
COPY . /app

# Build the Go app and output the binary to /app/build/fizzbuzz
RUN go build -o build/fizzbuzz

# Expose port 8080 for serving the app
EXPOSE 8080

# Run the command to start the app
CMD ["./build/fizzbuzz", "serve"]