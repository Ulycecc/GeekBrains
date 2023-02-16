// Задача 34:
// Задайте массив заполненный
// случайными положительными трёхзначными числами.
// Напишите программу, которая покажет количество чётных чисел в массиве.

// [345, 897, 568, 234] -> 2
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
int min = 100;
int max = 999;
int[] array = GenerateArray(length, min, max);
int cnt = 0;
for (int i = 0; i < length; i++)
{
    if (array[i]%2==0){cnt++;}
}
Console.WriteLine(cnt);