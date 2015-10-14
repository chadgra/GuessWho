namespace GuessWho
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class NormalPlayer : Player
    {
        private static readonly Random random = new Random((int)DateTime.Now.Ticks + 27);

        public NormalPlayer()
        {
            this.QueriedFeatures = new List<string>();
        }

        public List<string> QueriedFeatures
        {
            get; private set;
        }

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
            // Pick a feature - any feature
            var remainingFeatures = new List<string>();
            foreach (var character in this.GameBoard.Characters)
            {
                remainingFeatures.AddRange(character.Features);
            }

            //remainingFeatures = remainingFeatures.Distinct().ToList();
            remainingFeatures = remainingFeatures.Except(this.QueriedFeatures).ToList();
            var feature = remainingFeatures[random.Next(0, remainingFeatures.Count - 1)];
            Trace.WriteLineIf(Program.Debug, "Do they have " + feature);

            // Store the feature so we don't ask about it again.
            this.QueriedFeatures.Add(feature);

            return character => character.Features.Contains(feature);
        }

        public override Question GuessPerson()
        {
            this.HasGuessedPerson = true;
            var name = this.GameBoard.Characters[random.Next(0, this.GameBoard.Characters.Count - 1)].Name;
            Trace.WriteLineIf(Program.Debug, "Is there name " + name);
            return character => character.Name == name;
        }
    }
} 
