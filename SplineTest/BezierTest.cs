using System;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BezierTest
{
    public class BezierTest
    {
        [Test]
        public void VisualizeTest()
        {
            // creating a bezier curve with library
            var curve = BezierFactory.GetTestBezierWithLib();

            // ライブラリを利用したベジェ曲線をアウトプットログに可視化
            Console.WriteLine("### Bezier with Library ###");
            for(float i = 0f; i < 1f; i += 0.05f)
            {
                var pos = curve.Position(i);
                VisualizeForOutput(pos);
            }

            // 自力実装のベジェ曲線をアウトプットログに可視化
            Console.WriteLine("### Bezier from scratch ###");
            for (float i = 0f; i < 1f; i += 0.05f)
            {
                var pos = BezierFactory.GetTestBezierValueAt(i);
                VisualizeForOutput(pos);
            }

            // とりあえずt=0.5地点において両社の値が正しいことを確認
            Assert.True(curve.Position(0.5f).Y == BezierFactory.GetTestBezierValueAt(0.5f).Y);
        }

        /// <summary>
        /// ベクトルを出力ログ向けの文字列として可視化します。
        /// </summary>
        /// <param name="pos"></param>
        private void VisualizeForOutput(Vector2 pos)
        {
            string bar = "|";
            var cnt = 0f;
            // y の値になるまで.1刻みでバーを出力
            while (cnt < pos.Y)
            {
                bar += "|";
                cnt += 0.1f;
            }
            var x = FloatToString(pos.X);
            var y = FloatToString(pos.Y);
            Console.WriteLine($"{x}:{bar}({x}:{y})");
        }

        private string FloatToString(float x) => string.Format("{0:0.000}", x);


    }
}
