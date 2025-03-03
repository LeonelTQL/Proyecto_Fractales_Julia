using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Fractales_Julia.Class
{
    public class FractalManager
    {
        private frmConjuntoJulia form;
        private conjuntoJulia julia;
        private Bitmap fractalImage;
        private Stopwatch fpsTimer;
        private int frameCount;
        private bool needsRedraw = true;

        public FractalManager(frmConjuntoJulia form, conjuntoJulia julia)
        {
            this.form = form;
            this.julia = julia;
            fpsTimer = new Stopwatch();
            fpsTimer.Start();
        }

        public void GenerateFractal()
        {
            needsRedraw = false;
            form.Cursor = Cursors.WaitCursor;

            try
            {
                fractalImage = julia.GenerateJulia(form.picCanvas.Width, form.picCanvas.Height);
                form.picCanvas.Image = fractalImage;
                UpdateLabels();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generando el fractal: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                form.Cursor = Cursors.Default;
            }
        }

        public void UpdateLabels()
        {
            form.lblFPS.Text = $"FPS: {CalculateFPS():F1}";
            form.lblRangeX.Text = $"Rango X: [{julia.XMin:F4}, {julia.XMax:F4}]";
            form.lblRangeY.Text = $"Rango Y: [{julia.YMin:F4}, {julia.YMax:F4}]";
            form.lblIterations.Text = $"Iteraciones: {julia.MaxIterations}";
            form.lblColorScale.Text = $"Escala de color: {julia.ColorScale:F1}";
            form.lblConstant.Text = $"c: {julia.C.Real:F4} + {julia.C.Imaginary:F4}i";
            form.lblCalcTime.Text = $"Tiempo de cálculo: {julia.CalculationTime:F2} segundos";
        }

        private float CalculateFPS()
        {
            float fps = frameCount / ((float)fpsTimer.ElapsedMilliseconds / 1000.0f);

            // Reiniciar contador FPS cada segundo
            if (fpsTimer.ElapsedMilliseconds >= 1000)
            {
                frameCount = 0;
                fpsTimer.Restart();
            }

            return fps;
        }

        public void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (needsRedraw)
            {
                GenerateFractal();
            }

            frameCount++;
            UpdateLabels();
        }

        public void OnFormClosing()
        {
            if (fractalImage != null)
            {
                fractalImage.Dispose();
            }
        }

        public void SetNeedsRedraw(bool value)
        {
            needsRedraw = value;
        }
    }
}



