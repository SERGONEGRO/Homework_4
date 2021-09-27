using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme04_task3._3
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Random rand = new Random();
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
                    for (int z = 0; z < stolbC; z++)           //stolbC=strD (по правилу)
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
        }
    }
}
