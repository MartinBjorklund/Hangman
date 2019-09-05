using System;
using System.Collections.Generic;

namespace Hangman4
{
    class Program
    {
        static string correctword = "norrlandsdjup";
        static char[] letters; 
        static string name;
        static List<char> guessedLetters = new List<char>();
        static void Main(string[] args)
        {
            StartGame();
            PlayGame();
            EndGame();
        }
        
        private static void StartGame()
        {
            letters = new char[correctword.Length];
            for (int i = 0; i < correctword.Length; i++)
            letters[i] = '-';

            EnterUsersName();
           
        }

        static void EnterUsersName()
        {
            Console.WriteLine("What's your name?");
            string input = Console.ReadLine();
            if (input.Length >= 2)
                name = input;
            else
            {
                Console.WriteLine("invalid username...");
                EnterUsersName();

            }
            
            
        }
        private static void PlayGame()
        {
            do
            {
               Console.Clear();
               DisplayMaskedWord();
               char guessedLetter = AskForLetter();
               CheckLetter(guessedLetter);

            } while (correctword != new string(letters));
            Console.Clear();
        }
        

        private static void CheckLetter(char guessedLetter)
        {
            for (int i = 0; i < correctword.Length; i++)
            {
                if (guessedLetter == correctword[i])
                letters[i] = guessedLetter;
            }
        }

        static void DisplayMaskedWord()
        {
            foreach (char c in letters)
                Console.Write(c);
           
            Console.WriteLine();
        }
        static char AskForLetter()
        {
            string input;
            do
            {
                  Console.WriteLine("Enter a letter:");
                  input = Console.ReadLine();

            } while (input.Length != 1);

            var letter = input[0];
            if (!guessedLetters.Contains(letter))
                guessedLetters.Add(letter);

            return letter;
        }
        private static void EndGame()
        {
            Console.WriteLine("Correct word: " + correctword);
            Console.WriteLine($"Thank you {name}!");
            Console.WriteLine($"Total number of guesses: {guessedLetters}");
        }
    }
}
