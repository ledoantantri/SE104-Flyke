using Flyke.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;
using DataTable = System.Data.DataTable;
using MaterialDesignThemes.Wpf;
using System.Drawing;
using System.Windows.Controls.Primitives;
using Flyke.MVVM.Model;
//using static Flyke.FlykeDataSet;

namespace Flyke.Resources.CustomControls
{
    /// <summary>
    /// Interaction logic for MonthRevenue.xaml
    /// </summary>
    public partial class MonthRevenue : UserControl
    {
        public MonthRevenue()
        {
            InitializeComponent();

            List<int> months = new List<int>();
            for (int month = 1; month <= 12; month++)
            {
                months.Add(month);
            }
            cBoxMonth.ItemsSource = months;
            cBoxMonth.SelectedIndex = 0;
            List<int> years = new List<int>();
            int currentYear = DateTime.Now.Year;
            for (int year = 2020; year <= currentYear; year++)
            {
                years.Add(year);
            }
            cBoxYear.ItemsSource = years;
            cBoxYear.SelectedIndex = 0;
            MonthSale Example = new MonthSale();

        }
        public class MonthSale
        {
            public string stt { get; set; }
            public string chuyenbay { get; set; }
            public string sove { get; set; }
            public string doanhthu { get; set; }
            public string tile { get; set; }
        }

        DataTable dataTable;
        DataTable loadData()
        {
            DataTable dt = new DataTable();
            MonthRevenueTable.Items.Clear();

            string query =
                "SELECT C.MaChuyenBay, " +
                    "COUNT(DISTINCT MaVe) AS SoVe, " +
                    "COALESCE(SUM(V.GiaVe), 0) AS DoanhThu, " +
                "CASE " +
                            "WHEN(SELECT SUM(V1.GiaVe) " +
                      "FROM VE V1 " +
                      "JOIN CHUYENBAY C1 ON V1.MaChuyenBay = C1.MaChuyenBay " +
                      "WHERE SUBSTRING(C1.NgayKhoiHanh, 4, 2) = @Month AND SUBSTRING(C1.NgayKhoiHanh, 7, 4) = @Year AND V1.TinhTrang = 'SOLD') IS NULL THEN 0 " +
                "ELSE(COALESCE(SUM(CAST(V.GiaVe AS decimal(18, 2))), 0) * 100) / " +
                     "(SELECT SUM(V1.GiaVe) " +
                      "FROM VE V1 " +
                      "JOIN CHUYENBAY C1 ON V1.MaChuyenBay = C1.MaChuyenBay " +
                      "WHERE SUBSTRING(C1.NgayKhoiHanh, 4, 2) = @Month AND SUBSTRING(C1.NgayKhoiHanh, 7, 4) = @Year AND V1.TinhTrang = 'SOLD') " +
                      "END AS 'TyLe' " +
                "FROM CHUYENBAY C LEFT JOIN VE V ON C.MaChuyenBay = V.MaChuyenBay AND TinhTrang = 'SOLD' " +
                "WHERE SUBSTRING(C.NgayKhoiHanh, 4, 2) = @Month AND SUBSTRING(C.NgayKhoiHanh, 7, 4) = @Year " +
                "GROUP BY C.MaChuyenBay, C.NgayKhoiHanh";

            string query1 = "SELECT * FROM [BaoCaoThang] where Thang=@Month and Nam=@Year";

            SqlParameter param1 = new SqlParameter("@Month", int.Parse(cBoxMonth.SelectedItem.ToString()));
            SqlParameter param2 = new SqlParameter("@Year", int.Parse(cBoxYear.SelectedItem.ToString()));

            try
            {              
                bool flag = true;
                dt = new DataTable();
                DateTime currentDate = DateTime.Now;
                using (SqlDataReader reader = DataProvider.ExecuteReader(query1, CommandType.Text, param1, param2))
                {
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                        flag = false;
                        return dt;
                    }
                }
                if (flag)
                {
                    SqlParameter param3 = new SqlParameter("@Month", int.Parse(cBoxMonth.SelectedItem.ToString()));
                    SqlParameter param4 = new SqlParameter("@Year", int.Parse(cBoxYear.SelectedItem.ToString()));
                    using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param3, param4))
                    {
                        if (reader.HasRows)
                        {
                            dt = new DataTable();
                            dt.Load(reader);
                            if (currentDate.Month > int.Parse(cBoxMonth.SelectedItem.ToString()))
                            {
                                SqlConnection sqlCon = DataProvider.sqlConnection;

                                using (sqlCon)
                                {

                                    sqlCon.Open();

                                    foreach (DataRow row in dt.Rows)
                                    {
                                        try
                                        {
                                            SqlCommand cmd = new SqlCommand("Insert into [BaoCaoThang] values('" + row[0].ToString() + "', " + int.Parse(row[1].ToString()) + ", '" + row[2].ToString() + "', '" + row[3].ToString() + "', '" + cBoxMonth.SelectedItem.ToString() + "', '" + cBoxYear.SelectedItem.ToString() + "')", sqlCon);
                                            cmd.CommandType = CommandType.Text;
                                            cmd.ExecuteNonQuery();
                                        }
                                        catch (Exception ex) { System.Windows.MessageBox.Show(ex.ToString()); }
                                    }

                                    sqlCon.Close();
                                }
                            }                           
                        }
                        return dt;
                    }
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); return dt; }
            return dt;
        }

        private void btOk_click(object sender, RoutedEventArgs e)
        {
            dataTable = loadData();
            int stt = 1;
            int sum = 0;
            foreach (DataRow dr in dataTable.Rows)
            {
                MonthSale ms = new MonthSale();
                ms.stt = stt.ToString();
                ms.chuyenbay = dr[0].ToString();
                ms.sove = (dr.Field<int>(1)).ToString();
                ms.doanhthu = dr[2].ToString();
                ms.tile = dr[3].ToString();
                MonthRevenueTable.Items.Add(ms);
                stt++;
                sum += int.Parse(ms.doanhthu);
            }
            tb_total.Text = sum.ToString();
        }

        private void Excel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = null;
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            object missing = Type.Missing;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            Microsoft.Office.Interop.Excel.Range rng = null;



            excel = new Microsoft.Office.Interop.Excel.Application();
            wb = excel.Workbooks.Add();
            ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
            ws.Columns.AutoFit();
            ws.Columns.EntireColumn.ColumnWidth = 25;


            for (int i = 0; i < MonthRevenueTable.Columns.Count; i++)
            {
                ws.Cells[1, i + 1].Value = MonthRevenueTable.Columns[i].Header;
                for (int j = 0; j < MonthRevenueTable.Items.Count; j++)
                {
                    var cellValue = (MonthRevenueTable.Columns[i].GetCellContent(MonthRevenueTable.Items[j]) as TextBlock).Text;
                    ws.Cells[j + 2, i + 1].Value = cellValue;
                }
            }

            excel.Visible = true;
            wb.Activate();
        }
    }
}
