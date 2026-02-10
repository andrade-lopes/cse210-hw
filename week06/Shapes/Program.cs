using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        // Create list of shapes (polymorphism in action)
        List<Shape> shapes = new List<Shape>();

        // Add different shapes
        shapes.Add(new Square("Red", 4));


        // Iterate and display the areas and colors
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea():0.00}\n");
        }
    }
}