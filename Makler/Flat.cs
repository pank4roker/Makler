using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makler
{
    public abstract class Flat
    {
        public int CountRooms { get; set; }
        public double Area { get; set; }
        public int Floor { get; set; }
        public string Region { get; set; }
        public DateTime AddedTime { get; }
        public Flat() { }
        public Flat(int countRooms, double area, int floor, string region, DateTime addedTime)
        {
            CountRooms = countRooms;
            Area = area;
            Floor = floor;
            Region = region;
            AddedTime = addedTime;
        }
        public abstract void Info();

    }
}
