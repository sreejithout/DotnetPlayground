namespace Concepts._01OOPSConcepts
{
    internal class Polymorphism : BaseClass
    {
        #region Overloading (Compile-Time Polymorphism)
        public int Overloading(int i)
        {
            return i;
        }
        public bool Overloading(string str)
        {
            return true;
        }

        public bool Overloading(int i, string str)
        {
            return true;
        }
        #endregion

        /// <summary>
        /// Override (Run-Time Polymorphism)
        /// Note the override keywork
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public override int OverrideMethod(int x)
        {
            return x;
        }
    }

    internal class BaseClass
    {
        /// <summary>
        /// note the virtual keyword
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public virtual int OverrideMethod(int x)
        {
            return x;
        }
    }
}
