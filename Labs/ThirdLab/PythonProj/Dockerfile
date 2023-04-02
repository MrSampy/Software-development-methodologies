FROM python:slim-bullseye

EXPOSE 8080

# Set the working directory to /app
WORKDIR /app

# Copy the current directory contents into the container at /app
COPY . /app

# Create a vaairtual environment and install dependencies
RUN python -m venv ./.venv 

RUN . ./.venv/bin/activate

RUN pip install -r requirements/backend.in

# Run the application when the container launches
CMD ["uvicorn", "spaceship.main:app", "--host=0.0.0.0", "--port=8080"]
