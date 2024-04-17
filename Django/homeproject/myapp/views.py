from django.shortcuts import render
from django.http import HttpResponse


def index(request):
    return HttpResponse('''<div style="white-space:pre">
Hello,
World
</div>''')


def about(request):
    return HttpResponse('''<div style="white-space:pre">
Немного
о
нас
</div>''')
