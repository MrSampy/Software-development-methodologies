#Set the base image to the official Python Alpine image
FROM python:alpine

#Expose port 8080 to the outside world
EXPOSE 8080

#Set the working directory inside the container to /app
WORKDIR /app

#Copy the requirements file into the container
COPY requirements/backend.in .

RUN pip install --extra-index-url https://alpine-wheels.github.io/index numpy

#Install the required Python packages listed in backend.in
RUN pip install --no-cache-dir -r backend.in

#Copy the entire contents of the current directory into the container
COPY . .

#Specify the command to run when the container starts up
CMD ["uvicorn", "spaceship.main:app", "--host=0.0.0.0", "--port=8080"]