namespace LinqPlayground._01Intro
{
    internal class QuerySyntax
    {
        public List<int> QuerySyntaxExample()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var querySyntax = from obj in list
                              where obj == 2
                              select obj;

            return querySyntax.ToList();
        }
    }
}
