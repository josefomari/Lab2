using System;
using System.Numerics;

namespace ShapeLibrary
{
    public class Circle : Shape2D
    {
        private Vector2 _center;
        private float _radius;

        public Circle(Vector2 center, float radius)
        {
            _center = center;
            _radius = radius;
        }

        public override string ToString() => $"Circle @({_center.X:0.0},{_center.Y:0.0}) r: {_radius:0.0}";

        public override Vector3 Center => new Vector3(_center.X, _center.Y, 0f);

        public override float Area => (float)(_radius * _radius * Math.PI);

        public override float Circumference => (float)(_radius * 2 * Math.PI);
    }
}
