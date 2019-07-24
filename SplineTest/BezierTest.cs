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
        public static Bezier CreateTestBezier()
        {
            var pts = Enumerable.Range(0, 4).Select(i => {
                var y =
                    i == 1 ? 5 :
                    i == 2 ? 3 :
                    1;
                return new Vector2(i, y);
            }).ToArray();
            var x = new Bezier(pts[0], pts[1], pts[2], pts[3]);
            return x;
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
                Console.WriteLine($"{string.Format("{0:0.0}",y.X)}:{bar}");
            }

            Assert.IsNotNull(curve);
        }

    }
}
