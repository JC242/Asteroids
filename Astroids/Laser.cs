using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Astroids
{
    class Laser:Figuras
    {
        public int lado { get; set; }
        private Rectangle laser;
        public Laser(int lado, int posX, int posY) : 
            base(4, posX, posY)
        {
            this.lado = lado;
            laser = new Rectangle();
            figura = laser;
        }
        public override void Dibujar(Canvas elEspacio)
        {
            laser.Width = lado;
            laser.Height = lado;
            laser.Fill = brocha;
            elEspacio.Children.Add(laser);
            Canvas.SetLeft(laser, posX);
            Canvas.SetTop(laser, posY);
        }
    }
}
