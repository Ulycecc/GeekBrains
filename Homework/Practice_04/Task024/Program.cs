// Задача 25:
// Напишите цикл, который принимает на вход два числа (A и B)
// и возводит число A в натуральную степень B.

// 3, 5 -> 243 (3⁵)
// 2, 4 -> 16

int Prompt(string message)
{
    Console.WriteLine(message);
    int result = int.Parse(Console.ReadLine()!);
    return result;
}
int Power(int foundation, int indicator)
{
    int power = 1;
    for (int i = 0; i < indicator; i++)
    {
        power *= foundation;
    }
    return power;
}

int foundation = Prompt("Введите основание степени:");
int indicator = Prompt("Введите показатель степени");
if (indicator < 0)
{
    Console.WriteLine("Показатель должен быть натуральным числом");
}
else
{
    Console.WriteLine($"{foundation} в степени {indicator} -> {Power(foundation, indicator)}");
}