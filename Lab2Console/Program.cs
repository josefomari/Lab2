using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using ShapeLibrary;

namespace Lab2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Gör så att det blir punkter mellan koordinaterna som i lab2pdf exemplet.
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);

            //Skapar lista för alla 20 random shapes
            var shapegen = new List<Shape>();

            //Sätter den till null för att instantiera den.
            Shape3D myshape = null;

            float triangelCircumferenceSum = 0, totalArea = 0;

            //Loopar 20 random shapes som läggs till i listan
            for (var i = 0; i < 20; i++)
                //Lägger till den slumpade shapen i listan med slumpade värden beroendes på vilken metod, i det här fallet med inmatad center position
                shapegen.Add(Shape.GenerateShape(new Vector3(3.0f, 3.0f, 4.0f)));

            //Kollar varje loop för Triangel eller om det är en Shape3D
            foreach (var shape in shapegen)
            {
                if (shape is Triangle)
                {
                    var t = (Triangle)shape;
                    triangelCircumferenceSum += t.Circumference;
                }

                if (shape is Shape3D)
                {
                    //om den inte har instansierat till en shape så sätts den till den första den hittar i loopen som matchar Shape3D
                    if (myshape == null) myshape = (Shape3D)shape;

                    //Skapar en Shape3D variabel som sedan används för att alltid få högsta Volym värdet samt vilken instans
                    var k = (Shape3D)shape;

                    if (k.Volume > myshape.Volume) myshape = k;
                }

                Console.WriteLine($"{shape}");
                totalArea += shape.Area;
            }

            Console.WriteLine($"\nTotal circumference of triangles: {triangelCircumferenceSum:0.0}");
            Console.WriteLine($"Average area of all shapes: {totalArea / 20:0.0}");
            Console.WriteLine(
                $"The 3D Shape with the largest volume is {myshape}\nwith the volume of: {myshape.Volume:0.0}");
            Console.ReadKey();
        }
    }
}