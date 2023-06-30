using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
using Flyke.MVVM.Model;
using System.Data.SqlClient;
using System.Data;

namespace Flyke.MVVM.View
{

    public partial class SendCodeForm : Window
    {
        public SendCodeForm()
        {
            InitializeComponent();
        }
        string randomCode;
        public static string to;
        private void SendCode_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(txbEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                Errortxt.Text = "Email không hợp lệ!";
                txbEmail.Focus();
                return;
            }
            SqlConnection sqlCon = DataProvider.sqlConnection;
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    String query = "SELECT COUNT(1) FROM [TaiKhoan] WHERE Email=@email";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@email", txbEmail.Text);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (count < 1)
                    {
                        Errortxt.Text = "Email này không tồn tại trong danh sách tài khoản!";
                        return;
                    }
                }
            }
            catch { }
            finally { sqlCon.Close(); }
            string from, pass, message;
            Random rd = new Random();
            randomCode = rd.Next(999999).ToString();
            MailMessage mailMessage = new MailMessage();
            to = txbEmail.Text;
            from = "trileprovt@gmail.com";
            pass = "tsrfmfamwlvsbbmx";
            message = "Mã xác thực tài khoản ứng dụng Flyke của bạn là: " + randomCode;
            mailMessage.To.Add(to);
            mailMessage.From = new MailAddress(from);
            mailMessage.Body = message;
            mailMessage.Subject = "Mã xác thực";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.Port = 587;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtpClient.Send(mailMessage);
                MessageBox.Show("Đã gửi mã xác thực vào email!");
                email.Visibility = Visibility.Hidden;
                verifyCode.Visibility = Visibility.Visible;
                btnsendcode.Visibility = Visibility.Hidden;
                btnverifycode.Visibility = Visibility.Visible;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void VerifyCode_Click(object sender, RoutedEventArgs e)
        {
            if (randomCode == txbCode.Text)
            {
                this.Hide();
                ChangePassword changePasswordwd = new ChangePassword();
                changePasswordwd.ShowDialog();
                this.Close();
            }
            else
            {
                Errortxt.Text = "Mã xác thực không chính xác!";
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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