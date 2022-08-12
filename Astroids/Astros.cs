using System;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;
using System.Collections.Generic;

namespace Astroids
{
    class Astros: Figuras
    {
        public int lado { get; set; }
        private Polygon astros;

        public double espacioH
        {
            get { return lado * Math.Cos(1.0472); }
        }
        public double espacioV
        {
            get { return lado * Math.Sin(1.0472); }
        }
        public Astros(int lado, int posX, int posY) :
            base(4, posX, posY)
        {
            this.lado = lado;
            astros = new Polygon();
            figura = astros;
        }
        public override void Dibujar(Canvas elCanvas)
        {
            Point punto1 = new Point(espacioH, 0);
            Point punto2 = new Point(0, espacioV);
            Point punto3 = new Point(espacioH, 2 * espacioV);
            Point punto4 = new Point(espacioH + lado, 2 * espacioV);
            Point punto5 = new Point(2 * espacioH + lado, espacioV);
            Point punto6 = new Point(espacioH + lado, 0);
            astros.Points.Add(punto1);
            astros.Points.Add(punto2);
            astros.Points.Add(punto3);
            astros.Points.Add(punto4);
            astros.Points.Add(punto5);
            astros.Points.Add(punto6);
            astros.Stroke = brocha;
            elCanvas.Children.Add(astros);
            Canvas.SetLeft(astros, posX);
            Canvas.SetTop(astros, posY);
        }
        public void Colision(List<Nave> otros, Canvas elCanvas)
        {
            int vida = 3;
            foreach (Nave c in otros)
            {
                bool up = false, down = false, right = false, left = false;
                if (posX + 20 >= c.posX)
                {
                    left = true;
                }
                if (posX <= c.posX)
                {
                    right = true;
                }
                if (posY + 20 >= c.posY)
                {
                    up = true;
                }
                if (posY <= c.posY)
                {
                    down = true;
                }
                if (up && down && left && right)
                {
                    elCanvas.Children.Remove(c.nave);
                }
            }
        }

    }
}
