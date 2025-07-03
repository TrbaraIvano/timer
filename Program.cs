using Spectre.Console;
using System;
using System.Threading;
using System.Timers;

namespace WorkoutTimerApp
{
    public class Stopwatch
    {

        public static void Main()
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Willst du [green]Countdown[/] oder [green]Timer[/]?")
                    .PageSize(10)
                    .AddChoices(["Countdown", "Timer"]));

            if (choice == "Countdown")
            {
                Countdown();
            }
            else if (choice == "Timer")
            {
                Stopwatch timer = new Stopwatch();
                timer.DoTimer();
            }
            Console.SetCursorPosition(50, 7);

            Console.WriteLine();

        }

        public void DoTimer()
        {
            Console.Clear();
            Console.CursorVisible = false;

            int minuten = 0;
            int sekunden = 0;
            int millisekunden = 0;
            bool end = false;

            while (!end)
            {
                millisekunden++;
                if (millisekunden >= 100)
                {
                    millisekunden = 0;
                    sekunden++;

                    if (sekunden >= 60)
                    {
                        StopFor3Sec();
                        sekunden = 0;
                        minuten++;
                    }
                }


                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"{minuten:D2}:{sekunden:D2}:{millisekunden:D2}");


                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Enter)
                    {
                        end = true;
                    }
                }

                Thread.Sleep(1);
            }

        }
        public void StopFor3Sec()
        {
            int count = 0;


            while (count < 3)
            {
                Console.Beep();
                Thread.Sleep(1000);
                count++;
            }
        }

        public static void Countdown()
        {
            Console.Clear();
            Console.Write("Wie lang dauert der Countdown (s, min, h): ");
            string input = Console.ReadLine();
            int totalSec = 0;
            bool valid = false;

            do
            {
                input = input.Trim();

                if (input.Length >= 2 && input.Contains("s") && input[input.Length - 1] == 's')
                {
                    string numberPart = "";
                    for (int i = 0; i < input.Length - 1; i++)
                    {
                        numberPart = numberPart + input[i];
                    }
                    int number = 0;
                    if (int.TryParse(numberPart, out number) && number >= 0)
                    {
                        totalSec = number;
                        valid = true;
                    }

                }
                else if (input.Length >= 2 && input.Contains("min") && input[input.Length - 1] == 'n')
                {
                    string numberPart = "";
                    for (int i = 0; i < input.Length - 3; i++)
                    {
                        numberPart = numberPart + input[i];
                    }
                    int number = 0;
                    if (int.TryParse(numberPart, out number) && number >= 0)
                    {
                        totalSec = number * 60;
                        valid = true;
                    }
                }
                else if (input.Length >= 2 && input.Contains("h") && input[input.Length - 1] == 'h')
                {
                    string numberPart = "";
                    for (int i = 0; i < input.Length - 1; i++)
                    {
                        numberPart = numberPart + input[i];
                    }
                    int number = 0;
                    if (int.TryParse(numberPart, out number) && number >= 0)
                    {
                        totalSec = number * 3600;
                        valid = true;
                    }
                }

            } while (!valid);

            for (int i = totalSec; i >= 0; i--)
            {
                Console.Clear();
                Console.SetCursorPosition(50, 7);
                Console.WriteLine($"Countdown: {i} Sekunden");
                Thread.Sleep(1000);
            }
            Console.Clear();
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("Countdown abgelaufen!");
        }
    }
}