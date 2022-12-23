/* Задача 47. Задайте двумерный массив размером m×n, заполненный случайными 
вещественными числами.
Например m = 3, n = 4.
Массив
0,5  7  -2  -0,2
1  -3,3  8  -9,9
8   7,8 -7,1 9 
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
double[,] GetMatrix(int row, int column)
{
    double[,] matrix = new double[row, column];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = Math.Round((rnd.Next(-20,20)*Math.PI+rnd.NextDouble()*10*Math.PI),1);
        }
    }
    return matrix;
}

//Метод вывода массива на экран
void PrintMatrix(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write("{0,-10:0.#}", matrix[i, j]);
        }
        Console.WriteLine();
    }
}

int m = GetNumber(" Введите размер матрицы [i, ]= ");
int n = GetNumber(" Введите размер матрицы [ ,j] = ");
double[,] myMatrix = GetMatrix(m,n);
PrintMatrix(myMatrix);