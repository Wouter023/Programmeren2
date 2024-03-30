﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2
{
    internal struct Person
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public string City;
        public GenderType Gender;
    }

    internal enum GenderType
    {
        m, f
    }
}
