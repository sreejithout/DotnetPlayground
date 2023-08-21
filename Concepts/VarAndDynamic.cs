namespace Concepts
{
    internal class VarAndDynamic
    {
        /// <summary>
        /// Type of the variable is decided compile-time
        /// We need to 
        /// </summary>
        public int VarExample()
        {
            var x = 7;
            return x;
        }

        /// <summary>
        /// Type of the variable is decided run-time
        /// </summary>
        /// <returns></returns>
        public dynamic DynamicExample()
        {
            dynamic x;
            x = 7;
            x = "hi";
            return x;
        }
    }
}
