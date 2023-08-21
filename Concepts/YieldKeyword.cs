namespace Concepts
{
    internal class YieldKeyword
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberArray"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetNumbersList(int[] numberArray)
        {
            foreach (var number in numberArray) { 
                yield return number;
            }
        }
    }
}
