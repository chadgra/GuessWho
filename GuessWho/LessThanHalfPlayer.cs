namespace GuessWho
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class LessThanHalfPlayer : Player
    {
        private static readonly Random random = new Random((int)DateTime.Now.Ticks + 27);

        public override bool ReadyToGuessPerson
        {
            get { return this.GameBoard.Characters.Count == 1; }
            protected set
            {
                base.ReadyToGuessPerson = value;
            }
        }

        public override Question AskQuestion()
        {
            // Our question should apply to this many people
            var targetSize = (this.GameBoard.Characters.Count - 1) / 2;
            targetSize = Math.Max(targetSize, 1);

            // Get all the features
            var remainingFeatures = new List<string>();
            foreach (var character in this.GameBoard.Characters)
            {
                remainingFeatures.AddRange(character.Features);
            }

            remainingFeatures = remainingFeatures.Distinct().ToList();
            var question = this.CalculateFeatures(targetSize, new List<string>(), remainingFeatures);

            return question;
        }

        private Question CalculateFeatures(int target, List<string> firstGroup, List<string> secondGroup)
        {
            var newSecondGroup = new List<string>(secondGroup);
            foreach (var feature in secondGroup)
            {
                var newFirstGroup = new List<string>(firstGroup) {feature};
                Question question = (character) => character.ContainsAny(newFirstGroup);
                if (target == this.GameBoard.CharactersThatMatch(question))
                {
                    Trace.WriteLineIf(Program.Debug, "Do they have " + string.Join(" or ", newFirstGroup));
                    return question;
                }

                newSecondGroup.Remove(feature);
                question = CalculateFeatures(target, newFirstGroup, newSecondGroup);
                if (null != question)
                {
                    return question;
                }
            }

            return null;
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
