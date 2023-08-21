namespace DotnetPlayground.BLL.Models
{
    public  class User
    {
        public int Id { get; set; }
        public int CountryId { get; set; }

        /// <summary>
        /// You see the 'init' here? 
        /// The only way we can set the value for this property is through constructor.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// We created this to make sure the Name is not nullable
        /// </summary>
        /// <param name="name"></param>
        public User(string name)
        {
            Name = name;
        }
    }
}
