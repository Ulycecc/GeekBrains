// Задача 21
// Напишите программу,
// которая принимает на вход координаты двух точек
// и находит расстояние между ними в 3D пространстве.

// A (3,6,8); B (2,1,-7), -> 15.84
// A (7,-5, 0); B (1,-1,9) -> 11.53

double[] InpArray()
{
    double[] a = new double[3];
    for (int i = 0; i < 3; i++)
      {
         Console.Write("a[{0}]=", i);
         a[i] = Convert.ToDouble(Console.ReadLine());
      }
      return a;
}

double Distance (double[] Point1, double[] Point2)
{
    double dist = 0;
    for (int i = 0; i < 3; i++)
        {
            dist += Math.Pow((Point1[i]-Point2[i]), 2);
        }
    dist = Math.Sqrt(dist);
    return Math.Round(dist,2);
}

Console.WriteLine("Введите координаты первой точки");
double[] Point1 = InpArray();

Console.WriteLine("Введите координаты второй точки");
double[] Point2 = InpArray();


Console.Write("Расстояние: ");
Console.WriteLine(Distance(Point1, Point2));