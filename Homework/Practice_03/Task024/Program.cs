// Задача 23
// Напишите программу,
// которая принимает на вход число (N) и
// выдаёт таблицу кубов чисел от 1 до N.

// 3 -> 1, 8, 27
// 5 -> 1, 8, 27, 64, 125

Console.WriteLine("Ввведите натуральное число:");
int N = Convert.ToInt32(Console.ReadLine());
Console.Write($"{N} -> 1");

int i = 2;
while(i <= N)
{
    Console.Write($", {Math.Pow(i,3)}");
    i++;
}