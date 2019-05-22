using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace martix
{
    class Triangle
    {
        PointF A, B, C;

        public Triangle(PointF A, PointF B, PointF C)
        {
            this.A = A;

            this.B = B;

            this.C = C;
        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 2);

            g.DrawLine(pen, A, B);

            g.DrawLine(pen, B, C);

            g.DrawLine(pen, C, A);
        }

        public void Rotate(int degree)
        {
            float angle = (float)(degree / 360.0f * Math.PI);

            float newX = (float)(A.X * Math.Cos(angle) - A.Y * Math.Sin(angle));

            float newY = (float)(A.X * Math.Sin(angle) + A.Y * Math.Cos(angle));

            A.X = newX;

            A.Y = newY;

            newX = (float)(B.X * Math.Cos(angle) - B.Y * Math.Sin(angle));

            newY = (float)(B.X * Math.Sin(angle) + B.Y * Math.Cos(angle));

            B.X = newX;

            B.Y = newY;

            newX = (float)(C.X * Math.Cos(angle) - C.Y * Math.Sin(angle));

            newY = (float)(C.X * Math.Sin(angle) + C.Y * Math.Cos(angle));

            C.X = newX;
            C.Y = newY;
        }
    }
}
