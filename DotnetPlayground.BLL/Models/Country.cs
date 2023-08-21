namespace DotnetPlayground.BLL.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; init; }

        /// <summary>
        /// We created this to make sure the Name is not nullable
        /// </summary>
        /// <param name="name"></param>
        public Country(string name)
        {
            Name = name;
        }
    }
}
