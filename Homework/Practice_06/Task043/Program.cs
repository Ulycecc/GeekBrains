// Задача 43:
// Напишите программу,
// которая найдёт точку пересечения двух прямых,
// заданных уравнениями y = k1 * x + b1, y = k2 * x + b2;
// значения b1, k1, b2 и k2 задаются пользователем.

// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)

double Prompt(string message)
{
    System.Console.Write(message); //вывести сообщение
    string value = Console.ReadLine()!;//считать с консоли строку
    double result = Convert.ToDouble(value);//преобразует строку в целое
    return result;// возвращает результат

}

double Determinant(double a, double b, double c , double d)
{
    return a*d - b*c;
}
double k1 = -Prompt("Введите коэффициент при x для первой линии");
double k2 = -Prompt("Введите коэффициент при x для второй линии");
double b1 = Prompt("Введите свободный член для первой линии");
double b2 = Prompt("Введите свободный член для второй линии");
if (k1==k2)
{
    if(b1==b2){Console.WriteLine("Линии совпадают");}
    else {Console.WriteLine("Линии параллельны");}
}
else
{
    Console.WriteLine($"y = {Determinant(b1,b2,k1,k2)/Determinant(1,1,k1,k2)}");
    Console.WriteLine($"x = {Determinant(1,1,b1,b2)/Determinant(1,1,k1,k2)}");
}