# Generated by Django 5.0.4 on 2024-05-02 15:40

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('myapp', '0001_initial'),
    ]

    operations = [
        migrations.AlterField(
            model_name='order',
            name='date',
            field=models.DateField(),
        ),
        migrations.AlterField(
            model_name='product',
            name='date',
            field=models.DateField(),
        ),
    ]
