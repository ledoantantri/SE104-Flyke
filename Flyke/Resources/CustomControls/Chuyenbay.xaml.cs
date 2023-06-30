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
using static Flyke.Resources.CustomControls.Chuyenbay;
using Flyke.MVVM.Model;

namespace Flyke.Resources.CustomControls
{
    /// <summary>
    /// Interaction logic for Chuyenbay.xaml
    /// </summary>
    public partial class Chuyenbay : UserControl
    {
        private readonly QLCB_SB q;
        public Chuyenbay()
        {
            InitializeComponent();
            loadDatatoTable();
        }
        public Chuyenbay(QLCB_SB q)
        {
            InitializeComponent();
            this.q = q;
            loadDatatoTable();
        }
        public void loadDatatoTable()
        {
            string query = "SELECT * FROM CHUYENBAY";
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

                chuyenbayclass cb = new chuyenbayclass();
                cb.STT = stt.ToString();
                cb.maCB = dr["MaChuyenBay"].ToString();
                cb.SBdi = dr["SanBayDi"].ToString();
                cb.SBden = dr["SanBayDen"].ToString();
                cb.datetime = dr["NgayKhoiHanh"].ToString() + "-" + dr["ThoiGianXuatPhat"].ToString();
                cb.tgBay = dr["ThoiGianDuKien"].ToString();
                cb.Gia = dr["Gia"].ToString();
                CBTable.Items.Add(cb);
                stt++;
            }
        }
        DataTable dt;
        public class chuyenbayclass
        {
            public string STT { get; set; }
            public string maCB { get; set; }
            public string SBdi { get; set; }
            public string SBden { get; set; }
            public string datetime { get; set; }
            public string tgBay { get; set; }
            public string Gia { get; set; }
        }
        public class SanbayTG
        {
            public string STT { get; set; }
            public string tenSB { get; set; }
            public string TGdung { get; set; }
            public string ghichu { get; set; }
        }
        AddChuyenbay addChuyenbay;
        private void Them_Click(object sender, RoutedEventArgs e)
        {
            addChuyenbay = new AddChuyenbay(CBTable, 0);
            addChuyenbay.Show();
        }

        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            chuyenbayclass info = CBTable.SelectedItem as chuyenbayclass;
            if (info != null)
            {
                Boolean flag = false;
                string query = "SELECT * From VE where MaChuyenBay = @ma";
                SqlParameter param1 = new SqlParameter("@ma", info.maCB);
                DataTable table;
                using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
                {
                    table = new DataTable();
                    if (reader.HasRows)
                    {
                        table.Load(reader);

                    }
                    foreach (DataRow dr in table.Rows)
                    {
                        if (dr["TinhTrang"].ToString() != "TRONG") flag = true;
                    }
                }
                if (flag == true)
                {
                    MessageBox.Show("Chuyến bay đã được đưa vào sử dụng, không thể xóa.", "Thông báo");
                    return;
                }
                SqlConnection con = DataProvider.sqlConnection;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd2 = new SqlCommand("Delete from  SANBAYTRUNGGIAN where MaChuyenBay=N'" + info.maCB + "'", con);
                cmd2.CommandType = CommandType.Text;
                cmd2.ExecuteReader();
                con.Close();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd3 = new SqlCommand("Delete from VE where  MaChuyenBay=N'" + info.maCB + "'", con);
                cmd3.CommandType = CommandType.Text;
                cmd3.ExecuteReader();
                con.Close();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd1 = new SqlCommand("Delete from QuanLyHangVeChuyenBay where  MaChuyenBay=N'" + info.maCB + "'", con);
                cmd1.CommandType = CommandType.Text;
                cmd1.ExecuteReader();
                con.Close();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Delete from CHUYENBAY where MaChuyenBay=N'" + info.maCB + "'", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();
                con.Close();
                CBTable.Items.Clear();
                loadDatatoTable();
                MessageBox.Show("Xóa chuyến bay thành công ", "Thông báo");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng bạn muốn xóa");
            }

        }
        QLCB_SB qLCB_SB;
        public static chuyenbayclass chuyenbaytofix;
        private void Sua_Click(object sender, RoutedEventArgs e)
        {
            chuyenbaytofix = CBTable.SelectedItem as chuyenbayclass;
            if (chuyenbaytofix != null)
            {
                string ngayKH = "";
                string gioKH = "";
                string query = "SELECT * FROM CHUYENBAY where MaCHuyenBay = @ma";
                SqlParameter param1 = new SqlParameter("@ma", chuyenbaytofix.maCB);
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

                    ngayKH = dr["NgayKhoiHanh"].ToString();
                    gioKH = dr["ThoiGianXuatPhat"].ToString();

                }
                DateTime currentTime = DateTime.Now;
                int second = currentTime.Second;
                string[] thoigian = ngayKH.Split('/');
                int nam = int.Parse(thoigian[2]);
                int thang = int.Parse(thoigian[1]);
                int ngay = int.Parse(thoigian[0]);
                string[] thoigianKH = gioKH.Split(':');
                DateTime specificTime = new DateTime(nam, thang, ngay, int.Parse(thoigianKH[0]), int.Parse(thoigianKH[1]), second);
                if (specificTime <= currentTime)
                {
                    MessageBox.Show("Chuyến bay này đã khởi hành, không thể sửa ", "Thông báo");
                    return;
                }
                Boolean flag = false;
                query = "SELECT * From VE where MaChuyenBay = @ma";
                param1 = new SqlParameter("@ma", chuyenbaytofix.maCB);
                DataTable table;
                using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
                {
                    table = new DataTable();
                    if (reader.HasRows)
                    {
                        table.Load(reader);

                    }
                    foreach (DataRow dr in table.Rows)
                    {
                        if (dr["TinhTrang"].ToString() != "TRONG") flag = true;
                    }
                }
                if (flag == true)
                {
                    MessageBox.Show("Chuyến bay đã được đưa vào sử dụng, không thể sửa.", "Thông báo");
                    return;
                }
                AddChuyenbay cb = new AddChuyenbay(CBTable, 1);
                cb.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng bạn muốn sửa");
            }
        }

        private void CBTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //q.sanbaydetail.Visibility = Visibility.Hidden;
            //q.Cbaydetail.Visibility = Visibility.Visible;
            chuyenbayclass info = CBTable.SelectedItem as chuyenbayclass;
            if (info != null)
            {
                q.machuyenbayTxb.Text = info.maCB;
                string s = "SELECT * From SANBAY WHERE MaSanBay = @ma";
                SqlParameter p = new SqlParameter("@ma", info.SBdi);
                using (SqlDataReader reader = DataProvider.ExecuteReader(s, CommandType.Text, p))
                {
                    if (reader.Read())
                    {
                        q.fromTxb.Text = reader.GetString(reader.GetOrdinal("TenSanBay"));
                    }
                }
                // q.fromTxb.Text = info.SBden;
                s = "SELECT * From SANBAY WHERE MaSanBay = @ma";
                p = new SqlParameter("@ma", info.SBden);
                using (SqlDataReader reader = DataProvider.ExecuteReader(s, CommandType.Text, p))
                {
                    if (reader.Read())
                    {
                        q.toTxb.Text = reader.GetString(reader.GetOrdinal("TenSanBay"));
                    }
                }
                //  q.toTxb.Text =  info.SBdi;
                q.datetimeTxb.Text = info.datetime;
                string query = "SELECT * FROM CHUYENBAY where MaChuyenBay = @ma";
                SqlParameter param1 = new SqlParameter("@ma", info.maCB);
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

                    q.GiaTxb.Text = dr["Gia"].ToString();
                }
            }
        }
    }
}
