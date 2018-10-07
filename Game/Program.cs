using System;
using System.Threading;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Game game = new Game();
                game.Play();
                Console.WriteLine(game.RollScoreToString());
                Console.WriteLine(game.Score());
                Thread.Sleep(1000);
            }
            Console.ReadLine();

        }
    }
}
