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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Flyke.MVVM.Model;
using Flyke.Model;

namespace Flyke.Pages
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public event RoutedEventHandler redirectLogin;
        public Register()
        {
            InitializeComponent();
        }

        private void BtnSignup_click(object sender, RoutedEventArgs e)
        {
            if (Email.Text == "" || Displayname.Text == "" || Username.Text == ""  || PasswordBox1.Password == "" || PasswordBox2.Password == "")
            {
                txblError.Text = "Vui lòng nhập đầy đủ thông tin!";
                Email.Focus();
            }
            else if (PasswordBox1.Password != PasswordBox2.Password)
            {
                txblError.Text = "Mật khẩu không trùng nhau!";
                PasswordBox1.Focus();
            }
            else if (!Regex.IsMatch(Email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                txblError.Text = "Email không hợp lệ!";
                Email.Focus();
            }
            else
            {
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
                SqlConnection con = DataProvider.sqlConnection;
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into [TaiKhoan] values('" + ID.ToString() + "',N'" + Username.Text + "',N'"  + PasswordBox1.Password + "'," + 3 + ",'" + Email.Text + "',N'" + Displayname.Text + "')", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Đăng ký tài khoản thành công!", "Success");
                redirectLogin?.Invoke(this, new RoutedEventArgs());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            redirectLogin?.Invoke(this, new RoutedEventArgs());
        }
    }
}
