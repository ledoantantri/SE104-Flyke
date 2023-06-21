using Flyke.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
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
using Flyke.Model;
using Flyke.Resources;

namespace Flyke.Pages
{
    /// <summary>
    /// Interaction logic for AllFlight.xaml
    /// </summary>
    public partial class AllFlight : Page
    {
        public DateTime dateTimeDestination, dateTimeDeparture;
        public TimeSpan time;
        public string flightID;
        public string airlineLogo;

        public event RoutedEventHandler ShowDetail;
        public AllFlight()
        {
            InitializeComponent();
            DataProvider.sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(
             "select [c].*, Logo, TenHang, (select count(*) from [SANBAYTRUNGGIAN] [sbtg] where [sbtg].MaChuyenBay = [c].MaChuyenBay) SoSBTG, " +
             "(select count(*) from [Flight] [v1] where [v1].MaChuyenBay = [c].MaChuyenBay and [v1].TinhTrang = 'TRONG') SoVeTrong, " +
             "(select count(*) from [Flight] [v2] where [v2].MaChuyenBay = [c].MaChuyenBay and [v2].TinhTrang != 'TRONG') SoVeDat " +
             "from [CHUYENBAY] [c], [SANBAY] [s1], [SANBAY] [s2], [HANGMAYBAY] [hmb] " +
             "where [c].SanBayDi=[s1].MaSanBay " +
             "and [c].SanBayDen=[s2].MaSanBay " +
             "and [c].MaHangMayBay=[hmb].MaHang ",
            DataProvider.sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Flight> flight_list = new List<Flight>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string flightID = reader["MaChuyenBay"].ToString();
                    string airlineLogo = reader["Logo"].ToString();
                    string airlineName = reader["TenHang"].ToString();
                    string airportDepartureName = reader["SanBayDi"].ToString();
                    string airportDestinationName = reader["SanBayDen"].ToString();
                    string ngayGioXuatPhat = reader["NgayKhoiHanh"].ToString() + " " + reader["ThoiGianXuatPhat"].ToString();
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    string format = "d/M/yyyy HH:mm";
                    TimeSpan time = TimeSpan.FromMinutes(double.Parse(reader["ThoiGianDuKien"].ToString()));

                    DateTime dateTimeDeparture = DateTime.ParseExact(ngayGioXuatPhat, format, provider);
                    DateTime dateTimeDestination = dateTimeDeparture.Add(time);

                    string timeDeparture = dateTimeDeparture.ToString("HH:mm");
                    string timeDestination = dateTimeDestination.ToString("HH:mm");

                    int stop = int.Parse(reader["SoSBTG"].ToString());
                    long price = long.Parse(reader["Gia"].ToString()); int availableSeats = int.Parse(reader["SoVeTrong"].ToString());
                    int bookedSeats = int.Parse(reader["SoVeDat"].ToString());
                    flight_list.Add(new Flight(flightID, airlineLogo, airlineName, airportDepartureName, airportDestinationName, timeDestination, timeDeparture, time, dateTimeDeparture, dateTimeDestination, stop, price, availableSeats, bookedSeats));

                }
            }
            DataProvider.sqlConnection.Close();

            lvFlight.ItemsSource = flight_list;
            
        }
        private void FlightList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedFlight = (Flight)lvFlight.SelectedItem;
            lvFlight.ScrollIntoView(lvFlight.SelectedIndex);
            if (selectedFlight != null)
            {
                //dữ liệu cần truyền sang cho flightListDetail
                time = selectedFlight.Time;
                flightID = selectedFlight.FlightID;
                dateTimeDeparture = selectedFlight.DateTimeDeparture;
                dateTimeDestination = selectedFlight.DateTimeDestination;
                airlineLogo = selectedFlight.AirlineLogo;
                ShowDetail?.Invoke(this, new RoutedEventArgs());
                lvFlight.SelectedIndex = -1;
            }
        }
    }
}
