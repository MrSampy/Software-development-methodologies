# Проєкт на мові Python
## Початковий образ в Docker
Код докер файлу:
```
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
```
[Посилання на коміт](https://github.com/MrSampy/Software-development-methodologies/commit/77a17244822f45cfdfb1bc4f19df6316bd942a9f)</br></br>
Команда для збірки образу:
```
docker build -t python-1.0-test .
```
![Image11](./Labs/../Images/Python/1/photo_2023-04-02_19-33-40.jpg)
![Image12](./Labs/../Images/Python/1/photo_2023-04-02_19-33-44.jpg)
Команда для запуску образу:
```
docker run -p 8080:8080 --rm python-1.0-test
```
![Image13](./Labs/../Images/Python/1/photo_2023-04-02_19-33-47.jpg)
![Image14](./Labs/../Images/Python/1/photo_2023-04-02_19-33-51.jpg)

<b>Розмір: 215.34 М </br>
Час: 11.6 s</b></br>

## Зміни в api.py
Код api.py:
```
from fastapi import APIRouter

router = APIRouter()


@router.get('')
def get_userinfo() -> dict:
    data = {
        "name": "Serhiy",
        "second_name": "kolosov",
        "age": 19,
        "telegram": "MrSampy",
        "Job": "InCore",
    }

    return data
```
[Посилання на коміт](https://github.com/MrSampy/Software-development-methodologies/commit/2709af92a1944b42adcde49a38d18143704f6ddc)</br>
Команда для збірки образу:
```
docker build -t python-2.0-test .
```
![Image21](./Labs/../Images/Python/2/photo_2023-04-02_19-34-37.jpg)
![Image22](./Labs/../Images/Python/2/photo_2023-04-02_19-34-38.jpg)

Команда для запуску образу:
```
docker run -p 8080:8080 --rm python-2.0-test
```
![Image23](./Labs/../Images/Python/2/photo_2023-04-02_19-34-41.jpg)
![Image24](./Labs/../Images/Python/2/photo_2023-04-02_19-34-42.jpg)
![Image25](./Labs/../Images/Python/2/photo_2023-04-02_19-34-54.jpg)

<b>Розмір: 215.34 М </br>
Час: 10.6 s(Більша швидкіть через те, що python:slim-bullseye був вже завантажений, і докер взяв його з кешу)</b></br>

## Оптимізація докер файлу

Код докер файлу:

```
#Set the base image to the official Python Alpine image
FROM python:slim-bullseye

#Expose port 8080 to the outside world
EXPOSE 8080

#Set the working directory inside the container to /app
WORKDIR /app

#Copy the requirements file into the container
COPY requirements/backend.in .

#Install the required Python packages listed in backend.in
RUN pip install --no-cache-dir -r backend.in

#Copy the entire contents of the current directory into the container
COPY . .

#Specify the command to run when the container starts up
CMD ["uvicorn", "spaceship.main:app", "--host=0.0.0.0", "--port=8080"]
```
[Посилання на коміт](https://github.com/MrSampy/Software-development-methodologies/commit/421f80e3c4dc867c279cc5babc8c6d5ef48a8cf7)</br>

<h4 id="solution">У цьому випадку спочатку створюється копія файлу з залежностями Python, незалежно від іншого вмісту директорії. Залежності встановлюються після цього. Таким чином, Docker створить кеш-шар з залежностями, які будуть використовуватися з кешу у наступних збірках, якщо залежності не змінюватимуться. </h4>

Код api.py:

```
from fastapi import APIRouter

router = APIRouter()


@router.get('')
def get_userinfo() -> dict:
    data = {
        "name": "Serhiy",
        "second_name": "kolosov",
        "age": 19,
        "telegram": "MrSampy",
        "job": "InCore",
        "languages": ["C#", "C++", "Golang", "JS"],
        "phoneNumber":"+380989842116"
    }
    return data
```
[Посилання на коміт](https://github.com/MrSampy/Software-development-methodologies/commit/3a336653ab9a389a3e303149a5eea1ffc9d18485)</br>

Команда для збірки образу:
```
docker build -t python-3.0-test .
```
![Image31](./Labs/../Images/Python/3/photo_2023-04-02_19-35-54.jpg)
![Image32](./Labs/../Images/Python/3/photo_2023-04-02_19-35-27.jpg)
Команда для запуску образу:
```
docker run -p 8080:8080 --rm python-3.0-test
```
![Image33](./Labs/../Images/Python/3/photo_2023-04-02_19-35-30.jpg)
![Image34](./Labs/../Images/Python/3/photo_2023-04-02_19-35-36.jpg)

<b>Розмір: 215.34 М </br>
Час: 1.8 s(Більша швидкіть через <a href=#solution>цю причину.</a>)</b></br>

## Зміна базового образу

Код докер файлу:

```
#Set the base image to the official Python Alpine image
FROM python:alpine

#Expose port 8080 to the outside world
EXPOSE 8080

#Set the working directory inside the container to /app
WORKDIR /app

#Copy the requirements file into the container
COPY requirements/backend.in .

#Install the required Python packages listed in backend.in
RUN pip install --no-cache-dir -r backend.in

#Copy the entire contents of the current directory into the container
COPY . .

#Specify the command to run when the container starts up
CMD ["uvicorn", "spaceship.main:app", "--host=0.0.0.0", "--port=8080"]
```
[Посилання на коміт](https://github.com/MrSampy/Software-development-methodologies/commit/e75675f77f710c5b2965eddfbf26249d9dec2a6b)</br>

Команда для збірки образу:
```
docker build -t python-4.0-test .
```
![Image41](./Labs/../Images/Python/4/photo_2023-04-02_19-36-50.jpg)
Команда для запуску образу:
```
docker run -p 8080:8080 --rm python-4.0-test
```
![Image42](./Labs/../Images/Python/4/photo_2023-04-02_19-36-55.jpg)

<b>Розмір: 111.76 М(Розмір зменшився тому, що новий базовий образ менше важить) </br>
Час: 12.6 s(Швидкість зменшилися через те, що тре було час, щоб вперше завантажити новий базовий образ)</b></br>

##Порівнння базових образів

Код backend.in:
```
pydantic
starlette
uvicorn[standard]
numpy==1.24.2
```
[Посилання на коміт](https://github.com/MrSampy/Software-development-methodologies/commit/66086d91d8520bcd1b2a18e630124fce83c3bc1c)</br>

Код api.py:

```
import numpy as np
from fastapi import APIRouter

router = APIRouter()


@router.get('')
def get_userinfo() -> dict:
    data = {
        "name": "Serhiy",
        "second_name": "kolosov",
        "age": 19,
        "telegram": "MrSampy",
        "job": "InCore",
        "languages": ["C#", "C++", "Golang", "JS"],
        "phoneNumber":"+380989842116"
    }
    return data

@router.get('/multiply')
def multiply() -> dict:
    first_matrix = np.random.rand(10, 10)
    second_matrix = np.random.rand(10, 10)

    result = np.dot(first_matrix, second_matrix)

    result = {
        "first_matrix": first_matrix.tolist(),
        "second_matrix": second_matrix.tolist(),
        "result": result.tolist()
    }

    return result
```
[Посилання на коміт](https://github.com/MrSampy/Software-development-methodologies/commit/81df347e2f3fecc9f4148c230e0c373baf3f7cc0)</br>

### Збірка образу на базовому образі debian(slim-bullseye):
Код докер файлу:

```
FROM python:slim-bullseye

#Expose port 8080 to the outside world
EXPOSE 8080

#Set the working directory inside the container to /app
WORKDIR /app

#Copy the requirements file into the container
COPY requirements/backend.in .

#Install the required Python packages listed in backend.in
RUN pip install --no-cache-dir -r backend.in

#Copy the entire contents of the current directory into the container
COPY . .

#Specify the command to run when the container starts up
CMD ["uvicorn", "spaceship.main:app", "--host=0.0.0.0", "--port=8080"]
```
[Посилання на коміт](https://github.com/MrSampy/Software-development-methodologies/commit/d58922724087c1c3ee24602e19ecdc26edbfc8e0)</br>
Команда для збірки образу:
```
docker build -t python-sl.bu-test .
```
![Image51](./Labs/../Images/Python/5/photo_2023-04-02_19-37-51.jpg)
![Image52](./Labs/../Images/Python/5/photo_2023-04-02_19-37-53.jpg)
Команда для запуску образу:
```
docker run -p 8080:8080 --rm python-sl.bu-test
```
![Image53](./Labs/../Images/Python/5/photo_2023-04-02_19-38-02.jpg)
![Image54](./Labs/../Images/Python/5//photo_2023-04-02_19-38-05.jpg)
![Image55](./Labs/../Images/Python/5/photo_2023-04-02_19-38-14.jpg)
### Збірка образу на базовому образі alpine:
Код докер файлу:

```
#Set the base image to the official Python Alpine image
FROM python:alpine

#Expose port 8080 to the outside world
EXPOSE 8080

#Set the working directory inside the container to /app
WORKDIR /app

#Copy the requirements file into the container
COPY requirements/backend.in .

#Install the required Python packages listed in backend.in
RUN pip install --no-cache-dir -r backend.in

#Copy the entire contents of the current directory into the container
COPY . .

#Specify the command to run when the container starts up
CMD ["uvicorn", "spaceship.main:app", "--host=0.0.0.0", "--port=8080"]
```
[Посилання на коміт](https://github.com/MrSampy/Software-development-methodologies/commit/421f80e3c4dc867c279cc5babc8c6d5ef48a8cf7)</br>

Команда для збірки образу:
```
docker build -t python-alp-test .
```
Під час спроби збору образу, в мене виникла помилка:
![Image56](./Labs/../Images/Python/5/photo_2023-04-02_19-38-14.jpg)

Рішення було знайдено [тут](https://stackoverflow.com/questions/73273634/cant-install-wheels-on-docker-for-numpy)

В моєму випадку я просто трішки змінив код докера:

```
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
```

![Image57](./Labs/../Images/Python/5/photo_2023-04-02_19-38-19.jpg)

Команда для запуску образу:
```
docker run -p 8080:8080 --rm python-alp-test
```

![Image58](./Labs/../Images/Python/5/photo_2023-04-02_19-38-21.jpg)

Результат для slim-bullseye :
<b>Розмір: 256.44 М</br>
Час: 11.3 s</b></br>

Результат для alpine:
<b>Розмір: 480.87 М</br>
Час: 1.8 s</b></br>