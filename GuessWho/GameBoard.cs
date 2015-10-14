using System.Linq;

namespace GuessWho
{
    using System;
    using System.Collections.Generic;

    public class GameBoard
    {
        private static readonly Random random = new Random();

        public GameBoard()
        {
            this.Characters = new List<Character>();
            this.Characters.Add(new Character("Claire", new List<string> { "Woman", "Ginger Hair", "Hat", "Glasses" }));
            this.Characters.Add(new Character("Eric", new List<string> { "Yellow Hair", "Hat" }));
            this.Characters.Add(new Character("Maria", new List<string> { "Woman", "Brown Hair", "Hat" }));
            this.Characters.Add(new Character("George", new List<string> { "White Hair", "Hat" }));
            this.Characters.Add(new Character("Bernard", new List<string> { "Brown Hair", "Hat", "Bulbous Nose" }));
            this.Characters.Add(new Character("Sam", new List<string> { "White Hair", "Bald", "Glasses" }));
            this.Characters.Add(new Character("Tom", new List<string> { "Black Hair", "Bald", "Blue Eyes", "Glasses" }));
            this.Characters.Add(new Character("Paul", new List<string> { "White Hair", "Glasses" }));
            this.Characters.Add(new Character("Joe", new List<string> { "Yellow Hair", "Glasses" }));
            this.Characters.Add(new Character("Frans", new List<string> { "Ginger Hair" }));
            this.Characters.Add(new Character("Anne", new List<string> { "Woman", "Black Hair" }));
            this.Characters.Add(new Character("Max", new List<string> { "Black Hair", "Moustache", "Thick Lips", "Bulbous Nose" }));
            this.Characters.Add(new Character("Alex", new List<string> { "Black Hair", "Moustache", "Thick Lips" }));
            this.Characters.Add(new Character("Philip", new List<string> { "Black Hair", "Beard", "Rosy Cheeks" }));
            this.Characters.Add(new Character("Bill", new List<string> { "Ginger Hair", "Bald", "Beard", "Rosy Cheeks" }));
            this.Characters.Add(new Character("Anita", new List<string> { "Woman", "Yellow Hair", "Rosy Cheeks", "Blue Eyes" }));
            this.Characters.Add(new Character("David", new List<string> { "Yellow Hair", "Beard" }));
            this.Characters.Add(new Character("Charles", new List<string> { "Yellow Hair", "Moustache", "Thick Lips" }));
            this.Characters.Add(new Character("Herman", new List<string> { "Ginger Hair", "Bald", "Bulbous Nose" }));
            this.Characters.Add(new Character("Peter", new List<string> { "White Hair", "Thick Lips", "Blue Eyes", "Bulbous Nose" }));
            this.Characters.Add(new Character("Susan", new List<string> { "Woman", "White Hair", "Rosy Cheeks", "Thick Lips" }));
            this.Characters.Add(new Character("Robert", new List<string> { "Brown Hair", "Rosy Cheeks", "Blue Eyes", "Bulbous Nose" }));
            this.Characters.Add(new Character("Richard", new List<string> { "Brown Hair", "Bald", "Moustache", "Beard" }));
            this.Characters.Add(new Character("Alfred", new List<string> { "Ginger Hair", "Moustache", "Blue Eyes" }));

            this.MysteryPerson = this.Characters[random.Next(0, this.Characters.Count - 1)];
        }

        public List<Character> Characters
        {
            get; set;
        }

        public Character MysteryPerson
        {
            get; private set;
        }

        public int CharactersThatMatch(Question question)
        {
            return this.Characters.Sum(character => question(character) ? 1 : 0);
        }
    }
}
