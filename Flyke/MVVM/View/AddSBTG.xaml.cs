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
using System.Windows.Shapes;
using Flyke.MVVM.Model;
using static Flyke.Resources.CustomControls.Sanbay;
using static Flyke.Resources.CustomControls.Chuyenbay;
using Flyke.UserControls;


namespace Flyke.MVVM.View
{
    /// <summary>
    /// Interaction logic for AddSBTG.xaml
    /// </summary>
    public partial class AddSBTG : Window
    {
        DataGrid SanBayTG;
        string maCB;
        int thaotac;
        public AddSBTG(DataGrid sanBayTG, string maCB, int thaotac)
        {
            InitializeComponent();
            SanBayTG = sanBayTG;
            this.maCB = maCB;
            this.thaotac = thaotac;
            string query = "SELECT * FROM SANBAY";
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
                SBTGcBox.Items.Add(dr["TenSanBay"].ToString());
            }
            SBTGcBox.SelectedIndex = 0;
            if (thaotac == 1)
            {
                headertxt.Text = "Sửa sân bay";
                //string s = "SELECT * From SANBAY WHERE MaSanBay = @ma";
                //SqlParameter p = new SqlParameter("@ma", AddChuyenbay.infotofix.tenSB);
                //using (SqlDataReader reader = DataProvider.ExecuteReader(s, CommandType.Text, p))
                //{
                //    if (reader.Read())
                //    {
                //        SBTGcBox.SelectedItem = reader.GetString(reader.GetOrdinal("TenSanBay"));
                //    }
                //}
                SBTGcBox.SelectedItem = AddChuyenbay.infotofix.tenSB;
                thoigiandungTxb.Text = AddChuyenbay.infotofix.TGdung;
                ghichuTxb.Text = AddChuyenbay.infotofix.ghichu;
            }
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public string tenSB, tgDung, GhiChu;

        public void loadDatatoSBTG()
        {
            string query = "SELECT * FROM SANBAYTRUNGGIAN WHERE MaChuyenBay=@macb";
            SqlParameter param1 = new SqlParameter("@macb", maCB);
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

                SanbayTG sb = new SanbayTG();
                sb.STT = stt.ToString();
                string s = "SELECT * From SANBAY WHERE MaSanBay = @ma";
                SqlParameter p = new SqlParameter("@ma", dr["SanBayTrungGian"].ToString());
                using (SqlDataReader reader = DataProvider.ExecuteReader(s, CommandType.Text, p))
                {
                    if (reader.Read())
                    {
                        sb.tenSB = reader.GetString(reader.GetOrdinal("TenSanBay"));
                    }
                }
                //sb.tenSB = dr["SanBayTrungGian"].ToString();
                sb.TGdung = dr["ThoiGianDung"].ToString();
                sb.ghichu = dr["GhiChu"].ToString();
                SanBayTG.Items.Add(sb);
                stt++;
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string s = "SELECT * From SANBAY WHERE TenSanBay = @ten";
            SqlParameter p = new SqlParameter("@ten", SBTGcBox.Text);
            using (SqlDataReader reader = DataProvider.ExecuteReader(s, CommandType.Text, p))
            {
                if (reader.Read())
                {
                    tenSB = reader.GetString(reader.GetOrdinal("MaSanBay"));
                }
            }
            // tenSB = SBTGcBox.Text;
            tgDung = thoigiandungTxb.Text;
            GhiChu = ghichuTxb.Text;
            if (tenSB == "" || tgDung == "" || GhiChu == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (SBTGcBox.Text == AddChuyenbay.tenSBdi || tenSB == AddChuyenbay.tenSBden)
            {
                MessageBox.Show("Sân bay trung gian không được trùng với sân bay đi và sân bay đến.", "Dữ liệu không hợp lệ!");
                return;
            }
            if (thaotac == 0)
            {
                s = "SELECT * From SANBAYTRUNGGIAN where MaChuyenBay = @ma";
                SqlParameter par = new SqlParameter("@ma", maCB);
                DataTable table;
                using (SqlDataReader reader = DataProvider.ExecuteReader(s, CommandType.Text, par))
                {
                    table = new DataTable();
                    if (reader.HasRows)
                    {
                        table.Load(reader);
                        foreach (DataRow dr in table.Rows)
                        {
                            if (dr["SanBayTrungGian"].ToString() == tenSB)
                            {
                                MessageBox.Show("Sân bay trung gian đã có trong chuyến bay này.", "Dữ liệu không hợp lệ!");
                                return;
                            }
                        }

                    }
                }
            }
            try
            {
                int p1 = int.Parse(tgDung);

            }
            catch
            {
                MessageBox.Show("Vui lòng nhập thời gian dừng là một số nguyên.", "Dữ liệu không hợp lệ!");
                return;
            }
            int TGdungtoithieu = 0;
            int TGdungtoida = 0;
            string q = "SELECT * FROM BANGTHAMSO";
            DataTable d;
            using (SqlDataReader reader = DataProvider.ExecuteReader(q, CommandType.Text))
            {
                d = new DataTable();
                if (reader.HasRows)
                {
                    d.Load(reader);
                    DataRow dr = d.Rows[2];
                    TGdungtoithieu = dr.Field<int>(1);
                    dr = d.Rows[3];
                    TGdungtoida = dr.Field<int>(1);
                }
            }
            if (int.Parse(tgDung) < TGdungtoithieu || int.Parse(tgDung) > TGdungtoida)
            {
                string tb = TGdungtoithieu + " phút" + " - " + TGdungtoida + " phút";
                MessageBox.Show("Vui lòng nhập thời gian dừng phải phù hợp với thời gian dừng tối thiểu và tối đa đã định: " + tb, "Dữ liệu không hợp lệ!");
                return;
            }
            if (int.Parse(tgDung) >= int.Parse(AddChuyenbay.thoigianbayDC))
            {
                MessageBox.Show("Vui lòng nhập thời gian dừng phải bé hơn thời gian bay của chuyến bay: " + AddChuyenbay.thoigianbayDC + " phút", "Dữ liệu không hợp lệ!");
                return;
            }
            int tongTG = 0;
            string query9 = "SELECT * FROM SANBAYTRUNGGIAN where MaChuyenBay = @ma";
            SqlParameter param9 = new SqlParameter("@ma", maCB);
            DataTable dt9;
            using (SqlDataReader reader = DataProvider.ExecuteReader(query9, CommandType.Text, param9))
            {
                dt9 = new DataTable();
                if (reader.HasRows)
                {
                    dt9.Load(reader);
                }
                foreach(DataRow dr in dt9.Rows)
                {
                    tongTG += int.Parse(dr["ThoiGianDung"].ToString());
                }
            }
            if (int.Parse(tgDung) + tongTG >= int.Parse(AddChuyenbay.thoigianbayDC) && thaotac==0)
            {
                MessageBox.Show("Tổng thời gian dừng không được lớn hơn hoặc bằng thời gian bay: " + AddChuyenbay.thoigianbayDC + " phút", "Dữ liệu không hợp lệ!");
                return;
            }
           

            if (thaotac == 0)
            {
                string query = "SELECT * FROM SANBAYTRUNGGIAN where MaChuyenBay = @ma";
                SqlParameter param1 = new SqlParameter("@ma", maCB);
                DataTable dt;
                using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
                {
                    dt = new DataTable();
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }
                }
                SanbayTG sb = new SanbayTG();
                sb.STT = (dt.Rows.Count + 1).ToString();
                s = "SELECT * From SANBAY WHERE MaSanBay = @ma";
                p = new SqlParameter("@ma", tenSB);
                using (SqlDataReader reader = DataProvider.ExecuteReader(s, CommandType.Text, p))
                {
                    if (reader.Read())
                    {
                        sb.tenSB = reader.GetString(reader.GetOrdinal("TenSanBay"));
                    }
                }
                // sb.tenSB = tenSB;
                sb.TGdung = tgDung;
                sb.ghichu = GhiChu;
                SanBayTG.Items.Add(sb);
                SqlConnection con = DataProvider.sqlConnection;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Insert into SANBAYTRUNGGIAN values(N'" + tenSB + "',N'" + maCB + "',N'" + tgDung + "',N'" + GhiChu + "')", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();

                this.Close();
            }
            else
            {
                string MaSBTGtofix = "";
                s = "SELECT * From SANBAY WHERE TenSanBay = @ten";
                p = new SqlParameter("@ten", AddChuyenbay.infotofix.tenSB);
                using (SqlDataReader reader = DataProvider.ExecuteReader(s, CommandType.Text, p))
                {
                    if (reader.Read())
                    {
                        MaSBTGtofix = reader.GetString(reader.GetOrdinal("MaSanBay"));
                    }
                }
                SqlConnection con = DataProvider.sqlConnection;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Update [SANBAYTRUNGGIAN] set SanBayTrungGian=N'" + tenSB + "',ThoiGianDung='" + tgDung + "', GhiChu=N'" + GhiChu + "' where MaChuyenBay='" + maCB + "' and SanBayTrungGian=N'" + MaSBTGtofix + "'", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                SanBayTG.Items.Clear();
                loadDatatoSBTG();
                this.Close();
            }

        }
    }
}
