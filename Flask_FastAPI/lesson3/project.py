from flask import Flask, render_template, request
from flask_wtf.csrf import CSRFProtect
from models import db, User, RegistrationForm
import bcrypt

app = Flask(__name__)
app.config['SECRET_KEY'] = 'mysecretkey'
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///mydatabase.db'
csrf = CSRFProtect(app)
db.init_app(app)


@app.cli.command("init-db")
def init_db():
    db.create_all()
    print('OK')


@app.route('/register/', methods=['GET', 'POST'])
def register():
    form = RegistrationForm()
    if request.method == 'POST' and form.validate():
        # Обработка данных из формы
        name = form.name.data
        surname = form.surname.data
        email = form.email.data
        password = form.password.data
        # convert password to array of bytes
        bytes = password.encode()

        # Generate a salt and hash the password
        salt = bcrypt.gensalt()
        hashed_password = bcrypt.hashpw(bytes, salt)

        new_user = User(name=name, surname=surname,
                        email=email, password=hashed_password)
        db.session.add(new_user)
        db.session.commit()

    return render_template('register.html', form=form)


@app.route('/users/')
def all_users():
    users = User.query.all()
    context = {'users': users}
    return render_template('users.html', **context)


if __name__ == '__main__':
    app.run(debug=True)
