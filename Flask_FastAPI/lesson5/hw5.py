from fastapi import FastAPI
import logging
from pydantic import BaseModel
from fastapi.responses import HTMLResponse

logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

app = FastAPI()
tasks = {}


class Task(BaseModel):
    title: str
    description: str
    status: bool


@app.get("/", response_class=HTMLResponse)
async def read_root():
    return "<h1>Hello World</h1>"


@app.get("/get_items/{task_id}")
async def read_item(task_id: int):
    return tasks[task_id]


@app.get("/tasks/")
async def _item():
    return tasks


@app.post("/tasks/")
async def create_item(task: Task):
    if tasks:
        item_id = max(tasks.keys()) + 1
    else:
        item_id = 1
    tasks[item_id] = task
    return tasks


@app.put("/items/{task_id}")
async def update_item(task_id: int, task: Task):
    tasks[task_id] = task
    return tasks[task_id]


@app.delete("/items/{item_id}")
async def delete_item(item_id: int):
    del tasks[item_id]
    return tasks
