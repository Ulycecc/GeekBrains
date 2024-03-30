import databases
import sqlalchemy
from typing import List
from fastapi import FastAPI
from pydantic import BaseModel
from models import *


DATABASE_URL = "sqlite:///mydatabase.db"
database = databases.Database(DATABASE_URL)
metadata = sqlalchemy.MetaData()


users = sqlalchemy.Table(
    "users",
    metadata,
    sqlalchemy.Column("id", sqlalchemy.Integer,
                      primary_key=True),
    sqlalchemy.Column("name", sqlalchemy.String(32)),
    sqlalchemy.Column("last_name", sqlalchemy.String(32)),
    sqlalchemy.Column("email", sqlalchemy.String(128)),
    sqlalchemy.Column("password", sqlalchemy.String(128)),

)

products = sqlalchemy.Table(
    "products",
    metadata,
    sqlalchemy.Column("id", sqlalchemy.Integer,
                      primary_key=True),
    sqlalchemy.Column("name", sqlalchemy.String(32)),
    sqlalchemy.Column("price", sqlalchemy.Float),
    sqlalchemy.Column("description", sqlalchemy.String(1000)),
)

orders = sqlalchemy.Table(
    "order",
    metadata,
    sqlalchemy.Column("id", sqlalchemy.Integer,
                      primary_key=True),
    sqlalchemy.Column("user_id", sqlalchemy.Integer,
                      sqlalchemy.ForeignKey('users.id')),
    sqlalchemy.Column("prodact_id", sqlalchemy.Integer,
                      sqlalchemy.ForeignKey('products.id')),
    sqlalchemy.Column("date_order", sqlalchemy.Date),
    sqlalchemy.Column("status", sqlalchemy.String(10)),
)

engine = sqlalchemy.create_engine(
    DATABASE_URL, connect_args={"check_same_thread": False}
)
metadata.create_all(engine)
app = FastAPI()


@app.post("/users/", response_model=User)
async def create_user(user: UserIn):
    '''
    Создание пользователя
    '''
    query = users.insert().values(name=user.name, email=user.email)
    last_record_id = await database.execute(query)
    return {**user.dict(), "id": last_record_id}


@app.get("/users/", response_model=List[User])
async def read_users():
    '''
    Чтение списка пользователей
    '''

    query = users.select()
    return await database.fetch_all(query)


@app.get("/users/{user_id}", response_model=User)
async def read_user(user_id: int):
    '''
    Чтение одного пользователя
    '''
    query = users.select().where(users.c.id == user_id)
    return await database.fetch_one(query)


@app.put("/users/{user_id}", response_model=User)
async def update_user(user_id: int, new_user: UserIn):
    '''
    Обновление пользователя
    '''
    query = users.update().where(users.c.id ==
                                 user_id).values(**new_user.dict())
    await database.execute(query)
    return {**new_user.dict(), "id": user_id}


@app.delete("/users/{user_id}")
async def delete_user(user_id: int):
    '''
    Удаление пользователя
    '''
    query = users.delete().where(users.c.id == user_id)
    await database.execute(query)
    return {'message': 'User deleted'}


@app.post("/products/", response_model=Product)
async def create_product(product: ProductIn):
    '''
    Создание товара
    '''
    query = users.insert().values(name=product.name, price=product.price,
                                  description=product.description)
    last_record_id = await database.execute(query)
    return {**product.dict(), "id": last_record_id}


@app.get("/products/", response_model=List[Product])
async def read_products():
    '''
    Чтение списка товаров
    '''

    query = products.select()
    return await database.fetch_all(query)


@app.get("/products/{product_id}", response_model=Product)
async def read_product(product_id: int):
    '''
    Чтение одного товара
    '''
    query = users.select().where(products.c.id == product_id)
    return await database.fetch_one(query)


@app.put("/products/{product_id}", response_model=Product)
async def update_product(product_id: int, new_product: ProductIn):
    '''
    Обновление товара
    '''
    query = products.update().where(products.c.id ==
                                    product_id).values(**new_product.dict())
    await database.execute(query)
    return {**new_product.dict(), "id": product_id}


@app.delete("/products/{product_id}")
async def delete_product(product_id: int):
    '''
    Удаление товара
    '''
    query = users.delete().where(products.c.id == product_id)
    await database.execute(query)
    return {'message': 'Product deleted'}


@app.post("/orders/", response_model=Order)
async def create_order(order: OrderIn):
    '''
    Создание заказа
    '''
    query = users.insert().values(user_id=order.user_id,
                                  prodact_id=order.prodact_id,
                                  date_order=order.date_order,
                                  status=order.status,)
    last_record_id = await database.execute(query)
    return {**order.dict(), "id": last_record_id}


@app.get("/orders/", response_model=List[Order])
async def read_orders():
    '''
    Чтение списка заказов
    '''
    query = orders.select()
    return await database.fetch_all(query)


@app.get("/orders/{order_id}", response_model=Order)
async def read_order(order_id: int):
    '''
    Чтение одного заказа
    '''
    query = users.select().where(orders.c.id == order_id)
    return await database.fetch_one(query)


@app.put("/orders/{product_id}", response_model=Order)
async def update_order(order_id: int, new_order: OrderIn):
    '''
    Обновление заказа
    '''
    query = orders.update().where(orders.c.id ==
                                  new_order).values(**new_order.dict())
    await database.execute(query)
    return {**new_order.dict(), "id": order_id}


@app.delete("/orders/{order_id}")
async def delete_order(order_id: int):
    '''
    Удаление заказа
    '''
    query = orders.delete().where(orders.c.id == order_id)
    await database.execute(query)
    return {'message': 'Order deleted'}
