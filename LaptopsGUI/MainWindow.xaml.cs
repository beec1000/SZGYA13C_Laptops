using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LaptopsCLI;

namespace LaptopsGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Laptop> laptops = new List<Laptop>();
        int f15 = 0;
        public MainWindow()
        {
            InitializeComponent();

            laptops = Laptop.FromFile(@"..\..\..\..\LaptopsCLI\src\laptops.txt");

            //10. feladat
            var f10 = laptops.Select(f => $"{laptops.IndexOf(f) + 1}. {f.Manufacturer.ManufacturerName} {f.Model}").ToList();
            konfList.ItemsSource = f10/*laptops.ToString()*/;
            konfList.SelectedIndex = 0;
            konfList.Focus();

        }

        //10. feladat
        //public override string ToString()
        //{
        //    //return string.Join("\n", laptops.Select((f, index) => $"{index + 1}. {f.Manufacturer.ManufacturerName} {f.Model}"));
        //    string f10 = string.Empty;
        //    foreach (var l in laptops)
        //    {
        //        f10 = string.Join("\n", laptops.Select(f => $"{laptops.IndexOf(f) + 1}. {f.Manufacturer.ManufacturerName} {f.Model}"));
        //    }
        //    return f10;
        //}


        //14.feladat
        private void konfList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var f14 = laptops.Where(f => laptops.IndexOf(f) == konfList.SelectedIndex).ToList();
            foreach (var f in f14)
            {
                string[] screenData = f.Screen.Split('-');
                reszletesTXTB.Text = $"Kategória\n\t{f.Category.CategoryName}\n" +
                                     $"Képátló\n\t{screenData[0]}\n" +
                                     $"Felbontás\n\t{screenData[1]}\n" +
                                     $"Processzor\n\t{f.CPU}\n" +
                                     $"RAM\n\t{f.RAM} GB\n" +
                                     $"Háttértár(ak)\n\t{f.Storage}" +
                                     $"\nOperációs rendszer\n\t{f.OS}" +
                                     $"\nÁr\n\t{Math.Round(f.Price * 4.12)} Ft";
            }

            //15. feladat
            f15 += e.AddedItems.Count;
        }

        //15.feladat
        private void closeBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Ön {f15} termékünket tekintette meg. Visszavárjuk!", "", MessageBoxButton.OK);
            this.Close();
        }
    }
}