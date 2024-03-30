using Microsoft.VisualBasic;
using System.Numerics;
using System;
using System.Linq;

namespace assignment2
{
    internal class Program
    {
        const int MaximunAttempts = 8;
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            HangmanGame hangman = new HangmanGame();
            hangman.Init(SelectWord(ListOfWords()));
            
            if(PlayHangman(hangman) == true)
            {
                Console.WriteLine($"you guessed the word");
            }
            else
            {
                Console.WriteLine($"Too bad, you did not guess the word ({hangman.secretWord})");
            }
        }

        int ReadInt(string question)
        {
            Console.WriteLine(question);
            return int.Parse(Console.ReadLine());
        }

        int ReadInt(string question, int min, int max)
        {
            int value;
            do
            {
                value = ReadInt(question);
            }
            while (value < min || value > max);

            return value;
        }

        string ReadString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        List<string> ListOfWords()
        {
            List<string> words = new List<string>(){"airplane", "kitchen", "building", "incredible", "funny", "trainstation", "neighbour", "different", "department", "planet", "presentation", "embarrassment", "integration", "scenario", "discount", "management", "understanding", "registration", "security", "language"};
            return words;
        }

        string SelectWord(List<string> words)
        {
            Random random = new Random();
            int wordNumber = random.Next(0, words.Count);
            string word = words[wordNumber];
            return word;
        }

        bool PlayHangman(HangmanGame hangman)
        {
            List<char> enteredLetters = new List<char>();
            int attempts = MaximunAttempts;
            DisplayWord(hangman.guessedWord);

            do
            {
                Console.Write($"Enter a letter: ");
                char enteredLetter = ReadLetter(enteredLetters);
                enteredLetters.Add(enteredLetter);
                
                if (hangman.ContainsLetter(enteredLetter) == false)
                {
                    attempts--;
                }

                DisplayLetters(enteredLetters);
                Console.WriteLine();
                hangman.ProcessLetter(enteredLetter);
                Console.WriteLine($"Attempts left:{attempts}");
                DisplayWord(hangman.guessedWord);

                if (hangman.IsGuessed() == true)
                {
                    return true;
                }
            } while (attempts > 0);
            return false;
        }

        void DisplayWord(string word)
        {
            foreach (char c in word)
            {
                Console.Write($"{c} ");
            }
            Console.WriteLine();
        }

        void DisplayLetters(List<char> blacklistLetters)
        {
            Console.Write("Entered letters: ");
            foreach (char c in blacklistLetters)
            {
                Console.Write($"{c} ");
            }
        }

        char ReadLetter(List<char> blacklistLetters)
        {
            char input;
            do
            {
                input = char.Parse(Console.ReadLine());
            } while (blacklistLetters.Contains(input));
            return input;
        }
    }
}