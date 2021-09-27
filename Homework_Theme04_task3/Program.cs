using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme4_task3
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Random rand = new Random();
            int str, stolb;     //количество строк и стоблцов
            int num;            //число

            Console.WriteLine("\n3.1 Перемножение матрицы на число :");

            Console.WriteLine("\nВведите количество строк матрицы(0-9) :");
            str = EnterNumber();

            Console.WriteLine("\nВведите количество столбцов матрицы(0-9) :");
            stolb = EnterNumber();

            Console.WriteLine("\nВведите число(0-9) :");
            num = EnterNumber();

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

            //Ввод числа и его проверка 
            int EnterNumber()
            {
                string s;
                do
                {
                    s = Console.ReadLine();
                }
                while (s!="0"&& s!="1" && s!="2" && s!="3" && s!="4" && s!="5" && s!="6" && s!="7" && s!="8" && s!="9");

                return Int32.Parse(s);
            }
        }
    }
}
