from django.shortcuts import render
import datetime

from django.shortcuts import render, get_object_or_404
from .models import Сonsumer, Order


def product_week(request, consumer_id):
    consumer = get_object_or_404(Сonsumer, pk=consumer_id)
    orders = Order.objects.filter(consumer=consumer).order_by(
        '-date').filter(date__gte=datetime.datetime.today() - datetime.timedelta(days=7))
    return render(request, 'myapp/product_week.html', {'consumer':
                                                       consumer, 'orders': orders, 'days': 7})


def product_month(request, consumer_id):
    consumer = get_object_or_404(Сonsumer, pk=consumer_id)
    orders = Order.objects.filter(consumer=consumer).order_by(
        '-date').filter(date__gte=datetime.datetime.today() - datetime.timedelta(days=30))
    return render(request, 'myapp/product_week.html', {'consumer':
                                                       consumer, 'orders': orders, 'days': 30})


def product_year(request, consumer_id):
    consumer = get_object_or_404(Сonsumer, pk=consumer_id)
    orders = Order.objects.filter(consumer=consumer).order_by(
        '-date').filter(date__gte=datetime.datetime.today() - datetime.timedelta(days=365))
    return render(request, 'myapp/product_week.html', {'consumer':
                                                       consumer, 'orders': orders, 'days': 365})
