using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace Astroids
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Nave a;
        DispatcherTimer elTimer, elTimer2, elTimer3;
        Astros h;
        List<Astros> lista = new List<Astros>();
        List<Nave> listan = new List<Nave>();
        Random random = new Random();

        bool up = false, down = false, left = false, right = false, enter = false;
        int pre = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                up = false;
            }
            if (e.Key == Key.Down)
            {
                down = false;
            }
            if (e.Key == Key.Right)
            {
                right = false;
            }
            if (e.Key == Key.Left)
            {
                left = false;
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (pre == 0)
            {
                if (e.Key == Key.Enter)
                {
                    tITLE.Visibility = Visibility.Hidden;
                    lblSPACE.Visibility = Visibility.Hidden;
                    enter = false;
                    a = new Nave(60, 500, 500);
                    listan.Add(a);
                    a.Dibujar(elEspacio);
                    a.deltax = 20;
                    a.deltay = 20;
                    pre++;
                    Poner();
                }
            }
            if (pre > 0)
            {
                if (e.Key == Key.Up)
                {
                    up = true;
                }
                if (e.Key == Key.Down)
                {
                    down = true;
                }
                if (e.Key == Key.Right)
                {
                    right = true;
                }
                if (e.Key == Key.Left)
                {
                    left = true;
                }
                a.Mover(up, down, right, left, elEspacio);
            }
        }
        private void elTimer_Tick(object sender, EventArgs e)
        {
            foreach (Astros f in lista)
            {
                f.Muevetex(elEspacio);
                f.Colision(listan, elEspacio);
            }
        }
        public void Poner()

        {
            elTimer = new DispatcherTimer();
            elTimer.Interval = TimeSpan.FromMilliseconds(.5);
            elTimer.Tick += elTimer_Tick;
            elTimer2 = new DispatcherTimer();
            elTimer2.Interval = TimeSpan.FromSeconds(3);
            elTimer2.Tick += elTimer2_Tick;
            elTimer2.Start();
        }
        private void elTimer2_Tick(object sender, EventArgs e)
        {
            for (int x = 0; x < 20; x++)
            {
                int figura = random.Next(1, 6);
                int lado = 20;
                int posX = random.Next(1, (int)elEspacio.ActualWidth - 35);
                int posY = random.Next(1, (int)elEspacio.ActualHeight - 35);
                h = new Astros(lado, posX, posY);
                h.Color = Colors.WhiteSmoke;
                h.Dibujar(elEspacio);
                lista.Add(h);
                h.deltax = random.Next(-5, 5);
                h.deltay = random.Next(-5, 5);
                if (h.deltax == 0)
                {
                    h.deltax++;
                }
                if (h.deltay == 0)
                {
                    h.deltay++;
                }
            }
            elTimer.Start();
            elTimer2.Stop();
            elTimer3 = new DispatcherTimer();
            elTimer3.Interval = TimeSpan.FromSeconds(30);
            elTimer3.Tick += elTimer3_Tick;
            elTimer3.Start();
        }

        private void elTimer3_Tick(object sender, EventArgs e)
        {
            for (int x = 0; x < 20; x++)
            {
                int figura = random.Next(1, 6);
                int posX = random.Next(1, (int)elEspacio.ActualWidth - 35);
                int posY = random.Next(1, (int)elEspacio.ActualHeight - 35);
                h = new Astros(20, posX, posY);
                h.Color = Colors.WhiteSmoke;
                h.Dibujar(elEspacio);
                lista.Add(h);
                h.deltax = random.Next(-5, 5);
                h.deltay = random.Next(-5, 5);
                if (h.deltax == 0)
                {
                    h.deltax++;
                }
                if (h.deltay == 0)
                {
                    h.deltay++;
                }
            }
        }
    }
}



        // b = new Astros(70, 600, 500);
        // b.Dibujar(elEspacio);
        //C = new Astros(35, 800, 500);
        //C.Dibujar(elEspacio);
        //d = new Laser(10, 900,500);
        //d.Dibujar(elEspacio);
    
     