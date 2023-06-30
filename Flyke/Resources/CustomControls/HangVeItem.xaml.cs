using Flyke.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flyke.Resources.CustomControls
{
    /// <summary>
    /// Interaction logic for HangVeItem.xaml
    /// </summary>
    public partial class HangVeItem : UserControl
    {
        public HangVeItem()
        {
            InitializeComponent();
            string query = "SELECT * FROM HANGVE";
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
            foreach (DataRow dr in dt.Rows)
            {
                maHVcBox.Items.Add(dr["TenHangVe"]);
            }

            SLcBox.Items.Add("6");
            SLcBox.Items.Add("12");
            SLcBox.Items.Add("18");

        }


        private void maHVcBox_DropDownClosed(object sender, EventArgs e)
        {
            HangVe hv = (sender as ComboBox).DataContext as HangVe;
            if (hv != null)
            {
                hv.Mahangve = (sender as ComboBox).SelectedItem as string;
                //string s = "SELECT * From HANGVE WHERE TenHangVe = @ten";
                //SqlParameter p = new SqlParameter("@ten", (sender as ComboBox).SelectedItem as string);
                //using (SqlDataReader reader = DataProvider.ExecuteReader(s, CommandType.Text, p))
                //{
                //    if (reader.Read())
                //    {
                //        hv.Mahangve = reader.GetString(reader.GetOrdinal("MaHangVe"));
                //    }
                //}
            }
        }

        private void SLcBox_DropDownClosed(object sender, EventArgs e)
        {
            HangVe hv = (sender as ComboBox).DataContext as HangVe;
            if (hv != null)
            {
                hv.Soluong = (sender as ComboBox).SelectedItem as string;
            }
        }

        private void maHVcBox_DropDownOpened(object sender, EventArgs e)
        {
            HangVe hv = (sender as ComboBox).DataContext as HangVe;
            if (hv.Machuyenbay != null && hv.Mahangve != null)
            {
                string maHV = "";
                string s = "SELECT * From HANGVE WHERE TenHangVe = @ten";
                SqlParameter p = new SqlParameter("@ten", hv.Mahangve);
                using (SqlDataReader reader = DataProvider.ExecuteReader(s, CommandType.Text, p))
                {
                    if (reader.Read())
                    {
                        maHV = reader.GetString(reader.GetOrdinal("MaHangVe"));
                    }
                }
                string query = "SELECT * From VE where MaChuyenBay = @ma and MaHangVe = @mah";
                SqlParameter param1 = new SqlParameter("@ma", hv.Machuyenbay);
                SqlParameter param2 = new SqlParameter("@mah", maHV);
                DataTable table;
                using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1, param2))
                {
                    table = new DataTable();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Không thể sửa hạng vé này.", "Thông báo");

                        return;

                    }
                }
            }
        }

        private void SLcBox_DropDownOpened(object sender, EventArgs e)
        {
            HangVe hv = (sender as ComboBox).DataContext as HangVe;
            if (hv.Machuyenbay != null && hv.Mahangve != null)
            {
                string maHV = "";
                string s = "SELECT * From HANGVE WHERE TenHangVe = @ten";
                SqlParameter p = new SqlParameter("@ten",
                                                  hv.Mahangve);
                using (SqlDataReader reader = DataProvider.ExecuteReader(s, CommandType.Text, p))
                {
                    if (reader.Read())
                    {
                        maHV = reader.GetString(reader.GetOrdinal("MaHangVe"));
                    }
                }
                string query = "SELECT * From VE where MaChuyenBay = @ma and MaHangVe = @mah";
                SqlParameter param1 = new SqlParameter("@ma", hv.Machuyenbay);
                SqlParameter param2 = new SqlParameter("@mah", maHV);
                DataTable table;
                using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1, param2))
                {
                    table = new DataTable();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Không thể sửa hạng vé này.", "Thông báo");

                        return;

                    }
                }
            }
        }
    }
}
