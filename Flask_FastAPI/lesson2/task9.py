'''
Задание №9
Создать страницу, на которой будет форма для ввода имени
и электронной почты
При отправке которой будет создан cookie файл с данными
пользователя
Также будет произведено перенаправление на страницу
приветствия, где будет отображаться имя пользователя.
На странице приветствия должна быть кнопка "Выйти"
При нажатии на кнопку будет удален cookie файл с данными
пользователя и произведено перенаправление на страницу
ввода имени и электронной почты.
'''
from flask import request, make_response
from flask import Flask, render_template
import secrets

app = Flask(__name__)
app.secret_key = secrets.token_hex()


@app.route('/', methods=['GET', 'POST'])
def login():
    if request.method == 'POST':
        response = make_response(render_template('login.html'))
        response.set_cookie('name', '', expires=0)
        response.set_cookie('email', '', expires=0)
        return response
    return render_template('login.html')


@app.route('/logout', methods=['GET', 'POST'])
def logout():
    if request.method == 'POST':
        name = request.form.get('name')
        email = request.form.get('email')
        response = make_response(render_template('logout.html', name=name))
        response.set_cookie('name', name)
        response.set_cookie('email', email)
    return response


if __name__ == "__main__":
    app.run(debug=True)
