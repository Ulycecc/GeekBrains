int[] array = {1,2,3,4,5,6,8,9};
int n = array.Length;
int find = 6;
int index = -1;
while(index < n)
{
    if(index == find)
    {
        Console.Write(array[index]);
        break;
    }
    index++;
}