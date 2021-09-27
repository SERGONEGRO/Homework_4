using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme4_task2
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Random rand = new Random();
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
            Console.ReadKey();
        }
    }
}
