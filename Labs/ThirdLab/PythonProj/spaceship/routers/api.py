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
        "Job": "InCore"
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