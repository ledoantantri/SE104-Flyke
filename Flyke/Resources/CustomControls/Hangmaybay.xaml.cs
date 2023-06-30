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
using Flyke.MVVM.View;

namespace Flyke.Resources.CustomControls
{
    /// <summary>
    /// Interaction logic for Hangmaybay.xaml
    /// </summary>
    public partial class Hangmaybay : UserControl
    {
        private readonly QLCB_SB q;
        public Hangmaybay()
        {
            InitializeComponent();
            loadDatatoTable();
        }
        public Hangmaybay(QLCB_SB q)
        {
            InitializeComponent();
            loadDatatoTable();
            this.q = q;
        }
        public void loadDatatoTable()
        {
            string query = "SELECT * FROM HANGMAYBAY";
            SqlParameter param1 = new SqlParameter("", "");
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
                HangMBTable.Items.Add(hb);
                stt++;
            }
        }
        DataTable dt;
        public class HangMBclass
        {
            public string STT { get; set; }
            public string mahang { get; set; }
            public string tenhang { get; set; }
        }
        AddHangMB hangMB;
        private void Them_Click(object sender, RoutedEventArgs e)
        {
            hangMB = new AddHangMB(HangMBTable, 0);
            hangMB.Show();
        }

        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            HangMBclass info = HangMBTable.SelectedItem as HangMBclass;
            if (info != null)
            {
                try
                {
                    SqlConnection con = DataProvider.sqlConnection;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("Delete from HANGMAYBAY where MaHang=N'" + info.mahang + "'", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteReader();
                    con.Close();
                    HangMBTable.Items.Clear();
                    loadDatatoTable();
                    MessageBox.Show("Xóa hãng bay thành công ", "Thông báo");
                }
                catch
                {
                    MessageBox.Show("Hãng máy bay này đã được đưa vào sử dụng, không thể xóa");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng bạn muốn xóa");
            }

        }
        public static HangMBclass hangbaytofix;
        private void Sua_Click(object sender, RoutedEventArgs e)
        {
            hangbaytofix = HangMBTable.SelectedItem as HangMBclass;
            if (hangbaytofix != null)
            {
                hangMB = new AddHangMB(HangMBTable, 1);
                hangMB.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng bạn muốn sửa");
            }
        }

        private void HangMBTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HangMBclass info = (HangMBclass)HangMBTable.SelectedItem;
            if (info != null)
            {
                q.mahangTxb.Text = info.mahang;
                q.tenhangTxb.Text = info.tenhang;
            }
        }
    }
}
