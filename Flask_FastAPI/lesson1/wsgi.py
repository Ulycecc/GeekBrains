from flask import Flask, render_template

app = Flask(__name__)


@app.route('/')
def index():
    return render_template('index.html')


@app.route('/shoes/')
def shoes():
    _shoes = [
        {
            "name": "boots1",
            "price": 'price1',
            "description": 'description1',
        },
        {
            "name": "boots2",
            "price": 'price2',
            "description": 'description2',
        },
    ]
    return render_template('shoes.html', content=_shoes)


@app.route('/clothes/')
def clothes():
    _clothes = [
        {
            "name": "clothes1",
            "price": 'price1',
            "description": 'description1',
        },
        {
            "name": "clothes2",
            "price": 'price2',
            "description": 'description2',
        },
    ]
    return render_template('clothes.html', content=_clothes)


if __name__ == '__main__':
    app.run(debug=True)
