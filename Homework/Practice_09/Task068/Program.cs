// Задача 68: 
// Напишите программу вычисления функции Аккермана с помощью рекурсии. 
// Даны два неотрицательных числа m и n.
// m = 2, n = 3 -> A(m,n) = 9
// m = 3, n = 2 -> A(m,n) = 29

int AckermannFunctions(int N, int M)
{
    if (N==0) return M + 1;
    else if (M==0) return AckermannFunctions(N-1, 1);
    else return AckermannFunctions(N-1, AckermannFunctions(N, M-1));
}

Console.WriteLine($"A(2,3) = {AckermannFunctions(2, 3)}");
Console.WriteLine($"A(3,2) = {AckermannFunctions(3, 2)}");