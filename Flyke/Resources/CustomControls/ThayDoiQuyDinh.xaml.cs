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
using System.Xml.Linq;
using Flyke.MVVM.ViewModel;
using Flyke.MVVM.Model;


namespace Flyke.CustomControls
{
    /// <summary>
    /// Interaction logic for RuleChange.xaml
    /// </summary>
    public partial class ThayDoiQuyDinh : UserControl
    {
        RuleChangeViewModel ruleChangeVM;
        public ThayDoiQuyDinh()
        {
            InitializeComponent();
            loadData();
            this.DataContext = ruleChangeVM;
        }
        private void loadData()
        {
            string query = "SELECT * FROM BANGTHAMSO";
            DataTable dt;
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text))
            {
                dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    ruleChangeVM = new RuleChangeViewModel();
                    DataRow dr = dt.Rows[0];
                    ruleChangeVM.ThoiGianBayToiThieu = dr.Field<int>(1);
                    dr = dt.Rows[1];
                    ruleChangeVM.SoSanBayTrungGianToiDa = dr.Field<int>(1);
                    dr = dt.Rows[2];
                    ruleChangeVM.ThoiGianDungToiThieu = dr.Field<int>(1);
                    dr = dt.Rows[3];
                    ruleChangeVM.ThoiGianDungToiDa = dr.Field<int>(1);
                    dr = dt.Rows[4];
                    ruleChangeVM.SoGioTruocKhoiHanhChoPhepDatVe = dr.Field<int>(1);
                    dr = dt.Rows[5];
                    ruleChangeVM.SoGioTruocKhoiHanhChoPhepHuyVe = dr.Field<int>(1);

                }
            }
        }       
       
        private void editTGBTT_Click(object sender, RoutedEventArgs e)
        {
            panelTGBTT.Visibility = Visibility.Visible;
            TGBTT.IsReadOnly = false;
            TGBTT.Focus();
        }
        private void editSSBTGTD_Click(object sender, RoutedEventArgs e)
        {
            panelSSBTGTD.Visibility = Visibility.Visible;
            SSBTGTD.IsReadOnly = false;
            SSBTGTD.Focus();
        }
        private void editTGDTT_Click(object sender, RoutedEventArgs e)
        {
            panelTGDTT.Visibility = Visibility.Visible;
            TGDTT.IsReadOnly = false;
            TGDTT.Focus();
        }
        private void editTGDTD_Click(object sender, RoutedEventArgs e)
        {
            panelTGDTD.Visibility = Visibility.Visible;
            TGDTD.IsReadOnly = false;
            TGDTD.Focus();
        }
        private void editSGTKHCPDV_Click(object sender, RoutedEventArgs e)
        {
            panelSGTKHCPDV.Visibility = Visibility.Visible;
            SGTKHCPDV.IsReadOnly = false;
            SGTKHCPDV.Focus();
        }
        private void editSGTKHCPHV_Click(object sender, RoutedEventArgs e)
        {
            panelSGTKHCPHV.Visibility = Visibility.Visible;
            SGTKHCPHV.IsReadOnly = false;
            SGTKHCPHV.Focus();
        }
        private void OkTGBTTBtn_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                int oldvalue = ruleChangeVM.ThoiGianBayToiThieu;               
                if (int.Parse(TGBTT.Text) <= 10)
                {
                    MessageBox.Show("Vui lòng nhập thời gian bay tối thiểu lớn hơn 10 phút.", "Dữ liệu không hợp lệ!");
                    return;
                }
                ruleChangeVM.ThoiGianBayToiThieu = int.Parse(TGBTT.Text);
                
                SqlConnection sqlCon = DataProvider.sqlConnection;
                if (sqlCon.State != ConnectionState.Open)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Update BANGTHAMSO set GiaTri=" + ruleChangeVM.ThoiGianBayToiThieu + "where CONVERT(varchar, TenThamSo)='ThoiGianBayToiThieu'", sqlCon);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                panelTGBTT.Visibility = Visibility.Collapsed;
                TGBTT.IsReadOnly = true;
            } catch(Exception ex) {
                MessageBox.Show("Vui lòng nhập một số nguyên dương.", "Dữ liệu không hợp lệ!");
            }
        }
        private void CancelTGBTTBtn_Click(object sender, RoutedEventArgs e)
        {
            panelTGBTT.Visibility = Visibility.Collapsed;
            TGBTT.IsReadOnly = true;
            TGBTT.Text = ruleChangeVM.ThoiGianBayToiThieu.ToString();
        }
        private void OkSSBTGTDBtn_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                int oldvalue = ruleChangeVM.SoSanBayTrungGianToiDa;

                if (int.Parse(SSBTGTD.Text) <= 0)
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên dương.", "Dữ liệu không hợp lệ!");
                    return;
                }
                ruleChangeVM.SoSanBayTrungGianToiDa = int.Parse(SSBTGTD.Text);
                SqlConnection sqlCon = DataProvider.sqlConnection;
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Update BANGTHAMSO set GiaTri=" + ruleChangeVM.SoSanBayTrungGianToiDa + "where CONVERT(varchar, TenThamSo)='SoSanBayTrungGianToiDa'", sqlCon);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                panelSSBTGTD.Visibility = Visibility.Collapsed;
                SSBTGTD.IsReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập một số nguyên dương.", "Dữ liệu không hợp lệ!");
            }
        }
        private void CancelSSBTGTDBtn_Click(object sender, RoutedEventArgs e)
        {
            panelSSBTGTD.Visibility = Visibility.Collapsed;
            SSBTGTD.IsReadOnly = true;
            SSBTGTD.Text = ruleChangeVM.SoSanBayTrungGianToiDa.ToString();
        }
        private void OkTGDTTBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int oldvalue = ruleChangeVM.ThoiGianDungToiThieu;
                
                if (int.Parse(TGDTT.Text) <= 5)
                {
                    MessageBox.Show("Vui lòng nhập thời gian dừng tối thiểu lớn hơn 5 phút.", "Dữ liệu không hợp lệ!");
                    return;
                }
                ruleChangeVM.ThoiGianDungToiThieu = int.Parse(TGDTT.Text);
                SqlConnection sqlCon = DataProvider.sqlConnection;
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Update BANGTHAMSO set GiaTri=" + ruleChangeVM.ThoiGianDungToiThieu + "where CONVERT(varchar, TenThamSo)='ThoiGianDungToiThieu'", sqlCon);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                panelTGDTT.Visibility = Visibility.Collapsed;
                TGDTT.IsReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập một số nguyên.", "Dữ liệu không hợp lệ!");
            }
        }
        private void CancelTGDTTBtn_Click(object sender, RoutedEventArgs e)
        {
            panelTGDTT.Visibility = Visibility.Collapsed;
            TGDTT.IsReadOnly = true;
            TGDTT.Text = ruleChangeVM.ThoiGianDungToiThieu.ToString();
        }
        private void OkTGDTDBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int oldvalue = ruleChangeVM.ThoiGianDungToiDa;
                
                if (int.Parse(TGDTD.Text) <= 5)
                {
                    MessageBox.Show("Vui lòng nhập thời gian dừng tối đa lớn hơn 5 phút.", "Dữ liệu không hợp lệ!");
                    return;
                }
                ruleChangeVM.ThoiGianDungToiDa = int.Parse(TGDTD.Text);
                SqlConnection sqlCon = DataProvider.sqlConnection;
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Update BANGTHAMSO set GiaTri=" + ruleChangeVM.ThoiGianDungToiDa + "where CONVERT(varchar, TenThamSo)='ThoiGianDungToiDa'", sqlCon);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                panelTGDTD.Visibility = Visibility.Collapsed;
                TGDTD.IsReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập một số nguyên dương.", "Dữ liệu không hợp lệ!");
            }
        }
        private void CancelTGDTDBtn_Click(object sender, RoutedEventArgs e)
        {
            panelTGDTD.Visibility = Visibility.Collapsed;
            TGDTD.IsReadOnly = true;
            TGDTD.Text = ruleChangeVM.ThoiGianDungToiDa.ToString();
        }
        private void OkSGTKHCPDVBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int oldvalue = ruleChangeVM.SoGioTruocKhoiHanhChoPhepDatVe;
                
                if (int.Parse(SGTKHCPDV.Text) <= 0)
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên dương.", "Dữ liệu không hợp lệ!");
                    return;
                }
                ruleChangeVM.SoGioTruocKhoiHanhChoPhepDatVe = int.Parse(SGTKHCPDV.Text);
                SqlConnection sqlCon = DataProvider.sqlConnection;
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Update BANGTHAMSO set GiaTri=" + ruleChangeVM.SoGioTruocKhoiHanhChoPhepDatVe + "where CONVERT(varchar, TenThamSo)='ThoiGianChamNhatChoPhepDatVe'", sqlCon);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                panelSGTKHCPDV.Visibility = Visibility.Collapsed;
                SGTKHCPDV.IsReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập một số nguyên dương.", "Dữ liệu không hợp lệ!");
            }
        }
        private void CancelSGTKHCPDVBtn_Click(object sender, RoutedEventArgs e)
        {
            panelSGTKHCPDV.Visibility = Visibility.Collapsed;
            SGTKHCPDV.IsReadOnly = true;
            SGTKHCPDV.Text = ruleChangeVM.SoGioTruocKhoiHanhChoPhepDatVe.ToString();
        }
        private void OkSGTKHCPHVBtn_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                int oldvalue = ruleChangeVM.SoGioTruocKhoiHanhChoPhepHuyVe;
                if (int.Parse(SGTKHCPHV.Text) <= 0)
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên dương.", "Dữ liệu không hợp lệ!");
                    return;
                }
                ruleChangeVM.SoGioTruocKhoiHanhChoPhepHuyVe = int.Parse(SGTKHCPHV.Text);
                SqlConnection sqlCon = DataProvider.sqlConnection;
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Update BANGTHAMSO set GiaTri=" + ruleChangeVM.SoGioTruocKhoiHanhChoPhepHuyVe + "where CONVERT(varchar, TenThamSo)='ThoiGianChamNhatChoPhepHuyVe'", sqlCon);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                panelSGTKHCPHV.Visibility = Visibility.Collapsed;
                SGTKHCPHV.IsReadOnly = true;
            }
            catch (Exception ex)
            {              
                MessageBox.Show("Vui lòng nhập một số nguyên dương.", "Dữ liệu không hợp lệ!");
            }
        }
        private void CancelSGTKHCPHVBtn_Click(object sender, RoutedEventArgs e)
        {
            panelSGTKHCPHV.Visibility = Visibility.Collapsed;
            SGTKHCPHV.IsReadOnly = true;
            SGTKHCPHV.Text = ruleChangeVM.SoGioTruocKhoiHanhChoPhepHuyVe.ToString();
        }

    }
}
