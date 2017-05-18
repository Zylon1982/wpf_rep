using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Auto
    {
        public Auto(string model, string name, string color, int maxSpeed, int price, double fuelConsuption)
        {
            Model = model;
            Name = name;
            Color = color;
            MaxSpeed = maxSpeed;
            Price = price;
            FuelConsuption = fuelConsuption;
        }

        public string Model { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int MaxSpeed { get; set; }
        public int Price { get; set; }
        public double FuelConsuption { get; set; }
    }
}
