namespace Concepts
{
    internal class ReadonlyAndConstant
    {
        public readonly int readonly1 = 100; // assigned values in declaration part
        public readonly int readonly2;
        public const int myConstant = 30; // need to assign values here and cannot be changed.

        /// <summary>
        /// 1. Readonly field is run-time
        /// 2. Const field is compile-time
        /// </summary>
        public ReadonlyAndConstant()
        {
            readonly2 = 50; //  assigned values in construction part
        }
    }
}
