using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Data;
using Flyke.MVVM.Model;
using Flyke.Pages;
using System.Globalization;
using Microsoft.Office.Interop.Excel;


namespace Flyke.MVVM.View
{
    public partial class AddInforHK : System.Windows.Window
    {


        List<Ve> ve = new List<Ve>();
        List<string> list_mave = new List<string>();
        DateTime ngayHD = new DateTime();
        public event RoutedEventHandler GoToHomeScreen;

        public AddInforHK()
        {
            InitializeComponent();            
            if (MainWindow.curAccount != null) {
                if (MainWindow.curAccount.type == 1 || MainWindow.curAccount.type == 2)
                {
                    tbl_MaTK.Text = "Mã nhân viên: ";
                    btnTTNgay.Content = "Đã thanh toán";
                    btnTTSau.Content = "Chưa thanh toán";
                }
            }
        }               

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnXacNhanVe_Click(object sender, RoutedEventArgs e)
        {
            if (tenHanhKhachTxt.Text == "" || cmndTxt.Text == "" || sdtTxt.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hành khách!");
            }
            else
            {
                if (!CheckCMND())
                {
                    MessageBox.Show("Thông tin hành khách không hợp lệ.\nCMND đã được đăng ký cho một vé khác\nVui lòng kiểm tra và sửa đổi thông tin hành khách!");
                }
                else
                {

                    foreach (Ve item in ve)
                    {
                        if (item.TiketID == maVeBox.SelectedItem.ToString())
                        {
                            item.HkID = maHanhKhachText.Text;
                            item.HkName = tenHanhKhachTxt.Text;
                            item.CMND = cmndTxt.Text;
                            item.PhoneNumber = sdtTxt.Text;
                        }
                    }
                }
            }
        }

        private bool CheckCMND()
        {
            bool check = true;
            if (DataProvider.sqlConnection.State != ConnectionState.Open)
            DataProvider.sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(
                "select [v].CMND from [VE] [v] where [v].CMND = @cmnd ", DataProvider.sqlConnection);
            sqlCommand.Parameters.Add("@cmnd", SqlDbType.NVarChar).Value = cmndTxt.Text;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                check = false;
            }
            DataProvider.sqlConnection.Close();
            
            foreach(Ve ticket in ve)
            {
                if (ticket.CMND == cmndTxt.Text)
                {
                    check = false;
                }
            }
            return check;
        }

        private void TienVe()
        {
            int tien = 0;
            foreach (Ve item in ve)
            {
                DataProvider.sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(
                    "select [c].Gia, [hv].TyLe from [CHUYENBAY] [c], [HANGVE] [hv], [VE] [v] where [c].MaChuyenBay = @macb " +
                    "and [v].MaChuyenBay = [c].MaChuyenBay " +
                    "and [hv].MaHangVe = [v].MaHangVe " +
                    "and [hv].TenHangVe=@tenHangVe",
                    DataProvider.sqlConnection);
                sqlCommand.Parameters.Add("@macb", SqlDbType.NVarChar).Value = maChuyenBayTxt.Text;
                sqlCommand.Parameters.Add("@tenHangVe", SqlDbType.NVarChar).Value = item.FlightClass;
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        int dongia = int.Parse(reader["Gia"].ToString());
                        double TyLe = double.Parse(reader["TyLe"].ToString());
                        tien += (int)(dongia * TyLe / 100);
                    }
                }
                DataProvider.sqlConnection.Close();
            }
            tienTxt.Text = tien.ToString();
        }
        private void maVeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tenHanhKhachTxt.Clear();
            cmndTxt.Clear();
            sdtTxt.Clear();

            foreach (Ve item in ve)
            {
                if (item.TiketID == maVeBox.SelectedItem.ToString())
                {
                    tenHanhKhachTxt.Text = item.HkName;
                    cmndTxt.Text = item.CMND;
                    sdtTxt.Text = item.PhoneNumber;
                    soGheTxt.Text = item.SeatNumber.ToString();
                    hangVeTxt.Text = item.FlightClass;
                    maHanhKhachText.Text = item.HkID;
                }
            }
        }

        private void NewHD()
        {
            if (DataProvider.sqlConnection.State != ConnectionState.Open)
                DataProvider.sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select [h].* from HOADON [h] order by NgayLap desc", DataProvider.sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    int mahd = int.Parse(reader["MaHD"].ToString()) + 1;
                    maHoaDonTxt.Text = mahd.ToString();
                }
            }
            else maHoaDonTxt.Text = "1";
            DataProvider.sqlConnection.Close();
                        
        }

        private int NewHK_ID()
        {
            int newID = 1;
            DataProvider.sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select [v].* from VE [v] order by CMND desc", DataProvider.sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    if (reader["MaHK"].ToString() != "")
                    {
                        newID = int.Parse(reader["MaHK"].ToString()) + 1;
                    }
                }
            }
            DataProvider.sqlConnection.Close();
            return newID;
        }
        private void veLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ve item = veLV.SelectedItem as Ve;
            if (item != null)
            {
                tenHanhKhachTxt.Text = item.HkName;
                cmndTxt.Text = item.CMND;
                sdtTxt.Text = item.PhoneNumber;
                soGheTxt.Text = item.SeatNumber.ToString();
                hangVeTxt.Text = item.FlightClass;
                maVeBox.SelectedItem = item.TiketID;
                maHanhKhachText.Text = item.HkID;
            }
        }

        public void Show(string macb, List<string> list, string userID)
        {
            NewHD();
            int newHK = NewHK_ID();
            ngayHD = DateTime.Now;
            ngaylapHDTxt.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            maTKTTTxt.Text = userID;
            maVeBox.ItemsSource = list;
            maChuyenBayTxt.Text = macb;

            foreach (string mave in list)
            {
                DataProvider.sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(
                    "select [v].*, [hv].TenHangVe from [VE] [v], [HANGVE] [hv] where [v].MaVe = @mave and [hv].MaHangVe = [v].MaHangVe",
                    DataProvider.sqlConnection);
                sqlCommand.Parameters.Add("@mave", SqlDbType.NVarChar).Value = mave;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Ve ticket = new Ve();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        string mv = reader["MaVe"].ToString();
                        int sg = int.Parse(reader["SoGhe"].ToString());
                        string mhv = reader["TenHangVe"].ToString();
                        string tt = reader["TinhTrang"].ToString();
                        string thk = reader["TenHK"].ToString();
                        string cmnd = reader["CMND"].ToString();
                        string sdt = reader["SDT"].ToString();
                        ticket = new Ve(mv, mhv, sg, tt, "", thk, cmnd, sdt);
                    }
                }
                if (ve.Count == 0)
                {
                    ticket.HkID = newHK.ToString();
                }
                else
                {
                    ticket.HkID = (++newHK).ToString();
                }
                ve.Add(ticket);
                DataProvider.sqlConnection.Close();
            }
            veLV.ItemsSource = ve;


            DataProvider.sqlConnection.Open();
            SqlCommand sqlcommand = new SqlCommand(
                " select [s1].TenSanBay sbDi, [s2].TenSanBay sbDen, [c].NgayKhoiHanh, [c].ThoiGianXuatPhat " +
                "from [CHUYENBAY] [c], [SANBAY] [s1], [SANBAY] [s2] " +
                "where [c].MaChuyenBay = @macb and [s1].MaSanBay = [c].SanBayDi and [s2].MaSanBay = [c].SanBayDen",
                DataProvider.sqlConnection);
            sqlcommand.Parameters.Add("@macb", SqlDbType.NVarChar).Value = macb;
            SqlDataReader rd = sqlcommand.ExecuteReader();
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    tuTxt.Text = rd["sbDi"].ToString();
                    denTxt.Text = rd["sbDen"].ToString();
                    ngayGiotxt.Text = rd["NgayKhoiHanh"].ToString() + " " + rd["ThoiGianXuatPhat"].ToString();
                }
            }            
            DataProvider.sqlConnection.Close();

            maVeBox.SelectedIndex = 0;
            TienVe();
        }

        private void cmndTxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void sdtTxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tenHanhKhachTxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool CheckInfor()
        {
            foreach (Ve item in ve)
            {
                if (item.HkName == "")
                    return false;
            }
            return true;
        }

        private void btnTTSau_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckInfor())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin vé!");
            }
            else
            {
                //ko đặt vé nếu quá hạn chậm đặt vé
                SqlCommand _sqlCommand = new SqlCommand(
            "select GiaTri from [BANGTHAMSO] " +
            "where convert(varchar, TenThamSo)='ThoiGianChamNhatChoPhepDatVe'", DataProvider.sqlConnection);
                SqlDataAdapter _adapter = new SqlDataAdapter(_sqlCommand);
                DataSet _ds = new DataSet();
                _adapter.Fill(_ds);
                string _tgChamNhatDatVe = _ds.Tables[0].Rows[0][0].ToString();
                TimeSpan tgChamNhatDatVe = TimeSpan.FromHours(double.Parse(_tgChamNhatDatVe));
                CultureInfo provider = CultureInfo.InvariantCulture;
                string format = "dd/MM/yyyy HH:mm";
                DateTime dateTimeDeparture = DateTime.ParseExact(ngayGiotxt.Text, format, provider);
                DateTime dateTimeNow = DateTime.Now;
                if (dateTimeDeparture - dateTimeNow - tgChamNhatDatVe > TimeSpan.Zero)
                {
                    MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn đặt vé?", "", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        DataProvider.sqlConnection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        SqlCommand sqlCommand = new SqlCommand(
                            "insert into [HOADON] values (@mahd, @ngay, @tien, 'UNPAID', @matk)", DataProvider.sqlConnection);
                        sqlCommand.Parameters.Add("@mahd", SqlDbType.NVarChar).Value = maHoaDonTxt.Text;
                        sqlCommand.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngayHD;
                        sqlCommand.Parameters.Add("@tien", SqlDbType.Int).Value = int.Parse(tienTxt.Text.ToString());
                        sqlCommand.Parameters.Add("@matk", SqlDbType.NVarChar).Value = maTKTTTxt.Text;
                        sqlCommand.ExecuteNonQuery();
                        DataProvider.sqlConnection.Close();

                        SaveVe("BOOKED");
                        SaveCTHD();
                        //go to home screen in MainWindow
                        if (MainWindow.curAccount.type == 1 || MainWindow.curAccount.type == 2)
                        {
                            result = MessageBox.Show("Đặt vé thành công! \nVui lòng nhắc nhở hành khách thanh toán hóa đơn trước khi chuyến bay xuất phát! \n" +
                            "Phiếu đặt chỗ sẽ bị hủy nếu không được thanh toán trước giờ bay!");
                        }
                        else
                        {
                            result = MessageBox.Show("Đặt vé thành công! \nVui lòng thanh toán hóa đơn trước khi chuyến bay xuất phát! \n" +
                            "Phiếu đặt chỗ sẽ bị hủy nếu không được thanh toán trước giờ bay!");
                        }
                        if (result == MessageBoxResult.OK)
                        {
                            GoToHomeScreen?.Invoke(this, new RoutedEventArgs());
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vé phải được đặt chậm nhất trước giờ khởi hành là: " + _tgChamNhatDatVe + " giờ");

                }
            }
        }

        private void btnTTNgay_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckInfor())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin vé!");
            }
            else
            {
                //ko mua vé nếu hết hạn
                CultureInfo provider = CultureInfo.InvariantCulture;
                string format = "dd/MM/yyyy HH:mm";
                DateTime dateTimeDeparture = DateTime.ParseExact(ngayGiotxt.Text, format, provider);
                DateTime dateTimeNow = DateTime.Now;
                if (dateTimeDeparture - dateTimeNow > TimeSpan.Zero)
                {

                    MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thanh toán hóa đơn?", "", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        DataProvider.sqlConnection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        SqlCommand sqlCommand = new SqlCommand(
                            "insert into [HOADON] values (@mahd, @ngay, @tien, 'PAID', @matk)", DataProvider.sqlConnection);
                        sqlCommand.Parameters.Add("@mahd", SqlDbType.NVarChar).Value = maHoaDonTxt.Text;
                        sqlCommand.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngayHD;
                        sqlCommand.Parameters.Add("@tien", SqlDbType.Int).Value = int.Parse(tienTxt.Text.ToString());
                        sqlCommand.Parameters.Add("@matk", SqlDbType.NVarChar).Value = maTKTTTxt.Text;
                        sqlCommand.ExecuteNonQuery();
                        DataProvider.sqlConnection.Close();
                        SaveVe("SOLD");
                        SaveCTHD();

                        if (MainWindow.curAccount.type == 1 || MainWindow.curAccount.type == 2)
                        {
                            result = MessageBox.Show("Vui lòng thông báo đến hành khách vé đã được thanh toán thành công!");
                        }
                        else
                        {
                            result = MessageBox.Show("Thanh toán vé thành công!");
                        }
                        //go to home screen in MainWindow
                        if (result == MessageBoxResult.OK)
                        {
                            GoToHomeScreen?.Invoke(this, new RoutedEventArgs());
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Đã quá hạn mua vé");
                }
            }
        }

        private void SaveVe(String tinhtrang)
        {
            foreach (Ve item in ve)
            {
                DataProvider.sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand sqlCommand = new SqlCommand(
                    "update [VE] set MaHK = @mahk, TenHK = @tenhk, CMND = @cmnd, SDT = @sdt, TinhTrang = @tinhtrang " +
                    "where MaVe = @mave", DataProvider.sqlConnection);
                sqlCommand.Parameters.Add("@mahk", SqlDbType.NVarChar).Value = item.HkID;
                sqlCommand.Parameters.Add("@tenhk", SqlDbType.NVarChar).Value = item.HkName;
                sqlCommand.Parameters.Add("@cmnd", SqlDbType.NVarChar).Value = item.CMND;
                sqlCommand.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = item.PhoneNumber;
                sqlCommand.Parameters.Add("@mave", SqlDbType.NVarChar).Value = item.TiketID;
                sqlCommand.Parameters.Add("@tinhtrang", SqlDbType.NVarChar).Value = tinhtrang;
                sqlCommand.ExecuteNonQuery();
                DataProvider.sqlConnection.Close();
            }
        }
        private void SaveCTHD()
        {
           int count = 1;
            DataProvider.sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select count(*) SL from [CTHD]", DataProvider.sqlConnection);
            SqlDataReader rd = sqlCommand.ExecuteReader();
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    count = int.Parse(rd["SL"].ToString()) + 1;
                }
            }
          
            DataProvider.sqlConnection.Close();

            // SqlCommand _sqlCommand = new SqlCommand(
            //"select * from [CTHD]", DataProvider.sqlConnection);
            //SqlDataAdapter _adapter = new SqlDataAdapter(_sqlCommand);
            //DataSet ds = new DataSet();
            //_adapter.Fill(ds);            
            //int count = ds.Tables[0].Rows.Count + 1;
            int i = 1;
            foreach (Ve item in ve)
            {
                DataProvider.sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                sqlCommand = new SqlCommand(
                    "insert into [CTHD] values (@macthd, @mahd, @mave)", DataProvider.sqlConnection);
                Random r = new Random();
                int ID = r.Next(100000000, 999999999);
                sqlCommand.Parameters.Add("@macthd", SqlDbType.NVarChar).Value = ID.ToString() + item.TiketID;
                sqlCommand.Parameters.Add("@mahd", SqlDbType.NVarChar).Value = maHoaDonTxt.Text;
                sqlCommand.Parameters.Add("@mave", SqlDbType.NVarChar).Value = item.TiketID;
                sqlCommand.ExecuteNonQuery();
                DataProvider.sqlConnection.Close();
                i++;
            }
        }
    }
}