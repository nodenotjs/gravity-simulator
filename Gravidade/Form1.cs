using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gravidade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Settings.pointMove = new Vector2(canvas.Width / 2, canvas.Height / 2);
        }

        private Stopwatch sw = new Stopwatch();
        private static double DeltaTime = 0f;
        private void updateSimulation_Tick(object sender, EventArgs e)
        {
            if (!Settings.paused)
            {
                //M.simulation.Update(!Settings.slowMotion ? 0.015 : 0.0005);
                for (int i = 0; i < Settings.updatesTimesInSecond; i++)
                {
                    M.simulation.Update(DeltaTime / Settings.updatesTimesInSecond / (1000 * (Settings.slowMotion ? 50 : 1)));
                }
            }
            //DeltaTime = sw.ElapsedMilliseconds;
            DeltaTime = sw.Elapsed.TotalMilliseconds;
            sw.Restart();
        }

        private void updateCanvas_Tick(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(canvas.Width, canvas.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.Clear(Color.Gray);

            M.simulation.Render(bmp);
            if (Settings.showCoords)
            {
                g.DrawLine(Pens.Black, canvas.Width / 2, canvas.Height / 2 - 10, canvas.Width / 2, canvas.Height / 2 + 10);
                g.DrawLine(Pens.Black, canvas.Width / 2 - 10, canvas.Height / 2, canvas.Width / 2 + 10, canvas.Height / 2);
                g.DrawString($"X: {(Settings.pointMove.x + canvas.Width / 2 * -1):N0}, Y: {(Settings.pointMove.y + canvas.Height / 2 * -1):N0}", new Font("Consolas", 9), Brushes.Black, canvas.Width / 2, canvas.Height / 2);
            } 
            if (Settings.pFormOpened)
            {
                for (int i = 0; i < M.simulation.particles.Count(); i++)
                {
                    g.DrawString($"#{i}", new Font("Consolas", 12), Brushes.Black, (float)M.simulation.particles[i].positionWithMoving.x, (float)M.simulation.particles[i].positionWithMoving.y - 20);
                }
            }
            if (Settings.paused)
            {
                g.DrawString("Paused.", new Font("Consolas", 22), Brushes.Black, 20, 20);
            }
            if (Settings.slowMotion)
            {
                g.DrawString("Slow Motion [x50] (higher accuracy).", new Font("Consolas", 16), Brushes.Black, 20, 64);
            }
            g.DrawString($"Canvas size: {canvas.Width}x{canvas.Height}. Steps: {Settings.updatesTimesInSecond}. Delta Time: {DeltaTime}ms", new Font("Consolas", 10), Brushes.Black, 0, canvas.Height - 20);
            canvas.Image = bmp;
        }

        private void canvas_Click(object sender, EventArgs e)
        {
        }

        private void accelerationTraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void detalhedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.details = detalhedToolStripMenuItem.Checked;
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pauseToolStripMenuItem.Text = Settings.paused ? "Pause" : "Play";
            Settings.paused = pauseToolStripMenuItem.Checked;
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            Settings.moving = true;
            Settings.pointClick = new Vector2(e.X * Settings.motionMultipler - Settings.pointMove.x, e.Y * Settings.motionMultipler - Settings.pointMove.y);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (Settings.moving)
            {
                Settings.pointMove.x = e.X * Settings.motionMultipler - Settings.pointClick.x;
                Settings.pointMove.y = e.Y * Settings.motionMultipler - Settings.pointClick.y;
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            Settings.moving = false;
            //Settings.pointClick = new Vector2();
        }

        private void resetPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.pointMove = new Vector2();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Particle p = M.simulation.particles[new Random().Next(0, M.simulation.particles.Count())];
            Settings.pointMove = new Vector2(p.position.x * -1 + canvas.Width / 2, p.position.y * -1 + canvas.Height / 2);
        }

        private void drawWTFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.drawLineAtPlanets = drawWTFToolStripMenuItem.Checked;
        }

        private void lowCanvasUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (updateCanvas.Interval == 15)
            {
                updateCanvas.Interval = 100;
            }
            else
            {
                updateCanvas.Interval = 15;
            }
        }

        private void disableCoordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.showCoords = disableCoordsToolStripMenuItem.Checked;
            disableCoordsToolStripMenuItem.Text = Settings.showCoords ? "DC" : "EC";
        }

        private void gTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Settings.pFormOpened)
            {
                new ParticleList().Show();
            }
        }

        private void yay_Tick(object sender, EventArgs e)
        {
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.accTrace = aToolStripMenuItem.Checked;
        }

        private void iPFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.ipForces = iPFToolStripMenuItem.Checked;
        }

        private void fRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.rForce = fRToolStripMenuItem.Checked;
        }

        private void sLWMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.slowMotion = sLWMToolStripMenuItem.Checked;
        }
    }

    class M
    {
        public static Particle[] particles = {
            new Particle(new Vector2(), new Vector2(), 139, 3, Brushes.Yellow),

            new Particle(new Vector2(-200, 0), new Vector2(0, -380), 25, 2, Brushes.Blue),
            new Particle(new Vector2(-180, 0), new Vector2(0, 450), 7.5, 100, Brushes.Gray),
            new Particle(new Vector2(-100, 0), new Vector2(0, 540), 15, 1, Brushes.Brown),

            new Particle(new Vector2(5000, 0), new Vector2(0, 53.9), 20, 10, Brushes.Aqua),
            new Particle(new Vector2(5070, 0), new Vector2(0, -53.9), 20, 10, Brushes.DarkCyan),

            new Particle(new Vector2(-10000, 0), new Vector2(0, 0), 1000, 0.0001, Brushes.DarkRed),
    };
        public static Simulator simulation = new Simulator(particles);
    }

    //MizuText
    /*public static Particle[] planets = {
            new Particle(new Vector2(20, 20), new Vector2(0, 0), 20),
            new Particle(new Vector2(20, 70), new Vector2(0, 0), 20),
            new Particle(new Vector2(20, 120), new Vector2(0, 0), 20),
            new Particle(new Vector2(20, 170), new Vector2(0, 0), 20),
            new Particle(new Vector2(20, 220), new Vector2(0, 0), 20),
            new Particle(new Vector2(80, 70), new Vector2(0, 0), 20),
            new Particle(new Vector2(120, 120), new Vector2(0, 0), 20),
            new Particle(new Vector2(170, 70), new Vector2(0, 0), 20),
            new Particle(new Vector2(220, 20), new Vector2(0, 0), 20),
            new Particle(new Vector2(220, 220), new Vector2(0, 0), 20),
            new Particle(new Vector2(220, 170), new Vector2(0, 0), 20),
            new Particle(new Vector2(220, 120), new Vector2(0, 0), 20),
            new Particle(new Vector2(220, 70), new Vector2(0, 0), 20),

            new Particle(new Vector2(300, 20), new Vector2(0, 0), 20),
            new Particle(new Vector2(300, 70), new Vector2(0, 0), 20),
            new Particle(new Vector2(300, 120), new Vector2(0, 0), 20),
            new Particle(new Vector2(300, 170), new Vector2(0, 0), 20),
            new Particle(new Vector2(300, 220), new Vector2(0, 0), 20),

            new Particle(new Vector2(380, 20), new Vector2(0, 0), 20),
            new Particle(new Vector2(430, 20), new Vector2(0, 0), 20),
            new Particle(new Vector2(480, 20), new Vector2(0, 0), 20),
            new Particle(new Vector2(530, 20), new Vector2(0, 0), 20),
            new Particle(new Vector2(580, 20), new Vector2(0, 0), 20),
            new Particle(new Vector2(430, 70), new Vector2(0, 0), 20),
            new Particle(new Vector2(480, 120), new Vector2(0, 0), 20),
            new Particle(new Vector2(530, 170), new Vector2(0, 0), 20),
            new Particle(new Vector2(580, 220), new Vector2(0, 0), 20),
            new Particle(new Vector2(430, 220), new Vector2(0, 0), 20),
            new Particle(new Vector2(480, 220), new Vector2(0, 0), 20),
            new Particle(new Vector2(530, 220), new Vector2(0, 0), 20),
            new Particle(new Vector2(380, 220), new Vector2(0, 0), 20),

            new Particle(new Vector2(660, 20), new Vector2(0, 0), 20),
            new Particle(new Vector2(660, 70), new Vector2(0, 0), 20),
            new Particle(new Vector2(660, 120), new Vector2(0, 0), 20),
            new Particle(new Vector2(660, 170), new Vector2(0, 0), 20),
            new Particle(new Vector2(660, 220), new Vector2(0, 0), 20),
            new Particle(new Vector2(710, 220), new Vector2(0, 0), 20),
            new Particle(new Vector2(760, 220), new Vector2(0, 0), 20),
            new Particle(new Vector2(810, 220), new Vector2(0, 0), 20),
            new Particle(new Vector2(860, 220), new Vector2(0, 0), 20),
            new Particle(new Vector2(860, 20), new Vector2(0, 0), 20),
            new Particle(new Vector2(860, 70), new Vector2(0, 0), 20),
            new Particle(new Vector2(860, 120), new Vector2(0, 0), 20),
            new Particle(new Vector2(860, 170), new Vector2(0, 0), 20),
    };*/

    //Dogs text
    /*
    public static Particle[] particles = {
            new Particle(new Vector2(0, -40), new Vector2(), 15),
            new Particle(new Vector2(0, -20), new Vector2(), 15),
            new Particle(new Vector2(0, 0), new Vector2(), 15),
            new Particle(new Vector2(0, 20), new Vector2(), 15),
            new Particle(new Vector2(0, 40), new Vector2(), 15),
            new Particle(new Vector2(20, -40), new Vector2(), 15),
            new Particle(new Vector2(40, -40), new Vector2(), 15),
            new Particle(new Vector2(60, -40), new Vector2(), 15),
            new Particle(new Vector2(80, -20), new Vector2(), 15),
            new Particle(new Vector2(80, 0), new Vector2(), 15),
            new Particle(new Vector2(80, 20), new Vector2(), 15),
            new Particle(new Vector2(20, 40), new Vector2(), 15),
            new Particle(new Vector2(40, 40), new Vector2(), 15),
            new Particle(new Vector2(60, 40), new Vector2(), 15),
            new Particle(new Vector2(180, -20), new Vector2(), 15),
            new Particle(new Vector2(180, 0), new Vector2(), 15),
            new Particle(new Vector2(180, 20), new Vector2(), 15),
            new Particle(new Vector2(200, 40), new Vector2(), 15),
            new Particle(new Vector2(220, 40), new Vector2(), 15),
            new Particle(new Vector2(240, 40), new Vector2(), 15),
            new Particle(new Vector2(260, -20), new Vector2(), 15),
            new Particle(new Vector2(260, 0), new Vector2(), 15),
            new Particle(new Vector2(260, 20), new Vector2(), 15),
            new Particle(new Vector2(200, -40), new Vector2(), 15),
            new Particle(new Vector2(220, -40), new Vector2(), 15),
            new Particle(new Vector2(240, -40), new Vector2(), 15),
            new Particle(new Vector2(360, -20), new Vector2(), 15),
            new Particle(new Vector2(360, 0), new Vector2(), 15),
            new Particle(new Vector2(360, 20), new Vector2(), 15),
            new Particle(new Vector2(380, -40), new Vector2(), 15),
            new Particle(new Vector2(400, -40), new Vector2(), 15),
            new Particle(new Vector2(420, -40), new Vector2(), 15),
            new Particle(new Vector2(380, 40), new Vector2(), 15),
            new Particle(new Vector2(400, 40), new Vector2(), 15),
            new Particle(new Vector2(420, 40), new Vector2(), 15),
            new Particle(new Vector2(440, 20), new Vector2(), 15),
            new Particle(new Vector2(440, 0), new Vector2(), 15),
            new Particle(new Vector2(420, 0), new Vector2(), 15),
            new Particle(new Vector2(400, 0), new Vector2(), 15),
            new Particle(new Vector2(540, -20), new Vector2(), 15),
            new Particle(new Vector2(560, 0), new Vector2(), 15),
            new Particle(new Vector2(560, -40), new Vector2(), 15),
            new Particle(new Vector2(580, -40), new Vector2(), 15),
            new Particle(new Vector2(600, -40), new Vector2(), 15),
            new Particle(new Vector2(620, -40), new Vector2(), 15),
            new Particle(new Vector2(580, 0), new Vector2(), 15),
            new Particle(new Vector2(600, 0), new Vector2(), 15),
            new Particle(new Vector2(620, 20), new Vector2(), 15),
            new Particle(new Vector2(540, 40), new Vector2(), 15),
            new Particle(new Vector2(560, 40), new Vector2(), 15),
            new Particle(new Vector2(580, 40), new Vector2(), 15),
            new Particle(new Vector2(600, 40), new Vector2(), 15),


            new Particle(new Vector2(310, 400), new Vector2(), 100, 10),
    };*/
}
