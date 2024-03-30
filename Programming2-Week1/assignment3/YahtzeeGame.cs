using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    internal class YahtzeeGame
    {
        const int NumberOfDices = 5;
        Dice[] dices = new Dice[NumberOfDices];
        public void Init()
        {
            for (int i = 0; i < dices.Length; i++)
            {
                dices[i] = new Dice();
            }
        }

        public void Throw()
        {
            for (int i = 0; i < dices.Length; i++)
            {
                dices[i].Throw();
            }
        }

        public void DisplayValues()
        {
            for (int i = 0; i < dices.Length; i++)
            {
                dices[i].DisplayValue();
            }
            Console.WriteLine();
        }

        public bool Yahtzee()
        {

            for (int i = 1; i < dices.Length; i++)
            {
                if (dices[i].value != dices[0].value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
