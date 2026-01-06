using BalatonCLI;
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
        static List<Haz> hazak = new List<Haz>();

        public MainWindow()
        {
            InitializeComponent();
            Feladat1();
            dtgAdatok.ItemsSource = hazak;
            cbxValaszt.Items.Add("A");
            cbxValaszt.Items.Add("B");
            cbxValaszt.Items.Add("C");
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
    }
}