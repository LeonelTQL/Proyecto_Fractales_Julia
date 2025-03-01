using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Fractales_Julia.Class
{
    public class conjuntoJulia
    {
        private int maxIterations = 100;
        private double xMin = -1.5, xMax = 1.5;
        private double yMin = -1.5, yMax = 1.5;
        private double colorOffset = 0;
        private double colorScale = 10.0;
        private Complex c = new Complex(-0.7, 0.27);


        public int MaxIterations { get => maxIterations; set => maxIterations = value; }
        public double XMin { get => xMin; set => xMin = value; }
        public double XMax { get => xMax; set => xMax = value; }
        public double YMin { get => yMin; set => yMin = value; }
        public double YMax { get => yMax; set => yMax = value; }
        public double ColorOffset { get => colorOffset; set => colorOffset = value; }
        public double ColorScale { get => colorScale; set => colorScale = value; }
        public Complex C { get => c; set => c = value; }

        // Última información de cálculo
        public double CalculationTime { get; private set; }

        // Método para calcular el valor de un punto en el conjunto de Julia
        private double JuliaPoint(Complex z, Complex c, int maxIter)
        {
            int n = 0;
            while (Complex.Abs(z) <= 2 && n < maxIter)
            {
                z = z * z + c;
                n++;
            }

            if (n == maxIter)
                return maxIter;

            // Suavizado del color (smooth coloring)
            return n + 1 - Math.Log(Math.Log(Complex.Abs(z))) / Math.Log(2);
        }

        // Método para obtener un color basado en el número de iteraciones
        private Color GetColor(double iterations, int maxIter, double offset, double scale)
        {
            if (iterations >= maxIter)
                return Color.Black; // Negro para los puntos dentro del conjunto

            // Normalización y colorización usando HSV
            double normalized = ((iterations + offset) / scale) % 1.0;

            // Convertir de HSV a RGB (en C# no tenemos colorsys como en Python)
            return HSVToRGB(normalized, 1.0, iterations < maxIter ? 1.0 : 0.0);
        }

        // Conversión de HSV a RGB
        private Color HSVToRGB(double h, double s, double v)
        {
            double r = 0, g = 0, b = 0;

            if (s == 0)
            {
                r = g = b = v;
            }
            else
            {
                int i = (int)Math.Floor(h * 6);
                double f = h * 6 - i;
                double p = v * (1 - s);
                double q = v * (1 - f * s);
                double t = v * (1 - (1 - f) * s);

                switch (i % 6)
                {
                    case 0: r = v; g = t; b = p; break;
                    case 1: r = q; g = v; b = p; break;
                    case 2: r = p; g = v; b = t; break;
                    case 3: r = p; g = q; b = v; break;
                    case 4: r = t; g = p; b = v; break;
                    case 5: r = v; g = p; b = q; break;
                }
            }

            return Color.FromArgb(
                (int)(r * 255),
                (int)(g * 255),
                (int)(b * 255)
            );
        }

        // Generar el fractal del conjunto de Julia
        public Bitmap GenerateJulia(int width, int height)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Bitmap bitmap = new Bitmap(width, height);
            double[,] juliaValues = new double[height, width];

            // Calcular los valores del conjunto de Julia en paralelo
            Parallel.For(0, height, i =>
            {
                for (int j = 0; j < width; j++)
                {
                    double x = xMin + j * (xMax - xMin) / width;
                    double y = yMin + (height - i) * (yMax - yMin) / height;
                    Complex z = new Complex(x, y);
                    juliaValues[i, j] = JuliaPoint(z, c, maxIterations);
                }
            });

            // Actualizar los colores en el bitmap
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    bitmap.SetPixel(j, i, GetColor(juliaValues[i, j], maxIterations, colorOffset, colorScale));
                }
            }

            sw.Stop();
            CalculationTime = sw.Elapsed.TotalSeconds;

            return bitmap;
        }
        // Método para resetear a valores iniciales
        public void Reset()
        {
            xMin = -1.5;
            xMax = 1.5;
            yMin = -1.5;
            yMax = 1.5;
            maxIterations = 100;
            colorOffset = 0;
            colorScale = 10.0;
            c = new Complex(-0.7, 0.27);
        }

        // Método para hacer zoom en un punto específico
        public void Zoom(int mouseX, int mouseY, int width, int height, double zoomFactor)
        {
            // Convertir coordenadas de pantalla a coordenadas del fractal
            double cx = xMin + (xMax - xMin) * mouseX / width;
            double cy = yMin + (yMax - yMin) * (height - mouseY) / height;

            // Aplicar zoom
            xMin = cx - (cx - xMin) * zoomFactor;
            xMax = cx + (xMax - cx) * zoomFactor;
            yMin = cy - (cy - yMin) * zoomFactor;
            yMax = cy + (yMax - cy) * zoomFactor;
        }

        // Método para mover la vista
        public void Move(double moveX, double moveY)
        {
            double widthFrac = (xMax - xMin) * moveX;
            double heightFrac = (yMax - yMin) * moveY;

            xMin += widthFrac;
            xMax += widthFrac;
            yMin += heightFrac;
            yMax += heightFrac;
        }

        // Ajustar el valor de c
        public void AdjustC(double realDelta, double imagDelta)
        {
            c = new Complex(c.Real + realDelta, c.Imaginary + imagDelta);
        }

    }
}
