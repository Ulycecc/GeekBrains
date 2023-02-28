// Задача 66: 
// Задайте значения M и N. 
// Напишите программу, 
// которая найдёт сумму натуральных элементов в промежутке от M до N.
// M = 1; N = 15 -> 120
// M = 4; N = 8. -> 30

int Prompt(string message)
{
    Console.WriteLine(message);
    int result = int.Parse(Console.ReadLine()!);
    return result;
}
int SumNut(int N, int M)
{
    if(N==M) return N;
    else return SumNut(N+1, M) + N;
}
int N = Prompt("Введите число N");
int M = Prompt("Введите число M");

Console.WriteLine(SumNut(N, M));
