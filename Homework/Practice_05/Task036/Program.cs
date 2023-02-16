// Задача 36: 
// Задайте одномерный массив, заполненный случайными числами.
// Найдите сумму элементов, стоящих на нечётных позициях.

// [3, 7, 23, 12] -> 19
// [-4, -6, 89, 6] -> 0
int Prompt(string message)
{
    Console.WriteLine(message);
    int result = int.Parse(Console.ReadLine()!);
    return result;
}

int[] GenerateArray(int Length, int minValue, int maxValue)
{
    int[] array = new int[Length];
    Random random = new Random();
    for (int i = 0; i < Length; i++)
    {
        array[i] = random.Next(minValue, maxValue + 1);
    }
    return array;
}

int length = Prompt("Введите колличество элементов массива:");
int min = Prompt("Введите минимально возможное значение для элементов массива");
int max = Prompt("Введите максимально возможное значение для элементов массива");
int[] array = GenerateArray(length, min, max);
int sum = 0;
for(int i=1; i < length; i+=2)
{
    sum += array[i];
}
Console.WriteLine();
Console.WriteLine("[{0}]", string.Join(", ", array));
Console.WriteLine(sum);
