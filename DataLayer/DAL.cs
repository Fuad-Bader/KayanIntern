using System.Data;
using System.Data.SqlClient;
using Dapper;


namespace KayanIntern.DataLayer
{
    public class DAL
    {
        private static string connectionString = "Data Source=.;Initial Catalog=KayanIntern;TrustServerCertificate=True; Integrated Security=SSPI;";

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(procedureName, param, commandType : CommandType.StoredProcedure);
            }
        }

//DapperORM.ExecuteReturnScalar<T>(_,_);
        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
            }
        }

//DaperORM.ReturnList<T>(_,_);
        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
