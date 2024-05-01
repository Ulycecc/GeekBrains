from django.db import models


class Сonsumer(models.Model):
    name = models.CharField(max_length=100)
    email = models.EmailField()
    phone_number = models.CharField(max_length=10)
    address = models.CharField(max_length=100)
    date = models.DateField(auto_now_add=True)

    def __str__(self):
        return f'Name: {self.name}, email: {self.email}, phone_number: {self.phone_number},  address: {self.address}'


class Product(models.Model):
    name = models.CharField(max_length=100)
    description = models.TextField()
    price = models.DecimalField(max_digits=10, decimal_places=2)
    quantity = models.IntegerField(max_length=5)
    date = models.DateField(auto_now=True)

    def __str__(self):
        return f'Name: {self.name}, description: {self.description}, price: {self.price},  quantity: {self.quantity}'


class Order(models.Model):
    consumer = models.ForeignKey(Сonsumer, on_delete=models.CASCADE)
    product = models.ForeignKey(Product, on_delete=models.CASCADE)
    amount = models.DecimalField(max_digits=10, decimal_places=2)
    date = models.DateField()

    def __str__(self):
        return f'Name: {self.consumer}, product: {self.product}, amount: {self.amount},  date: {self.date}'
