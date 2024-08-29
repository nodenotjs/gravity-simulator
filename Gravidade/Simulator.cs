using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gravidade
{
    class Simulator
    {
        public Particle[] particles;
        public Simulator(Particle[] particles)
        {
            this.particles = particles;
        }

        public void Update(double dt)
        {
            foreach (var particle in particles)
            {
                particle.Update(dt);
            }
        }

        public void Render(Bitmap bmp)
        {
            foreach (var particle in particles)
            {
                particle.RenderParticle(bmp);
            }
        }
    }
}
