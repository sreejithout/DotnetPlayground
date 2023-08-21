using System.Collections;

namespace Concepts
{
    internal class IsOperator
    {

        public bool NullCheck()
        {
            var i = "hello";
            return i is null;
        }
        public bool NotNullCheck()
        {
            var i = "world";
            return i is not null;
        }

        public bool CheckObjectType()
        {
            var i = new ArrayList() { 1, "hi", true, new { x = "X" } };
            return i is ArrayList;
        }

        public bool CheckValue()
        {
            var i = 5;
            return i is 5;
        }
    }
}
