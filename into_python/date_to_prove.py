import argparse
import logging


def main(date):
    '''
    Функция проверяет даты
    '''
    FORMAT = '{levelname:<8} - {asctime}. В модуле "{name}" ' \
        'в строке {lineno:03d} функция "{funcName}()" ' \
        'в {created} секунд записала сообщение: {msg}'

    logging.basicConfig(format=FORMAT, filename='project.log.',
                        encoding='utf-8', level=logging.NOTSET, style='{')
    logger = logging.getLogger('main')

    day, month, year = map(int, date.split('.'))
    if year <= 0:
        prove = "False"
    elif month in [4, 6, 9, 11] and 0 < day <= 30:
        prove = "True"
    elif month in [1, 3, 5, 7, 8, 10, 12] and 0 < day <= 31:
        prove = "True"
    elif month == 2 and 0 < day <= 29 and year % 4 == 0:
        prove = "True"
    elif month == 2 and 0 < day <= 28 and year % 4 != 0:
        prove = "True"
    else:
        prove = "False"
    logger.warning(date + ' - ' + prove)
    return prove


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description='Проверка даты')
    parser.add_argument('param', metavar='date', type=str,
                        nargs=1, help='enter date')
    args = parser.parse_args()
    print(main(*args.param))
