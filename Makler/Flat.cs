using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makler
{
    /// <summary>
    /// Абстрактный класс описывающий квартиры
    /// </summary>
    public abstract class Flat
    {
        /// <summary>
        /// Cвойства кваритиры
        /// </summary>
        public int CountRooms { get; set; }
        public double Area { get; set; }
        public int Floor { get; set; }
        public string Region { get; set; }
        public DateTime AddedTime { get; }
        public Flat() { }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="countRooms">Количество комнат</param>
        /// <param name="area">Площадь</param>
        /// <param name="floor">Этаж</param>
        /// <param name="region">Район</param>
        /// <param name="addedTime">Время добавления</param>
        public Flat(int countRooms, double area, int floor, string region, DateTime addedTime)
        {
            CountRooms = countRooms;
            Area = area;
            Floor = floor;
            Region = region;
            AddedTime = addedTime;
        }
        /// <summary>
        /// Метод вывода всей информации
        /// </summary>
        public abstract void Info();

    }
}
