using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gravidade
{
    class Particle
    {
        public Vector2 position;
        public Vector2 positionWithMoving => new Vector2(position.x + Settings.pointMove.x, position.y + Settings.pointMove.y);
        private Vector2 velocity;
        public Vector2 acceleration = new Vector2();
        public Vector2 forces = new Vector2();
        public double radius;
        public double volume;
        public double mass;
        public double density;
        public Brush color = Brushes.Red;
        public static int DeltaTime = 0;

        public Particle(Vector2 initialPosition, Vector2 initalVelocity, double radius = 1, double density = 1, Brush brush = null)
        {
            color = brush ?? Brushes.Red;
            position = initialPosition;
            velocity = initalVelocity;
            this.radius = radius;
            volume = 4 / 3 * Math.PI * Math.Pow(radius, 3);
            mass = volume * density;
        }

        public Bitmap RenderParticle(Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            RectangleF p = new RectangleF((float)(positionWithMoving.x - radius / 2), (float)(positionWithMoving.y - radius / 2), (float)radius, (float)radius);
            if (Settings.drawLineAtPlanets)
                foreach (var particle in M.simulation.particles)
                {
                    if (particle == this)
                        continue;
                    g.DrawLine(Pens.Magenta, (float)positionWithMoving.x, (float)positionWithMoving.y, (float)particle.positionWithMoving.x, (float)particle.positionWithMoving.y);
                }

            g.FillEllipse(color, p);
            g.DrawEllipse(Pens.Black, p);
            if (Settings.ipForces)
            {
                foreach (var particle in M.simulation.particles)
                {
                    if (particle == this)
                        continue;
                    g.DrawLine(Pens.Azure, (float)positionWithMoving.x, (float)positionWithMoving.y, (float)(AttractionTo(particle).Scale(1 / mass).x + positionWithMoving.x), (float)(AttractionTo(particle).Scale(1 / mass).y + positionWithMoving.y));
                }
            }
            if (Settings.rForce)
            {
                g.DrawLine(Pens.Aqua, (float)positionWithMoving.x, (float)positionWithMoving.y, (float)(forces.Copy().Scale(1 / mass).x + positionWithMoving.x), (float)(forces.Copy().Scale(1 / mass).y + positionWithMoving.y));
            }
            if (Settings.accTrace)
            {
                g.DrawLine(Pens.Blue, (float)positionWithMoving.x, (float)positionWithMoving.y, (float)(velocity.x + positionWithMoving.x), (float)(velocity.y + positionWithMoving.y));
            }
            if (Settings.details)
                g.DrawString(this.ToString(), new Font("Consolas", 7), Brushes.Black, (float)positionWithMoving.x, (float)positionWithMoving.y);
            return bmp;
        }

        public override string ToString()
        {
            return $"P: {position}, V: {(velocity.x - velocity.y):N2}, A: {(acceleration.x - acceleration.y):N2}, M: {mass:N0}";
        }

        public void Update(double dt = 0.015)
        {
            forces = ComputeTotalForces();
            acceleration = forces.Copy().Scale(1 / mass);
            velocity.Add(acceleration.Copy().Scale(dt));
            position.Add(velocity.Copy().Scale(dt));
        }

        public Vector2 AttractionTo(Particle otherParticle)
        {
            if (this == otherParticle)
            {
                return new Vector2();
            }
            Vector2 distanceBeteweenPlanets = otherParticle.position.Copy().Sub(position);
            double distanceBeteweenPlanetsScalar = distanceBeteweenPlanets.Magnitude();
            double forceScalar = this.mass * otherParticle.mass / Math.Pow(distanceBeteweenPlanetsScalar, 2);
            Vector2 forceVector = distanceBeteweenPlanets.Normalize().Scale(forceScalar);
            return forceVector;
        }

        public Vector2 ComputeTotalForces()
        {
            Vector2 f = new Vector2();
            foreach (var particle in M.simulation.particles)
            {
                f.Add(AttractionTo(particle));
            }
            return f;
        }
    }
}
