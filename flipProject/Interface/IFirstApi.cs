using System.Data;

namespace flipProject.Interface
{
    public interface IFirstApi
    {
        public DataTable GetAllData();
        public DataTable InsertData(string Daytime, string Domain, int Stpid, int Mtpid, string DomainExcelSheet, int Piaca_PartnerOneId, string piaca_DownloadExcelSheet);
    }
}
