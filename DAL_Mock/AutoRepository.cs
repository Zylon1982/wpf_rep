using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL_Mock
{
    using Model;
    using Repository;
    public class AutoRepository : IAutoRepository
    {
        private static List<Auto> lstAuto = new List<Auto>();

        public IEnumerable<Auto> GetAll()
        {
            lstAuto.Clear();
            string[] allLines = File.ReadAllLines(@"d:\work\auto_DB.txt", Encoding.Default); // читаем строки текстового файла в массив
            for (int i = 0; i < allLines.Length; i++) // в цикле пробегаем по каждой строке
            {
                string line = allLines[i];  // читаем заданную строку в переменную line
                string[] inf = line.Split(' ', ';');  // строку разбиваем на слова разделенными пробелами и записываем их в элементы массива inf
                string ModelName = inf[0]; // инициализация переменной Id считанным словом 
                string Color = inf[1]; // инициализация переменной ModelName считанным словом
                int MaxSpeed = Convert.ToInt32(inf[2]); // инициализация переменной MaxCargo считанным словом
                int Price = Convert.ToInt32(inf[3]); // инициализация переменной Passangers считанным словом
                double FuelConsuption = Convert.ToDouble(inf[4]); // инициализация переменной FuelLoad считанным словом
                {
                    Auto infAuto = new Auto(ModelName, Color, MaxSpeed, Price, FuelConsuption); // создаем объект infAirPlane
                    lstAuto.Add(infAuto); // сохраняем в лист lstAirPlane объект infAirPlane
                }
            }
            return lstAuto;
        }



        public void Add(Auto auto)
        {

            StreamWriter clear_1 = new StreamWriter(@"d:\work\auto_DB.txt", false, Encoding.Default); // открываем поток для записи в файл с кодировкой по умолчанию и стираем содержимое файла
            clear_1.Close(); // Закрываем поток
            lstAuto.Add(auto);
            foreach (Auto WriteAuto in lstAuto) // цикл foreach для просмотра UsedRatesList и после запись данных в файл
            {
                StreamWriter ConsumptionWriter = new StreamWriter(@"d:work\auto_DB.txt", true, Encoding.Default); // открываем поток для записи в файл с кодировкой по умолчанию
                ConsumptionWriter.Write("{0} ", WriteAuto.ModelName); // запись в файл фамилии клиента
                ConsumptionWriter.Write("{0} ", WriteAuto.Color); // запись в файл имени клиента
                ConsumptionWriter.Write("{0} ", WriteAuto.MaxSpeed); // запись в файл местных звонков
                ConsumptionWriter.Write("{0} ", WriteAuto.Price); // запись в файл междугородних звонков
                ConsumptionWriter.Write("{0};\n", WriteAuto.FuelConsuption); // запись в файл международных звонков
                ConsumptionWriter.Close();// Закрываем поток
            }
            return;
        }

        public void Remove(string name)
        {
            throw new NotImplementedException();
        }

        public Auto GetAutoByName(string name)
        {
            throw new NotImplementedException();
        }


    }
}
