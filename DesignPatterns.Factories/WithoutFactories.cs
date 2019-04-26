using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factories
{
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }

    public class PointForWithOutFactories
    {
        private double x, y;
        public PointForWithOutFactories(double x, double y, CoordinateSystem coordinateSystem = CoordinateSystem.Cartesian)
        {
            switch (coordinateSystem)
            {
                case CoordinateSystem.Cartesian:
                    this.x = x;
                    this.y = y;
                    break;
                case CoordinateSystem.Polar:
                    this.x = x * Math.Cos(y);
                    this.y = x * Math.Sin(y);
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
    public class WithoutFactories
    {
        public void Run()
        {
            var point = new PointForWithOutFactories(50, 11, CoordinateSystem.Cartesian);
            Console.WriteLine(point);
        }
    }
}
