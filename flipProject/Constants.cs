namespace flipProject
{
    public class Constants
    {
        //Database and Table Name
        public static string MasterSchema = "[dbo]";

        public static string BookTable = "[Books]";

        public static string FirstApiTable = "[Firstapi1]";
        //Query
        public static string GellAllBook = $"SELECT * FROM {MasterSchema}.{BookTable} where id = @bookId";

        public static string InsertBook = $"INSERT INTO {MasterSchema}.{BookTable} (id, title, author, description) VALUES(@BookId, @Title, @Author, @Description)";

        public static string InsertFirstApi = $"INSERT INTO {MasterSchema}.{FirstApiTable} VALUES(@Daytime, @Domain, @Stpid, @Mtpid, @DomainExcelSheet, @Piaca_PartnerOneId, @piaca_DownloadExcelSheet)";

        public static string GellAllFirstApi = $"SELECT * FROM {MasterSchema}.{FirstApiTable}";
    }
}
