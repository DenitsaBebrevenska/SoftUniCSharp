using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public Car()
        {
            Weight = "n/a";
            Color = "n/a";
        }
        public Car(string model, Engine engine) : this ()
        {
            Model = model;
            Engine = engine;
        }

        public override string ToString()
        {
            return $"{Model}:\n" +
                   $" {Engine}\n" +
                   $" Weight: {Weight}\n" +
                   $" Color: {Color}";
        }
    }
}
