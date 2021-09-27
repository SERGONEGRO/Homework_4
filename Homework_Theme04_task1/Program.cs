using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1.
            // Заказчик просит вас написать приложение по учёту финансов
            // и продемонстрировать его работу.
            // Суть задачи в следующем: 
            // Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств. 
            // За год получены два массива – расходов и поступлений.
            // Определить прибыли по месяцам
            // Количество месяцев с положительной прибылью.
            // Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью, 
            // если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
            // Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

            // Пример
            //       
            // Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.
            //     1              100 000             80 000                 20 000
            //     2              120 000             90 000                 30 000
            //     3               80 000             70 000                 10 000
            //     4               70 000             70 000                      0
            //     5              100 000             80 000                 20 000
            //     6              200 000            120 000                 80 000
            //     7              130 000            140 000                -10 000
            //     8              150 000             65 000                 85 000
            //     9              190 000             90 000                100 000
            //    10              110 000             70 000                 40 000
            //    11              150 000            120 000                 30 000
            //    12              100 000             80 000                 20 000
            // 
            // Худшая прибыль в месяцах: 7, 4, 1, 5, 12
            // Месяцев с положительной прибылью: 10


            //                        /*----------РЕШЕНИЕ------------*/
            Random rand = new Random();    //генератор чисел

            int[] income = new int[12];    //задание массивов
            int[] expens = new int[12];
            int[] profit = new int[12];     //прибыль
            int goodProfit = 0;               //Количество месяцев с положительной прибылью
            int minValue;
            int minIndex;

            //Заполнение и вывод на экран массивов дохода, расхода, прибыли
            Console.WriteLine("Месяц\t Доход,тыс.руб.\tРасход,тыс.руб.\tПрибыль,тыс.руб");
            for (int i = 0; i < 12; i++)
            {
                income[i] = rand.Next(10, 100) * 1000;
                expens[i] = rand.Next(10, 90) * 1000;
                profit[i] = income[i] - expens[i];
                if (profit[i] > 0) goodProfit++;

                Console.WriteLine($"{i + 1} \t{income[i]} \t\t{expens[i]} \t\t{profit[i]}");
            }
            Console.WriteLine($"\nКоличество месяцев с положительной прибылью: {goodProfit}");

            //вычисление 3х месяцев с самой низкой прибылью
            Console.WriteLine($"\n3 месяца с худшей прибылью: ");
            for (int j = 0; j < 3; j++)
            {
                minValue = profit.Min();
                minIndex = profit.ToList().IndexOf(minValue);
                profit[minIndex] = Int32.MaxValue;                        //после того, как выявили минимальный элемент, примсваиваем ему максимальное значение Int32
                Console.WriteLine($"\n {minIndex + 1}\t {minValue}");     //чтобы он точно не попал в следующую итерацию.
            }
            Console.WriteLine();
            Console.ReadKey();


            // * Задание 2
            // Заказчику требуется приложение строящее первых N строк треугольника паскаля. N < 25
            // 
            // При N = 9. Треугольник выглядит следующим образом:
            //                                 1
            //                             1       1
            //                         1       2       1
            //                     1       3       3       1
            //                 1       4       6       4       1
            //             1       5      10      10       5       1
            //         1       6      15      20      15       6       1
            //     1       7      21      35      35       21      7       1
            //                                                              
            //                                                              
            // Простое решение:                                                             
            // 1
            // 1       1
            // 1       2       1
            // 1       3       3       1
            // 1       4       6       4       1
            // 1       5      10      10       5       1
            // 1       6      15      20      15       6       1
            // 1       7      21      35      35       21      7       1
            // 
            // Справка: https://ru.wikipedia.org/wiki/Треугольник_Паскаля


            /*---------РЕШЕНИЕ------------*/

            int N = rand.Next(15);                   //задаем N рандомно
            int[][] jaggedArray = new int[N][];      //определяем зубчатый массив из N подмассивов
            string printString = "";                   //определяем строку, которая будет выводится на экран
            int centerX, y;                          //координаты курсора

            Console.WriteLine($"N = {N}\n");

            for (int i = 0; i < N; i++)                   //для каждого подмассива
            {
                //обнуляется строка печати
                printString = "";

                jaggedArray[i] = new int[i + 1];     //задание длины подмассива

                //если первый подмассив, то его единственный элемент = 1, печать по центру и пропуск итерации
                if (i == 0) { jaggedArray[i][0] = 1; printString = jaggedArray[i][0].ToString(); CenterPrint(printString); continue; }

                //Если массив не первый:
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    //если элемент первый, то он =1, Добавляется в строку для печати
                    if (j == 0) { jaggedArray[i][j] = 1; printString = jaggedArray[i][j].ToString() + "  "; }
                    //если элемент последний, то он =1, Добавляется в строку для печати
                    else if (j == jaggedArray[i].Length - 1) { jaggedArray[i][j] = 1; printString = printString + jaggedArray[i][j].ToString(); }
                    else
                    {
                        //во всех остальных случаях элемент вычисляется согласно правилу
                        jaggedArray[i][j] = jaggedArray[i - 1][j - 1] + jaggedArray[i - 1][j];
                        //...и добавляется в строку для печати
                        printString = printString + jaggedArray[i][j].ToString() + "  ";
                    }

                }
                //печать строки по центру
                CenterPrint(printString);
            }

            //Метод для печати строк по центру
            void CenterPrint(string sometext)
            {
                y = Console.CursorTop + 1;
                centerX = (Console.WindowWidth / 2) - (sometext.Length / 2);
                Console.SetCursorPosition(centerX, y);
                Console.WriteLine(sometext);
            }


            // 
            // * Задание 3.1
            // Заказчику требуется приложение позволяющщее умножать математическую матрицу на число
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матрицы_на_число
            // Добавить возможность ввода количество строк и столцов матрицы и число,
            // на которое будет производиться умножение.
            // Матрицы заполняются автоматически. 
            // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
            //
            // Пример
            //
            //      |  1  3  5  |   |  5  15  25  |
            //  5 х |  4  5  7  | = | 20  25  35  |
            //      |  5  3  1  |   | 25  15   5  |
            //

            /*-----------РЕШЕНИЕ-------------*/
            int str, stolb;     //количество строк и стоблцов
            int num;            //число

            //Метод для заполнения матрицы, общий для заданий 3.1-3.3
            int[,] MatrixFill(int stroka, int stolbec)
            {
                int[,] matrixX = new int[stroka, stolbec];
                for (int i = 0; i < stroka; i++)
                {
                    for (int j = 0; j < stolbec; j++)
                    {
                        matrixX[i, j] = rand.Next(5);
                        Console.Write($"{matrixX[i, j]}\t");
                    }
                    Console.WriteLine();
                }
                return matrixX;
            }

            Console.WriteLine("\n3.1 Перемножение матрицы на число :");

            Console.WriteLine("\nВведите количество строк матрицы :");
            str = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nВведите количество столбцов матрицы :");
            stolb = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nВведите число :");
            num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nИсходная матрица: ");
            int[,] matrix = new int[str, stolb];
            matrix = MatrixFill(str, stolb);         //определение матрицы

            Console.WriteLine("\n Перемноженная матрица на число: ");
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < stolb; j++)
                {
                    matrix[i, j] = matrix[i, j] * num;
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }

            //
            // ** Задание 3.2
            // Заказчику требуется приложение позволяющщее складывать и вычитать математические матрицы
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Сложение_матриц
            // Добавить возможность ввода количество строк и столцов матрицы.
            // Матрицы заполняются автоматически
            // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
            //
            // Пример
            //  |  1  3  5  |   |  1  3  4  |   |  2   6   9  |
            //  |  4  5  7  | + |  2  5  6  | = |  6  10  13  |
            //  |  5  3  1  |   |  3  6  7  |   |  8   9   8  |
            //  
            //  
            //  |  1  3  5  |   |  1  3  4  |   |  0   0   1  |
            //  |  4  5  7  | - |  2  5  6  | = |  2   0   1  |
            //  |  5  3  1  |   |  3  6  7  |   |  2  -3  -6  |
            //

                                    /*---------РЕШЕНИЕ-------------*/
            Console.WriteLine("\n3.2 Сложение и вычитание матриц :");

            Console.WriteLine("\tВведите количество строк матрицы :");
            str = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\tВведите количество столбцов матрицы :");
            stolb = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n Матрица А:");          //определение и заполнение матриц 
            int [,] matrixA = MatrixFill(str, stolb);
            Console.WriteLine("\n Матрица B:");          
            int[,] matrixB = MatrixFill(str, stolb);


            Console.WriteLine("\n Сложенные матрицы: ");
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < stolb; j++)
                {
                    Console.Write($"{matrixA[i, j]+ matrixB[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n Вычитание матриц:");
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < stolb; j++)
                {
                    Console.Write($"{matrixA[i, j] - matrixB[i, j]}\t");
                }
                Console.WriteLine();
            }


            // *** Задание 3.3
            // Заказчику требуется приложение позволяющщее перемножать математические матрицы
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матриц
            // Добавить возможность ввода количество строк и столцов матрицы.
            // Матрицы заполняются автоматически
            // Если по введённым пользователем данным действие произвести нельзя - сообщить об этом
            //  
            //  |  1  3  5  |   |  1  3  4  |   | 22  48  57  |
            //  |  4  5  7  | х |  2  5  6  | = | 35  79  95  |
            //  |  5  3  1  |   |  3  6  7  |   | 14  36  45  |
            //
            //  
            //                  | 4 |   
            //  |  1  2  3  | х | 5 | = | 32 |
            //                  | 6 |  
            //
                                  /*---------РЕШЕНИЕ-------------*/
            Console.WriteLine("\n3.3 Умножение матрицы на матрицу :");

            int strC, stolbC;                   //размерности матриц
            int strD, stolbD;
            int sum;                            //для суммирования элементов

            do
            {
                //Ввод размерностей матриц и проверка условий
                Console.WriteLine("\t--->Введите размерность матриц<----\n" +
                    " Количество столбцов в матрице 1 должно совпадать с количеством строк в матрице 2\n");

                Console.WriteLine("\tВведите количество строк первой матрицы :");
                strC = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\tВведите количество столбцов первой матрицы :");
                stolbC = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\tВведите количество строк второй матрицы :");
                strD = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\tВведите количество столбцов второй матрицы :");
                stolbD = Convert.ToInt32(Console.ReadLine());

            } while (stolbC != strD);


            Console.WriteLine("\n Матрица C:");          //определение и заполнение матриц 
            int[,] matrixC = MatrixFill(strC, stolbC);
            Console.WriteLine("\n Матрица D:");
            int[,] matrixD = MatrixFill(strD, stolbD);
            
            Console.WriteLine("\n Произведение матриц:");          //Результирующая матрица
            
            for (int i = 0; i < strC; i++)
            {
                for (int j = 0; j < stolbD; j++)
                {
                    //встаем в каждую ячейку по очереди и считаем значение элемента согласно правилу
                    sum = 0;                                        
                    for(int z =0;z<stolbC;z++)           //stolbC=strD (по правилу)
                    {
                        //Операция вычисления матрицы , каждый элемент которой равен сумме произведений
                        //элементов в соответствующей строке первого множителя и столбце второго
                        sum = sum + matrixC[i, z] * matrixD[z, j];
                    }
                    Console.Write($"{sum}\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
