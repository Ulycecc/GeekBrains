// Задача 10:
// Напишите программу,
// которая принимает на вход трёхзначное число
// и на выходе показывает вторую цифру этого числа.

// 456 -> 5
// 782 -> 8
// 918 -> 1
Console.Clear();
string intr = "Введите трехзначное число:";
Console.WriteLine(intr);
int num = Convert.ToInt32(Console.ReadLine());
if(num >999)
{
string intr1 = "Попробуйте снова. Введите трехзначное число:";
Console.WriteLine(intr1);
num = Convert.ToInt32(Console.ReadLine());    
}
int result = (num / 10 % 10);
Console.WriteLine($"{num} -> {result}");;