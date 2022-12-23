/* Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее 
арифметическое элементов в каждом столбце.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3
*/

//Метод провеки на валидность вводимых элементов размерности массива
int GetNumber(string message)
{
    int result = 0;

    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out result) && result > 0)
        {
            break;
        }
        else
        {
            Console.WriteLine("Ввели не размер массива. Введите размер ммассива");
        }
    }

    return result;
}

//Метод заполнения массива случайными числами
int[,] GetMatrix(int row, int column)
{
    int[,] matrix = new int[row, column];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(0,20);
        }
    }
    return matrix;
}

//Метод вывода матрицы на экран
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write("{0,-5:0.#}", matrix[i, j]);
        }
        Console.WriteLine();
    }
}

//Метод расчета среднего арифметического столбцов
double[] GetArray (int[,] matrix)
{
    int sum=0;
    double[] array = new double[matrix.GetLength(1)];
    Console.WriteLine("Среднее арифметическое каждого столбца");
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            sum+=matrix[j,i];
        }
        array[i]=Math.Round(Convert.ToDouble(sum)/matrix.GetLength(0),3);
        sum=0;
    }
    return array;
}

//Метод вывода массива на экран
void PrintArray(double[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write("{0,-5:0.#}", array[i]);
    }
}

int m = GetNumber(" Введите размер матрицы [i, ]= ");
int n = GetNumber(" Введите размер матрицы [ ,j] = ");
int[,] myMatrix = GetMatrix(m,n);
Console.WriteLine("Случайная матрица");
PrintMatrix(myMatrix);
double[] resultArray = GetArray(myMatrix);
PrintArray(resultArray);