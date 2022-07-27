using flipProject.Helpers;
using flipProject.Interface;
using System.Data;
using System.Data.SqlClient;

namespace flipProject.Services
{
    public class FirstApiServices : IFirstApi
    {

        public SQLHelper sqlHelper;
        //public TelemetryClient telemetry;

        public FirstApiServices(SQLHelper dbConnection)
        {
            sqlHelper = dbConnection;
        }

        public DataTable GetAllData()
        {
            DataTable result = sqlHelper.ExecuteSelectQuery(Constants.GellAllFirstApi);
            return result;
        }

        public DataTable InsertData(string Daytime, string Domain, int Stpid, int Mtpid, string DomainExcelSheet, int Piaca_PartnerOneId, string piaca_DownloadExcelSheet)
        {
            try
            {
                List<SqlParameter> paramList = new List<SqlParameter> {
                new SqlParameter("@Daytime", Daytime),
                new SqlParameter("@Domain", Domain),
                new SqlParameter("@Stpid", Stpid),
                new SqlParameter("@Mtpid", Mtpid),
                new SqlParameter("@DomainExcelSheet", DomainExcelSheet),
                new SqlParameter("@Piaca_PartnerOneId", Piaca_PartnerOneId),
                new SqlParameter("@piaca_DownloadExcelSheet", piaca_DownloadExcelSheet),
            };
                DataTable result = sqlHelper.ExecuteSelectQuery(Constants.InsertFirstApi, paramList);
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
