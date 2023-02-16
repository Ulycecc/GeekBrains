// Задача 38:
// Задайте массив вещественных чисел.
// Найдите разницу между максимальным и минимальным элементов массива.

// [3 7 22 2 78] -> 76
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

double[] GenerateArray(int Length, double minValue, double maxValue)
{
    double[] array = new double[Length];
    Random random = new Random();
    for (int i = 0; i < Length; i++)
    {
        array[i] = maxValue - (maxValue - minValue)*random.NextDouble();
    }
    return array;
}

int length = Prompt("Введите колличество элементов массива:");
double min = Prompt_double("Введите минимально возможное значение для элементов массива");
double max = Prompt_double("Введите максимально возможное значение для элементов массива");
double[] array = GenerateArray(length, min, max);

double maxValue = array.Max();
double minValue = array.Min();

Console.WriteLine();
Console.WriteLine("[{0}]", string.Join(", ", array));
Console.WriteLine(maxValue-minValue);