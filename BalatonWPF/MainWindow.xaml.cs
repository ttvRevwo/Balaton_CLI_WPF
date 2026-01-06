using BalatonCLI;
using System.Collections.ObjectModel;
using System.IO;
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

namespace BalatonWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static ObservableCollection<Haz> hazak = new ObservableCollection<Haz>();

        public MainWindow()
        {
            InitializeComponent();
            Feladat1();
            dtgAdatok.ItemsSource = hazak;
            cbxValaszt.Items.Add("A");
            cbxValaszt.Items.Add("B");
            cbxValaszt.Items.Add("C");
            cbxValaszt.SelectedIndex = 0;
        }

        public static void Feladat1()
        {
            StreamReader sr = new StreamReader("utca.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] tomb = sr.ReadLine().Split(' ');
                hazak.Add(new Haz(int.Parse(tomb[0]), tomb[1], tomb[2], tomb[3], int.Parse(tomb[4])));
            }
        }

        private void btnModosit_Click(object sender, RoutedEventArgs e)
        {
            if(dtgAdatok.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs kijelölve elem!");
            }
            else
            {
                switch (cbxValaszt.SelectedItem)
                {
                    case 0: hazak[dtgAdatok.SelectedIndex].SetAdosav("A"); break;
                    case 1: hazak[dtgAdatok.SelectedIndex].SetAdosav("B"); break;
                    case 2: hazak[dtgAdatok.SelectedIndex].SetAdosav("C"); break;
                }
            }
                
            dtgAdatok.Items.Refresh();
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("modositottadatok.txt");
                foreach(var i in hazak)
                {
                    sw.WriteLine($"{i.Telekadoszam} {i.Utcaneve} {i.Hazszam} {i.Adosav} {i.Terulet}");
                }
                sw.Close();
                MessageBox.Show("Sikeres mentés!");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Hiba a mentés során: {ex.Message}");
            }
        }
    }
}