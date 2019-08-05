using System;
using System.Collections.Generic;
using System.Linq;
using System.Geometry;
using System.Numerics;

namespace BezierTest
{
    public class BezierFactory
    {
        /// <summary>
        /// テスト用ベクトルのコレクションを作成し返します。
        /// </summary>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public static IEnumerable<Vector2> GetVectors(int cnt)
        {
            // i = x としてベクトルx,yをcntの数だけ生成する
            for (int i = 0; i < cnt; i++)
            {
                var y =
                    // x = 1 のとき y = 0
                    i == 1 ? 0 :
                    // x = 2 のとき y = 3
                    i == 2 ? 3 :
                    // それ以外のとき y = 1
                    1;
                // 二次元ベクトルとして返す
                yield return new Vector2(i, y);
            }
        }
        /// <summary>
        /// テスト用ベクトルを使用し、Bezierライブラリを利用したベジェ曲線を返します。
        /// </summary>
        /// <returns></returns>
        public static Bezier GetTestBezierWithLib()
        {
            var pts = GetVectors(4).ToArray();
            var x = new Bezier(pts[0], pts[1], pts[2], pts[3]);
            return x;
        }

        /// <summary>
        /// テスト用ベクトルを使用し、基本的な公式から導いたベジェ補間値を返します。
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector2 GetTestBezierValueAt(float t)
        {
            var pts = GetVectors(4).ToArray();
            return new Vector2
            {
                X = (float)Solve(pts[0].X, pts[1].X, pts[2].X, pts[3].X, t),
                Y = (float)Solve(pts[0].Y, pts[1].Y, pts[2].Y, pts[3].Y, t)
            };
            
        }
        /// <summary>
        /// 地点tにおけるベジェ曲線の補間値を返します。
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private static double Solve(float p0, float p1, float p2, float p3, float t)
        {
            return Math.Pow(1 - t, 3f) * p0 + 3 * Math.Pow(1 - t, 2f) * t * p1 + 3 * (1 - t) * Math.Pow(t, 2) * p2 + Math.Pow(t, 3f) * p3;
        }
    }
}
