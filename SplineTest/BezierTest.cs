using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Geometry;
using System.Numerics;
using NUnit.Framework;

namespace SplineTest
{
    public class CurveFactory
    {
        public static IEnumerable<Vector2> GetVectors(int cnt)
        {
            for (int i = 0; i < cnt; i++)
            {
                var y =
                    i == 1 ? 5 :
                    i == 2 ? 3 :
                    1;
                yield return new Vector2(i, y);
            }
        }
        public static Bezier CreateTestBezier()
        {
            var pts = GetVectors(4).ToArray();
            var x = new Bezier(pts[0], pts[1], pts[2], pts[3]);
            return x;
        }

        public static Vector2 GetBezierValueAt(float t)
        {
            var pts = GetVectors(4).ToArray();
            return new Vector2
            {
                X = (float)Solve(pts[0].X, pts[1].X, pts[2].X, pts[3].X, t),
                Y = (float)Solve(pts[0].Y, pts[1].Y, pts[2].Y, pts[3].Y, t)
            };
            
        }
        public static double Solve(float p0, float p1, float p2, float p3, float t)
        {
            return Math.Pow(1 - t, 3f) * p0 + 3 * Math.Pow(1 - t, 2f) * t * p1 + 3 * (1 - t) * Math.Pow(t, 2) * p2 + Math.Pow(t, 3f) * p3;
        }
    }
    public class Test
    {
        [Test]
        public void test()
        {
            // creating a bezier curve
            var curve = CurveFactory.CreateTestBezier();

            // visualizing in test output
            for(float i = 0f; i < 1f; i += 0.05f)
            {
                var y = curve.Position(i);
                string bar = "|";
                var cnt = 0f;
                while(cnt < y.Y)
                {
                    bar += "|";
                    cnt += 0.1f;
                }
                Console.WriteLine($"{string.Format("{0:0.0}",y.X)}:{bar}:({y.X}:{y.Y})");
            }

            for (float i = 0f; i < 1f; i += 0.05f)
            {
                var pos = CurveFactory.GetBezierValueAt(i);
                string bar = "|";
                var cnt = 0f;
                while (cnt < pos.Y)
                {
                    bar += "|";
                    cnt += 0.1f;
                }
                Console.WriteLine($"{string.Format("{0:0.0}", pos.X)}:{bar}({pos.X}:{pos.Y})");
            }
            Assert.IsNotNull(curve);
        }
    }
}
