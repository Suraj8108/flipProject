using System.Data;

namespace flipProject.Services
{
    public interface IBookServices
    {
        public DataTable GetAllData(int BookId);
        public DataTable InsertData(int BookId, string Title, string Author, string Description);
    }
}
