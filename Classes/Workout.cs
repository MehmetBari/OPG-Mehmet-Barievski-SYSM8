using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace FITTRACK_PROJEKTUPPGIFT_OPG.Classes
{
    public abstract class Workout
    {
        //Egenskaper

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public TimeSpan Duration { get; set; }

        public int CaloriesBurned { get; set; }

        public string Notes { get; set; } 

        //Konstruktor 

        public Workout(DateTime Date, string Type, string Notes, TimeSpan Duration, int CaloriesBurned)
        {
            this.Date = Date;
            this.Type = Type;
            this.Notes = Notes;
            this.Duration = Duration;
            this.CaloriesBurned = CaloriesBurned;
        }
        //Metod 

        public abstract int CalculateCaloriesBurned();
    }
}
