namespace GuessWho
{
    using System.Diagnostics;

    public class Game
    {
        public Game()
        {
            this.Player1 = new SimplePlayer();
            this.Player2 = new SimplePlayer();
        }

        public IPlayer Player1
        {
            get; set;
        }

        public IPlayer Player2
        {
            get; set;
        }

        public int Rounds
        {
            get; set;
        }

        public void PlayGame()
        {
            do
            {
                this.Rounds++;
                this.Player1.TakeTurn(this.Player2);
            } while (!this.Player1.FigureredItOut);

            Trace.WriteLineIf(Program.Debug, this.Rounds);
        }
    }
}
