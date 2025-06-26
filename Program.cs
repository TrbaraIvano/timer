using System;
using System.Threading;
using System.Timers;

namespace TimerApp
{
    public class Stopwatch
    {

        public static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.DoTimer();
        }

        public void DoTimer()
        {
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

        public static void StopFor3Sec()
        {
            int count = 1;

            do
            {
                Console.Beep();
                Thread.Sleep(1000);
                count++;

            } while (count < 3);
        }
    }
}