using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace Stundenplan
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int Woche = 0;
        private new Button Tag;
        private string wfarbe;
        private string[] Tagladen = { "Montag1.txt", "Montag2.txt", "Montag3.txt" , "Montag4.txt" , "Montag5.txt",
        "Dienstag1.txt", "Dienstag2.txt", "Dienstag3.txt", "Dienstag4.txt", "Dienstag5.txt",
        "Mittwoch1.txt", "Mittwoch2.txt", "Mittwoch3.txt", "Mittwoch4.txt", "Mittwoch5.txt",
        "Donnerstag1.txt", "Donnerstag2.txt", "Donnerstag3.txt", "Donnerstag4.txt", "Donnerstag5.txt",
        "Freitag1.txt", "Freitag2.txt", "Freitag3.txt", "Freitag4.txt", "Freitag5.txt"};
        public MainWindow()
        {
            InitializeComponent();
            Fachladen();
        }

        private void Laden()
        {

        }

        public int i = 0;
        void Fachladen()
        {
            i = 0;
            while (i >= 0 && i != 25)
            {
                Button aendern = this.FindName("T" + i.ToString()) as Button;
                Debug.WriteLine("T" + i.ToString() + "     " + i);
                aendern.Content = "Fach wählen";
                aendern.Background = Brushes.LightGray;
                i++;
            }

            i = 0;
            while (i >= 0 && i != 25)
            {
                try
                {
                    if (Woche == 0)
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        FileStream auslesen = new FileStream(@"A" + Tagladen[i], FileMode.Open, FileAccess.Read);

                        Fach fach2 = (Fach)formatter.Deserialize(auslesen);
                        wfarbe = fach2.Farbe;
                        Tag = this.FindName("T" + i.ToString()) as Button;
                        Debug.WriteLine("T" + i.ToString());
                        Tag.Content = fach2.FachName;
                        Farbe();
                        auslesen.Close();
                    }
                    else
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        FileStream auslesen = new FileStream(@"B" +Tagladen[i], FileMode.Open, FileAccess.Read);

                        Fach fach2 = (Fach)formatter.Deserialize(auslesen);
                        wfarbe = fach2.Farbe;
                        Tag = this.FindName("T" + i.ToString()) as Button;
                        Tag.Content = fach2.FachName;
                        Farbe();
                        auslesen.Close();
                    }
                }
                catch
                {

                }

                i++;
            }
        }

        void Farbe()
        {
            if (wfarbe == "Red")
            {
                Tag.Background = Brushes.Red;
            }
            else if (wfarbe == "Blue")
            {
                Tag.Background = Brushes.Blue;
            }
            else if (wfarbe == "Yellow")
            {
                Tag.Background = Brushes.Yellow;
            }
            else if (wfarbe == "Purple")
            {
                Tag.Background = Brushes.Purple;
            }
            else if (wfarbe == "Green")
            {
                Tag.Background = Brushes.Green;
            }
            else if (wfarbe == "Brown")
            {
                Tag.Background = Brushes.Brown;
            }
            else if (wfarbe == "Orange")
            {
                Tag.Background = Brushes.Orange;
            }
            else if (wfarbe == "White")
            {
                Tag.Background = Brushes.White;
            }
            else if (wfarbe == "Beige")
            {
                Tag.Background = Brushes.Beige;
            }
            else if (wfarbe == "Coral")
            {
                Tag.Background = Brushes.Coral;
            }
            else if (wfarbe == "DeepPink")
            {
                Tag.Background = Brushes.DeepPink;
            }
            else if (wfarbe == "Gray")
            {
                Tag.Background = Brushes.Gray;
            }
        }

        private void Wochen_Click(object sender, RoutedEventArgs e)
        {
            if (Woche == 0)
            {
                Woche = 1;
                Wochen.Content = "B";
                Fachladen();
            }
            else
            {
                Woche = 0;
                Wochen.Content = "A";
                Fachladen();
            }
        }

        public string Tagbearbeiten;
        private string Tagbeschreibung;
        private void Montag1_Click(object sender, RoutedEventArgs e)
        {
            if(Woche == 0)
            {
                Tagbearbeiten = "AMontag1";
                SpeichernTemp();
            }
            else
            {
                Tagbearbeiten = "BMontag1";
                SpeichernTemp();
            }
        }

        private void Montag5_Click(object sender, RoutedEventArgs e)
        {
            if (Woche == 0)
            {
                Tagbearbeiten = "AMontag5";
                SpeichernTemp();
            }
            else
            {
                Tagbearbeiten = "BMontag5";
                SpeichernTemp();
            }
        }

        private void Montag4_Click(object sender, RoutedEventArgs e)
        {
            if (Woche == 0)
            {
                Tagbearbeiten = "AMontag4";
                SpeichernTemp();
            }
            else
            {
                Tagbearbeiten = "BMontag4";
                SpeichernTemp();
            }
        }

        private void Montag3_Click(object sender, RoutedEventArgs e)
        {
            if (Woche == 0)
            {
                Tagbearbeiten = "AMontag3";
                SpeichernTemp();
            }
            else
            {
                Tagbearbeiten = "BMontag3";
                SpeichernTemp();
            }
        }

        private void Montag2_Click(object sender, RoutedEventArgs e)
        {
            if (Woche == 0)
            {
                Tagbearbeiten = "AMontag2";
                SpeichernTemp();
            }
            else
            {
                Tagbearbeiten = "BMontag2";
                SpeichernTemp();
            }
        }

        private void SpeichernTemp()
        {
            Fach fach1 = new Fach(Tagbearbeiten, Tagbeschreibung);
            FileStream stream = new FileStream(@"Temp.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, fach1);
            stream.Close();
            Fach_einrichten window = new Fach_einrichten();
            window.Show();
        }

        private void Dientsag1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dientsag2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dientsag3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dientsag4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dientsag5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Mittwoch1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Mittwoch2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Mittwoch3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Mittwoch4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Mittwoch5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Donnerstag1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Donnerstag2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Donnerstag3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Donnerstag4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Donnerstag5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Freitag1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Freitag2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Freitag3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Freitag4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Freitag5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            Fachladen();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    [Serializable]
    public class Fach
    {
        public string FachName { get; set; }
        public string Farbe { get; set; }

        public string Tagbearbeiten { get; set; }

        public string Textoben { get; set; }

        public Fach(string firstName, string lastName)
        {
            FachName = firstName;
            Farbe = lastName;
        }
    }
}
