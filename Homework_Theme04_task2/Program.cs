using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme4_task2
{
    class Program
    {
        public const int cellWidth = 5;
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
            int row = rand.Next(10);
            int[,] triangle = new int [row,row];
            const int cellWidth = 5;

            Console.WriteLine($"N={row}\n");
            FillTriangle();

            int col = cellWidth*row;
            
            for(int i = 0; i<row;i++)
            {
                for (int j = 0;j<=i;j++)
                {
                    Console.SetCursorPosition(col,i+1);
                    if (triangle[i,j] != 0) Console.Write($"{triangle[i,j], cellWidth}");
                    col+=cellWidth*2;
                }
                col = cellWidth*row-cellWidth*(i+1);
                Console.WriteLine();
            }
            Console.ReadKey();


            void FillTriangle()
            {
                for (int i = 0;i<row;i++)
                {
                    triangle[i,0]=1;
                    triangle[i,i]=1;
                }
                
                for (int i = 2; i<row;i++)
                {
                    for (int j =1;j<=i;j++)
                    {
                        triangle[i,j]=triangle[i-1,j-1]+triangle[i-1,j];
                    }
                }
            }

            void Print()
            {
                for (int i = 0; i<row;i++)
                {
                    for (int j = 0;j < row;j++)
                    {
                        if (triangle[i,j]!=0) Console.Write($"{triangle[i,j],cellWidth}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
