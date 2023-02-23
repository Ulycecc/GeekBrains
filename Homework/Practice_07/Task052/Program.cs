// Задача 52.
// Задайте двумерный массив из целых чисел.
// Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
int Prompt(string message)
{
    Console.WriteLine(message);
    int result = int.Parse(Console.ReadLine()!);
    return result;
}


int[,] GenerateArray(int Length, int Width, int minValue, int maxValue)
// Функция создает двумерный массив
{
    int [,] array = new int[Length, Width];
    Random random = new Random();
    for (int i = 0; i < Length; i++)
    {
        for(int j = 0; j < Width; j++)
        {
            array[i, j] = maxValue - (maxValue - minValue)*random.Next();
        }
    }
    return array;
}

int length = Prompt("Введите колличество строк массива:");
int width = Prompt("Введите колличество столбцов массива:");
int min = Prompt("Введите минимально возможное значение для элементов массива");
int max = Prompt("Введите максимально возможное значение для элементов массива");
int[,] array = GenerateArray(length, width, min, max);

double[] mean = new double[width];
for(int i = 0; i<width; i++)
{
    int sum = 0;
    for(int j = 0; j < length; j++)
    {
        sum += array[j,i];
    }
    mean[i] = Convert.ToDouble(sum)/Convert.ToDouble(length);
}
Console.WriteLine();
Console.WriteLine("[{0}]", string.Join(", ", mean));