// Программа заполняет массив случайными положительными трёхзначными числами и показывает количество чётных чисел в массиве.
//[345, 897, 568, 234] -> 2

Console.Clear();

int N = GetSizeOfArray("Введите размер одномерного массива: ", "Ошибка ввода!");   //Пользовательский ввод размера массива

int[] arr = GetArray(N);    //Формируем массива

int numEvenNumbers = GetNumEvenNumbers(arr);    //Вычисляем количество четных элементов массива

PrintResult(arr, numEvenNumbers);    //Выводим в консоль результатов работы программы

//-----------------------------Functions------------------------------------
static int GetSizeOfArray(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        bool isTrue = int.TryParse(Console.ReadLine() ?? "", out int sizeArray) && sizeArray > 0;
        if (isTrue)
            return sizeArray;
        Console.WriteLine(errorMessage);
    }
}

//-------------------------------------------------------------------------
static int[] GetArray(int N)
{
    int[] arr = new int[N];
    for (int i = 0; i < N; i++)
    {
        arr[i] = new Random().Next(100, 1000);
    }
    return arr;
}

//-------------------------------------------------------------------------
static int GetNumEvenNumbers(int[] arr)
{
    int  numEvenNumbers = 0;
    foreach(int el in arr)
    {
        if((el % 2 ) == 0)
            numEvenNumbers += 1;
    }
    return numEvenNumbers;
}

//----------------------------------------------------------------------
static void PrintResult(int[] arr, int numEvenNumbers) => Console.WriteLine($"[{String.Join(", ",arr)}] -> {numEvenNumbers}");