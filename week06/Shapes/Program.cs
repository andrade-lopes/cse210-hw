using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.\n");

        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 4));
        shapes.Add(new Rectangle("Blue", 5, 3));
        shapes.Add(new Circle("Green", 2.5));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape name: {shape.GetName()}");
            Console.WriteLine($"Shape color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea():0.00}\n");
        }
    }
}