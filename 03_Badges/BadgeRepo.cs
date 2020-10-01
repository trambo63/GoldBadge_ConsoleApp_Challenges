using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class BadgeRepo : Badge
    {
        
        protected readonly Dictionary<int, List<Doors>> _badgeDictionary = new Dictionary<int, List<Doors>>();
        public bool AddBadge(Badge badge)
        {
            int startingCount = _badgeDictionary.Count;
            _badgeDictionary.Add(badge.Id, badge.DoorsList);
            bool wasAdded = (_badgeDictionary.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public Dictionary<int, List<Doors>> GetBadges()
        {
            return _badgeDictionary;
        }


    }
}
