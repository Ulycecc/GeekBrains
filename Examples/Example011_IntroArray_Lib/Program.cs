void ArrayFill(int[] collection)
{
    int n = collection.Length;
    int index = 0;
    while(index < n)
    {
        collection[index] = new Random().Next(1,10);
        index++;
    }
}
void ArrayPrint(int[] collection)
{
    int n = collection.Length;
    int index = 0;
    while(index < n)
    {
        Console.Write(collection[index]);
        Console.Write(' ');
        index++;
    }
}
int IndexOf(int[] collection, int find)
{
    int n = collection.Length;
    int index = 0;
    int posion = -1;
    while(index < n)
    {
        if (collection[index] == find)
        {
          posion = index;
          break;
        }
        index++;
    }
    return posion;
}

int[] array = new int[10];

ArrayFill(array);
ArrayPrint(array);
Console.WriteLine(' ');
Console.WriteLine(IndexOf(array, 7));