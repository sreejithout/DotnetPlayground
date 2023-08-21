namespace Concepts.Constructors
{
    internal class DefaultAndParametarizedConstructors
    {
        /// <summary>
        /// This is a default constructor.
        /// </summary>
        public DefaultAndParametarizedConstructors()
        {
            Console.WriteLine("Default Constructor");
        }

        /// <summary>
        /// This is a parametarized constructor.
        /// </summary>
        public DefaultAndParametarizedConstructors(int i)
        {
            Console.WriteLine($"parametarized Constructor: {i}");
        }

        /// <summary>
        /// This is another parametarized constructor.
        /// </summary>
        public DefaultAndParametarizedConstructors(string str)
        {
            Console.WriteLine($"parametarized Constructor: {str}");
        }
    }
}
