using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\n=== ВЫБЕРИТЕ ЗАДАНИЕ ===");
            Console.WriteLine("1 - Задание 1: Создание массивов");
            Console.WriteLine("2 - Задание 2: Поиск банка с максимальным долгом");
            Console.WriteLine("3 - Задание 3: Вычисление матричного выражения");
            Console.WriteLine("4 - Задание 4: Противоположные пары чисел");
            Console.WriteLine("5 - Задание 5: Багаж пассажиров");
            Console.WriteLine("6 - Задание 6: Проверка на ноль");
            Console.WriteLine("7 - Задание 7: Максимальный элемент");
            Console.WriteLine("8 - Задание 8: Строки, оканчивающиеся на заданный символ");
            Console.WriteLine("100 - ВЫХОД");              
            while (true)
            {
                Console.Write("Ваш выбор: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 100)
                {
                    Console.WriteLine("Завершение программы");
                    break;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("=== Задание 1: Создание массивов ===");

                        // Первый массив
                        Console.Write("Ввод размера первого массива\n Введите кол-во строк: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите кол-во столбцов: ");
                        int m = Convert.ToInt32(Console.ReadLine());
                        MatrixOperations matrix1 = new MatrixOperations(n, m);
                        Console.WriteLine(matrix1);

                        // Второй массив
                        Console.Write("Введите размер второго массива (NxN): ");
                        n = Convert.ToInt32(Console.ReadLine());
                        MatrixOperations matrix2 = new MatrixOperations(n, true);
                        Console.WriteLine(matrix2);

                        // Третий массив
                        Console.Write("Введите размер треугольной матрицы:");
                        n = Convert.ToInt32(Console.ReadLine());
                        MatrixOperations matrix3 = new MatrixOperations(n, "third");
                        Console.WriteLine(matrix3);
                        break;
                    case 2:
                        Console.WriteLine("Задание 2: Поиск банка с максимальным долгом");
                        Console.Write("Введите количество банков: ");
                        n = Convert.ToInt32(Console.ReadLine());

                        // Создаем объект для банков с вводом данных с клавиатуры
                        MatrixOperations banks = new MatrixOperations(n, n);
                        Console.WriteLine("Матрица долгов:");
                        Console.WriteLine(banks);
                        int maxDebtBank = banks.FindBankWithMaxDebt();
                        if (maxDebtBank != 0)
                        {
                            Console.WriteLine($"Банк с максимальным долгом: {maxDebtBank + 1}");
                        }
                        break;
                    case 3:
                        Console.WriteLine("=== Задание 3 ===");
                        Console.Write("Введите размерность матриц n: ");
                        n = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ввод матрицы A:");
                        MatrixOperations A = new MatrixOperations(n, n);

                        Console.WriteLine("Ввод матрицы B:");
                        MatrixOperations B = new MatrixOperations(n, n);

                        Console.WriteLine("Ввод матрицы C:");
                        MatrixOperations C = new MatrixOperations(n, n);

                        MatrixOperations result = MatrixOperations.CalculateExpression(A, B, C);
                        Console.WriteLine("Результат:\n" + result);
                        break;
                    case 4:
                        Console.WriteLine("=== Задание 4 ===");
                        FileTasks.CreateNumbersFile("numbers.bin");
                        int pairs = FileTasks.FindOppositePairs("numbers.bin");
                        Console.WriteLine("Пар противоположных чисел: " + pairs);
                        break;
                    case 5:
                        Console.WriteLine("\n=== Задание 5 ===");
                        FileTasks.CreateBaggageFile("baggage.txt");
                        double diff = FileTasks.FindWeightDifference("baggage.txt");
                        Console.WriteLine("Разница в весе: " + diff + " кг");
                        break;
                    case 6:
                        Console.WriteLine("\n=== Задание 6 ===");
                        FileTasks.CreateSingleNumberFile("single.txt");
                        bool noZero = FileTasks.CheckNoZero("single.txt");
                        Console.WriteLine(noZero);
                        break;
                    case 7:
                        Console.WriteLine("\n=== Задание 7 ===");
                        FileTasks.CreateMultiNumberFile("multi.txt");
                        int max = FileTasks.FindMaxNumber("multi.txt");
                        Console.WriteLine("Максимальное число: " + max);
                        break;
                    case 8:
                        Console.WriteLine("\n=== Задание 8 ===");
                        FileTasks.CreateTextFile("text.txt");
                        Console.Write("Введите символ для проверки: ");
                        char searchChar = Console.ReadLine()[0];
                        FileTasks.CopyLinesWithEnding(searchChar);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;             
                }
            }       
        }
    }
}
