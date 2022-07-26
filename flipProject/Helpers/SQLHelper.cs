using Microsoft.ApplicationInsights;
using System.Data;
using System.Data.SqlClient;

namespace flipProject.Helpers
{
    public class SQLHelper
    {
        readonly string sqlConnectionString;
        readonly string userAssignedClientId;

        public SQLHelper()
        {
            sqlConnectionString = "Data Source=DESKTOP-H92FAID;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
        }

        public SqlConnection GetSQLConnection()
        {
            SqlConnection connection = new SqlConnection(sqlConnectionString);
            return connection;
        }

        public DataTable ExecuteSelectQuery(string selectQuery, List<SqlParameter> queryParameters = null)
        {
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                DataTable resultSet = new DataTable();
                using (sqlConnection = GetSQLConnection())
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(selectQuery, sqlConnection)
                    {
                        CommandTimeout = 100
                    };
                    if (queryParameters?.Count > 0)
                    {
                        sqlCommand.Parameters.AddRange(queryParameters.ToArray());
                    }
                    SqlDataReader rd = sqlCommand.ExecuteReader();
                    resultSet.Load(rd);
                    rd.Close();
                }
                return resultSet;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

    }
}
