/* Задача 50. Напишите программу, которая на вход принимает позиции элемента 
в двумерном массиве, и возвращает значение этого элемента или же указание, 
что такого элемента нет.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4

17 -> такого числа в массиве нет
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
            matrix[i, j] = rnd.Next(0, 20);
        }
    }
    return matrix;
}

//Метод вывода массива на экран
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write("{0,4:0.#}", matrix[i, j]);
        }
        Console.WriteLine();
    }
}

//Метод проверки наличия элемента в двумерном массиве
(bool,int,int) FindElementOfMassive(int[,] matrix, int elementFind)
{
    bool flag=false;
    int rows=-1;
    int columns=-1;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if(matrix[i,j]==elementFind)
            {

                return (flag=true, rows=i+1, columns=j+1);
            }
        }
    }
    return (flag,rows,columns);
}


int m = GetNumber(" Введите размер матрицы [i, ]= ");
int n = GetNumber(" Введите размер матрицы [ ,j] = ");
int digit = GetNumber(" Введите искомое значение массива= ");
int[,] myMatrix = GetMatrix(m, n);
Console.WriteLine("Случайная матрица");
PrintMatrix(myMatrix);
(bool findOrNot,int findRows, int findColumns) = FindElementOfMassive(myMatrix,digit);
Console.WriteLine(findOrNot ? $"Элемент {digit} в массиве найден в {findRows} ряду {findColumns} столбце":$"Элемент {digit} в массиве не найден");