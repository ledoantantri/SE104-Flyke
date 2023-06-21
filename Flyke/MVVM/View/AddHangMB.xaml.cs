using Flyke.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Flyke.Resources.CustomControls.Hangmaybay;
using Flyke.UserControls;
using Flyke.Resources.CustomControls;

namespace Flyke.MVVM.View
{
    /// <summary>
    /// Interaction logic for AddHangMB.xaml
    /// </summary>
    public partial class AddHangMB : Window
    {
        int thaotac;
        DataGrid hangmbtable;
        public AddHangMB(DataGrid dataGrid, int thaotac)
        {
            InitializeComponent();
            this.thaotac = thaotac;
            this.hangmbtable = dataGrid;
            if (thaotac == 1)
            {
                headertxt.Text = "Sửa hãng bay";
                mahangTxb.Text = Hangmaybay.hangbaytofix.mahang;
                mahangTxb.IsEnabled = false;
                tenhangTxb.Text = Hangmaybay.hangbaytofix.tenhang;
            }
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void loadDatatoHMB()
        {
            string query = "SELECT * FROM HANGMAYBAY";
            SqlParameter param1 = new SqlParameter("", "");
            DataTable dt;
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
            {
                dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            int stt = 1;
            foreach (DataRow dr in dt.Rows)
            {

                HangMBclass hb = new HangMBclass();
                hb.STT = stt.ToString();
                hb.mahang = dr["MaHang"].ToString();
                hb.tenhang = dr["TenHang"].ToString();
                hangmbtable.Items.Add(hb);
                stt++;
            }
        }
        private string mahang, tenhang;
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            mahang = mahangTxb.Text;
            tenhang = tenhangTxb.Text;
            if (mahang == "" || tenhang == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (thaotac == 0)
            {
                string s = "SELECT * From HANGMAYBAY WHERE MaHang = @ma";
                SqlParameter p = new SqlParameter("@ma", mahang);
                using (SqlDataReader reader = DataProvider.ExecuteReader(s, CommandType.Text, p))
                {
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Mã hãng đã tồn tại. ", "Dữ liệu không hợp lệ!");
                        return;
                    }
                }
            }
            if (thaotac == 0)
            {
                string query = "SELECT * FROM HANGMAYBAY";
                SqlParameter param1 = new SqlParameter("", "");
                DataTable dt;
                using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
                {
                    dt = new DataTable();
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }
                }
                HangMBclass hb = new HangMBclass();
                hb.STT = (dt.Rows.Count + 1).ToString();
                hb.tenhang = tenhang;
                hb.mahang = mahang;
                hangmbtable.Items.Add(hb);
                SqlConnection con = DataProvider.sqlConnection;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Insert into HANGMAYBAY values(N'" + mahang + "',N'" + tenhang + "',N'" + "" + "')", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();

                this.Close();
            }
            else
            {
                SqlConnection con = DataProvider.sqlConnection;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Update [HANGMAYBAY] set MaHang=N'" + mahang + "',TenHang=N'" + tenhang + "' where MaHang=N'" + Hangmaybay.hangbaytofix.mahang + "'", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                hangmbtable.Items.Clear();
                loadDatatoHMB();
                this.Close();
            }
        }
    }
}
