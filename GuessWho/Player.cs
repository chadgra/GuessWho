namespace GuessWho
{
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Player : IPlayer
    {
        public Player()
        {
            this.GameBoard = new GameBoard();
            Trace.WriteLineIf(Program.Debug, "Shhhhhh. I choose " + this.GameBoard.MysteryPerson.Name);
        }

        public virtual bool ReadyToGuessPerson
        {
            get; protected set;
        }

        public virtual bool HasGuessedPerson
        {
            get; protected set;
        }

        public bool FigureredItOut
        {
            get; protected set;
        }

        protected GameBoard GameBoard
        {
            get; private set;
        }

        public virtual void TakeTurn(IPlayer otherPlayer)
        {
            if (this.GameBoard.Characters.Count == 1)
            {
                int test = 5;
            }
            var question = this.ReadyToGuessPerson ? this.GuessPerson() : this.AskQuestion();
            var result = otherPlayer.AnswerQuestion(question);
            var remainingCharacters = new List<Character>();

            foreach (var character in this.GameBoard.Characters)
            {
                if (result == question(character))
                {
                    remainingCharacters.Add(character);
                }
            }

            this.GameBoard.Characters = remainingCharacters;
            this.FigureredItOut = this.HasGuessedPerson && (remainingCharacters.Count == 1) && result;
        }

        public virtual Question AskQuestion()
        {
            return character => false;
        }

        public virtual Question GuessPerson()
        {
            return character => false;
        }

        public virtual bool AnswerQuestion(Question question)
        {
            var result = question(this.GameBoard.MysteryPerson);
            Trace.WriteLineIf(Program.Debug, result);
            return result;
        }
    }
}
