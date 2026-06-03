using System.Configuration;
using System.Data.SqlClient;

namespace LifeFlowBBMS.DAL
{
    public static class ConnectionManager
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(
                ConfigurationManager.ConnectionStrings["cn"].ConnectionString
            );
        }
    }
}