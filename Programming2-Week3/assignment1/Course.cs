using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Course
    {
        public string Name;
        public int TheoryGrade;
        public PracticalGrade PracticalGrade;
        public bool Passed()
        {
            if(TheoryGrade >= 55 && (PracticalGrade.ToString() == "Good" || PracticalGrade.ToString() == "Sufficient")){
                return true;
            }
           
            return false;
        }
        
        public bool Cumlaude()
        {
            if (TheoryGrade >= 80 && PracticalGrade.ToString() == "Good"){
                return true;
            }
            
            return false;
        }
    }  
}
