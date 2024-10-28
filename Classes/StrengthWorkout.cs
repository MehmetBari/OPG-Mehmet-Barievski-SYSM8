using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITTRACK_PROJEKTUPPGIFT_OPG.Classes
{
    public class StrengthWorkout : Workout
    {
        //Egenskaper 
        public int Repetitions { get; set; }

        //Konstruktor

        public StrengthWorkout(int repetitions)
        {
            this.Repetitions = repetitions;
        }
        //Metod 
        public override int CalculateCaloriesBurned()
        {
            throw new NotImplementedException();
        }

    }
}
