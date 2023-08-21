namespace LinqPlayground._01Intro
{
    internal class MethodSyntax
    {
        public List<int> MethodSyntaxExample()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var methodSyntax = list.Where(obj=> obj == 2);

            return methodSyntax.ToList();
        }
    }
}
