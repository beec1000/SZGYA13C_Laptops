using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LaptopsCLI
{
    public class Laptop
    {
        public Category Category { get; set; }
        public string CPU { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Model { get; set; }
        public string OS { get; set; }
        public double Price { get; set; }
        public int RAM { get; set; }
        public string Screen { get; set; }
        public string Storage { get; set; }

        public Laptop(Category category, string cpu, Manufacturer manufacturer, string model, string os, double price, int ram, string screen, string storage) 
        {
            Category = category;
            CPU = cpu;
            Manufacturer = manufacturer;
            Model = model;
            OS = os;
            Price = price;
            RAM = ram;
            Screen = screen;
            Storage = storage;
        }

        public static List<Laptop> FromFile(string path)
        {
            List<Laptop> laptops = new List<Laptop>();

            string[] temp = File.ReadAllLines(path);

            foreach (var t in temp.Skip(1))
            {
                string[] v = t.Split(';');

                Category Category = new Category(int.Parse(v[0]), v[1]);
                string CPU = v[2];
                Manufacturer Manufacturer = new Manufacturer(int.Parse(v[3]), v[4]);
                string Model = v[5];
                string OS = v[6];
                double Price = double.Parse(v[7]);
                int RAM = int.Parse(v[8]);
                string Screen = v[9];
                string Storage = v[10];

                Laptop laptop = new Laptop(Category, CPU, Manufacturer, Model, OS, Price, RAM, Screen, Storage);
                laptops.Add(laptop);
            }
            return laptops;
        }

        public override string ToString()
        {
            return $"{Category.CategoryName} | {Manufacturer.ManufacturerName} {Model} | {OS}";
        }
    }
}
