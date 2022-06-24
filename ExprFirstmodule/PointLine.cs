using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExprFirstmodule
{
    internal class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point() : this(0, 0)
        {

        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double FindDistance(Point point)
        {
            return Math.Sqrt((point.X - X) * (point.X - X) + (point.Y - Y) * (point.Y - Y));
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Пряма з координатами \nХ: {X}; Y: {Y};");
        }
    }

    internal class Straight
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }

        public Straight() : this(0, 0, 0, 0)
        {

        }

        public Straight(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public Point FindMiddleStraight()
        {
            double x = (X1 + X2) / 2;
            double y = (Y1 + Y2) / 2;
            return new Point(x, y);
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Пряма з координатами \nХ1: {X1}; Y1: {Y1}; \nХ2: {X2}; Y2: {Y2};");
        }
    }
}
