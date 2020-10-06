using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class Badge
    {
        public int Id { get; set; }
        public List<Doors> DoorsList { get; set; }

        public Badge() { }
        public Badge(int id, List<Doors> doors)
        {
            Id = id;
            DoorsList = doors; 
        }
    }

    public class Doors : Badge
    {
        public string Door1 { get; set; }
        public string Door2 { get; set; }
        public string Door3 { get; set; }
        public string Door4 { get; set; }
        public string Door5 { get; set; }
        public string Door6 { get; set; }
        public string Door7 { get; set; }
        public string Door8 { get; set; }

        public Doors() { }
        
        public void GetDoor1()
        {
            Door1 = "A1";
        }
        public void GetDoor2()
        {
            Door2 = "A2";
        }
        public void GetDoor3()
        {
            Door3 = "A3";
        }
        public void GetDoor4()
        {
            Door4 = "A4";
        }
        public void GetDoor5()
        {
            Door5 = "B1";
        }
        public void GetDoor6()
        {
            Door6 = "B2";
        }
        public void GetDoor7()
        {
            Door7 = "B3";
        }
        public void GetDoor8()
        {
            Door8 = "B4";
        }
    }
}
