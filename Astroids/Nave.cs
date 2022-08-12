using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Astroids
{
    class Nave:Figuras
    {
        public int lado { get; set; }
        private double angulo { get; set; }
        public int Deltangulo { get; set; }
        public double altura
        {
            get
            {
                double ladoCuadrado = lado * lado;
                double medioladocuadrado = Math.Pow(lado / 2, 2);
                double resta = ladoCuadrado - medioladocuadrado;
                return Math.Sqrt(resta);
            }
        }
        public Polygon nave;
        public Nave(int lado, int posX, int posY) : 
            base(3, posX, posY)
        {
            this.lado = lado;
            Deltangulo = 1;
            nave = new Polygon();
            figura = nave;
        }
        public override void Dibujar(Canvas elEspacio)
        {
            Point punto1 = new Point(0, altura);
            Point punto2 = new Point(lado/2, altura-(altura/4));
            Point punto3 = new Point(lado, altura);
            Point punto4 = new Point(lado / 2, 0);
            nave.Points.Add(punto1);
            nave.Points.Add(punto2);
            nave.Points.Add(punto3);
            nave.Points.Add(punto4);
            nave.Fill = brocha;
            elEspacio.Children.Add(nave);
            Canvas.SetLeft(nave, posX);
            Canvas.SetTop(nave, posY);
        }
        public void Mover(bool up, bool down , bool right, bool left, Canvas elCanvas)
        {
            if (right)
            {
                nave.RenderTransform = new RotateTransform(angulo, lado / 2, altura / 2);
                angulo = angulo + Deltangulo > 360 ? 0 : angulo + Deltangulo;
            }
            if (left)
            {
                nave.RenderTransform = new RotateTransform(angulo, lado / 2, altura / 2);
                angulo = angulo + Deltangulo > 360 ? 0 : angulo - Deltangulo;
            }
            if (up)
            {
                posX += Math.Sin((angulo) * (Math.PI / 180)) * deltax;
                posY -= Math.Cos((angulo) * (Math.PI / 180)) * deltay;
                if (angulo == 2 * Math.PI) { angulo = 0; }
            }
            if (down)
            {
                posX -= Math.Sin((angulo) * (Math.PI / 180)) * deltax;
                posY += Math.Cos((angulo) * (Math.PI / 180)) * deltay;
                if (angulo == 2 * Math.PI) { angulo = 0; }
            }
            if (posX + nave.ActualWidth >= elCanvas.ActualWidth)
            {
                posX = 0;
            }
            if (posX + nave.ActualWidth <= 0)
            {
                posX = (int)(elCanvas.ActualWidth - nave.ActualHeight);
            }
            if (posY + nave.ActualHeight >= elCanvas.ActualHeight)
            {
                posY = 0;
            }
             if (posY + nave.ActualHeight <= 0)
            {
                posY= (int)(elCanvas.ActualHeight - nave.ActualHeight);

            }
            Canvas.SetLeft(nave, posX);
            Canvas.SetTop(nave, posY);
        }
      
    }
}
