using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Data;
using System.Data.SqlClient;
using Flyke.Pages;
using Flyke.MVVM.View;
using Flyke.UserControls;
using Flyke.MVVM.Model;
using System.Windows.Threading;
using System.Globalization;
using Flyke.Resources.CustomControls;
using Flyke.CustomControls;

namespace Flyke
{

    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private Home home;
        private FlightsList flights;
        private FlightDetail flightDetail;
        public static TaiKhoan curAccount = null;
        private AddInforHK addInforHK;
        private AllFlight allFlight;
        private MyBookings myBookings;        
        public MainWindow()
        {
            InitializeComponent();
            //hủy vé tự động
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();

            //main code
            home = new Home();
            allFlight = new AllFlight();
            addInforHK = new AddInforHK();
            flightDetail = new FlightDetail();
            home.Search += Home_Search;

            flights = new FlightsList();
            fContainer.Content = home;
            
        }

        private void Flights_Return(object sender, RoutedEventArgs e)
        {
            fContainer.Content = home;
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                TimeSpan Timeout = TimeSpan.Zero;
                DataProvider.sqlConnection.Open();
                SqlCommand sqlcommand = new SqlCommand(
                    "select [t].GiaTri from [BANGTHAMSO] [t] " +
                    "where convert(varchar,[t].TenThamSo) = 'ThoiGianChamNhatChoPhepHuyVe'"
                    , DataProvider.sqlConnection);
                SqlDataReader rd = sqlcommand.ExecuteReader();
                if (rd.HasRows)
                {
                    if (rd.Read())
                    {
                        Timeout = TimeSpan.FromHours(double.Parse(rd["GiaTri"].ToString()));
                    }
                }
                DataProvider.sqlConnection.Close();

                DataProvider.sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(
                    "select [c].NgayKhoiHanh, [c].ThoiGianXuatPhat, [v].MaVe " +
                    "from [CHUYENBAY] [c], [VE] [v] " +
                    "where [c].MaChuyenBay = [v].MaChuyenBay and [v].TinhTrang = 'BOOKED'"
                    , DataProvider.sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                List<string> ticket_des = new List<string>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string strtime = reader["NgayKhoiHanh"].ToString() + " " + reader["ThoiGianXuatPhat"].ToString();
                        DateTime flighttime = DateTime.ParseExact(strtime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                        TimeSpan time = flighttime - DateTime.Now;

                        if (time - Timeout <= TimeSpan.Zero)
                        {
                            ticket_des.Add(reader["MaVe"].ToString());
                        }
                    }
                }
                DataProvider.sqlConnection.Close();

                if (ticket_des.Count > 0)
                {
                    //List<string> bookings = new List<string>();
                    //DataProvider.sqlConnection.Open();
                    //sqlCommand = new SqlCommand(
                    //    "select [ct].MaVe from [HOADON] [hd], [CTHD] [ct] " +
                    //    "where [ct].MaHD = [hd].MaHD and [hd].MaTK = @id", DataProvider.sqlConnection);
                    //sqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = curAccount.id;
                    //rd = sqlCommand.ExecuteReader();
                    //if (rd.HasRows)
                    //{
                    //    if (rd.Read())
                    //    {
                    //        bookings.Add(rd["MaVe"].ToString());
                    //    }
                    //}
                    //DataProvider.sqlConnection.Close();

                    //bool check = false;
                    //foreach (string ticket in ticket_des)
                    //{
                    //    foreach (string curticket in bookings)
                    //    {
                    //        if (curticket == ticket)
                    //        {
                    //            MessageBox.Show("Một số vé của bạn bị hủy do không thanh toán đúng hạn! Vui lòng kiểm tra lại!", "Thông báo");
                    //            check = true;
                    //            break;
                    //        }
                    //    }
                    //    if (check)
                    //    {
                    //        break;
                    //    }
                    //}

                    foreach (string ticket in ticket_des)
                    {
                        DataProvider.sqlConnection.Open();
                        sqlCommand = new SqlCommand(
                            "update [VE] set TinhTrang = 'TRONG', TenHK = NULL, CMND = NULL, SDT = NULL, MaHK = NULL" +
                            " where MaVe = @mave ", DataProvider.sqlConnection);
                        sqlCommand.Parameters.Add("@mave", SqlDbType.NVarChar).Value = ticket;
                        sqlCommand.ExecuteNonQuery();
                        DataProvider.sqlConnection.Close();
                    }

                    if (fContainer.Content == flightDetail)
                    {
                        string flightID = flightDetail.flight_ID.Text;
                        string airlineLogo = flightDetail.airline_logo;
                        TimeSpan time = (TimeSpan)flightDetail.tb_Time.DataContext;
                        DateTime timedes = (DateTime)flightDetail.sp_timeDestination.DataContext;
                        DateTime timedepar = (DateTime)flightDetail.sp_timeDeparture.DataContext;

                        flightDetail = new FlightDetail();
                        flightDetail.Show(flightID, airlineLogo, time, timedes, timedepar, false);
                        flightDetail.Return += FlightDetail_Return;
                        flightDetail.Continue += FlightDetail_Continue;
                        fContainer.Content = flightDetail;
                    }
                    else if (fContainer.Content == myBookings)
                    {
                        myBookings = new MyBookings();
                        myBookings.MyTicket(curAccount.id);
                        fContainer.Content = myBookings;
                    }
                    else if (fContainer.Content == allFlight)
                    {
                        allFlight = new AllFlight();
                        fContainer.Content = allFlight;
                        allFlight.ShowDetail += AllFlight_ShowDetail;
                    }

                    string id = "";
                    foreach (string ticket in ticket_des)
                    {
                        DataProvider.sqlConnection.Open();
                        sqlCommand = new SqlCommand(
                            "select [hd].MaTK from [HOADON] [hd], [CTHD] [ct] " +
                            "where [ct].MaVe = @mave and [ct].MaHD = [hd].MaHD", DataProvider.sqlConnection);
                        sqlCommand.Parameters.Add("@mave", SqlDbType.NVarChar).Value = ticket;
                        reader = sqlCommand.ExecuteReader();
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                id = reader["MaTK"].ToString();
                            }
                        }
                        DataProvider.sqlConnection.Close();

                        if (id == curAccount.id)
                        {
                            MessageBox.Show("Một số vé của bạn đã bị hủy do không thanh toán đúng hạn!");
                            break;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }


        private void AddInforHK_GoToHomeScreen(object sender, RoutedEventArgs e)
        {
            home = new Home();
            fContainer.Content = home;
            home.Search += Home_Search;
        }

        private void FlightDetail_Return(object sender, RoutedEventArgs e)
        {
            if (flightDetail.isAllFlight == true)
            {
                btnAllFlight_Click(sender, e);
            }
            else
            {
                Home_Search(sender, e);
            }
        }

        private void FlightDetail_Continue(object sender, RoutedEventArgs e)
        {
            if (curAccount != null)
            {
                if (addInforHK == null)
                {
                    addInforHK = new AddInforHK();
                }
                else
                {
                    addInforHK.Close();
                    addInforHK = new AddInforHK();
                }
                addInforHK.GoToHomeScreen += AddInforHK_GoToHomeScreen;
                addInforHK.Show(flightDetail.flightID, flightDetail.TicketID_Chosen, curAccount.id);
                addInforHK.Show();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Vui lòng đăng nhập trước khi đặt vé!");
                if (result == MessageBoxResult.OK)
                {
                    Login login = new Login();
                    login.redirectSignup += Login_redirectSignup;
                    login.loginSuccess += Login_loginSuccess;
                    fContainer.Content = login;
                }
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            home = new Home();
            home.Search += Home_Search;
            fContainer.Content = home;
        }

        private void Home_Search(object sender, RoutedEventArgs e)
        {
            flights = new FlightsList();
            flights.Return += Flights_Return;
            flights.Search += Flights_Return;
            flights.ShowDetail += Flight_ShowDetail;
            flights.FlightSearched(home.Departure, home.Destination, home.Date, home.Quantity, home.FlightClass);
            fContainer.Content = flights;

        }

        private void Flight_ShowDetail(object sender, RoutedEventArgs e)
        {
            flightDetail = new FlightDetail();
            flightDetail.Show(flights.flightID, flights.airlineLogo, flights.time, flights.dateTimeDestination, flights.dateTimeDeparture, false);
            flightDetail.Return += FlightDetail_Return;
            flightDetail.Continue += FlightDetail_Continue;
            fContainer.Content = flightDetail;
        }
        private void AdminAccessBtn(object sender, RoutedEventArgs e)
        {
            AdminRight adminRight = new AdminRight();
            fContainer.Content = adminRight;
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.curAccount == null)
            {
                Login login = new Login();
                login.redirectSignup += Login_redirectSignup;
                login.loginSuccess += Login_loginSuccess;
                fContainer.Content = login;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn đăng xuất khỏi tài khoản này?", "Đăng xuất", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    MainWindow.curAccount = null;
                    tblLogin.Text = "Đăng nhập";
                    
                    
                    btn_UserManagement.Visibility = Visibility.Collapsed;
                    btn_SalesmanRight.Visibility = Visibility.Collapsed;
                    btn_ChangeRule.Visibility = Visibility.Collapsed;
                    btn_setting.Visibility = Visibility.Collapsed;
                    btnMyBookings.Visibility = Visibility.Collapsed;
                    btnHome_Click(sender, e);
                }
            }
        }

        private void Login_loginSuccess(object sender, RoutedEventArgs e)
        {
            btnHome_Click(sender, e);
            tblLogin.Text = "Đăng xuất";
         
            if (MainWindow.curAccount.type == 1)
            {
                btn_UserManagement.Visibility = Visibility.Visible;
                btn_SalesmanRight.Visibility = Visibility.Visible;
                btn_ChangeRule.Visibility = Visibility.Visible;
            }
            if (MainWindow.curAccount.type == 2)
            {
                btn_SalesmanRight.Visibility = Visibility.Visible;
            }
            btn_setting.Visibility = Visibility.Visible;
            btnMyBookings.Visibility = Visibility.Visible;
        }

        private void Login_redirectSignup(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.redirectLogin += Register_redirectLogin;
            fContainer.Content = register;
        }

        private void Register_redirectLogin(object sender, RoutedEventArgs e)
        {
            loginBtn_Click(sender, e);
        }

        private void userManagement_Click(object sender, RoutedEventArgs e)
        {
            UserManagement userManagement = new UserManagement();
            fContainer.Content = userManagement;
        }

        private void btnAllFlight_Click(object sender, RoutedEventArgs e)
        {
            allFlight = new AllFlight();
            fContainer.Content = allFlight;
            allFlight.ShowDetail += AllFlight_ShowDetail;
        }

        private void AllFlight_ShowDetail(object sender, RoutedEventArgs e)
        {
            flightDetail = new FlightDetail();
            flightDetail.Return += FlightDetail_Return;
            flightDetail.Continue += FlightDetail_Continue;
            flightDetail.Show(allFlight.flightID, allFlight.airlineLogo, allFlight.time, allFlight.dateTimeDestination, allFlight.dateTimeDeparture, true);
            fContainer.Content = flightDetail;
        }
        private void setting_click(object sender, RoutedEventArgs e)
        {
            if (curAccount != null)
            {
                Setting setting = new Setting();
                fContainer.Content = setting;
            }
        }
        //private void contactsUs_click(object sender, RoutedEventArgs e)
        //{
        //    ContactUs contactUs = new ContactUs();
        //    fContainer.Content = contactUs;
        //}
        private void Reload_Mybookings(object sender, RoutedEventArgs e)
        {
            myBookings = new MyBookings();
            myBookings.Return += Reload_Mybookings;
            myBookings.MyTicket(curAccount.id);
            fContainer.Content = myBookings;
        }

        private void btnMyBookings_Click(object sender, RoutedEventArgs e)
        {
            myBookings = new MyBookings();
            myBookings.Return += Reload_Mybookings;
            if (curAccount == null)
            {
                myBookings.NoLogin();
            }
            else
            {
                myBookings.MyTicket(curAccount.id);
            }
            fContainer.Content = myBookings;
        }

        private void changeRule_Click(object sender, RoutedEventArgs e)
        {
            ThayDoiQuyDinh ruleChange = new ThayDoiQuyDinh();
            fContainer.Content = ruleChange;
        }
    }
}