// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

namespace Adapter_Pattern
{
    // interface for ToyBear.
    interface ToyBear
    {
        public void hug();
    }

    // interface for full size bear.
    interface Bear
    {
        public void maul();
        public void hibernate();
    }

    // Grizzly implements the Bear interface.
    class Grizzly : Bear
    {
        public void maul()
        {
            Console.WriteLine("Mauls your face off");
        }

        public void hibernate()
        {
            Console.WriteLine("Hibernates its butt off");
        }
    }

    // TeddyBear implements the ToyBear interface
    class TeddyBear : ToyBear
    {
        public void hug()
        {
            Console.WriteLine("Hugs <3");
        }
    }

    // Implementation of the Adapter Structural Design Pattern
    class BearAdapter : ToyBear
    {
        // Bear member variable (adaptee)
        Bear? imposter = null;

        // Parameterized Constructor
        public BearAdapter(Bear b)
        {
            imposter = b;
        }

        // Sneak Attack!
        public void hug()
        {
            imposter.maul();
        }
    }
    class Program
    {
        static void Main()
        {
            // Create a Bear instance holding a Grizzly
            Bear grizzly = new Grizzly();

            // Create a ToyBear instance holding a TeddyBear
            ToyBear teddy = new TeddyBear();

            // Create a ToyBear instance with the BearAdapter, using your Grizzly as the constructor argument
            ToyBear sus_bear = new BearAdapter(grizzly);

            // Run through all Bear functions with the Grizzly
            grizzly.maul();
            grizzly.hibernate();

            // Run through all ToyBear functions with your TeddyBear
            teddy.hug();

            // Run through all ToyBear functions with your BearAdapter
            sus_bear.hug();

            Console.ReadKey();
        }
    }
}