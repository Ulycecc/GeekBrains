// Задача 15:
// Напишите программу, которая принимает на вход цифру,
// обозначающую день недели,
// и проверяет, является ли этот день выходным.

// 6 -> да
// 7 -> да
// 1 -> нет
Console.Clear();

string[] WeekDay = {"нет","нет","нет","нет","нет","да","да"};
string intr = "Введите день недели от 0 до 7:";
Console.WriteLine(intr);

int num = Convert.ToInt32(Console.ReadLine());

if((1 <= num) & (num <= 7))
{
Console.Write($"{num} -> ");
Console.WriteLine(WeekDay[num-1]);   
}