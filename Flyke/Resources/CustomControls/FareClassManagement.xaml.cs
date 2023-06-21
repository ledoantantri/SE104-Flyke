using Flyke.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
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
using Flyke.MVVM.View;
using Flyke.Resources.CustomControls;
using Flyke.Model;

namespace Flyke.UserControls
{
    /// <summary>
    /// Interaction logic for FareClassManagement.xaml
    /// </summary>
    public class FareClass
    {
        string _id, _name, _percentage;
        public string id { get { return _id; } set { _id = value; } }
        public string name { get { return _name; } set { _name = value; } }
        public string percentage { get { return _percentage; } set { _percentage = value; } }
    }
    public partial class FareClassManagement : UserControl
    {
        private readonly QLCB_SB q;
        public FareClassManagement()
        {
            InitializeComponent();
            loadData();
            
        }
        public FareClassManagement(QLCB_SB q)
        {
            InitializeComponent();
            loadData();
            this.q = q;

        }
        private void loadData() {
            FareClassTable.Items.Clear();
            string query = "SELECT * FROM HANGVE";
            DataTable dt;
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text))
            {
                dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    foreach (DataRow dr in dt.Rows)
                    {
                        FareClass fareClass = new FareClass();
                        fareClass.id = dr[0].ToString();
                        fareClass.name = dr[1].ToString();
                        fareClass.percentage = dr[2].ToString();
                        FareClassTable.Items.Add(fareClass);
                    }
                }
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            FareClassForm fareClassForm = new FareClassForm();
            fareClassForm.ShowDialog();
            if (fareClassForm.isSaved)
                loadData();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            FareClass selectedFareClass = FareClassTable.SelectedItem as FareClass;
            if (selectedFareClass != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa hạng vé này không?", "Xóa hạng vé", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        SqlConnection con = DataProvider.sqlConnection;
                        SqlCommand cmd = new SqlCommand("Delete from HANGVE where MaHangVe=N'" + selectedFareClass.id + "'", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteReader();
                        con.Close();
                        FareClassTable.Items.Remove(selectedFareClass);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        MessageBox.Show("Hạng vé này đang được sử dụng trong các chuyến báy nên không thể xóa!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng bạn muốn xóa!", "Error");
            }
        }

        private void FareClassTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FareClass info = FareClassTable.SelectedItem as FareClass;
            if (info != null)
            {
                q.mahangveTxb.Text = info.id;
                q.tenhangveTxb.Text = info.name;
                q.tileTxb.Text = info.percentage;
            }
        }
    }
}
