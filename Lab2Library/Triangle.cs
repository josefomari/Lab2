using System;
using System.Numerics;

namespace ShapeLibrary
{
    public class Triangle : Shape2D
    {
        private Vector2 _p1, _p2, _p3;
        private Vector2 _triangelCenter;

        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
            _triangelCenter.X = (float)((p1.X + p2.X + p3.X) / 3);
            _triangelCenter.Y = (float)((p1.Y + p2.Y + p3.Y) / 3);
        }
        

        public override Vector3 Center => new Vector3(_triangelCenter.X, _triangelCenter.Y, 0f);

        //Formel för arean som dessutom kräver användande utav absoutbelopp för att inte få negativa värden
        public override float Area =>
            (float)0.5 *
            Math.Abs((_p1.X * (_p2.Y - _p3.Y)) + (_p2.X * (_p3.Y - _p1.Y)) + (_p3.X * (_p1.Y - _p2.Y)));

        //Formel för att räkna ut omkretsen på en triangel med 3 koordinater
        public override float Circumference =>
            (float)((Math.Sqrt((Math.Pow(_p1.X - _p2.X, 2) + Math.Pow(_p1.Y - _p2.Y, 2)))) +
                    (Math.Sqrt((Math.Pow(_p2.X - _p3.X, 2) + Math.Pow(_p2.Y - _p3.Y, 2)))) +
                    (Math.Sqrt((Math.Pow(_p3.X - _p1.X, 2) + Math.Pow(_p3.Y - _p1.Y, 2)))));

        public override string ToString()
        {
            return $"triangle @({_triangelCenter.X:0.0}, {_triangelCenter.Y:0.0}): p1({_p1.X:0.0}, {_p1.Y:0.0}), p2({_p2.X:0.0}, {_p2.Y:0.0}), p3({_p3.X:0.0}, {_p3.Y:0.0})";
        }
    }
}
