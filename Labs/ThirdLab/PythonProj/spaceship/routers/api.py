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
