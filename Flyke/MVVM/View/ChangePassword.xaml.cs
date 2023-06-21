﻿using System;
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
using Flyke.MVVM.Model;

namespace Flyke.MVVM.View
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void changePassword_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Visibility == Visibility.Visible)
            {
                SqlConnection sqlCon = DataProvider.sqlConnection;
                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                        String query = "SELECT COUNT(1) FROM [TaiKhoan] WHERE MaTK=@uid AND MatKhau=@password";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.Parameters.AddWithValue("@uid", MainWindow.curAccount.id);
                        sqlCmd.Parameters.AddWithValue("@password", PasswordBox.Password);
                        int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                        if (count < 1)
                        {
                            Errortxt.Text = "Mật khẩu cũ không chính xác!";
                            PasswordBox.Focus();
                            return;
                        }
                    }
                }
                catch { }
                finally { sqlCon.Close(); }
            }

            if (PasswordBox1.Password != PasswordBox2.Password)
            {
                Errortxt.Text = "Mật khẩu không trùng nhau!";
                PasswordBox1.Focus();
            }
            else if (PasswordBox1.Password == "" || PasswordBox2.Password == "")
            {
                Errortxt.Text = "Vui lòng nhập mật khẩu mới!";
            }
            else
            {
                try
                {
                    SqlConnection con = DataProvider.sqlConnection;
                    con.Open();
                    SqlCommand cmd;
                    if (MainWindow.curAccount != null)
                    {
                        cmd = new SqlCommand("Update [TaiKhoan] set MatKhau='" + PasswordBox1.Password + "'where MaTK=N'" + MainWindow.curAccount.id + "'", con);
                    }
                    else
                    {
                        cmd = new SqlCommand("Update [TaiKhoan] set MatKhau='" + PasswordBox1.Password + "'where Email='" + SendCodeForm.to + "'", con);
                    }
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    this.Close();
                    MessageBox.Show("Đổi mật khẩu thành công!", "Success");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
