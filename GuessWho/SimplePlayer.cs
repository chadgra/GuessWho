namespace GuessWho
{
    using System;
    using System.Diagnostics;

    public class SimplePlayer : Player
    {
        private static readonly Random random = new Random((int)DateTime.Now.Ticks + 27);

        public override bool ReadyToGuessPerson
        {
            get { return true; }
            protected set
            {
                base.ReadyToGuessPerson = value;
            }
        }

        public override Question AskQuestion()
        {
            return this.GuessPerson();
        }

        public override Question GuessPerson()
        {
            this.HasGuessedPerson = true;
            var name = this.GameBoard.Characters[random.Next(0, this.GameBoard.Characters.Count - 1)].Name;
            Trace.WriteLineIf(Program.Debug, "Is there name " + name);
            return (character) => character.Name == name;
        }
    }
} 
