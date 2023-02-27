// Задача 58: 
// Задайте две матрицы. 
// Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int Prompt(string message)
{
    Console.WriteLine(message);
    int result = int.Parse(Console.ReadLine()!);
    return result;
}

int[,] GenerateArray(int Length, int Width)
// Функция заполняет двумерный массив
{
    int [,] array = new int[Length, Width];
    for (int i = 0; i < Length; i++)
    {
        Console.WriteLine($"Введите значения строки {i}:");
        for(int j = 0; j < Width; j++)
        {
            array[i, j] = int.Parse(Console.ReadLine()!);
        }
    }
    return array;
}
int[,] ProductArr(int [,] arr1, int [,] arr2)
// Функция заполняет двумерный массив
{
    int n1 = arr1.GetLength(0);
    int m1 = arr1.GetLength(1);
    int n2 = arr2.GetLength(0);
    int m2 = arr2.GetLength(1);

    int [,] array = new int[n1, m2];
    for (int i = 0; i < n1; i++)
    {
        for (int j = 0; j < m2; j++)
        {
            for (int k = 0; k < n1; k++)
            {
                array[i,j] += arr1[i,k]*arr2[k,j];
            }
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
                    Console.Write("{0,3} ", arr[i, j]);
                }
                Console.WriteLine();
            }
}
int n1 = Prompt("Введите количество строк первой матрицы");
int m1 = Prompt("Введите количество строк первой матрицы");
int n2 = Prompt("Введите количество строк второй матрицы");
int m2 = Prompt("Введите количество строк второй матрицы");
if(m1 != n2){Console.WriteLine("Такие матрицы перемножить нельзя");}
else 
{
    int [,] arr1 = GenerateArray(n1, m1);
    PrtArr(arr1);
    int [,] arr2 = GenerateArray(n2, m2);
    PrtArr(arr2);
    Console.WriteLine();
    int [,] Product = ProductArr(arr1, arr2);
    PrtArr(Product);
}