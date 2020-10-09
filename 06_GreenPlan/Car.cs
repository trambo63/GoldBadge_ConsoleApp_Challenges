using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan
{
    public enum CarType { Electric, Hybrid, Gas}
    public enum SateyRating { One_Star, Two_Star, Three_Star, Four_Star, Five_Star }
    public enum FuelEfficiencyRating { Poor, Fair, Good, Excellent }
    public class Car
    {
        //Classes are the user defined data types that represent the state and behaviour of an object. 
        //State represents the properties and behaviour is the action that objects can perform.
        public CarType CarType { get; set; }
        public double AverageCost { get; set; }
        public SateyRating SateyRating { get; set; }
        public FuelEfficiencyRating FuelEfficiencyRating { get; set; }

        public Car() { }
        public Car(CarType carType, double averageCost, SateyRating safeyRating, FuelEfficiencyRating fuelEfficiencyRating)
        {
            CarType = carType;
            AverageCost = averageCost;
            SateyRating = safeyRating;
            FuelEfficiencyRating = fuelEfficiencyRating;
        }
    }
}
