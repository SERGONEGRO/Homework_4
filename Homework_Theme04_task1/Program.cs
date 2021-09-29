﻿using System;
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
            int[] badprofit = new int[12];
            int goodProfit = 0;               //Количество месяцев с положительной прибылью
            int minValue;
            int minIndex;

            int count = 3;              //кол-во месяцев с худшей прибылью, по умолчанию 3

            //Заполнение и вывод на экран массивов дохода, расхода, прибыли
            Console.WriteLine("Месяц\t Доход,тыс.руб.\tРасход,тыс.руб.\tПрибыль,тыс.руб");
            for (int i = 0; i < 12; i++)
            {
                income[i] = rand.Next(0, 2) * 100;
                expens[i] = rand.Next(1, 2) * 100;
                profit[i] = income[i] - expens[i];
                if (profit[i] > 0) goodProfit++;

                Console.WriteLine($"{i + 1} \t{income[i]} \t\t{expens[i]} \t\t{profit[i]}");
            }
            Console.WriteLine($"\nКоличество месяцев с положительной прибылью: {goodProfit}");

            //вычисление 3х месяцев с самой низкой прибылью
            Console.WriteLine($"\n Месяцы с 3 худшими прибылями: ");

            Array.Copy(profit,badprofit,12);    //делаем копию массива
            Array.Sort(badprofit);

            for (int j = 0; j < count; j++)
            {
                for (int i=0; i < 12; i++)
                {
                    //если прибыль в числе худших, печатаем все месфцы с такой прибылью
                    if (profit[i]==badprofit[j])
                    {
                        Console.WriteLine($"{i + 1} \t\t{badprofit[j]}");
                        profit[i]=int.MaxValue;                             //присваиваем максимально значение, чтобы вывести месяц из сравнения
                    } 
                    
                }
                //если несколько месяцев с одинаково плохой прибылью, то увеличиваем значение count
                if (badprofit[j]==badprofit[j+1] && count<11) { count++;}               
               
            }
            Console.ReadKey();

        }
    }
}
