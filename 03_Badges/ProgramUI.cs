using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class ProgramUI
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();
        readonly List<Doors> _doorList1 = new List<Doors>();
        readonly List<Doors> _doorList2 = new List<Doors>();

        public void Run()
        {
            SeedData();
            RunMenu();
        }

        private void RunMenu()
        {
            bool keepThinking = true;
            while (keepThinking)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, What would you like to do? \n" +
                    "1. Add a badge \n" +
                    "2. Edit a badge. \n" +
                    "3. List all badges \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        keepThinking = false;
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddNewBadge()
        {
            Console.Clear();
            Badge myBadge = new Badge();
            List<Doors> doorList = new List<Doors>();
            Doors access = new Doors();
            Console.WriteLine("Enter Badge Number: ");
            myBadge.Id = Convert.ToInt32(Console.ReadLine());
            bool keepThinking = true;
            while (keepThinking)
            {
                Console.Clear();
                Console.WriteLine("Which doors would you like to add to this Badge \n" +
                    "Level A: A1, A2, A3, A4 \n" +
                    "Level B: B1, B2, B3, B4 \n" +
                    "Type x and hit enter to exit Menu");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "A1":
                        access.GetDoor1();
                        break;
                    case "A2":
                        access.GetDoor2();
                        break;
                    case "A3":
                        access.GetDoor3();
                        break;
                    case "A4":
                        access.GetDoor4();
                        break;
                    case "B1":
                        access.GetDoor5();
                        break;
                    case "B2":
                        access.GetDoor6();
                        break;
                    case "B3":
                        access.GetDoor7();
                        break;
                    case "B4":
                        access.GetDoor8();
                        break;
                    case "x":
                        keepThinking = false;
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        Console.ReadKey();
                        break;
                }
            }
            doorList.Add(access);
            myBadge.DoorsList = doorList;
            
            Console.WriteLine("Press any key to continue.........");
            Console.ReadKey();
            _badgeRepo.AddBadge(myBadge);
        }

        private void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("Type the ID# of the Badge you want to edit, then press enter");
            Dictionary<int, List<Doors>> badges = _badgeRepo.GetBadges();
            foreach (var id in badges)
            {
                Console.WriteLine($"Badge ID: {id.Key}");
            }
            int userInput = Convert.ToInt32(Console.ReadLine());
            foreach (var id in badges.Keys)
            {
                if (userInput == id)
                {
                    badges.Remove(id);
                    Console.Clear();
                    Badge myBadge = new Badge();
                    List<Doors> doorList = new List<Doors>();
                    Doors access = new Doors();
                    Console.WriteLine("Re-Enter Badge Number: ");
                    myBadge.Id = Convert.ToInt32(Console.ReadLine());
                    bool keepThinking = true;
                    while (keepThinking)
                    {
                        Console.Clear();
                        Console.WriteLine("Which doors would you like to add to this Badge \n" +
                            "Level A: A1, A2, A3, A4 \n" +
                            "Level B: B1, B2, B3, B4 \n" +
                            "Type x and hit enter to exit Menu");
                        string userChoice = Console.ReadLine();
                        switch (userChoice)
                        {
                            case "A1":
                                access.GetDoor1();
                                break;
                            case "A2":
                                access.GetDoor2();
                                break;
                            case "A3":
                                access.GetDoor3();
                                break;
                            case "A4":
                                access.GetDoor4();
                                break;
                            case "B1":
                                access.GetDoor5();
                                break;
                            case "B2":
                                access.GetDoor6();
                                break;
                            case "B3":
                                access.GetDoor7();
                                break;
                            case "B4":
                                access.GetDoor8();
                                break;
                            case "x":
                                keepThinking = false;
                                break;
                            default:
                                Console.WriteLine("Invalid");
                                Console.ReadKey();
                                break;
                        }
                    }
                    doorList.Add(access);
                    myBadge.DoorsList = doorList;
                    _badgeRepo.AddBadge(myBadge);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }




            Console.WriteLine("Press any key to continue.........");
            Console.ReadKey();
        }

        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<Doors>> badges = _badgeRepo.GetBadges();
            foreach (var contents in badges.Keys)
            {
                foreach (var listMember in badges[contents])
                {
                    Console.WriteLine($"Badge ID: {contents} \n" +
                        $"Door Access: {listMember.Door1} {listMember.Door2} {listMember.Door3} {listMember.Door4} {listMember.Door5} {listMember.Door6} {listMember.Door7} {listMember.Door8}");
                }
            }
            Console.WriteLine("Press any key to continue.........");
            Console.ReadKey();
        }

        private void SeedData()
        {
            Doors access1 = new Doors();
            access1.GetDoor1();
            access1.GetDoor2();
            _doorList1.Add(access1);

            var badge1 = new Badge(1, _doorList1);
            _badgeRepo.AddBadge(badge1);

            Doors access2 = new Doors();
            access2.GetDoor1();
            access2.GetDoor2();
            access2.GetDoor3();
            _doorList2.Add(access2);

            var badge2 = new Badge(2, _doorList2);
            _badgeRepo.AddBadge(badge2);
        }
    }
}
