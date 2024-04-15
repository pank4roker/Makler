using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Makler
{
    /// <summary>
    /// Наследуемый класс от квартиры - Имеющаяся квартира
    /// </summary>
    class HavingFlat : Flat
    {
        public HavingFlat() { }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="countRooms">Количество комнат</param>
        /// <param name="area">Площадь</param>
        /// <param name="floor">Этаж</param>
        /// <param name="region">Район</param>
        /// <param name="addedTime">Время добавления</param>
        public HavingFlat(int countRooms, double area, int floor, string region, DateTime addedTime) : base(countRooms, area, floor, region, addedTime) { }
        /// <summary>
        /// Переопределенный метод вывода информации
        /// </summary>
        public override void Info()
        {
            WriteLine($"Количество комнат: {CountRooms}; Площадь: {Area}  кв.м; Этаж: {Floor}; Район: {Region}; Время добавления: {AddedTime.ToString("dd MMM HH:mm")}");
        }
    }

}
