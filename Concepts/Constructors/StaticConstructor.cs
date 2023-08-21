namespace Concepts.Constructors
{
    internal class StaticConstructor
    {
        /// <summary>
        /// Static constructor gets called before the Static Method is invoked.
        /// </summary>
        static StaticConstructor()
        {
            Console.WriteLine("Static Constructor");
        }

        public static void StaticMethod()
        {
            Console.WriteLine("Static Method");
        }
    }
}
