using System;
using System.IO;

namespace lab3
{
    public static class FileTasks
    {
        // Задание 4: Бинарный файл с числами
        public static void CreateNumbersFile(string filename)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Create);
                BinaryWriter writer = new BinaryWriter(fs);

                Random rnd = new Random();
                int count = 10;

                Console.WriteLine("Содержимое бинарного файла:");
                for (int i = 0; i < count; i++)
                {
                    int number = rnd.Next(-10, 11);
                    writer.Write(number);
                    Console.Write(number + " ");
                }
                Console.WriteLine();

                writer.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании файла {filename}: {ex.Message}");
            }
        }

        public static int FindOppositePairs(string filename)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open);
                BinaryReader reader = new BinaryReader(fs);

                int count = (int)(fs.Length / 4);
                int[] numbers = new int[count];

                for (int i = 0; i < count; i++)
                {
                    numbers[i] = reader.ReadInt32();
                }

                reader.Close();
                fs.Close();

                int pairsCount = 0;
                for (int i = 0; i < count; i++)
                {
                    for (int j = i + 1; j < count; j++)
                    {
                        if (numbers[i] == -numbers[j])
                        {
                            pairsCount++;
                        }
                    }
                }

                return pairsCount;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Файл {filename} не найден");
                return 0;
            }
        }

        // Задание 5: Багаж пассажиров
        public static void CreateBaggageFile(string filename)
        {
            try
            {
                StreamWriter writer = new StreamWriter(filename);
                Random rnd = new Random();

                string[] baggageNames = { "Чемодан", "Сумка", "Рюкзак", "Коробка", "Пакет" };
                int passengerCount = 4;

                for (int passenger = 1; passenger <= passengerCount; passenger++)
                {
                    writer.WriteLine("Пассажир " + passenger);

                    int baggageCount = rnd.Next(2, 5);
                    int totalWeight = 0;

                    for (int i = 0; i < baggageCount; i++)
                    {
                        string name = baggageNames[rnd.Next(baggageNames.Length)];
                        int weight = rnd.Next(1, 16);
                        writer.WriteLine(name + "," + weight);
                        totalWeight += weight;
                    }

                    writer.WriteLine("Итого," + totalWeight);
                    writer.WriteLine("---");
                }

                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании файла {filename}: {ex.Message}");
            }
        }

        public static int FindWeightDifference(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);
                int[] weights = new int[10];
                int passengerIndex = -1;

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith("Пассажир"))
                    {
                        passengerIndex++;
                    }
                    else if (lines[i].StartsWith("Итого"))
                    {
                        string[] parts = lines[i].Split(',');
                        weights[passengerIndex] = int.Parse(parts[1]);
                    }
                }

                int max = weights[0];
                int min = weights[0];

                for (int i = 1; i <= passengerIndex; i++)
                {
                    if (weights[i] > max) max = weights[i];
                    if (weights[i] < min) min = weights[i];
                }

                return max - min;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Файл {filename} не найден");
                return 0;
            }
        }

        // Задание 6: Проверка на 0
        public static void CreateSingleNumberFile(string filename)
        {
            try
            {
                StreamWriter writer = new StreamWriter(filename);
                Random rnd = new Random();
                int count = 10;

                for (int i = 0; i < count; i++)
                {
                    int number = rnd.Next(-3, 4);
                    writer.WriteLine(number);
                }

                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании файла {filename}: {ex.Message}");
            }
        }

        public static bool CheckNoZero(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);

                for (int i = 0; i < lines.Length; i++)
                {
                    int number = int.Parse(lines[i]);
                    if (number == 0)
                    {
                        return true;
                    }
                }

                return true;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Файл {filename} не найден");
                return false;
            }
        }

        // Задание 7: Текстовый файл с несколькими числами в строке
        public static void CreateMultiNumberFile(string filename)
        {
            try
            {
                StreamWriter writer = new StreamWriter(filename);
                Random rnd = new Random();
                int lineCount = 6;

                for (int i = 0; i < lineCount; i++)
                {
                    int numbersInLine = rnd.Next(2, 6);
                    for (int j = 0; j < numbersInLine; j++)
                    {
                        int number = rnd.Next(1, 101);
                        writer.Write(number);
                        if (j < numbersInLine - 1)
                            writer.Write(" ");
                    }
                    writer.WriteLine();
                }

                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании файла {filename}: {ex.Message}");
            }
        }

        public static int FindMaxNumber(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);
                int max = 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] numbers = lines[i].Split(' ');

                    for (int j = 0; j < numbers.Length; j++)
                    {
                        int number = int.Parse(numbers[j]);
                        if (number > max)
                        {
                            max = number;
                        }
                    }
                }

                return max;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Файл {filename} не найден");
                return 0;
            }
        }

        // Задание 8: Текстовый файл со строками
        public static void CreateTextFile(string filename)
        {
            try
            {
                StreamWriter writer = new StreamWriter(filename);
                Random rnd = new Random();
                int lineCount = 20;
                string allChars = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ";

                for (int i = 0; i < lineCount; i++)
                {
                    int lineLength = rnd.Next(1, 21);
                    string line = "";

                    for (int j = 0; j < lineLength; j++)
                    {
                        char randomChar = allChars[rnd.Next(allChars.Length)];
                        line += randomChar;
                    }

                    writer.WriteLine(line);
                }

                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании файла {filename}: {ex.Message}");
            }
        }

        public static void CopyLinesWithEnding(char searchChar)
        {
            try
            {
                CreateTextFile("text.txt");
                string[] lines = File.ReadAllLines("text.txt");

                string[] tempResult = new string[lines.Length];
                int count = 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Length > 0 && lines[i][lines[i].Length - 1] == searchChar)
                    {
                        tempResult[count] = lines[i];
                        count++;
                    }
                }

                string[] finalResult = new string[count];
                for (int i = 0; i < count; i++)
                {
                    finalResult[i] = tempResult[i];
                }

                File.WriteAllLines("result.txt", finalResult);

                Console.WriteLine($"\nНайдено строк, оканчивающихся на '{searchChar}': {count}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл text.txt не найден");
            }
        }
    }
}
