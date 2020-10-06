using System;
using System.Collections.Generic;
using _03_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Badges_Tests
{
    [TestClass]
    public class BadgesTests
    {
        [TestMethod]
        public void AddBadgeAddsBadge()
        {
            Badge badge = new Badge();
            BadgeRepo badgeRepo = new BadgeRepo();
            bool result = badgeRepo.AddBadge(badge);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetBadgesGetsBadges()
        {
            Badge badge = new Badge();
            Doors door = new Doors();
            BadgeRepo badgeRepo = new BadgeRepo();
            List<Doors> doorList = new List<Doors>();
            doorList.Add(door);
            badge.DoorsList = doorList;
            badge.Id = 1;
            badgeRepo.AddBadge(badge);
            Dictionary<int, List<Doors>> badges = badgeRepo.GetBadges();
            bool KeyNotEmpty = badges.ContainsKey(1);
            bool ValueNotEmpty = badges.ContainsValue(doorList);
            Assert.IsTrue(KeyNotEmpty);
            Assert.IsTrue(ValueNotEmpty);
        }
    }
}
