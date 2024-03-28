
from multiprocessing import Process
import asyncio
import time
import threading
from sys import argv
import aiohttp


import requests


def download(url):
    '''
    Функция загружает файл
    '''
    response = requests.get(url)
    parts = url.split('/')
    filename = parts[-1]
    with open(filename, "wb") as f:
        f.write(response.content)
    print(f"Downloaded {url} in {time.time()-start_time:.2f}seconds")


def threads_(urls):
    '''
    Функция многопоточной загрузки списка файлов
    '''
    threads = []
    for url in urls:
        thread = threading.Thread(target=download, args=[url])
        threads.append(thread)
        thread.start()
    for thread in threads:
        thread.join()


def processes_(urls):
    '''
    Функция многопроцессорной загрузки списка файлов
    '''
    processes = []
    if __name__ == '__main__':
        for url in urls:
            process = Process(target=download, args=(url,))
            processes.append(process)
            process.start()
        for process in processes:
            process.join()


async def download_(url):
    '''
    Корутины загружает файл
    '''
    async with aiohttp.ClientSession() as session:
        async with session.get(url) as response:
            img = await response.content.read()
            parts = url.split('/')
            filename = parts[-1]
            with open(filename, "wb") as f:
                f.write(img)
                print(
                    f"Downloaded {url} in {time.time() - start_time:.2f} seconds")


async def async_():
    '''
    Корутины загрузки списка файлов
    '''
    tasks = []
    for url in urls:
        task = asyncio.ensure_future(download_(url))
        tasks.append(task)
    await asyncio.gather(*tasks)


start_time = time.time()

if __name__ == '__main__':

    n = int(argv[1])
    urls = [
        'https://m.obsuzhday.com/user_media/052/fe0/15f/937b7.jpg',
        'https://pp.userapi.com/c10899/v10899150/4f9/dG_8yX6BSDU.jpg',
        'https://ic.pics.livejournal.com/pet_and/85003607/413435/413435_original.png',
        'https://m.obsuzhday.com/user_media/231/014/89a/ac6cf.jpg',
        'https://i.pinimg.com/originals/62/1e/80/621e80540dac84022b574b34ca9d71df.jpg',
    ]

    if len(argv) > 2:
        urls = argv[2:]

    match n:
        case 1:
            threads_(urls)
        case 2:
            processes_(urls)
        case 3:
            loop = asyncio.get_event_loop()
            loop.run_until_complete(async_())
