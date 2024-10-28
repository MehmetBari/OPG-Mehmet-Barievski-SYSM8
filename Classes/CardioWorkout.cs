using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITTRACK_PROJEKTUPPGIFT_OPG.Classes
{
    public class CardioWorkout : Workout 
    {
        //Egenskaper
        public int Distance { get; set; }

        //Konstruktor

        public CardioWorkout(int Distance, DateTime Date, string Type, string Notes, TimeSpan Duration, int CaloriesBurned) : base (Date, Type, Notes, Duration, CaloriesBurned)
        {
            this.Distance = Distance;
        }
        //Metod 
        public override int CalculateCaloriesBurned()
        {
            throw new NotImplementedException();
        }
    }
}
