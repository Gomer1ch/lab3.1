using System;

namespace Лаба_3_задание_1_С_МЕТОДАМИ
{
    class Program
    {
        static void Create(int[,] mas, int n, int m)
        {
            Random rnd = new Random(); //Создание объекта генерации случайных чисел
            //Console.WriteLine("Введите элементы массива: ");
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < m; i++)
                {
                    mas[i, j] = rnd.Next(-10, 10); //Запись случайных чисел в массив по столбцам
                }
                //Console.WriteLine();
            }
        }
        static void Stats(int[,] mas, int n, int m, int[] sum)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (mas[j, i] % 2 != 0 /*нечётное*/ & mas[j, i] < 0 /*отрицательное число*/)
                    {
                        sum[i] += Math.Abs(mas[j, i]); // Сумма элементов столбца матрицы + запись значений в массив сумм
                    }
                }
            }
            Console.WriteLine("\n Характеристики");
            foreach(int i in sum) { Console.Write($"{i} \t"); }
            Console.WriteLine("\n");
        }
        static void Sort(int[,] mas, int n, int m, int[] sum)
        {
            int min, imin, b; int a;
            for (int k = 0; k < n; k++)
            {
                min = sum[k]; imin = k;
                //Получение индекса столбца с минимальной суммой
                for (int i = 1 + k; i < n; i++)
                {
                    if (sum[i] < min)
                    {
                        min = sum[i];
                        imin = i;
                    }
                }
                //Сортировка индексов сумм по возрастанию
                b = sum[k]; 
                sum[k] = min;
                sum[imin] = b;
                //Меняем местами столбцы (1-ий та з минимальной сумой, потом 2-ий...)
                for (int j = 0; j < m; j++)
                {
                    a = mas[j, k];
                    mas[j, k] = mas[j, imin];
                    mas[j, imin] = a;
                }
            }
        }
        static void see(int[,] mas, int n, int m)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{mas[i, j]} \t"); ;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void summa(int[,] mas, int n, int m)
        {
            string[] sum2 = new string[n]; //Строчное значение массива суммы для возможности вывода "Нету отрицательных чисел" 
            Console.WriteLine("Сумма элементов в столбцах которых есть отрицательные числа:");
            for (int j = 0; j < n; j++)
            {
                int TF = 0;
                sum2[j] = "0";
                for (int i = 0; i < m; i++)
                {
                    if (mas[i, j] < 0) TF = 1;
                    sum2[j] = "" + (Convert.ToInt32(sum2[j]) + mas[i, j]); //При помощи "" значение суммы превращается в строчное значения
                }
                if (TF != 1) sum2[j] = "Нету"; // Нету отрицательных чисел //Если TF не равно 1, заменяет значение суммы на "Нету"
            }
            foreach (string j in sum2) { Console.Write($"{j} \t"); }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            int m, /*строки*/ n /*столбцы*/;
            Console.Write("Введите количество строк в массиве: ");
            m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество столбцов в массиве: ");
            n = Convert.ToInt32(Console.ReadLine());
            int[] sum = new int[n]; //Объявление массив сумм (характеристик матрицы)
            int[,] mas = new int[m, n]; //Объявление изначального массива
            Create(mas, n, m);
            Console.WriteLine("Матричный вид:");
            see(mas, n, m);
            Stats(mas, n, m, sum);
            Sort(mas, n, m, sum);
            Console.WriteLine("Отсортированный массив");
            //Выводим массив строками
            see(mas, n, m);
            Console.ReadKey();
            //Сумма
            summa(mas, n, m);
        }
    }
}
