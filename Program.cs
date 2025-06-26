using System;
using System.Threading;
using System.Timers;

namespace TimerApp
{
    public class Stopwatch
    {

        public static void Main(string[] args)
        {
        }

        public void DoTimer()
        {

            Stopwatch timer = new Stopwatch();
            timer.DoTimer();
            int minuten = 0;
            int sekunden = 0;
            int millisekunden = 0;
            bool end = false;

            while (!end)
            {
                millisekunden++;

namespace Timer
{
    public class Timer
    {
        public static void Main()
        {

            Console.Write("Willst du Countdown oder Timer: ");
            string input= Console.ReadLine();
            if (input == "Countdown")
            {
                Countdown();
            }
            else if (input== "Timer")
            {
                
            }
            Console.SetCursorPosition(50, 7);
            
            Console.WriteLine();

        }
        public static void Countdown()
        {
            Console.Write("Wie lang dauert der Countdown (s, min, h): ");
            string input = Console.ReadLine();
            int totalSec = 0;
            bool valid = false;

            do
            {
                input = input.Trim();
                
                if(input.Length>= 2 && input.Contains("s") && input[input.Length-1] == 's')
                {
                    string numberPart = "";
                    for (int i = 0; i< input.Length-1; i++)
                    {
                        numberPart = numberPart + input[i];
                    }
                    int number = 0;
                    if(int.TryParse(numberPart, out number)  && number>=0)
                    {
                        totalSec = number;
                        valid = true;
                    }

                }
                else if(input.Length>= 2 && input.Contains("min") && input[input.Length-1] == 'n')
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
                Console.SetCursorPosition(50,7);
                Console.WriteLine($"Countdown: {i} Sekunden");
                Thread.Sleep(1000);
            }
            Console.Clear();
            Console.SetCursorPosition(0,7);
            Console.WriteLine("Countdown abgelaufen!");
        }
    }
}