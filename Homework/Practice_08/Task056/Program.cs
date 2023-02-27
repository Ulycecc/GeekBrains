// Задача 56: 
// Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:

// 1 4 7 2

// 5 9 2 3

// 8 4 2 4

// 5 2 6 7

// Программа считает сумму элементов в каждой строке и
// выдаёт номер строки с наименьшей суммой элементов: 1 строка

int Prompt(string message)
{
    Console.WriteLine(message);
    int result = int.Parse(Console.ReadLine()!);
    return result;
}


int[,] GenerateArray(int Length, int Width)
// Функция создает двумерный массив
{
    int [,] array = new int[Length, Width];
    Random random = new Random();
    for (int i = 0; i < Length; i++)
    {
        for(int j = 0; j < Width; j++)
        {
            array[i, j] = random.Next(0,99);
        }
    }
    return array;
}
void PrtArr(int [,] arr)
// Функция выводит двумерный массив на печать
{
    for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0:D2} ", arr[i, j]);
                }
                Console.WriteLine();
            }
}
int Length = Prompt("Введите колличество строк массива:");
int Width = Prompt("Введите колличество столбцов массива:");
int[,] arr = GenerateArray(Length, Width);

Console.WriteLine("Исходный массив");
PrtArr(arr);
Console.WriteLine();

int ind = 0;
int maxsum = 0;
int sum;
for (int i = 0; i < Length; i++)
    {
        sum = 0;
        for(int j = 0; j < Width; j++)
        {
            sum += arr[i, j];
        }
        if(sum > maxsum)
        {
            maxsum = sum;
            ind = i;
        }
    }
Console.WriteLine($"Максимальная сумма элементов в строке {ind}");