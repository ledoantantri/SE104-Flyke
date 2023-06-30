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
using System.Text.RegularExpressions;
using Flyke.MVVM.View;

namespace Flyke.Pages
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : Page
    {
        TaiKhoan account;
        public Setting()
        {
            InitializeComponent();
            if (MainWindow.curAccount != null)
            {
                string query = "SELECT * FROM [TAIKHOAN] Where MaTK = @uid";
                SqlParameter param1 = new SqlParameter("@uid", MainWindow.curAccount.id);
                DataTable dt;
                using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
                {
                    dt = new DataTable();
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                        foreach (DataRow dr in dt.Rows)
                        {
                            account = new TaiKhoan()
                            {
                                username = dr[1].ToString(),
                                password = dr[2].ToString(),
                                type = dr.Field<int>(3),
                                email = dr[4].ToString(),
                                displayname = dr[5].ToString(),
                            };
                        }
                        this.DataContext = account;
                    }
                }
            }
        }

        string oldDName, oldEmail;
        private void editDname_Click(object sender, RoutedEventArgs e)
        {
            panelDName.Visibility = Visibility.Visible;
            DName.IsReadOnly = false;
            DName.Focus();
            oldDName = DName.Text;
        }

        private void editEmail_Click(object sender, RoutedEventArgs e)
        {
            panelEmail.Visibility = Visibility.Visible;
            Email.IsReadOnly = false;
            Email.Focus();
            oldEmail = Email.Text;
        }

        private void editPassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword changePasswordwd = new ChangePassword();
            changePasswordwd.PasswordBox.Visibility = Visibility.Visible;
            changePasswordwd.ShowDialog();
        }

        private void OkDnameBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = DataProvider.sqlConnection;
                con.Open();
                SqlCommand cmd = new SqlCommand("Update [TaiKhoan] set TenHienThi=N'" + DName.Text + "' where MaTK=N'" + MainWindow.curAccount.id + "'", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                panelDName.Visibility = Visibility.Collapsed;
                DName.IsReadOnly = true;
                MainWindow.curAccount.displayname = DName.Text;
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void OkEmailBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(Email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                txblError.Text = "Email không hợp lệ!";
                Email.Focus();
                return;
            }
            try
            {
                SqlConnection con = DataProvider.sqlConnection;
                con.Open();
                SqlCommand cmd = new SqlCommand("Update [TaiKhoan] set Email=N'" + Email.Text + "' where MaTK=N'" + MainWindow.curAccount.id + "'", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                panelEmail.Visibility = Visibility.Collapsed;
                Email.IsReadOnly = true;
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void CancelDnameBtn_Click(object sender, RoutedEventArgs e)
        {
            account.displayname = oldDName;
            DName.Text = oldDName;
            panelDName.Visibility = Visibility.Collapsed;
            DName.IsReadOnly = true;
        }

        private void CancelEmailBtn_Click(object sender, RoutedEventArgs e)
        {
            account.email = oldEmail;
            Email.Text = oldEmail;
            panelEmail.Visibility = Visibility.Collapsed;
            Email.IsReadOnly = true;
        }
    }
}
