using System.IO;

namespace GuessWho
{
    using System;

    class Program
    {
        public static bool Debug = true;

        static void Main(string[] args)
        {
            using (var writer = File.CreateText("result.csv"))
            {
                for (var i = 0; i < 1000; i++)
                {
                    var game = new Game();
                    game.PlayGame();
                    writer.WriteLine(game.Rounds);
                }
            }

            Console.WriteLine("All Done");
            Console.ReadLine();
        }
    }
}
