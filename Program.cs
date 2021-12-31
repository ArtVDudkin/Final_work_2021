﻿// **Задача**: Написать программу, которая из имеющегося массива целых чисел формирует массив из четных чисел. 
// Первоначальный массив можно ввести с клавиатуры, либо сгенерировать случайным образом. 
// При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

string ChooseInput(int value1, int value2)
{
    string optionInput = string.Empty;
    while ( (optionInput != $"{value1}") && (optionInput != $"{value2}") )
    {
        Console.Clear();
        Console.WriteLine("Для ввода массива с клавиатуры введите 1, для заполнения массива случайными числами введите 2");
        optionInput = Console.ReadLine();
    }
    return optionInput;
}

// метод для создания массива
int[] CreateArray(int count)
{
    return new int[count];                      // размерности 2 x col, по умолчанию заполнен нулями
}

// метод для получения чисел путем ввода с клавиатуры, либо путем генерации случайных чисел
string GetNumbers(string optionInput)     
{
    string result = string.Empty;
    if (optionInput == "1")                                       // если выбран вариант заполнения путем ввода с клавиатуры
    {
        Console.Clear();
        Console.WriteLine("Веедите целые числа в одну строку через запятую");
        string inputText = Console.ReadLine();
        result = TextFormatter(inputText);                      // форматируем введенную строку
    }
    else                                                        // если выбран вариант заполнения случайными числами
    {
        int size = new Random().Next(3, 10);                    // задаем размерность массива случайным образом от 3 до 10 элементов
        int[] arr = CreateArray(size);
        int minValue = -10;
        int maxValue = 10;
        for (int i = 0; i < size; i++)
        {
            result += $"{new Random().Next(minValue, maxValue +1)},";
        }
    }
    return result;
}

// метод для форматирования введенный строки с числами
string TextFormatter(string text)                   
{
    string result = String.Empty;
    int length = text.Length;
    for (int i = 0; i < length; i++)
    {   // исключаем все другие символы, кроме ',-0123456789'      // 44 = ','    45 = '-'     48-57 = '0..9'
        if ( ((char)text[i] >= 44) && ((char)text[i] <= 57) && ((char)text[i] != 46) && ((char)text[i] != 47) )
            result += text[i];      
    }
    text = result;
    length = text.Length; 
    result = string.Empty;
    for (int i = 0; i < length; i++)
    {   // удаляем повторяющиеся запятые и минусы
        if ( (i != (length -1)) && (text[i] == '-') && (text[i +1] == '-') ) result += $"";
        else if ( (i != (length -1)) && (text[i] == ',') && (text[i +1] == ',') ) result += $"";
        else result += $"{text[i]}";
    }
    text = result;
    length = text.Length; 
    result = string.Empty;
    for (int i = 0; i < length; i++)
    {   // если минус стоит после числа, то удаляем его
        if ( (i != 0) && (text[i] == '-') && ((char)text[i -1] >= 48) && ((char)text[i -1] <= 57 ) ) result += $"";
        else result += $"{text[i]}";
    }
    if ( (result == "") || (result == "-") || (result == ",") ) return $"";
    else
    {
        // удаляем лишние минусы и запятые в конце строки
        length = result.Length;
        int count = 0;
        for (int i = length -1; i >= 0; i--)
            if ( (result[i] == ',') || (result[i] == '-') )
                count++;
            else break;
        result = result.Substring(0, length - count);
        if (result[0] == ',')                     
        {   // если строка начинается с запятой, то удаляем ее
            result = result.Substring(1);
        }
        length = result.Length;
        if (result[length -1] != ',')                     
        {   // если в конце строки нет запятой, то добавляем ее для работы метода NumbersReader()
            result += ",";
        }
        return result;
    }
}

// метод для определения количества чисел в отформатированной строке (числа разделяются запятой)
int ElementsCounter(string inputText)                     
{
    int counter = 0;
    for (int i = 0; i < inputText.Length; i++)
    {
        if (inputText[i] == ',') counter++;
    }
    return counter;
}

// метод для получения массива целых чисел из введенной строки
int[] NumbersReader(string text)                 
{
    int counter = ElementsCounter(text);
    int[] result = CreateArray(counter);
    for (int i = 0; i < counter; i++)   
    {
        int posComma = 0;
        string temp = string.Empty;
        while (text[posComma] != ',' )
            posComma++;
        temp = text.Substring(0, posComma);
        result[i] = Convert.ToInt32(temp);
        text = text.Substring(posComma +1);
    }
    return result;
}

// метод для определения количества четных чисел в исходном массиве
int EvenCounter(int[] arr)                     
{
    int counter = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] % 2 == 0) counter++;
    }
    return counter;
}

// метод для нахождения четных элементов в исходном массиве
int[] GetEvenNumbers(int[] arr)                              
{
    int count = arr.Length;
    int j = 0;
    int[] result = CreateArray(EvenCounter(arr));
    for (int i = 0; i < count; i++)
    {
        if(arr[i] % 2 == 0)
        {
            result[j] = arr[i];
            j++;
        }
    }
    return result;
}

Console.Clear();
string optionInput = ChooseInput(1,2);
string inputText = GetNumbers(optionInput);
int size = ElementsCounter(inputText);      // определяем размер исходного массива чисел
int[] allNumbers = CreateArray(size);       // создаем исходный массив чисел
allNumbers = NumbersReader(inputText);      // заполняем исходный массив чисел
size = EvenCounter(allNumbers);             // определяем размер итогового массива по количеству четных чисел в нем
int[] evenNumbers = CreateArray(size);      // создаем массив для хранения четных чисел
evenNumbers = GetEvenNumbers(allNumbers);   // сортируем исходный массив и добавляем в итоговый массив четные числа 