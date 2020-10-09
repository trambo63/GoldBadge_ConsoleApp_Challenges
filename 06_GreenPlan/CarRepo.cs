using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan
{
    public class CarRepo : Car
    {
        protected readonly List<Car> _carDB = new List<Car>();

        public bool AddCar(Car car)
        {
            int startingCount = _carDB.Count();
            _carDB.Add(car);
            bool isGreater = (_carDB.Count() > startingCount)? true : false;
            return isGreater;
        }

        public List<Car> GetAllCars()
        {
            return _carDB;
        }


    }
}
