using flipProject.Helpers;
using flipProject.Interface;
using flipProject.Models;
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

        public DataTable InsertData(Firstapi firstApiData)
        {
            try
            {
                List<SqlParameter> paramList = new List<SqlParameter> {
                new SqlParameter("@Daytime", firstApiData.Daytime),
                new SqlParameter("@Domain", firstApiData.Domain),
                new SqlParameter("@Stpid", firstApiData.Stpid),
                new SqlParameter("@Mtpid", firstApiData.Mtpid),
                new SqlParameter("@DomainExcelSheet", firstApiData.DownloadExcelSheet),
                new SqlParameter("@Piaca_PartnerOneId", firstApiData.Piaca_PartnerOneId),
                new SqlParameter("@piaca_DownloadExcelSheet", firstApiData.piaca_DownloadExcelSheet),
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
