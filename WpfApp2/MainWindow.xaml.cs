using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Fuvar> list = new List<Fuvar>();
        List<Fuvar> hibasLista = new List<Fuvar>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fajl = new OpenFileDialog();

            if (fajl.ShowDialog() == true)
            {
                StreamReader sr = new StreamReader(fajl.FileName);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] data = line.Split(";");
                    Fuvar item = new Fuvar(Convert.ToInt16(data[0]), Convert.ToDateTime(data[1]), Convert.ToInt16(data[2]), Convert.ToDouble(data[3]), Convert.ToDouble(data[4]), Convert.ToDouble(data[5]), data[6]);
                    list.Add(item);
                }
                lbEredmenyek.Items.Add($"Utazások: {list.Count()}");
                lbEredmenyek.Items.Add($" ");
                lbEredmenyek.Items.Add($"{list.Where(x => x.Azonosito == 6185).ToList().Count()} Fuvar alatt: {list.Where(x => x.Azonosito == 6185).ToList().Sum(x => x.Viteldij)}$");
                lbEredmenyek.Items.Add($" ");
                lbEredmenyek.Items.Add($"5.Feladat:");
                lbEredmenyek.Items.Add($"Bankkártya: {list.Where(x => x.FizetesiMod == "bankkártya").ToList().Count()}");
                lbEredmenyek.Items.Add($"Készpénz: {list.Where(x => x.FizetesiMod == "készpénz").ToList().Count()}");
                lbEredmenyek.Items.Add($"Vitatott: {list.Where(x => x.FizetesiMod == "vitatott").ToList().Count()}");
                lbEredmenyek.Items.Add($"Ingyenes: {list.Where(x => x.FizetesiMod == "ingyenes").ToList().Count()}");
                lbEredmenyek.Items.Add($"Ismeretlen: {list.Where(x => x.FizetesiMod == "ismeretlen").ToList().Count()}");
                lbEredmenyek.Items.Add($" ");
                lbEredmenyek.Items.Add($"6.feladat:");
                lbEredmenyek.Items.Add($"{Math.Round(list.Select(x => x.Tavolsag).Sum() * 1.6, 2)}km");
                lbEredmenyek.Items.Add($" ");
                lbEredmenyek.Items.Add($"7.feladat:");
                lbEredmenyek.Items.Add($"Adatok:");
                lbEredmenyek.Items.Add($"Fuvar Hossza: {list.Select(x => x).OrderByDescending(x => x.Tavolsag).ToList().First().UtazasIdotartama}");
                lbEredmenyek.Items.Add($"Taxi Azonosito: {list.Select(x => x).OrderByDescending(x => x.Tavolsag).ToList().First().Azonosito}");
                lbEredmenyek.Items.Add($"Megtett tavolsag: {list.Select(x => x).OrderByDescending(x => x.Tavolsag).ToList().First().Tavolsag}");
                lbEredmenyek.Items.Add($"Viteldij: {list.Select(x => x).OrderByDescending(x => x.Tavolsag).ToList().First().Viteldij}");



                StreamWriter sw = new StreamWriter("hibak.txt");
                sw.WriteLine();
                list.Where(x => x.UtazasIdotartama > 0 && x.Viteldij > 0).ToList().ForEach(x => hibasLista.Add(x));

                foreach (Fuvar adat in hibasLista)
                {
                    sw.WriteLine($"{adat.Azonosito};{adat.IndulasIdo};{adat.UtazasIdotartama};{adat.Tavolsag};{adat.Viteldij};{adat.Borravalo};{adat.FizetesiMod};");
                }

            }

        }
    }
}
