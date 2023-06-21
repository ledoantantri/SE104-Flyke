using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Flyke.Model;
using System.Xml.Linq;

namespace Flyke.MVVM.View
{
    /// <summary>
    /// Interaction logic for UserForm.xaml
    /// </summary>
    public partial class UserForm : Window
    {
        int action;
        public bool isSaved = false;
        string userId;
        public UserForm(int action)
        {
            InitializeComponent();
            this.action = action;
        }
        public UserForm(int action, TaiKhoan account)
        {
            InitializeComponent();
            this.action = action;
            headertxt.Text = "Sửa thông tin user";
            PasswordBox1.Visibility = Visibility.Collapsed;
            PasswordBox2.Visibility = Visibility.Collapsed;
            userId = account.id;
            Displayname.Text = account.displayname;
            Username.Text = account.username;
            Email.Text = account.email;
            PasswordBox1.Password = PasswordBox2.Password = account.password;
            cbRBAC.SelectedIndex = account.type - 1;
        }

        private void BtnSave_click(object sender, RoutedEventArgs e)
        {
            isSaved= true;
            if (Email.Text == "" || Displayname.Text == "" || Username.Text == "" || PasswordBox1.Password == "" || PasswordBox2.Password == "" || cbRBAC.SelectedIndex == -1)
            {
                txblError.Text = "Vui lòng nhập đầy đủ thông tin!";
                Email.Focus();
                return;
            }
            if (PasswordBox1.Password != PasswordBox2.Password)
            {
                txblError.Text = "Mật khẩu không trùng nhau!";
                PasswordBox1.Focus();
                return;
            }
            if (!Regex.IsMatch(Email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                txblError.Text = "Email không hợp lệ!";
                Email.Focus();
                return;
            }

            if (action == 0) {
                SqlConnection sqlCon = DataProvider.sqlConnection;
                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                        String query = "SELECT COUNT(1) FROM [TAIKHOAN] WHERE TenDangNhap=@Username";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.Parameters.AddWithValue("@Username", Username.Text);
                        int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            txblError.Text = "Tên đăng nhập này đã có người sử dụng!";
                            return;
                        }
                    }
                }
                catch { }
                finally { sqlCon.Close(); }
                Random rd = new Random();
                int ID = rd.Next(100000, 999999);
                try
                {
                    sqlCon.Open();
                    int type = cbRBAC.SelectedIndex + 1;
                    SqlCommand cmd = new SqlCommand("Insert into [TaiKhoan] values('" + "U" + ID + "',N'" + Username.Text + "',N'" + PasswordBox1.Password + "'," + type + ",'" + Email.Text + "',N'" + Displayname.Text + "')", sqlCon);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    this.Close();
                    MessageBox.Show("Thêm tài khoản thành công!", "Success");
                } catch (Exception ex) { Console.WriteLine(ex); }
        }
            else if(action == 1) {
                SqlConnection sqlCon = DataProvider.sqlConnection;
                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                        String query = "SELECT COUNT(1) FROM [TAIKHOAN] WHERE TenDangNhap=@Username AND MaTk<>@UserId";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.Parameters.AddWithValue("@Username", Username.Text);
                        sqlCmd.Parameters.AddWithValue("@UserId", userId);
                        int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            txblError.Text = "Tên đăng nhập này đã có người sử dụng!";
                            return;
                        }
                    }
                }
                catch { }
                finally { sqlCon.Close(); }
                try
                {
                    sqlCon.Open();
                    int type = cbRBAC.SelectedIndex + 1;
                    SqlCommand cmd = new SqlCommand("Update [TAIKHOAN] set TenDangNhap=N'" + Username.Text + "',Email=N'" + Email.Text + "',TenHienThi=N'" + Displayname.Text + "',Loai=" + type + " where MaTK='" + userId + "'", sqlCon);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    this.Close();
                    MessageBox.Show("Sửa thông tin tài khoản thành công!", "Success");
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
        }

        private void BtnCancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
