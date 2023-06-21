using System;
using System.Collections.Generic;
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
using Flyke.Pages;
using Flyke.MVVM.View;
using Flyke.MVVM.Model;
using System.Data.SqlClient;
using System.Data;
using Flyke.MVVM.Model;

namespace Flyke.Pages
{
    /// <summary>
    /// Interaction logic for MyBookings.xaml
    /// </summary>
    public partial class MyBookings : Page
    {
        BookingsDetail bookingsDetail;
        public event RoutedEventHandler Return;
        string user_id;
        public MyBookings()
        {
            InitializeComponent();
            addSearchOptions();
        }

        public void MyTicket(string userID)
        {
            user_id = userID;
            DataProvider.sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(
                "select distinct [cb].MaChuyenBay, [ct].MaHD, [v].MaVe, [v].TenHK, [v].SoGhe, [hv].TenHangVe, [cb].SanBayDi, [cb].SanBayDen,[cb].NgayKhoiHanh, [cb].ThoiGianXuatPhat " +
                "from [HOADON] [hd], [VE] [v], [CTHD] [ct], [CHUYENBAY] [cb], [HANGVE] [hv]" +
                "where  [hd].MaHD = [ct].MaHD and " +
                        "[v].MaVe = [ct].MaVe and " +
                        "[v].MaChuyenBay = [cb].MaChuyenBay and " +
                        "[hv].MaHangVe = [v].MaHangVe and " +
                        "[hd].MaTK = @userID and [v].TenHK is not NULL " +
                "order by [v].MaVe DESC", DataProvider.sqlConnection);
            sqlCommand.Parameters.Add("@userID", SqlDbType.NVarChar).Value = userID;
            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<SymbolTicket> list = new List<SymbolTicket>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string mave = reader["MaVe"].ToString();
                    string tuyen = reader["SanBayDi"].ToString() + " - " + reader["SanBayDen"].ToString();
                    string ngaygio = reader["ThoiGianXuatPhat"].ToString() + " " + reader["NgayKhoiHanh"].ToString();
                    string soghe = reader["SoGhe"].ToString();
                    string hangve = reader["TenHangVe"].ToString();
                    string tenhk = reader["TenHK"].ToString();
                    list.Add(new SymbolTicket(mave, tuyen, ngaygio, soghe, hangve, tenhk));
                }
            }
            DataProvider.sqlConnection.Close();

            lvTicket.ItemsSource = list;
            if (list.Count == 0)
            {
                StatusBookings.Text = "Không có lịch sử đặt vé";
            }
            else StatusBookings.Text = "Vui lòng nhấn vào vé để xem thông tin vé!";
        }

        public void NoLogin()
        {
            StatusBookings.Text = "Vui lòng đăng nhập để xem thông tin vé!";
            tuSearchTxt.IsEnabled = false;
            denSearchTxt.IsEnabled = false;
            ngaySearchBox.IsEnabled = false;
            hangveSearchBox.IsEnabled = false;
            btnSearch.IsEnabled = false;
        }

        private void lvTicket_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bookingsDetail = new BookingsDetail();
            SymbolTicket ticket = (SymbolTicket)lvTicket.SelectedItem;
            if (ticket != null)
            {
                bookingsDetail.ReturnBookings += ReturnBookings;
                bookingsDetail.Pay_ReturnBookings += Pay_Return;
                bookingsDetail.ShowDetail(ticket.MaVe, user_id);
                fTicket.Content = bookingsDetail;
            }
        }

        private void Pay_Return(object sender, RoutedEventArgs e)
        {
            Return?.Invoke(this, new RoutedEventArgs());
        }
        private void ReturnBookings(object sender, RoutedEventArgs e)
        {
            bookingsDetail = new BookingsDetail();
            SymbolTicket ticket = (SymbolTicket)lvTicket.SelectedItem;
            if (ticket != null)
            {
                bookingsDetail.ReturnBookings += ReturnBookings;
                bookingsDetail.Pay_ReturnBookings += Pay_Return;
                bookingsDetail.ShowDetail(ticket.MaVe, user_id);
                fTicket.Content = bookingsDetail;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            DataProvider.sqlConnection.Open();
            string sql = "select distinct [cb].MaChuyenBay, [ct].MaHD, [v].MaVe, [v].TenHK, [v].SoGhe, [hv].TenHangVe, " +
                                 "[cb].SanBayDi, [cb].SanBayDen,[cb].NgayKhoiHanh, [cb].ThoiGianXuatPhat " +
                         "from [HOADON] [hd], [VE] [v], [CTHD] [ct], [CHUYENBAY] [cb], [HANGVE] [hv], " +
                                "[SANBAY] [sbdi], [SANBAY] [sbden] " +
                         "where  [hd].MaHD = [ct].MaHD and " +
                                 "[v].MaVe = [ct].MaVe and " +
                                 "[v].MaChuyenBay = [cb].MaChuyenBay and " +
                                 "[hv].MaHangVe = [v].MaHangVe and " +
                                 "[hd].MaTK = @userID";
            if (tuSearchTxt.SelectedIndex != -1)
            {
                sql += " and [cb].SanBayDi = [sbdi].MaSanBay and [sbdi].Tinh = N'" + tuSearchTxt.SelectedItem + "'";
            }
            if (denSearchTxt.Text != "")
            {
                sql += " and [cb].SanBayDen = [sbden].MaSanBay and [sbden].Tinh = N'" + denSearchTxt.SelectedItem + "'";
            }
            if (ngaySearchBox.Text != "")
            {
                sql += " and [cb].NgayKhoiHanh = '" + ngaySearchBox.Text + "'";
            }
            if (hangveSearchBox.Text != "")
            {
                sql += " and [hv].TenHangVe = N'" + hangveSearchBox.SelectedItem + "'";
            }
            sql += " order by [v].MaVe DESC";
            SqlCommand sqlCommand = new SqlCommand(sql, DataProvider.sqlConnection);
            sqlCommand.Parameters.Add("@userID", SqlDbType.NVarChar).Value = user_id;
            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<SymbolTicket> listSearch = new List<SymbolTicket>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string mave = reader["MaVe"].ToString();
                    string tuyen = reader["SanBayDi"].ToString() + " - " + reader["SanBayDen"].ToString();
                    string ngaygio = reader["ThoiGianXuatPhat"].ToString() + " " + reader["NgayKhoiHanh"].ToString();
                    string soghe = reader["SoGhe"].ToString();
                    string hangve = reader["TenHangVe"].ToString();
                    string tenhk = reader["TenHK"].ToString();
                    listSearch.Add(new SymbolTicket(mave, tuyen, ngaygio, soghe, hangve, tenhk));
                }
            }
            DataProvider.sqlConnection.Close();
            lvTicket.ItemsSource = listSearch;
            if (listSearch.Count == 0)
            {
                StatusBookings.Text = "Không có lịch sử đặt vé";
            }
            else StatusBookings.Text = "Vui lòng nhấn vào vé để xem thông tin vé!";

            fTicket.Content = null;
        }

        private void addSearchOptions()
        {
            DataProvider.sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(
                "select distinct [s].Tinh from [SANBAY] [s], [CHUYENBAY] [c] " +
                "where [s].MaSanBay = [c].SanBayDi", DataProvider.sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<string> listTuSearch = new List<string>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listTuSearch.Add(reader["Tinh"].ToString());
                }
            }
            DataProvider.sqlConnection.Close();
            tuSearchTxt.ItemsSource = listTuSearch;

            DataProvider.sqlConnection.Open();
            SqlCommand sqlCommand1 = new SqlCommand(
                "select distinct [s].Tinh from [SANBAY] [s], [CHUYENBAY] [c] " +
                "where [s].MaSanBay = [c].SanBayDen", DataProvider.sqlConnection);
            SqlDataReader reader1 = sqlCommand1.ExecuteReader();
            List<string> listDenSearch = new List<string>();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    listDenSearch.Add(reader1["Tinh"].ToString());
                }
            }
            denSearchTxt.ItemsSource = listDenSearch;
            DataProvider.sqlConnection.Close();

            DataProvider.sqlConnection.Open();
            SqlCommand sqlCommand2 = new SqlCommand(
                "select [h].TenHangVe from [HANGVE] [h]", DataProvider.sqlConnection);
            SqlDataReader reader2 = sqlCommand2.ExecuteReader();
            List<string> listHVSearch = new List<string>();
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    listHVSearch.Add(reader2["TenHangVe"].ToString());
                }
            }
            hangveSearchBox.ItemsSource = listHVSearch;
            DataProvider.sqlConnection.Close();
        }
    }
}