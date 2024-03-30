using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2
{
    class HangmanGame
    {
        public string secretWord;
        public string guessedWord;

        public void Init(string SecretWord)
        {
            foreach(char c in SecretWord)
            {
                secretWord += c;
                guessedWord += $".";
            }
        }

        public bool ContainsLetter(char letter)
        {
            if (secretWord.Contains(letter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ProcessLetter(char letter)
        {
            char[] array = guessedWord.ToArray();
            for (int i = 0; i < secretWord.Length; i++)
            {
                if(letter == secretWord[i])
                {
                    array[i] = letter;
                }
            }
            guessedWord = new string(array);
        }

        public bool IsGuessed()
        {
            if(guessedWord == secretWord)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
