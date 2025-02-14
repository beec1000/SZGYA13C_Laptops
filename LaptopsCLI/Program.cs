using System.IO;

namespace LaptopsCLI
{
    internal class Program
    {
        public static List<Laptop> laptops = new List<Laptop>();
        static void Main(string[] args)
        {
            laptops = Laptop.FromFile(@"..\..\..\src\laptops.txt");

            //5. feladat
            foreach (var l in laptops)
            {
                Console.WriteLine($"{laptops.IndexOf(l) + 1}. {l.ToString()} | {Math.Round(l.Price * 4.12)} HUF");
            }

            //6. feladat
            var f6 = laptops.Where(f => f.CPU.Contains("Intel Core i7") && f.Storage.Contains("SSD")).ToList();

            foreach (var l in f6)
            {
                Console.WriteLine($"[{f6.IndexOf(l) + 1}] {l.ToString()}");
            }
            var f6AVG = f6.Average(f => f.Price);
            Console.WriteLine($"A laptopok átlag ára: {f6AVG} INR");

            //7. feladat
            var f7 = laptops.Where(f => f.Category.CategoryName.Contains("Gaming")).OrderBy(f => f.Price).Take(20).ToList();
            var lines = f7.Select(l => $"{l.Manufacturer.ManufacturerName} {l.Model}\n\t{l.CPU} \n\t{l.Storage} \n\t{l.Screen}\n").ToList();
            File.WriteAllLines(@"..\..\..\src\cheap.txt", lines);

        }
    }
}
