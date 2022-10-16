/* Программа задаёт одномерный массив, заполненный случайными числами и находит сумму элементов, стоящих на нечётных позициях.
[3, 7, 23, 12] -> 19
[-4, -6, 89, 6] -> 0
*/

Console.Clear();

int sizeOfArray = GetSizeOfArray("Введите размер одномерного массива: ", "Ошибка ввода!");
Console.WriteLine($"Размер массива: {sizeOfArray}");

label1:
int minOfRange = GetRangeOfArray("\nВведите минимальное значение диапазона массива: ", "Ошибка ввода!");
Console.WriteLine($"Нижняя граница диапазона массива: {minOfRange}");

int maxOfRange = GetRangeOfArray("\nВведите максимальное значение диапазона массива: ", "Ошибка ввода!");
Console.WriteLine($"Верхняя граница диапазона массива: {maxOfRange}");

if (maxOfRange <= minOfRange) //Проверяем корректность ввода границ диапазона массива
{
    Console.Clear();
    Console.WriteLine("Ошибка ввода!");
    goto label1;    //Очень не популярный оператор "goto" :(
}

int[] arr = GetArrayRandom(sizeOfArray, minOfRange, maxOfRange);

int summOddPos = SummOfElemInOddPositions(sizeOfArray, arr);

PrintResult(arr, summOddPos);

//-----------------------------------Functions-------------------------------------
static int GetSizeOfArray(string message, string messageError)
{
    while (true)
    {
        Console.Write(message);
        bool isTrue = int.TryParse(Console.ReadLine() ?? "", out int sizeOfArray) && sizeOfArray > 0;
        if (isTrue)
        {
            //Console.WriteLine($"Размер массива: {sizeOfArray}");
            return sizeOfArray;
        }
        Console.WriteLine(messageError);
    }
}

//----------------------------------------------------------------------------------
static int GetRangeOfArray(string message, string messageError)
{
    while (true)
    {
        Console.Write(message);
        bool isTrue = int.TryParse(Console.ReadLine() ?? "", out int rangeOfArray);
        if (isTrue)
        {
            return rangeOfArray;
        }
        Console.WriteLine(messageError);
    }
}

//----------------------------------------------------------------------------------
static int[] GetArrayRandom(int N, int minOfRange, int maxOfRange)
{
    int[] arr = new int[N];
    for (int i = 0; i < N; i++)
    {
        arr[i] = new Random().Next(minOfRange, maxOfRange + 1);
    }
    return arr;
}

//----------------------------------------------------------------------------------
int SummOfElemInOddPositions(int N, int[] arr)
{
    int summOddPos = 0;
    for (int i = 1; i <= N; i = i + 2)
    {
        summOddPos += arr[i];
    }
    return summOddPos;
}

//----------------------------------------------------------------------------------
static void PrintResult(int[] arr, int summOddPos)
{
    Console.Clear();
    Console.WriteLine($"[{String.Join(", ", arr)}] -> {summOddPos}");
}
