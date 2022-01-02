using System;

namespace TimerTask
{
    class Program
    {
        public class Gamer
        {
            public string Name { get; set; }

            public void SayGameIsOver (object sender, TimeIsOverEventArgs e)
            {
                Console.WriteLine($"{e.Msg} Game is over!");
            }
        }

        public class MyAdmin
        {
            public string Name { get; set; }

            public void SayGameIsOver (object sender, TimeIsOverEventArgs e)
            {
                Console.WriteLine($"{e.Msg} Time out. PC#1 is free!");
            }
        }
        static void Main(string[] args)
        {
            var timer = new Timer { Time = 1 };
            var artur = new Gamer { Name = "Artur" };
            var goodAdmin = new MyAdmin { Name = "Alex"};
            
            timer.TimeIsOver += artur.SayGameIsOver;
            timer.TimeIsOver += goodAdmin.SayGameIsOver;

            Console.WriteLine("NET.C#.10 Делегаты и события");

            timer.Start("Time of game - 1 min! ");
            
            Console.ReadLine();
        }
    }
}
