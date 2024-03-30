using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    internal class Dice
    {
        public int value;
        static Random rnd = new Random();
        public void Throw()
        {
            value = rnd.Next(1, 7);
        }

        public void DisplayValue()
        {
            Console.Write(value);
        }
    }
}
