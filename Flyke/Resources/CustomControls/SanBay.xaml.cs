using Flyke.MVVM.View;
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
using Flyke.Model;
using MaterialDesignThemes.Wpf;

namespace Flyke.Resources.CustomControls
{
    /// <summary>
    /// Interaction logic for Sanbay.xaml
    /// </summary>
    public partial class Sanbay : UserControl
    {
        TextBox Ma, Ten;
        private readonly QLCB_SB q;
        public Sanbay()
        {
            InitializeComponent();
            loadDatatoTable();
        }
        public Sanbay(QLCB_SB q)
        {
            InitializeComponent();
            loadDatatoTable();
            this.q = q;
        }
        public void loadDatatoTable()
        {
            string query = "SELECT * FROM SANBAY";
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

                sanbayclass sb = new sanbayclass();
                sb.STT = stt.ToString();
                sb.maSB = dr["MaSanBay"].ToString();
                sb.tenSB = dr["TenSanBay"].ToString();
                sb.tinh = dr["Tinh"].ToString();
                SBTable.Items.Add(sb);
                stt++;
            }
        }
        DataTable dt;
        public class sanbayclass
        {
            public string STT { get; set; }
            public string maSB { get; set; }
            public string tenSB { get; set; }
            public string tinh { get; set; }
        }

        AddSanBay addSB;
        private void Them_Click(object sender, RoutedEventArgs e)
        {
            addSB = new AddSanBay(SBTable, 0);
            addSB.Show();
        }
        // DataRowView dataRow;
        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            sanbayclass info = SBTable.SelectedItem as sanbayclass;
            if (info != null)
            {
                int kt = 0;
                string query = "SELECT * From CHUYENBAY where SanBayDi = @sbdi";
                SqlParameter param1 = new SqlParameter("@sbdi", info.maSB);
                using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
                {
                    if (reader.HasRows)
                    {
                        kt += 1;

                    }
                }
                string query1 = "SELECT * From CHUYENBAY where SanBayDen = @sbden";
                SqlParameter param2 = new SqlParameter("@sbden", info.maSB);
                using (SqlDataReader reader = DataProvider.ExecuteReader(query1, CommandType.Text, param2))
                {
                    if (reader.HasRows)
                    {
                        kt += 1;

                    }
                }
                if (kt == 0)
                {
                    SqlConnection con = DataProvider.sqlConnection;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("Delete from SANBAY where MaSanBay=N'" + info.maSB + "'", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteReader();
                    con.Close();
                    SBTable.Items.Clear();
                    loadDatatoTable();
                    MessageBox.Show("Xóa sân bay thành công ", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Sân bay này không thể xóa", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng bạn muốn xóa");
            }

        }
        QLCB_SB qLCB_SB;
        public static sanbayclass sanbaytofix;
        private void Sua_Click(object sender, RoutedEventArgs e)
        {
            sanbaytofix = SBTable.SelectedItem as sanbayclass;
            if (sanbaytofix != null)
            {
                addSB = new AddSanBay(SBTable, 1);
                addSB.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng bạn muốn sửa");
            }


        }

        private void SBTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataGrid dv = (DataGrid)sender;
            //DataRowView dataRow = dv.SelectedItem as DataRowView ;
            //q.sanbaydetail.Visibility = Visibility.Visible;
            //q.Cbaydetail.Visibility = Visibility.Hidden;
            sanbayclass info = SBTable.SelectedItem as sanbayclass;
            // qLCB_SB = new QLCB_SB(info.maSB,info.tenSB);
            if (info != null)
            {
                q.masanbayTxb.Text = info.maSB;
                q.tensanbayTxb.Text = info.tenSB;
                q.tinhTxb.Text = info.tinh;
            }
        }
    }
}
