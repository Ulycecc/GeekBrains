// Задача 62.
// Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07
int Contour(int [,] arr, int N, int itr, int Nmax)
// Функция заполняет последовательными числами контур любого двумерного массива
{
    int n = arr.GetLength(0) - itr;
    int m = arr.GetLength(1) - itr;
    
    for(int j = itr; j < m; j++){N++;arr[itr,j]=N;}
    if(N==Nmax){return N;}
    for(int i = itr+1; i < n; i++){N++;arr[i,m-1]=N;}
    if(N==Nmax){return N;}
    for(int j = m-2; j > itr; j--){N++;arr[(n-1),j]=N;}
    for(int i = n-1; i > itr; i--){N++;arr[i,itr]=N;}
    return N;
}
void PrtArr(int [,] arr)
// Функция выводит двумерный массив на печать
{
    for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0:D2} ", arr[i, j]);
                }
                Console.WriteLine();
            }
}

int[ , ] arr = new int [4, 4];
int itr = 0;
int N = 0;
int Nmax = arr.GetLength(0)*arr.GetLength(1);
while (N < Nmax)
{
    N = Contour(arr,N,itr, Nmax);
    itr++;
}
PrtArr(arr);
