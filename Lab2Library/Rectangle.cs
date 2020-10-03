using System;
using System.Numerics;

namespace ShapeLibrary
{
    public class Rectangle : Shape2D
    {
        private Vector2 _center;
        private float _width, _height;
        private bool _isSquare = false;

        
        public Rectangle(Vector2 center, Vector2 size)
        {
            _center = center;
            _height = size.X;
            _width = size.Y;

            //Om höjden och bredden möjligtvis blir lika i GenerateShape metoden så sätts den direkt till square.
            if (size.X == size.Y)
            {
                _isSquare = true;
            }
            
        }

        public Rectangle(Vector2 center, float width)
        {
            _center = center;
            _height = width;
            _width = width;
            //Blir automatiskt square då width täcker för både längd och bredd i denna konstruktor.
            _isSquare = true;

        }

        public string IsSquare
        {
            get
            {
                if (_isSquare != true)
                    return "False";
                else
                {
                    return "True";
                }
            }

        }
        public override Vector3 Center => new Vector3(_center.X, _center.Y, 0f);

        public override float Area => (float)(_width * _height);

        public override float Circumference => (float)(_width * 2) + (_height * 2);

        public override string ToString()
        {
            if (_isSquare == true)
            {
                return $"square @({_center.X:0.0}, {_center.Y:0.0}) w = {_width:0.0}, h = {_height:0.0}";
            }
            else
            {
                return $"rectangle @({_center.X:0.0}, {_center.Y:0.0}) w = {_width:0.0}, h = {_height:0.0}";
            }
        }



    }
}
