// Задача 29:
// Напишите программу, которая задаёт массив из 8 элементов
// и выводит их на экран.

// 1, 2, 5, 7, 19 -> [1, 2, 5, 7, 19]

// 6, 1, 33 -> [6, 1, 33]

int Prompt(string message)
{
    Console.WriteLine(message);
    int result = int.Parse(Console.ReadLine()!);
    return result;
}

int[] GenerateArray(int Length, int minValue, int maxValue)
{
    int[] array = new int[Length];
    Random random = new Random();
    for (int i = 0; i < Length; i++)
    {
        array[i] = random.Next(minValue, maxValue + 1);
    }
    return array;
}

int length = Prompt("Введите колличество элементов массива:");
int min = Prompt("Введите минимально возможное значение для элементов массива");
int max = Prompt("Введите максимально возможное значение для элементов массива");
int[] array = GenerateArray(length, min, max);
Console.WriteLine();

Console.WriteLine("[{0}]", string.Join(", ", array));