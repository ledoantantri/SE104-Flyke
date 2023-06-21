using System;
using System.Collections.Generic;
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
    /// Interaction logic for AdminRight.xaml
    /// </summary>
    public partial class AdminRight : UserControl
    {
        MonthRevenue MonthBCDT = new MonthRevenue();
        YearRevenue YearBCDT = new YearRevenue();
        QLCB_SB qLCB = new QLCB_SB();
        public AdminRight()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(MonthBCDT);
        }

        private void MonthRevenue_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(MonthBCDT);
        }

        private void YearRevenue_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(YearBCDT);
        }

        private void QLCB_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(qLCB);
        }

    }
    
}
