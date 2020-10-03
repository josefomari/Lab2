using System;
using System.Numerics;

namespace ShapeLibrary
{
    public abstract class Shape
    {
        private static readonly Random random = new Random();
        public abstract Vector3 Center { get; }
        public abstract float Area { get; }


        public static Shape GenerateShape()
        {
            var rndShape = random.Next(0, 6);


            switch (rndShape)
            {
                //Circle
                case 0:
                    return new Circle(new Vector2((float) RndFloat(1, 5), (float) RndFloat(1, 5)),
                        (float) RndFloat(1, 5));
                //Rectangle
                case 1:
                    return new Rectangle(new Vector2((float) RndFloat(1, 5), (float) RndFloat(1, 5)),
                        new Vector2((float) RndFloat(1, 5), (float) RndFloat(1, 5)));
                //Square
                case 2:
                    return new Rectangle(new Vector2((float) RndFloat(1, 5), (float) RndFloat(1, 5)),
                        (float) RndFloat(1, 5));
                //Triangle
                case 3:
                    return new Triangle(new Vector2((float) RndFloat(1, 5), (float) RndFloat(1, 5)),
                        new Vector2((float) RndFloat(1, 5), (float) RndFloat(1, 5)),
                        new Vector2((float) RndFloat(1, 5), (float) RndFloat(1, 5)));
                //Cuboid
                case 4:
                    return new Cuboid(
                        new Vector3((float) RndFloat(1, 5), (float) RndFloat(1, 5), (float) RndFloat(1, 5)),
                        new Vector3((float) RndFloat(1, 5), (float) RndFloat(1, 5), (float) RndFloat(1, 5)));
                //Cube
                case 5:
                    return new Cuboid(
                        new Vector3((float) RndFloat(1, 5), (float) RndFloat(1, 5), (float) RndFloat(1, 5)),
                        (float) RndFloat(1, 5));
                //Sphere
                case 6:
                    return new Sphere(
                        new Vector3((float) RndFloat(1, 5), (float) RndFloat(1, 5), (float) RndFloat(1, 5)),
                        (float) RndFloat(1, 5));
            }


            return null;
        }

        public static Shape GenerateShape(Vector3 centerInput)
        {
            var rndShape = random.Next(0, 6);

            switch (rndShape)
            {
                //Circle
                case 0:
                    return new Circle(new Vector2(centerInput.X, centerInput.Y), (float) RndFloat(1, 5));
                //Rectangle
                case 1:
                    return new Rectangle(new Vector2(centerInput.X, centerInput.Y),
                        new Vector2((float) RndFloat(1, 5), (float) RndFloat(1, 5)));
                //Square
                case 2:
                    return new Rectangle(new Vector2(centerInput.X, centerInput.Y), (float) RndFloat(1, 5));
                //Triangle
                case 3:
                    //Slumpar två punkter och räknar ut den tredje med Center positionen man matar in i metoden
                    var p1X = (float) RndFloat(1, 5);
                    var p1Y = (float) RndFloat(1, 5);
                    var p2X = (float) RndFloat(1, 5);
                    var p2Y = (float) RndFloat(1, 5);
                    var p3X = centerInput.X * 3 - (p1X + p2X);
                    var p3Y = centerInput.Y * 3 - (p1Y + p2Y);
                    return new Triangle(new Vector2(p1X, p1Y), new Vector2(p2X, p2Y), new Vector2(p3X, p3Y));
                //Cuboid
                case 4:
                    return new Cuboid(new Vector3(centerInput.X, centerInput.Y, centerInput.Z),
                        new Vector3((float) RndFloat(1, 5), (float) RndFloat(1, 5), (float) RndFloat(1, 5)));

                //Cube
                case 5:
                    return new Cuboid(new Vector3(centerInput.X, centerInput.Y, centerInput.Z), (float) RndFloat(1, 5));

                //Sphere
                case 6:
                    return new Sphere(new Vector3(centerInput.X, centerInput.Y, centerInput.Z), (float) RndFloat(1, 5));
            }


            return null;
        }

        //Skapar en metod för att randomiza ett double värde som sedan castas till float
        public static double RndFloat(double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}