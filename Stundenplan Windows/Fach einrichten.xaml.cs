using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Stundenplan
{
    /// <summary>
    /// Interaktionslogik für Fach_einrichten.xaml
    /// </summary>
    /// 

    public partial class Fach_einrichten : Window
    {
        private string Color = "Red";
        private string Speichername;

        public Fach_einrichten()
        {
            InitializeComponent();
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream auslesen = new FileStream(@"Temp.txt", FileMode.Open, FileAccess.Read);

            Fach fach2 = (Fach)formatter.Deserialize(auslesen);
            Taganzeige.Text = fach2.Farbe;
            Speichername = fach2.FachName;
            auslesen.Close();
        }

        private void F0_Click(object sender, RoutedEventArgs e)
        {
            ColorBox.Fill = Brushes.Red;
            Color = "Red";
        }
       
        private void F1_Click(object sender, RoutedEventArgs e)
        {
            ColorBox.Fill = Brushes.Blue;
            Color = "Blue";
        }

        private void F2_Click(object sender, RoutedEventArgs e)
        {
            ColorBox.Fill = Brushes.Yellow;
            Color = "Yellow";
        }

        private void F3_Click(object sender, RoutedEventArgs e)
        {
            ColorBox.Fill = Brushes.Purple;
            Color = "Purple";
        }

        private void F4_Click(object sender, RoutedEventArgs e)
        {
            ColorBox.Fill = Brushes.Green;
            Color = "Green";
        }

        private void F5_Click(object sender, RoutedEventArgs e)
        {
            ColorBox.Fill = Brushes.Brown;
            Color = "Brown";
        }

        private void F6_Click(object sender, RoutedEventArgs e)
        {
            ColorBox.Fill = Brushes.Orange;
            Color = "Orange";
        }

        private void F7_Click(object sender, RoutedEventArgs e)
        {
            ColorBox.Fill = Brushes.White;
            Color = "White";
        }

        private void F8_Click(object sender, RoutedEventArgs e)
        {
            ColorBox.Fill = Brushes.Beige;
            Color = "Beige";
        }

        private void F9_Click(object sender, RoutedEventArgs e)
        {
            ColorBox.Fill = Brushes.Coral;
            Color = "Coral";
        }

        private void F10_Click(object sender, RoutedEventArgs e)
        {
            ColorBox.Fill = Brushes.DeepPink;
            Color = "DeepPink";
        }

        private void F11_Click(object sender, RoutedEventArgs e)
        {
            ColorBox.Fill = Brushes.Gray;
            Color = "Gray";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(FachName.Text != "" && FachName.Text != "Fachname hier eingeben")
            {
                Fach fach1 = new Fach(FachName.Text, Color);
                FileStream stream = new FileStream(Speichername + ".txt", FileMode.Create, FileAccess.Write);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, fach1);
                stream.Close();
                this.Close();
            }
            else
            {
                
            }
        }
    }
}
