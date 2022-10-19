/* Программа задаёт одномерный массив, заполненный случайными числами и находит сумму элементов, стоящих на нечётных позициях.
[3, 7, 23, 12] -> 19
[-4, -6, 89, 6] -> 0
*/

Console.Clear();

label1:
int sizeOfArray = GetParametrOfArray("Введите размер одномерного массива: ", "Ошибка ввода!");
Console.WriteLine($"Размер массива: {sizeOfArray}");
if (sizeOfArray < 0)     //Отфильтровываем отрицательные значения
{
    Console.Clear();
    Console.WriteLine("Ошибка ввода!");
    goto label1;    //Очень НЕ популярный оператор "goto" :(
}

label2:
int minOfRange = GetParametrOfArray("\nВведите минимальное значение диапазона массива: ", "Ошибка ввода!");
Console.WriteLine($"Нижняя граница диапазона массива: {minOfRange}");

int maxOfRange = GetParametrOfArray("\nВведите максимальное значение диапазона массива: ", "Ошибка ввода!");
Console.WriteLine($"Верхняя граница диапазона массива: {maxOfRange}");

if (maxOfRange <= minOfRange) //Проверяем корректность ввода границ диапазона массива
{
    Console.Clear();
    Console.WriteLine("Ошибка ввода!");
    goto label2;
}

int[] arr = GetArrayRandom(sizeOfArray, minOfRange, maxOfRange);

int summOddPos = SummOfElemInOddPositions(sizeOfArray, arr);

PrintResult(arr, summOddPos);

//----------------------------------------------------------------------------------
//Функция возвращает натуральное число, вводимое потребителем с клавиатуры
//и выдаёт ошибку ввода в случае ввода не натурального числа

static int GetParametrOfArray(string message, string messageError)
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
//Функция принимает размер и границы массива и возвращает массив случайных чисел

static int[] GetArrayRandom(int N, int minOfRange, int maxOfRange)
{
    int[] arr = new int[N];
    for (int i = 0; i < N; i++)
    {
        arr[i] = new Random().Next(minOfRange, maxOfRange + 1);
    }
    Console.WriteLine($"[{String.Join(", ", arr)}]");
    return arr;
}

//----------------------------------------------------------------------------------
//Функция принимает массив натуральных чисел и возвращает сумму элементов, стоящих на нечётных позициях

int SummOfElemInOddPositions(int N, int[] arr)
{
    int summOddPos = 0;
    for (int i = 1; i < N; i = i + 2)
    {
        summOddPos += arr[i];
    }
    return summOddPos;
}

//----------------------------------------------------------------------------------
//Функция выводит в консоль массив и сумму элементов, стоящих на нечётных позициях
static void PrintResult(int[] arr, int summOddPos)
{
    Console.Clear();
    Console.WriteLine($"[{String.Join(", ", arr)}] -> {summOddPos}");
}
