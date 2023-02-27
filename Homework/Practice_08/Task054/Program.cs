// Задача 54:
// Задайте двумерный массив. Напишите программу,
// которая упорядочит по возрастанию элементы
// каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

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
void SrtArr(int [,] arr)
//Функция сортирует строки
{
    int n = arr.GetLength(0);
    int m = arr.GetLength(1);
    int rev = 0;
    for(int i = 0; i < n; i++)
    {
        int cnt = 1;
        while (cnt != 0)
        {
            cnt = 0;
            for(int j = 0; j < m-1; j++)
            {
                if(arr[i,j] < arr[i,j+1])
                {
                    rev = arr[i,j];
                    arr[i,j] = arr[i,j+1];
                    arr[i,j+1] = rev;
                    cnt++;
                }
            }
        }
    }
}

int length = Prompt("Введите колличество строк массива:");
int width = Prompt("Введите колличество столбцов массива:");
int[,] arr = GenerateArray(length, width);

Console.WriteLine("Исходный массив");
PrtArr(arr);
SrtArr(arr);
Console.WriteLine("Отслртированный массив");
PrtArr(arr);