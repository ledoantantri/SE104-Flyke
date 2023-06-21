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
using static Flyke.Resources.CustomControls.Chuyenbay;
using Flyke.MVVM.View;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Globalization;
using Flyke.Model;

namespace Flyke.Pages
{
    /// <summary>
    /// Interaction logic for UserManagement.xaml
    /// </summary>
    public class AccountTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int accountType = (int)value;
            switch (accountType)
            {
                case 1:
                    return "Admin";
                case 2:
                    return "Nhân viên";
                case 3:
                    return "Khách hàng";
                default:
                    return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public partial class UserManagement : Page
    {      

        public UserManagement()
        {
            InitializeComponent();
            loadData();
        }
        void loadData()
        {
            UserTable.Items.Clear();
            string query = "SELECT * FROM TAIKHOAN";
            DataTable dt;
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text))
            {
                dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    foreach (DataRow dr in dt.Rows)
                    {
                        TaiKhoan account = new TaiKhoan();
                        account.id = dr[0].ToString();
                        account.username= dr[1].ToString();
                        account.password= dr[2].ToString();
                        account.type = dr.Field<int>(3);
                        account.email = dr[4].ToString();
                        account.displayname = dr[5].ToString();
                        UserTable.Items.Add(account);
                    }
                }
            }
           
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            UserForm userForm = new UserForm(0);
            userForm.ShowDialog();
            if(userForm.isSaved)
                loadData();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            TaiKhoan selectedAccount = UserTable.SelectedItem as TaiKhoan;
            if (selectedAccount != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa tài khoản này không?", "Xác nhận xóa tài khoản", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        SqlConnection sqlCon = DataProvider.sqlConnection;
                        sqlCon.Open();
                        SqlCommand cmd = new SqlCommand("Delete from [TAIKHOAN]  where MaTK='" + selectedAccount.id + "'", sqlCon);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        sqlCon.Close();
                        UserTable.Items.Remove(selectedAccount);
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng bạn muốn xóa!", "Error");
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            TaiKhoan selectedAccount = UserTable.SelectedItem as TaiKhoan;
            if(selectedAccount != null) {
                UserForm userForm = new UserForm(1, selectedAccount);
                userForm.ShowDialog();
                if (userForm.isSaved)
                    loadData();
            }
            else {
                MessageBox.Show("Vui lòng chọn dòng bạn muốn sửa!", "Error");
            }
        }
       

    }
}
