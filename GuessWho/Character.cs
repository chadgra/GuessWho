namespace GuessWho
{
    using System.Collections.Generic;
    using System.Linq;

    public class Character
    {
        public Character(string name, List<string> features)
        {
            this.Name = name;
            this.Features = features;
        }

        public string Name
        {
            get; set;
        }

        public List<string> Features
        {
            get; private set;
        }

        public bool ContainsAll(List<string> features)
        {
            return features.All(f => this.Features.Contains(f));
        }

        public bool ContainsAny(List<string> features)
        {
            return features.Any(f => this.Features.Contains(f));
        }
    }
}
