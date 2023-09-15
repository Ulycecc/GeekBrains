// Загружаем библиотеки
using System;
using System.Collections;

// Инициализируем массив
string[] Verifay = { "hello", "2", "word", ":-)" };

int Length = Verifay.Length;
int j = 0;

// Преобразуем масситв в список
var tmp = Verifay.ToList();

// Удаляем элементы, длина которых больше 3. 
for (int i = 0; i < Length; i++)
{
    if (tmp[j].Length > 3) { tmp.RemoveAt(j); }
    else { j++; }
}

// Выводим на печать
Console.WriteLine(String.Join(",", tmp));
