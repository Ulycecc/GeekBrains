from fastapi import FastAPI
from pydantic import BaseModel, Field
from datetime import date, datetime

app = FastAPI()


class UserIn(BaseModel):
    name: str = Field(title="Name", max_length=32)
    last_name: str = Field(title="Last name", max_length=32)
    email: str = Field(title="email", max_length=128)
    password: str = Field(title="password", max_length=128)


class User(BaseModel):
    id: int
    name: str = Field(title="Name", max_length=32)
    last_name: str = Field(title="Last name", max_length=32)
    email: str = Field(title="email", max_length=128)
    password: str = Field(title="password", max_length=128)


class ProductIn(BaseModel):
    name: str = Field(title="Product name", max_length=32)
    price: float = Field(title="Price", gt=0, le=100000)
    description: str = Field(
        default=None, title="Description", max_length=1000)


class Product(BaseModel):
    id: int
    name: str = Field(title="Product name", max_length=32)
    price: float = Field(title="Price", gt=0, le=100000)
    description: str = Field(
        default=None, title="Description", max_length=1000)


class OrderIn(BaseModel):
    user_id: int = Field(title="user_id")
    prodact_id: int = Field(title="prodact_id")
    date_order: date
    status: str = Field(max_length=10)


class Order(BaseModel):
    id: int
    user_id: int = Field(title="user_id")
    prodact_id: int = Field(title="prodact_id")
    date_order: date = Field(title="Date")
    status: str = Field(title="Status", max_length=10)
