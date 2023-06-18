using System;
using System.ComponentModel;

namespace MatrixOperationsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int[,] matrix = GetMatrix();
                PrintMatrix(matrix);
                FunctionsMenu(matrix);
            }
        }

        private static int[,] GetMatrix()
        {
            int height, length;
            Console.WriteLine("Ведите высоту матрицы > 0");

            height = PositiveNumberInput(Console.ReadLine());

            Console.WriteLine("Ведите длину матрицы > 0");
            length = PositiveNumberInput(Console.ReadLine());

            int[,] matrix = new int[height, length];

            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    Console.Write("[" + i + "," + j + "]:   ");
                    matrix[i, j] = IntInput(Console.ReadLine());
                }
            }

            return matrix;
        }

        public static int IntInput(string input)
        {
            var converter = TypeDescriptor.GetConverter(typeof(int));
            if (converter.IsValid(input))
            {
                return (int)converter.ConvertFrom(input);
            }
            else
            {
                Console.WriteLine("Неверный ввод. Попробуйте ещё раз");
                return IntInput(Console.ReadLine());
            }
        }

        public static int PositiveNumberInput(string input)
        {
            int number = IntInput(input);
            if (number <= 0)
            {
                Console.WriteLine("Неверный ввод. Попробуйте ещё раз");
                return PositiveNumberInput(Console.ReadLine());
            }
            return number;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            int[,] spacesMatrix = CountSpaces(matrix);
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("| ");
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(new string(' ', spacesMatrix[i, j]) + matrix[i, j] + " ");
                }
                Console.WriteLine("|");
            }
        }

        private static int[,] CountSpaces(int[,] matrix)
        {
            int[,] spacesMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int[] maxLengts = new int[matrix.GetLength(1)];
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                maxLengts[j] = 0;
                for (var i = 0; i < matrix.GetLength(0); i++)
                {
                    spacesMatrix[i, j] = matrix[i, j].ToString().Length;
                    if (spacesMatrix[i, j] > maxLengts[j]) maxLengts[j] = spacesMatrix[i, j];
                }
            }

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    spacesMatrix[i, j] = maxLengts[j] - spacesMatrix[i, j];
                }
            }
            return spacesMatrix;
        }

        private static void FunctionsMenu(int[,] matrix) {
            Console.WriteLine("Выберите действие из меню \n" +
                                      "1 - Посчитать количество положительных/отрицательных чисел в матрице\n" +
                                      "2 - Построчная сортировка\n" +
                                      "3 - Построчная инверсия элементов\n" +
                                      "4 - Ввести другую матрицу\n" +
                                      "0 - Выйти из приложения");
            var input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    ElementsAmount(matrix);
                    break;
                case "2":
                    LinesSorting(matrix);
                    break;
                case "3":
                    LinesInverting(matrix);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неверный ввод. Попробуйте ещё раз");
                    break;
            }
            FunctionsMenu(matrix);
        }

        private static void ElementsAmount(int[,] matrix)
        {
            Console.WriteLine("Посчитать количество \n" +
                                  "1 - положительных чисел\n" +
                                  "2 - отрицательных чисел\n" +
                                  "0 - Вернуться к основному меню");
            var input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    return;
                case "1":
                    var positiveCount = 0;
                    foreach (var element in matrix)
                        if (element > 0) positiveCount++;
                    Console.WriteLine("Количество положительных чисел " + positiveCount);
                    break;
                case "2":
                    var negativeCount = 0;
                    foreach (var element in matrix)
                        if (element < 0) negativeCount++;
                    Console.WriteLine("Количество отрицательных чисел " + negativeCount);
                    break;
                default:
                    Console.WriteLine("Неверный ввод. Попробуйте ещё раз");
                    ElementsAmount(matrix);
                    break;
            }
        }

        private static void LinesSorting(int[,] matrix)
        {
            Console.WriteLine("Отсортировать построчно в порядке \n" +
                                  "1 - возрастания\n" +
                                  "2 - убывания\n" +
                                  "0 - Вернуться к основному меню");
            var input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    return;
                case "1":
                case "2":
                    for (var i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (var j = 0; j < matrix.GetLength(1); j++)
                        {
                            for (var k = j; k < matrix.GetLength(1); k++)
                            {
                                if (input == "1" && matrix[i, k] < matrix[i, j]||
                                    input == "2" && matrix[i, k] > matrix[i, j])
                                {
                                    int bufer = matrix[i, k];
                                    matrix[i, k] = matrix[i, j];
                                    matrix[i, j] = bufer;
                                }
                            }
                        }
                    }
                    PrintMatrix(matrix);
                    break;
                default:
                    Console.WriteLine("Неверный ввод. Попробуйте ещё раз");
                    LinesSorting(matrix);
                    break;
            }
        }

        private static void LinesInverting(int[,] matrix)
        {

        }
    }
}
