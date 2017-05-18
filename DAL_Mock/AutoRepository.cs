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
            string[] allLines = File.ReadAllLines(@"d:\work\auto_DB.txt", Encoding.Default);
            for (int i = 0; i < allLines.Length; i++)
            {
                string line = allLines[i];  
                string[] inf = line.Split(' ', ';'); 
                string Model = inf[0];
                string Name = inf[1];
                string Color = inf[2]; 
                int MaxSpeed = Convert.ToInt32(inf[3]);
                int Price = Convert.ToInt32(inf[4]); 
                double FuelConsuption = Convert.ToDouble(inf[5]);
                {
                    Auto infAuto = new Auto(Model, Name,  Color, MaxSpeed, Price, FuelConsuption); 
                    lstAuto.Add(infAuto);
                }
            }
            return lstAuto;
        }



        public void Add(Auto auto)
        {
            StreamWriter clear_1 = new StreamWriter(@"d:\work\auto_DB.txt", false, Encoding.Default);
            clear_1.Close(); // Закрываем поток
            lstAuto.Add(auto);
            foreach (Auto WriteAuto in lstAuto) 
            {
                StreamWriter ConsumptionWriter = new StreamWriter(@"d:work\auto_DB.txt", true, Encoding.Default); 
                ConsumptionWriter.Write("{0} ", WriteAuto.Model);
                ConsumptionWriter.Write("{0} ", WriteAuto.Name);
                ConsumptionWriter.Write("{0} ", WriteAuto.Color); 
                ConsumptionWriter.Write("{0} ", WriteAuto.MaxSpeed); 
                ConsumptionWriter.Write("{0} ", WriteAuto.Price);
                ConsumptionWriter.Write("{0};\n", WriteAuto.FuelConsuption);
                ConsumptionWriter.Close();
            }
            return;
        }

        public void Remove(string name)
        {
            StreamWriter clear_1 = new StreamWriter(@"d:\work\auto_DB.txt", false, Encoding.Default); 
            clear_1.Close();

            lstAuto.AsReadOnly();
            foreach (Auto WriteAuto in lstAuto)
            {
                if (name == WriteAuto.Model)
                    continue;
                StreamWriter ConsumptionWriter = new StreamWriter(@"d:work\auto_DB.txt", true, Encoding.Default);
                ConsumptionWriter.Write("{0} ", WriteAuto.Model);
                ConsumptionWriter.Write("{0} ", WriteAuto.Name);
                ConsumptionWriter.Write("{0} ", WriteAuto.Color); 
                ConsumptionWriter.Write("{0} ", WriteAuto.MaxSpeed);
                ConsumptionWriter.Write("{0} ", WriteAuto.Price); 
                ConsumptionWriter.Write("{0};\n", WriteAuto.FuelConsuption);
                ConsumptionWriter.Close();
            }
            return;
        }

        public Auto GetAutoByName(string name)
        {
            throw new NotImplementedException();
        }


    }
}
