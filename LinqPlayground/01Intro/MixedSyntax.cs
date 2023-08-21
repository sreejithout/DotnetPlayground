using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPlayground._01Intro
{
    internal class MixedSyntax
    {
        public int MixedSyntaxExample()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var mixedSyntaxResult = (from obj in list
                              select obj).Max();

            return mixedSyntaxResult;
        }
    }
}
