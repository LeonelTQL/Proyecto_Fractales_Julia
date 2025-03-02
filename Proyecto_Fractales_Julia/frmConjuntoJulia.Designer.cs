namespace Proyectos_Fractales_Julia
{
    partial class frmConjuntoJulia
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.txtIterations = new System.Windows.Forms.TextBox();
            this.btnInterations = new System.Windows.Forms.Button();
            this.lblFPS = new System.Windows.Forms.Label();
            this.lblRangeX = new System.Windows.Forms.Label();
            this.lblRangeY = new System.Windows.Forms.Label();
            this.lblIterations = new System.Windows.Forms.Label();
            this.lblColorScale = new System.Windows.Forms.Label();
            this.lblConstant = new System.Windows.Forms.Label();
            this.lblCalcTime = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Dock = System.Windows.Forms.DockStyle.Right;
            this.picCanvas.Location = new System.Drawing.Point(139, 0);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(885, 563);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            // 
            // txtIterations
            // 
            this.txtIterations.Location = new System.Drawing.Point(20, 33);
            this.txtIterations.Name = "txtIterations";
            this.txtIterations.Size = new System.Drawing.Size(100, 22);
            this.txtIterations.TabIndex = 1;
            // 
            // btnInterations
            // 
            this.btnInterations.Location = new System.Drawing.Point(20, 71);
            this.btnInterations.Name = "btnInterations";
            this.btnInterations.Size = new System.Drawing.Size(100, 23);
            this.btnInterations.TabIndex = 2;
            this.btnInterations.Text = "Iteraciones";
            this.btnInterations.UseVisualStyleBackColor = true;
            this.btnInterations.Click += new System.EventHandler(this.btnInterations_Click);
            // 
            // lblFPS
            // 
            this.lblFPS.AutoSize = true;
            this.lblFPS.Location = new System.Drawing.Point(166, 32);
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(47, 16);
            this.lblFPS.TabIndex = 3;
            this.lblFPS.Text = "lblFPS";
            // 
            // lblRangeX
            // 
            this.lblRangeX.AutoSize = true;
            this.lblRangeX.Location = new System.Drawing.Point(166, 60);
            this.lblRangeX.Name = "lblRangeX";
            this.lblRangeX.Size = new System.Drawing.Size(44, 16);
            this.lblRangeX.TabIndex = 4;
            this.lblRangeX.Text = "label1";
            // 
            // lblRangeY
            // 
            this.lblRangeY.AutoSize = true;
            this.lblRangeY.Location = new System.Drawing.Point(166, 89);
            this.lblRangeY.Name = "lblRangeY";
            this.lblRangeY.Size = new System.Drawing.Size(44, 16);
            this.lblRangeY.TabIndex = 5;
            this.lblRangeY.Text = "label2";
            // 
            // lblIterations
            // 
            this.lblIterations.AutoSize = true;
            this.lblIterations.Location = new System.Drawing.Point(166, 116);
            this.lblIterations.Name = "lblIterations";
            this.lblIterations.Size = new System.Drawing.Size(44, 16);
            this.lblIterations.TabIndex = 6;
            this.lblIterations.Text = "label3";
            // 
            // lblColorScale
            // 
            this.lblColorScale.AutoSize = true;
            this.lblColorScale.Location = new System.Drawing.Point(166, 144);
            this.lblColorScale.Name = "lblColorScale";
            this.lblColorScale.Size = new System.Drawing.Size(44, 16);
            this.lblColorScale.TabIndex = 7;
            this.lblColorScale.Text = "label4";
            // 
            // lblConstant
            // 
            this.lblConstant.AutoSize = true;
            this.lblConstant.Location = new System.Drawing.Point(166, 171);
            this.lblConstant.Name = "lblConstant";
            this.lblConstant.Size = new System.Drawing.Size(44, 16);
            this.lblConstant.TabIndex = 8;
            this.lblConstant.Text = "label5";
            // 
            // lblCalcTime
            // 
            this.lblCalcTime.AutoSize = true;
            this.lblCalcTime.Location = new System.Drawing.Point(166, 198);
            this.lblCalcTime.Name = "lblCalcTime";
            this.lblCalcTime.Size = new System.Drawing.Size(44, 16);
            this.lblCalcTime.TabIndex = 9;
            this.lblCalcTime.Text = "label5";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(20, 109);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Resetear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmConjuntoJulia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 563);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblCalcTime);
            this.Controls.Add(this.lblConstant);
            this.Controls.Add(this.lblColorScale);
            this.Controls.Add(this.lblIterations);
            this.Controls.Add(this.lblRangeY);
            this.Controls.Add(this.lblRangeX);
            this.Controls.Add(this.lblFPS);
            this.Controls.Add(this.btnInterations);
            this.Controls.Add(this.txtIterations);
            this.Controls.Add(this.picCanvas);
            this.Name = "frmConjuntoJulia";
            this.Text = "Conjunto de Julia";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConjuntoJulia_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picCanvas;
        internal System.Windows.Forms.TextBox txtIterations;
        internal System.Windows.Forms.Button btnInterations;
        internal System.Windows.Forms.Label lblFPS;
        internal System.Windows.Forms.Label lblRangeX;
        internal System.Windows.Forms.Label lblRangeY;
        internal System.Windows.Forms.Label lblIterations;
        internal System.Windows.Forms.Label lblColorScale;
        internal System.Windows.Forms.Label lblConstant;
        internal System.Windows.Forms.Label lblCalcTime;
        internal System.Windows.Forms.Button btnReset;
    }
}

