using System;

namespace DesignPatterns.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            //Without Builder
            var withoutBuilder = new WithoutBuilder();
            withoutBuilder.Run();

            //WithBuilder

            //basic
            var withBuilder = new WithBuilder();
            withBuilder.Run();

            //fluently
            withBuilder.RunForFluent();



            //Fluent Builder
            var fluentBuilder = new FluentBuilder();
            fluentBuilder.Run();


            //Faceted Builder
            var facetedBuilder = new FacetedBuilder();
            facetedBuilder.Run();

            Console.ReadKey();
        }
    }
}
