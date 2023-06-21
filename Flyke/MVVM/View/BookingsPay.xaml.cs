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
using System.Windows.Shapes;
using Flyke.MVVM.Model;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using Flyke.MVVM.Model;

namespace Flyke.MVVM.View
{
    /// <summary>
    /// Interaction logic for BookingsUpdate.xaml
    /// </summary>
    public partial class BookingsPay : Window
    {
        private string MaHD;
        public event RoutedEventHandler ReturnBookings;
        public event RoutedEventHandler Return;
        List<SymbolTicket> list_ticker;
        public BookingsPay()
        {
            InitializeComponent();
        }

        public void ShowBill(string maHD, string ngaylap, string maCB, string giobay, string tien)
        {
            MaHD = maHD;
            maHDTxt.Text = maHD;
            ngayHDTxt.Text = ngaylap;
            tienTxt.Text = tien;
            tuyenTxt.Text = maCB;
            ngayGioTxt.Text = giobay;

            if (MainWindow.curAccount.type == 1 || MainWindow.curAccount.type == 2)
            {
                btnPay.Content = "Đã thanh toán";
            }

            DataProvider.sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(
                "select [v].MaVe, [hv].TenHangVe, [v].SoGhe, [v].TenHK " +
                "from [VE] [v], [HANGVE] [hv], [CTHD] [ct] " +
                "where [hv].MaHangVe = [v].MaHangVe and [ct].MaHD = @maHD and [v].MaVe = [ct].MaVe"
                , DataProvider.sqlConnection);
            sqlCommand.Parameters.Add("@maHD", SqlDbType.NVarChar).Value = maHD;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            list_ticker = new List<SymbolTicket>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string mave = reader["MaVe"].ToString();
                    string soghe = reader["SoGhe"].ToString();
                    string hangve = reader["TenHangVe"].ToString();
                    string tenHK = reader["TenHK"].ToString();
                    list_ticker.Add(new SymbolTicket(mave, soghe, hangve, tenHK));
                }
            }
            DataProvider.sqlConnection.Close();
            lvTicket.ItemsSource = list_ticker;
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy thanh toán?","",MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thanh toán?", "", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                DataProvider.sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(
                    "update [VE] set TinhTrang = 'SOLD' " +
                    "where MaVe in ( select [v].MaVe from [CTHD] [ct], [VE] [v] " +
                                        "where [v].MaVe = [ct].MaVe and [ct].MaHD = @mahd)", DataProvider.sqlConnection);
                sqlCommand.Parameters.Add("@mahd", SqlDbType.NVarChar).Value = MaHD;
                sqlCommand.ExecuteNonQuery();
                DataProvider.sqlConnection.Close();

                DataProvider.sqlConnection.Open();
                sqlCommand = new SqlCommand(
                    "update [HOADON] set TinhTrang = 'PAID' " +
                    "where MaHD = @mahd", DataProvider.sqlConnection);
                sqlCommand.Parameters.Add("@mahd", SqlDbType.NVarChar).Value = MaHD;
                sqlCommand.ExecuteNonQuery();
                DataProvider.sqlConnection.Close();

                MessageBox.Show("Vui lòng thông báo đến hành khách hóa đơn đã được thanh toán thành công!");

                ReturnBookings?.Invoke(this, new RoutedEventArgs());
                this.Close();
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Hủy hóa đơn đồng nghĩa với hủy tất cả vé đã đặt trong hóa đơn.\nBạn có chắc chắn muốn hủy hóa đơn?", "Thông báo", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                RemoveCTHD();
                RemoveHD();
                RemoveVe();

                if (MainWindow.curAccount.type == 1 || MainWindow.curAccount.type == 2)
                {
                    MessageBox.Show("Vui lòng thông báo đến hành khách hủy hóa đơn thành công!", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Hủy hóa đơn thành công!", "Thông báo");

                }
                Return?.Invoke(this, new RoutedEventArgs());
                this.Close();
            }
        }

        private void RemoveHD()
        {
            DataProvider.sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(
                "delete from [HOADON] where MaHD = @mahd", DataProvider.sqlConnection);
            sqlCommand.Parameters.Add("@mahd", SqlDbType.NVarChar).Value = MaHD;
            sqlCommand.ExecuteNonQuery();
            DataProvider.sqlConnection.Close();
        }

        private void RemoveCTHD()
        {
            DataProvider.sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(
                "delete from [CTHD] where MaHD = @mahd", DataProvider.sqlConnection);
            sqlCommand.Parameters.Add("@mahd", SqlDbType.NVarChar).Value = MaHD;
            sqlCommand.ExecuteNonQuery();
            DataProvider.sqlConnection.Close();
        }

        private void RemoveVe()
        {
            foreach (SymbolTicket ticket in list_ticker)
            {
                DataProvider.sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(
                    "update [VE] set TinhTrang = 'TRONG', TenHK = NULL, CMND = NULL, SDT = NULL, MaHK = NULL" +
                    " where MaVe = @mave ", DataProvider.sqlConnection);
                sqlCommand.Parameters.Add("@mave", SqlDbType.NVarChar).Value = ticket.MaVe;
                sqlCommand.ExecuteNonQuery();
                DataProvider.sqlConnection.Close();
            }
        }
    }
}