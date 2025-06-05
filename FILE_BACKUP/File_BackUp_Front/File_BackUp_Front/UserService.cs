using System.Data.SqlClient;
using System.Configuration;

namespace File_BackUp_Front
{
    public class UserService
    {
        public static bool Login(string userId, string pw, out bool isAdmin, out string userName)
        {
            isAdmin = false;
            userName = "";
            string connStr = ConfigurationManager.ConnectionStrings["BackupDb"].ConnectionString;
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT UserName, IsAdmin FROM TEST_Users WHERE UserID=@id AND Password=@pw", conn);
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.Parameters.AddWithValue("@pw", pw);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        userName = r.GetString(0);
                        isAdmin = r.GetBoolean(1);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
