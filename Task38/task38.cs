// Программа задаёт массив вещественных чисел и находит разницу между максимальным и минимальным элементов массива.
//[3 7 22 2 78] -> 76

Console.Clear();

int sizeArr = GetSizeOfArray("Введите размер одномерного массива: ", "Ошибка ввода!");

double[] arr = GetRandomNumber(sizeArr, 1, 10); //Формируем одномерный массив из случайных вещественных чисел

double diffMaxMin = DiffBeetwenMaxMin(arr, sizeArr);    //Вычисляем разницу между максимальным и минимальным значениями массива

PrintResult(arr, diffMaxMin);  //Печатаем результат

//-----------------------Functions---------------------

static int GetSizeOfArray(string message, string messageError)
{
    while (true)
    {
        Console.Write(message);
        bool inTrue = int.TryParse(Console.ReadLine() ?? "", out int N) && N >= 0;
        if (inTrue)
            return N;
        Console.WriteLine(messageError);
    }
}

//-----------------------------------------------------------
static double[] GetRandomNumber(int sizeArr, double min, double max)
{
    double[] arr = new double[sizeArr];
    Random rnd = new Random();

    for (int i = 0; i < sizeArr; i++)
    {
        //sample[i] = rand.NextDouble(min, max);
        arr[i] = Math.Round((rnd.NextDouble() * (1 - 10) + 10), 2);
    }
    return arr;
}

//-----------------------------------------------------------
static double DiffBeetwenMaxMin(double[] arr, int sizeArr)
{
    double elMin = arr[1];
    double elMax = arr[1];

    for (int i = 0; i < sizeArr; i++)
    {
        if (arr[i] < elMin)
            elMin = arr[i];

        if (arr[i] > elMax)
            elMax = arr[i];
    }
    return elMax - elMin;
}

//-----------------------------------------------------------
static void PrintResult(double[] arr, double diffMaxMin)
{
    Console.WriteLine($"[{String.Join(", ", arr)}] -> {diffMaxMin}");
}