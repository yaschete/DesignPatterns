
namespace DesignPatterns.Factories
{
    class Program
    {
        static void Main(string[] args)
        {
            //without factory
            var withoutFactories = new WithoutFactories();
            withoutFactories.Run();

            //with factory
            var withFactories = new WithFactories();
            withFactories.Run();

            //abstract factory
            var abstractFactory = new AbstractFactory();
            abstractFactory.Run();
        }
    }
}
