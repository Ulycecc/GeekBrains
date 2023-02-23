// Задача 50.
// Напишите программу, которая на вход принимает
// позиции элемента в двумерном массиве,
// и возвращает значение этого элемента
// или же указание, что такого элемента нет.

// Например, задан массив:

// 1 4 7 2

// 5 9 2 3

// 8 4 2 4

// 17 -> такого числа в массиве нет
int Prompt(string message)
{
    Console.WriteLine(message);
    int result = int.Parse(Console.ReadLine()!);
    return result;
}

double Prompt_double(string message)
{
    Console.WriteLine(message);
    double result = double.Parse(Console.ReadLine()!);
    return result;
}

double[,] GenerateArray(int Length, int Width, double minValue, double maxValue)
// Функция создает двумерный массив
{
    double[,] array = new double[Length, Width];
    Random random = new Random();
    for (int i = 0; i < Length; i++)
    {
        for(int j = 0; j < Width; j++)
        {
            array[i, j] = maxValue - (maxValue - minValue)*random.NextDouble();
        }
    }
    return array;
}

int length = Prompt("Введите колличество строк массива:");
int width = Prompt("Введите колличество столбцов массива:");
double min = Prompt_double("Введите минимально возможное значение для элементов массива");
double max = Prompt_double("Введите максимально возможное значение для элементов массива");
double[,] array = GenerateArray(length, width, min, max);

int n = Prompt("Введите Первый индекс элемента массива:");
int m = Prompt("Введите Второй индекс элемента массива:");

if ((n>0)&(n<length)&(m>0)&(m<width))
{
    Console.WriteLine(array[n,m]);
}
else
{
    Console.WriteLine("Нам очень жаль, но такого элемента массива нет.");
}