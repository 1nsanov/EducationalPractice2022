﻿using Helper;
using Task_04_04;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        var swicth = true;
        while (swicth)
        {
            Console.WriteLine("Q - Построить линиию | W - Выход из программы");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    Console.Clear();                    
                    var line = new Line();
                    line.SetPoints();
                    line.GetСoefficientStraight();
                    Help.StopperConsole();
                    break;
                case ConsoleKey.W:
                    Console.Clear();
                    swicth = false;
                    break;
                default:
                    Console.WriteLine("Такой команды не существует");
                    break;
            }
        }
    }
}