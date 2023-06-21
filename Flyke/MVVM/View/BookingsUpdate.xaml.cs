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
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Flyke.MVVM.Model;

namespace Flyke.MVVM.View
{
    /// <summary>
    /// Interaction logic for BookingsUpdate.xaml
    /// </summary>
    public partial class BookingsUpdate : Window
    {
        string maVe;
        public event RoutedEventHandler ReturnBookings;
        public BookingsUpdate()
        {
            InitializeComponent();
        }
        private void NumberTxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void tenHanhKhachTxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public void ShowInforHK(string mave)
        {
            maVe = mave;
            DataProvider.sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(
                "select [v].TenHK, [v].CMND, [v].SDT from [VE] [v] where [v].MaVe = @mave"
                , DataProvider.sqlConnection);
            sqlCommand.Parameters.Add("@mave", SqlDbType.NVarChar).Value = mave;
            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tenHanhKhachTxt.Text = reader["TenHK"].ToString();
                    cmndTxt.Text = reader["CMND"].ToString();
                    sdtTxt.Text = reader["SDT"].ToString();
                }
            }
            DataProvider.sqlConnection.Close();
        }
        private bool CheckCMND()
        {
            bool check = true;
            DataProvider.sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(
                "select [v].CMND, [v].MaVe from [VE] [v] where [v].CMND = @cmnd ", DataProvider.sqlConnection);
            sqlCommand.Parameters.Add("@cmnd", SqlDbType.NVarChar).Value = cmndTxt.Text;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    string mv = reader["MaVe"].ToString();
                    if (mv != maVe) { check = false; }
                }
            }
            DataProvider.sqlConnection.Close();
            return check;
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCMND())
            {
                MessageBox.Show("Thông tin hành khách không hợp lệ.\nCMND đã được đăng ký cho một vé khác.\nVui lòng kiểm tra và sửa đổi thông tin hành khách!");
            }
            else
            {
                DataProvider.sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(
                    "update [VE] set TenHK = @tenhk, CMND = @cmnd, SDT = @sdt " +
                    "where MaVe = @mave", DataProvider.sqlConnection);
                sqlCommand.Parameters.Add("@tenhk", SqlDbType.NVarChar).Value = tenHanhKhachTxt.Text;
                sqlCommand.Parameters.Add("@cmnd", SqlDbType.NVarChar).Value = cmndTxt.Text;
                sqlCommand.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = sdtTxt.Text;
                sqlCommand.Parameters.Add("@mave", SqlDbType.NVarChar).Value = maVe;
                sqlCommand.ExecuteNonQuery();
                DataProvider.sqlConnection.Close();

                if (MainWindow.curAccount.type == 1 || MainWindow.curAccount.type == 2)
                {
                    MessageBox.Show("Vui lòng thông báo đến hành khách cập nhật thông tin hành khách thành công!", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin hành khách thành công!", "Thông báo");
                }

                ReturnBookings?.Invoke(this, new RoutedEventArgs());
                this.Close();
            }
        }

        private void tbnCancle_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy cập nhật thông tin hành khách?", "Thông báo", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
