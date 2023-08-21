using System.Data.SqlClient; // 1.USING DIRECTIVES

namespace Concepts
{
    internal class UsingKeyword
    {
        /// <summary>
        /// Using Statement ensures that Dispose() method of the class object iscalled even if there's an exception.
        /// It works with those classes which implements IDisposable Interface.
        /// </summary>
        public void UsingStatement()
        {
            using var con = new SqlConnection("ConnectionString"); // 2. Using statement
            var query = "SELECT id, name FROM USERS";
            var command = new SqlCommand(query, con);

            con.Open();
            command.ExecuteReaderAsync();

        }
    }
}
