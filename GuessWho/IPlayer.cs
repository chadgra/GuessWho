namespace GuessWho
{
    public delegate bool Question(Character character);

    public interface IPlayer
    {
        bool ReadyToGuessPerson { get; }

        bool HasGuessedPerson { get; }

        bool FigureredItOut { get; }

        void TakeTurn(IPlayer otherPlayer);

        Question AskQuestion();

        Question GuessPerson();

        bool AnswerQuestion(Question question);
    }
}
