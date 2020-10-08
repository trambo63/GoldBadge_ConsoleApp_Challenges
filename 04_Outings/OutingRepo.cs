using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings
{
    public class OutingRepo : Outing
    {
        protected readonly List<Outing> _outingDB = new List<Outing>();

        public bool AddOuting(Outing outing)
        {
            int startingCount = _outingDB.Count();
            _outingDB.Add(outing);
            bool wasAdded = (_outingDB.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<Outing> GetAllOutings()
        {
            return _outingDB;
        }
    }
}
