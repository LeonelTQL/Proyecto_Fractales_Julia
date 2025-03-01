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

    }
}
