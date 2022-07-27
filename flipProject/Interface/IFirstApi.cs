using flipProject.Models;
using System.Data;

namespace flipProject.Interface
{
    public interface IFirstApi
    {
        public DataTable GetAllData();
        public DataTable InsertData(Firstapi firstApiData);
    }
}
