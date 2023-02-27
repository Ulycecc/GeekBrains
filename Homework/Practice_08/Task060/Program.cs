// Задача 60
// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, 
// добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(0,1,0) 41(0,1,1)
// 27(1,0,0) 90(1,0,1)
// 26(1,1,0) 55(1,1,1)

int Prompt(string message)
{
    Console.WriteLine(message);
    int result = int.Parse(Console.ReadLine()!);
    return result;
}

int[,,] GenerateArray(int Length, int Width, int Height)
// Функция создает трехмерный массив c неповторяющимися элементами
{
    int [,,] array = new int[Length, Width, Height];
    int [] compare = new int[Length*Width*Height];
    int m = 0;
    Random random = new Random();
    for (int i = 0; i < Length; i++)
    {
        for(int j = 0; j < Width; j++)
        {
            for(int k=0; k < Height; k++)
            {
                while(array[i, j, k]==0)
                {
                    int rnd = random.Next(1,99);
                    if (Array.IndexOf(compare, rnd) == -1)
                    {
                        array[i, j, k] = rnd;
                        compare[m] = rnd;
                        m += 1;
                    }
                }
            }
        }
    }
    return array;
}
void PrtArr(int [,,] arr)
// Функция выводит двумерный массив на печать
{
    for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                    Console.Write($"{arr[i, j, k]:D2}({i},{j},{k}) ");

                    }
                    Console.WriteLine();
                }
    
            }
    Console.WriteLine();
}
int Length = Prompt("Введите длину массива");
int Width = Prompt("Введите ширину массива");
int Height = Prompt("Введите высоту массива");
int [,,] arr = GenerateArray(Length, Width, Height);

PrtArr(arr);
