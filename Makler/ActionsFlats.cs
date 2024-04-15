using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Makler
{
    /// <summary>
    /// Класс предназначенный для меню и действиями над квартирами
    /// </summary>
    class ActionsFlats
    {
        private List<Flat> flats = new List<Flat>();
        /// <summary>
        /// Метод добавления квартиры
        /// </summary>
        public void AddFlat()
        {
            Write("Введите количество комнат: ");
            int countRooms;
            while (!int.TryParse(ReadLine(), out countRooms) || countRooms <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                Write("Введите количество комнат: ");
            }

            Write("Введите площадь в кв.м: ");
            double area;
            while (!double.TryParse(ReadLine(), out area) || area <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите положительное число.");
                Write("Введите площадь в кв.м: ");
            }

            Write("Введите этаж: ");
            int floor;
            while (!int.TryParse(ReadLine(), out floor) || floor <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                Write("Введите этаж: ");
            }

            Write("Введите район: ");
            string region;
            while (string.IsNullOrEmpty(region = ReadLine().Trim()))
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите непустое значение.");
                Write("Введите район: ");
            }
            WriteLine();
            bool foundRequired = false;
            foreach (var reqFlat in flats.Where(f => f is RequiredFlat))
            {
                if (reqFlat.Floor == floor &&
                    reqFlat.CountRooms == countRooms &&
                    reqFlat.Region == region &&
                    Math.Abs(reqFlat.Area - area) <= area * 0.1)
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("\nОбнаружено совпадение с требуемой квартирой. Удаляем из списка требуемых квартир.");
                    ResetColor();
                    WriteLine();
                    flats.Remove(reqFlat);
                    foundRequired = true;
                    break; // Выходим из цикла, чтобы не искать дальше
                }

            }
            if (!foundRequired)
            {
                HavingFlat havingFlat = new HavingFlat(countRooms, area, floor, region, DateTime.Now);
                flats.Add(havingFlat);
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Новая квартира успешно добавлена.");
                ResetColor();
                WriteLine();
            }
        }
        /// <summary>
        /// Метод записи полей квартиры
        /// </summary>
        public void WriteFlat()
        {
            Write("Введите количество комнат: ");
            int countRooms;
            while (!int.TryParse(ReadLine(), out countRooms) || countRooms <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                Write("Введите количество комнат: ");
            }

            Write("Введите площадь в кв.м: ");
            double area;
            while (!double.TryParse(ReadLine(), out area) || area <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите положительное число.");
                Write("Введите площадь в кв.м: ");
            }

            Write("Введите этаж: ");
            int floor;
            while (!int.TryParse(ReadLine(), out floor) || floor <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                Write("Введите этаж: ");
            }

            Write("Введите район: ");
            string region;
            while (string.IsNullOrEmpty(region = ReadLine().Trim()))
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите непустое значение.");
                Write("Введите район: ");
            }
            SearchAndManageApartments(floor, countRooms, area, region);
        }
        /// <summary>
        /// Метод осуществяющий поиск квартир
        /// </summary>
        /// <param name="floor">Этаж</param>
        /// <param name="roomCount">Количество комнат</param>
        /// <param name="area">Площадь</param>
        /// <param name="region">Район</param>
        public void SearchAndManageApartments(int floor, int roomCount, double area, string region)
        {
            Flat foundFlat = null;
            foreach (var flat in flats)
            {
                if (flat.Floor == floor &&
                    flat.CountRooms == roomCount &&
                    flat.Region == region &&
                    Math.Abs(flat.Area - area) <= area * 0.1)
                {

                    foundFlat = flat;
                    break;
                }
            }

            if (foundFlat != null)
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("\nНайдена подходящая квартира:");
                ResetColor();
                foundFlat.Info();
                WriteLine();
                flats.Remove(foundFlat);
            }
            else
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("\nПодходящая квартира не найдена. Добавляем новую квартиру в картотеку.");
                ResetColor();
                WriteLine();
                RequiredFlat requiredFlat = new RequiredFlat(roomCount, area, floor, region, DateTime.Now);
                flats.Add(requiredFlat);
            }
        }
        /// <summary>
        /// Вывод информации о квартирах 
        /// </summary>
        public void Info()
        {
            //Проверка есть ли вообще квартиры 
            bool requiredFlatsExist = false;
            bool havingFlatsExist = false;

            foreach (var apartment in flats)
            {
                if (apartment is RequiredFlat)
                {
                    requiredFlatsExist = true;
                    break;
                }
            }

            foreach (var apartment in flats)
            {
                if (apartment is HavingFlat)
                {
                    havingFlatsExist = true;
                    break;
                }
            }
            //Если нет, то выводит сообщение 
            if (!requiredFlatsExist && !havingFlatsExist)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Квартиры отсутствуют в картотеке.");
                ResetColor();
                WriteLine();
                return;
            }
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Требуемые: ");
            ResetColor();

            foreach (var apartment in flats)
            {
                if (apartment is RequiredFlat)
                {
                    apartment.Info();
                }
            }
            WriteLine();
            ForegroundColor = ConsoleColor.Blue;
            WriteLine("Имеющиеся: ");
            ResetColor();

            foreach (var apartamet in flats)
            {
                if (apartamet is HavingFlat)
                {
                    apartamet.Info();
                }
            }
            WriteLine();
        }
        /// <summary>
        /// Метод который выгружает данные с файла
        /// </summary>
        /// <param name="actionsFlats">Экземпляр класса</param>
        public void LoadDataFromFile(ActionsFlats actionsFlats)
        {
            string filePath = @"E:\Kyrsova24\Makler\Base.txt";

            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        string[] data = line.Split(';');
                        if (data.Length >= 6)
                        {
                            string type = data[0];
                            int countRooms = int.Parse(data[1]);
                            double area = double.Parse(data[2]);
                            int floor = int.Parse(data[3]);
                            string region = data[4];
                            DateTime addedTime = DateTime.Parse(data[5]);

                            if (type == "REQ")
                            {
                                RequiredFlat requiredFlat = new RequiredFlat(countRooms, area, floor, region, addedTime);
                                actionsFlats.flats.Add(requiredFlat);
                            }
                            else if (type == "HAV")
                            {
                                HavingFlat havingFlat = new HavingFlat(countRooms, area, floor, region, addedTime);
                                actionsFlats.flats.Add(havingFlat);
                            }
                        }
                    }


                }
                else
                {
                    WriteLine("Файл с данными не найден. Создан новый файл.");
                    File.Create(filePath).Close();
                }
            }
            catch (Exception ex)
            {
                WriteLine($"Ошибка при загрузке данных из файла: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод для сохранения данных в файл
        /// </summary>
        /// <param name="actionsFlats">Экземпляр класса</param>
        public void SaveDataToFile(ActionsFlats actionsFlats)
        {
            string filePath = @"E:\Kyrsova24\Makler\Base.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Flat flat in actionsFlats.flats)
                    {
                        if (flat is RequiredFlat requiredFlat)
                        {
                            writer.WriteLine($"REQ;{requiredFlat.CountRooms};{requiredFlat.Area};{requiredFlat.Floor};{requiredFlat.Region};{requiredFlat.AddedTime}");
                        }
                        else if (flat is HavingFlat havingFlat)
                        {
                            writer.WriteLine($"HAV;{havingFlat.CountRooms};{havingFlat.Area};{havingFlat.Floor};{havingFlat.Region};{havingFlat.AddedTime}");
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                WriteLine($"Ошибка при сохранении данных в файл: {ex.Message}");
            }
        }
    }
}

