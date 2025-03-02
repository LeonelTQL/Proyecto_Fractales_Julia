using Proyectos_Fractales_Julia.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyectos_Fractales_Julia
{
    public partial class frmConjuntoJulia : Form
    {
        private const double ZOOM_FACTOR_IN = 0.8;
        private const double ZOOM_FACTOR_OUT = 1.25;
        private const double MOVE_FACTOR = 0.1;

        // Propiedades
        private conjuntoJulia julia;
        private FractalManager fractalManager;
        private Timer refreshTimer;

        // Coordenadas del último clic del mouse
        private Point lastMousePosition;
        public frmConjuntoJulia()
        {
            InitializeComponent();
            julia = new conjuntoJulia();
            fractalManager = new FractalManager(this, julia);
            refreshTimer = new Timer();

            // Configurar timer para actualizar la UI
            refreshTimer.Interval = 16; // ~60 FPS
            refreshTimer.Tick += fractalManager.RefreshTimer_Tick;

            // Cargar valores iniciales en UI
            txtIterations.Text = julia.MaxIterations.ToString();

            picCanvas.MouseWheel += picCanvas_MouseWheel;

            // Iniciar timers
            refreshTimer.Start();

            // Generar fractal inicial
            fractalManager.GenerateFractal();
        }

        private void btnInterations_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIterations.Text, out int iterations) && iterations > 0)
            {
                julia.MaxIterations = iterations;
                fractalManager.SetNeedsRedraw(true);
            }
            else
            {
                MessageBox.Show("Por favor introduce un número válido de iteraciones.",
                    "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIterations.Text = julia.MaxIterations.ToString();
            }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            refreshTimer.Stop();
            fractalManager.OnFormClosing();
            base.OnFormClosing(e);
        }

        private void picCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            double zoomFactor = e.Delta > 0 ? ZOOM_FACTOR_IN : ZOOM_FACTOR_OUT;
            julia.Zoom(e.X, e.Y, picCanvas.Width, picCanvas.Height, zoomFactor);
            fractalManager.SetNeedsRedraw(true);
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lastMousePosition = e.Location;
            }
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int deltaX = e.X - lastMousePosition.X;
                int deltaY = e.Y - lastMousePosition.Y;

                if (deltaX != 0 || deltaY != 0)
                {
                    double moveX = -deltaX * (julia.XMax - julia.XMin) / picCanvas.Width;
                    double moveY = deltaY * (julia.YMax - julia.YMin) / picCanvas.Height;

                    julia.Move(moveX, moveY);
                    lastMousePosition = e.Location;
                    fractalManager.SetNeedsRedraw(true);
                }
            }
        }

        private void frmConjuntoJulia_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            julia.Reset();

           
            fractalManager.SetNeedsRedraw(true);

            txtIterations.Text = julia.MaxIterations.ToString(); 
            fractalManager.GenerateFractal();
        }
    }
}
