using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme04_task3._2
{
    class Program
    {
        static void Main(string[] args)
        {
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

            int str, stolb;     //количество строк и стоблцов
            
            Console.WriteLine("\n3.2 Сложение и вычитание матриц :");

            Console.WriteLine("\tВведите количество строк матрицы :");
            str = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\tВведите количество столбцов матрицы :");
            stolb = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n Матрица А:");          //определение и заполнение матриц 
            int[,] matrixA = MatrixFill(str, stolb);
            Console.WriteLine("\n Матрица B:");
            int[,] matrixB = MatrixFill(str, stolb);


            Console.WriteLine("\n Сложенные матрицы: ");
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < stolb; j++)
                {
                    Console.Write($"{matrixA[i, j] + matrixB[i, j]}\t");
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
