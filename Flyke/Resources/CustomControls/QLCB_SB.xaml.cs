using Flyke.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Flyke.Resources.CustomControls
{
    /// <summary>
    /// Interaction logic for QLCB_SB.xaml
    /// </summary>
    public partial class QLCB_SB : UserControl
    {
        Sanbay sanbay;
        Chuyenbay chuyenbay;
        Hangmaybay hangmaybay;
        public QLCB_SB()
        {
            InitializeComponent();
            sanbaydetail.Visibility = Visibility.Visible;
            Cbaydetail.Visibility = Visibility.Hidden;
            Hbaydetail.Visibility = Visibility.Hidden;
            Hvedetail.Visibility = Visibility.Hidden;
            sanbay = new Sanbay(this);
            SB_CB.NavigationService.Navigate(sanbay);
        }
        private static string Masb;
        private static string Tensb;
        public QLCB_SB(string ma, string ten)
        {
            InitializeComponent();
            masanbayTxb.Text = ma;
            tensanbayTxb.Text = ten;
            tensanbayTxb.Background = Brushes.Yellow;
            // MessageBox.Show(masanbayTxb.Text);
        }

        private void SanBay_Click(object sender, RoutedEventArgs e)
        {
            sanbay = new Sanbay(this);
            sanbaydetail.Visibility = Visibility.Visible;
            Cbaydetail.Visibility = Visibility.Hidden;
            Hbaydetail.Visibility = Visibility.Hidden;
            Hvedetail.Visibility = Visibility.Hidden;
            SB_CB.NavigationService.Navigate(sanbay);

        }

        private void ChuyenBay_Click(object sender, RoutedEventArgs e)
        {
            chuyenbay = new Chuyenbay(this);
            sanbaydetail.Visibility = Visibility.Hidden;
            Cbaydetail.Visibility = Visibility.Visible;
            Hbaydetail.Visibility = Visibility.Hidden;
            Hvedetail.Visibility = Visibility.Hidden;
            SB_CB.NavigationService.Navigate(chuyenbay);
        }
        //private void HangMB_Click(object sender, RoutedEventArgs e)
        //{
        //    hangmaybay = new Hangmaybay(this);
        //    sanbaydetail.Visibility = Visibility.Hidden;
        //    Cbaydetail.Visibility = Visibility.Hidden;
        //    Hbaydetail.Visibility = Visibility.Visible;
        //    Hvedetail.Visibility = Visibility.Hidden;
        //    SB_CB.NavigationService.Navigate(hangmaybay);
        //}
        private void HangVe_Click(object sender, RoutedEventArgs e)
        {
            FareClassManagement fareClassManagement = new FareClassManagement(this);
            sanbaydetail.Visibility = Visibility.Hidden;
            Cbaydetail.Visibility = Visibility.Hidden;
            Hbaydetail.Visibility = Visibility.Hidden;
            Hvedetail.Visibility = Visibility.Visible;
            SB_CB.NavigationService.Navigate(fareClassManagement);
        }
    }
}
