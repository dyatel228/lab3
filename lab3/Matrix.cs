using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class MatrixOperations
    {
        private double[,] data;

        // Конструкторы для Задания 1
        public MatrixOperations(int n, int m)
        {
            data = new double[n, m];
            FillFromKeyboard(n, m);
        }

        public MatrixOperations(int n, bool isSecondArray)
        {

            data = new double[n, n];
            FillSecondArray(n);
        }

        public MatrixOperations(int n, string third)
        {

            data = new double[n, n];
            TriangleMatrix(n);
        }

        // Конструктор для существующего массива
        public MatrixOperations(double[,] array)
        {
            data = (double[,])array.Clone();
        }

        // Задание 1.1: Заполнение с клавиатуры по строкам
        private void FillFromKeyboard(int n, int m)
        {
            Console.WriteLine($"Введите элементы массива {n}x{m} по строкам:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                    data[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
        }

        // Задание 1.2: Заполнение второго массива
        private void FillSecondArray(int n)
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j < n - i - 1) // Выше побочной диагонали
                    {
                        data[i, j] = rand.Next(-65, 121); // [-65; 120]
                    }
                    else // На побочной диагонали и ниже
                    {
                        data[i, j] = rand.NextDouble() * (10.75 - (-3.5)) + (-3.5); // [-3.5; 10.75]
                    }
                }
            }
        }

        // Задание 1.3: Заполнение третьего массива
        private void TriangleMatrix(int n)
        {
            Console.WriteLine($"Введите элементы выше главной диагонали для массива {n}x{n}:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j > i) // Выше главной диагонали
                    {
                        Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                        data[i, j] = Convert.ToDouble(Console.ReadLine());
                    }
                    else if (j == i) // На главной диагонали
                    {
                        Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                        data[i, j] = Convert.ToDouble(Console.ReadLine());
                    }
                    else // Ниже главной диагонали - нули
                    {
                        data[i, j] = 0;
                    }
                }
            }
        }

        // Задание 2: Поиск банка с максимальным долгом
        public int FindBankWithMaxDebt()
        {
            int banksCount = data.GetLength(0); // Количество банков
            double[] totalDebts = new double[banksCount];
            bool hasDebts = false;
            // Суммируем долги каждого банка (по строкам)
            for (int i = 0; i < banksCount; i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    totalDebts[i] += data[i, j]; // Суммируем i-ю строку
                    if (data[i, j] > 0)
                    {
                        hasDebts = true;
                    }
                }
                Console.WriteLine($"{i + 1} Банк: {totalDebts[i]}");
            }
            // Находим банк с максимальным долгом
            int maxDebtBank = 0;
            double maxDebt = totalDebts[0];
            for (int i = 1; i < banksCount; i++)
            {
                if (hasDebts == false)
                {
                    Console.WriteLine("Никто никому не должен. Все долги равны нулю.");
                    break;
                }
                if (totalDebts[i] > maxDebt)
                {
                    maxDebt = totalDebts[i];
                    maxDebtBank = i;
                }
            }

            return maxDebtBank;
        }

        // Перегрузка операторов для Задания 3
        public static MatrixOperations operator *(double scalar, MatrixOperations matrix)
        {
            int rows = matrix.data.GetLength(0);
            int cols = matrix.data.GetLength(1);
            double[,] result = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = scalar * matrix.data[i, j];
                }
            }

            return new MatrixOperations(result);
        }

        public static MatrixOperations operator -(MatrixOperations a, MatrixOperations b)
        {
            int rows = a.data.GetLength(0);
            int cols = a.data.GetLength(1);
            double[,] result = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = a.data[i, j] - b.data[i, j];
                }
            }

            return new MatrixOperations(result);
        }

        // Транспонирование матрицы
        public MatrixOperations Transpose()
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);
            double[,] result = new double[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[j, i] = data[i, j];
                }
            }

            return new MatrixOperations(result);
        }

        // Перегрузка ToString()
        public override string ToString()
        {
            string result = "";
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += $"{data[i, j],10:F2}";
                }
                result += "\n";
            }

            return result;
        }

        // Метод для вычисления выражения: 2*A - B^T * C
        public static MatrixOperations CalculateExpression(MatrixOperations A, MatrixOperations B, MatrixOperations C)
        {
            // 2 * A
            MatrixOperations twoA = 2 * A;

            // B^T
            MatrixOperations bTransposed = B.Transpose();

            // B^T * C (МАТРИЧНОЕ умножение)
            MatrixOperations bTransposedTimesC = MatrixMultiply(bTransposed, C);

            // 2*A - B^T * C
            return twoA - bTransposedTimesC;
        }

        // Метод для матричного умножения
        public static MatrixOperations MatrixMultiply(MatrixOperations a, MatrixOperations b)
        {
            int aRows = a.data.GetLength(0);
            int aCols = a.data.GetLength(1);
            int bRows = b.data.GetLength(0);
            int bCols = b.data.GetLength(1);

            if (aCols != bRows)
                throw new InvalidOperationException("Несовместимые размеры для матричного умножения");

            double[,] result = new double[aRows, bCols];

            for (int i = 0; i < aRows; i++)
            {
                for (int j = 0; j < bCols; j++)
                {
                    for (int k = 0; k < aCols; k++)
                    {
                        result[i, j] += a.data[i, k] * b.data[k, j];
                    }
                }
            }

            return new MatrixOperations(result);
        }

        // Свойство для доступа к данным
        public double[,] Data
        {
            get { return (double[,])data.Clone(); }
        }
    }
}
