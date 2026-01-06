using System.Diagnostics;

namespace BalatonCLI
{
    public class Program
    {
        static List<Haz> hazak = new List<Haz>();
        static int[] adoKategoriak;
        static void Main(string[] args)
        {
            Feladat1();
            Feladat2();
            Feladat3();
            Ado("A", 100);
            Feladat5();
            Feladat6();
        }

        public static void Feladat6()
        {
            StreamWriter sw = new StreamWriter("teljes.txt");
            foreach (Haz i in hazak)
            {
                sw.WriteLine($"{i.Telekadoszam} {i.Utcaneve} {i.Hazszam} {i.Adosav} {i.Terulet} {Ado(i.Adosav, i.Terulet)}");
            }
        }

        public static void Feladat5()
        {
            List<Haz> ATelkek = new();
            List<Haz> BTelkek = new();
            List<Haz> CTelkek = new();

            foreach(Haz haz in hazak)
            {
                switch (haz.Adosav)
                {
                    case "A":
                        ATelkek.Add(haz);
                        break;
                    case "B":
                        BTelkek.Add(haz);
                        break;
                    case "C":
                        CTelkek.Add(haz);
                        break;
                }
            }


        }

        public static int Ado(string adosav, int terulet)
        {
            int ado = 0;
            if(adosav == "A")
            {
               ado = adoKategoriak[0] * terulet;
            }
            else if(adosav == "B")
            {
                ado = adoKategoriak[1] * terulet;
            }
            else if (adosav == "C")
            {
                ado = adoKategoriak[2] * terulet;
            }
            if (ado < 10000)
            {
                return 0;
            }
            else
            {
                return ado;
            }
        }

        public static void Feladat3()
        {
            Console.WriteLine("3. Feladat: egy tulajdonos adószáma: ");
            int adoszam = Convert.ToInt32(Console.ReadLine());

            List<Haz> keresett = hazak.Where(h => h.Telekadoszam == adoszam).ToList();  
            bool van = false;
            foreach (Haz i in hazak)
            {
                if(i.Telekadoszam == adoszam)
                {
                    Console.WriteLine($"\t{i.Utcaneve} utca {i.Hazszam}0");
                    van = true;
                }
            }
            if (!van)
            {
                Console.WriteLine("Nem szerepel az adatállományban.");
            }
        }

        public static void Feladat2()
        {
            Console.WriteLine($"2. Feladat. A mintában {hazak.Count} telek szerepel."); 
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
