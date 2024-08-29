namespace Gravidade
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.updateSimulation = new System.Windows.Forms.Timer(this.components);
            this.updateCanvas = new System.Windows.Forms.Timer(this.components);
            this.canvas = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accelerationTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detalhedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawWTFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetPosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableCoordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sLWMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yay = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateSimulation
            // 
            this.updateSimulation.Enabled = true;
            this.updateSimulation.Interval = 15;
            this.updateSimulation.Tick += new System.EventHandler(this.updateSimulation_Tick);
            // 
            // updateCanvas
            // 
            this.updateCanvas.Enabled = true;
            this.updateCanvas.Interval = 15;
            this.updateCanvas.Tick += new System.EventHandler(this.updateCanvas_Tick);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.DimGray;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 24);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(900, 725);
            this.canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Click += new System.EventHandler(this.canvas_Click);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pauseToolStripMenuItem,
            this.accelerationTraceToolStripMenuItem,
            this.detalhedToolStripMenuItem,
            this.drawWTFToolStripMenuItem,
            this.resetPosToolStripMenuItem,
            this.testToolStripMenuItem,
            this.disableCoordsToolStripMenuItem,
            this.gTPToolStripMenuItem,
            this.sLWMToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(900, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Checked = true;
            this.pauseToolStripMenuItem.CheckOnClick = true;
            this.pauseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.pauseToolStripMenuItem.Text = "Play";
            this.pauseToolStripMenuItem.CheckedChanged += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // accelerationTraceToolStripMenuItem
            // 
            this.accelerationTraceToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.accelerationTraceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem,
            this.iPFToolStripMenuItem,
            this.fRToolStripMenuItem});
            this.accelerationTraceToolStripMenuItem.Name = "accelerationTraceToolStripMenuItem";
            this.accelerationTraceToolStripMenuItem.Size = new System.Drawing.Size(26, 20);
            this.accelerationTraceToolStripMenuItem.Text = "F";
            this.accelerationTraceToolStripMenuItem.ToolTipText = "Acceleration Traces";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.CheckOnClick = true;
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.aToolStripMenuItem.Text = "AC";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // iPFToolStripMenuItem
            // 
            this.iPFToolStripMenuItem.CheckOnClick = true;
            this.iPFToolStripMenuItem.Name = "iPFToolStripMenuItem";
            this.iPFToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.iPFToolStripMenuItem.Text = "IPF";
            this.iPFToolStripMenuItem.Click += new System.EventHandler(this.iPFToolStripMenuItem_Click);
            // 
            // fRToolStripMenuItem
            // 
            this.fRToolStripMenuItem.CheckOnClick = true;
            this.fRToolStripMenuItem.Name = "fRToolStripMenuItem";
            this.fRToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.fRToolStripMenuItem.Text = "FR";
            this.fRToolStripMenuItem.Click += new System.EventHandler(this.fRToolStripMenuItem_Click);
            // 
            // detalhedToolStripMenuItem
            // 
            this.detalhedToolStripMenuItem.CheckOnClick = true;
            this.detalhedToolStripMenuItem.Name = "detalhedToolStripMenuItem";
            this.detalhedToolStripMenuItem.Size = new System.Drawing.Size(33, 20);
            this.detalhedToolStripMenuItem.Text = "MD";
            this.detalhedToolStripMenuItem.ToolTipText = "More Details";
            this.detalhedToolStripMenuItem.Click += new System.EventHandler(this.detalhedToolStripMenuItem_Click);
            // 
            // drawWTFToolStripMenuItem
            // 
            this.drawWTFToolStripMenuItem.CheckOnClick = true;
            this.drawWTFToolStripMenuItem.Name = "drawWTFToolStripMenuItem";
            this.drawWTFToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.drawWTFToolStripMenuItem.Text = "DLAP";
            this.drawWTFToolStripMenuItem.ToolTipText = "Draw line at Particles";
            this.drawWTFToolStripMenuItem.Click += new System.EventHandler(this.drawWTFToolStripMenuItem_Click);
            // 
            // resetPosToolStripMenuItem
            // 
            this.resetPosToolStripMenuItem.Name = "resetPosToolStripMenuItem";
            this.resetPosToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.resetPosToolStripMenuItem.Text = "RCP";
            this.resetPosToolStripMenuItem.ToolTipText = "Reset Camera Position";
            this.resetPosToolStripMenuItem.Click += new System.EventHandler(this.resetPosToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.testToolStripMenuItem.Text = "GTRP";
            this.testToolStripMenuItem.ToolTipText = "Go to Random Particle";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // disableCoordsToolStripMenuItem
            // 
            this.disableCoordsToolStripMenuItem.CheckOnClick = true;
            this.disableCoordsToolStripMenuItem.Name = "disableCoordsToolStripMenuItem";
            this.disableCoordsToolStripMenuItem.Size = new System.Drawing.Size(33, 20);
            this.disableCoordsToolStripMenuItem.Text = "EC";
            this.disableCoordsToolStripMenuItem.ToolTipText = "Enable Coords";
            this.disableCoordsToolStripMenuItem.Click += new System.EventHandler(this.disableCoordsToolStripMenuItem_Click);
            // 
            // gTPToolStripMenuItem
            // 
            this.gTPToolStripMenuItem.Name = "gTPToolStripMenuItem";
            this.gTPToolStripMenuItem.Size = new System.Drawing.Size(33, 20);
            this.gTPToolStripMenuItem.Text = "PL";
            this.gTPToolStripMenuItem.ToolTipText = "Particles list";
            this.gTPToolStripMenuItem.Click += new System.EventHandler(this.gTPToolStripMenuItem_Click);
            // 
            // sLWMToolStripMenuItem
            // 
            this.sLWMToolStripMenuItem.CheckOnClick = true;
            this.sLWMToolStripMenuItem.Name = "sLWMToolStripMenuItem";
            this.sLWMToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.sLWMToolStripMenuItem.Text = "SLWM";
            this.sLWMToolStripMenuItem.Click += new System.EventHandler(this.sLWMToolStripMenuItem_Click);
            // 
            // yay
            // 
            this.yay.Enabled = true;
            this.yay.Interval = 1000;
            this.yay.Tick += new System.EventHandler(this.yay_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 749);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Particles";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer updateSimulation;
        private System.Windows.Forms.Timer updateCanvas;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accelerationTraceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detalhedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetPosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawWTFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableCoordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gTPToolStripMenuItem;
        private System.Windows.Forms.Timer yay;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iPFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sLWMToolStripMenuItem;
    }
}

