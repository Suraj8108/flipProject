using flipProject.Helpers;
using Microsoft.ApplicationInsights;
using System.Data;
using System.Data.SqlClient;

namespace flipProject.Services
{
    public class BookServices : IBookServices
    {
        public SQLHelper sqlHelper;
        //public TelemetryClient telemetry;

        public BookServices(SQLHelper dbConnection)
        {
            sqlHelper = dbConnection;
        }
        public DataTable GetAllData(int BookId)
        {
            try
            {
                List<SqlParameter> paramList = new List<SqlParameter> {
                new SqlParameter("@bookId", BookId),
            };
                DataTable result = sqlHelper.ExecuteSelectQuery(Constants.GellAllBook, paramList);
                return result;
            }
            catch (Exception e)
            {
                //telemetry.TrackException(e);
                return null;
            }
        }

        public DataTable InsertData(int BookId, string Title, string Author, string Description)
        {
            try
            {
                List<SqlParameter> paramList = new List<SqlParameter> {
                new SqlParameter("@BookId", BookId),
                new SqlParameter("@Title", Title),
                new SqlParameter("@Author", Author),
                new SqlParameter("@Description", Description),
            };
                DataTable result = sqlHelper.ExecuteSelectQuery(Constants.InsertBook, paramList);
                return result;
            }
            catch (Exception e)
            {
                //telemetry.TrackException(e);
                return null;
            }
        }
    }
}
