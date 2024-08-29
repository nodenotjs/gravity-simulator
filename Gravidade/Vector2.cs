using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gravidade
{
    class Vector2
    {
        public double x;
        public double y;

        public Vector2(double x = 0, double y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"[{x:N}, {y:N}]";
        }

        public Vector2 Add(Vector2 vector)
        {
            x += vector.x;
            y += vector.y;
            return this;
        }

        public Vector2 Sub(Vector2 vector)
        {
            x -= vector.x;
            y -= vector.y;
            return this;
        }

        public Vector2 Scale(double factorX, double? factorY = null)
        {
            x *= factorX;
            y *= factorY ?? factorX;
            return this;
        }

        public double Magnitude()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        public Vector2 Normalize()
        {
            double magnitude = Magnitude();
            x /= magnitude;
            y /= magnitude;
            return this;
        }

        public Vector2 Copy()
        {
            return new Vector2(x, y);
        }
    }
}
