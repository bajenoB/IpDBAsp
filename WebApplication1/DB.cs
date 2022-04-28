using System.Data.SqlClient;

namespace WebApplication1
{
    public class DataBase
    {
        private string connectionString;
        private SqlConnection conn;
        public DataBase()
        {
            connectionString = @"Data Source = SQL8001.site4now.net; Initial Catalog = db_a84e8b_bajen; User Id = db_a84e8b_bajen_admin; Password = Savelstan123";
            conn = new SqlConnection(connectionString);
        }
        public void ConnectToDB()
        {
            try
            {
                conn.Open();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InsertFile(string fileName, byte[] data)
        {
            string query = $"INSERT INTO File_Info (File_Name,Data) VALUES (@File_Name,@Data)";
            using (SqlCommand sqlCommand = new SqlCommand(query, conn))
            {
                try
                {
                    SqlParameter parameter1 = sqlCommand.Parameters.AddWithValue("@File_Name", fileName);
                    parameter1.DbType = System.Data.DbType.String;
                    SqlParameter parameter2 = sqlCommand.Parameters.AddWithValue("@Data", data);
                    parameter2.DbType = System.Data.DbType.Binary;

                    sqlCommand.ExecuteNonQuery();
                }
                catch (System.Exception)
                {

                    throw;
                }
            }

        }
    }
}