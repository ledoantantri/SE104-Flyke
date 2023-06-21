using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyke.Model
{
    internal class DataProvider
    {
        //private static string connectionStr = @"Data Source=(local);Initial Catalog=Flyke;Integrated Security=True";
        private static string connectionStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=Flyke;Integrated Security=True";

        public static SqlDataReader ExecuteReader(String commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionStr);

            SqlCommand cmd = new SqlCommand(commandText, conn);

            cmd.CommandType = commandType;
            cmd.Parameters.AddRange(parameters);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }


        //public static SqlConnection sqlConnection = new SqlConnection(@"Data Source=(local);Initial Catalog=Flyke;Integrated Security=True");
        public static SqlConnection sqlConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Flyke;Integrated Security=True");

        public static List<string> colorList = new List<string>() { "#C8D70C", "#CB1D1D", "#459DF2", "#459DF2", "#F44EEE", "#ECA65D", "#ECA65D", "#C0F081" };
    }
}
