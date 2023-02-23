// Задача 47.
// Задайте двумерный массив размером m×n,
// заполненный случайными вещественными числами.

// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

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

void WriteTDArray(double [,] array)
// Функция выводит двумерный массив на печать
{
for ( int i = 0; i < array.GetLength(0); i++ )
{
    for ( int j = 0; j < array.GetLength(1); j++ )
    {
        Console.Write("{0}\t", array[i, j]);
    }
    Console.WriteLine();
}
}

int length = Prompt("Введите колличество строк массива:");
int width = Prompt("Введите колличество столбцов массива:");
double min = Prompt_double("Введите минимально возможное значение для элементов массива");
double max = Prompt_double("Введите максимально возможное значение для элементов массива");
double[,] array = GenerateArray(length, width, min, max);

Console.WriteLine();
WriteTDArray(array);
