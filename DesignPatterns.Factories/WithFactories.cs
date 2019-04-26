using System;

namespace DesignPatterns.Factories
{

    public class PointForWithFactories
    {
        private double x, y;
        private PointForWithFactories(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        //factory method
        public static PointForWithFactories NewCartesianPoint(double x, double y)
        {
            return new PointForWithFactories(x, y);
        }
        //factory method
        public static PointForWithFactories NewPolarPoint(double rho, double theta)
        {
            return new PointForWithFactories(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }

    public class WithFactories
    {
        public void Run()
        {
            var point = PointForWithFactories.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);
        }
    }
}
