using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Astroids
{
    abstract class Figuras
    {
        public int lados { get; set; }
        public double posX { get; set; }
        public double posY { get; set; }
        public int deltax { get; set; }
        public int deltay { get; set; }
        private Color color { get; set; }
        protected Shape figura { get; set; }
        protected SolidColorBrush brocha { get; set; }
        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                brocha = new SolidColorBrush(color);
            }
        }

        public Figuras(int lados, double posX, double posY)
        {
            this.lados = lados;
            this.posX = posX;
            this.posY = posY;
            deltax = 1;
            deltay = 1;
            color = Colors.Gray;
            brocha = new SolidColorBrush(color);
        }
        public abstract void Dibujar(Canvas elEspacio);

        public virtual void Muevetex(Canvas elEspacio)
        {
            if (posX + figura.ActualWidth > elEspacio.ActualWidth + 200 || posX <0)
            {
                deltax *= -1;
            }
            posX += deltax;
            Canvas.SetLeft(figura, posX);
            if (posY + figura.ActualHeight > elEspacio.ActualHeight +200|| posY < 0)
            {
                deltay *= -1;
            }
            posY += deltay;
            Canvas.SetTop(figura, posY);
        }
    }
}
