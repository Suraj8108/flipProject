namespace flipProject
{
    public class Constants
    {
        //Database and Table Name
        public static string MasterSchema = "[dbo]";

        public static string BookTable = "[Books]";

        //Query
        public static string GellAllBook = $"SELECT * FROM {MasterSchema}.{BookTable} where id = @bookId";

        public static string InsertBook = $"INSERT INTO {MasterSchema}.{BookTable} (id, title, author, description) VALUES(@BookId, @Title, @Author, @Description)";
    }
}
