using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyke.MVVM.Model
{
    internal class HangVe : INotifyPropertyChanged
    {
        private string machuyenbay;
        private string mahangve;
        private string soluong;

        public string Machuyenbay { get { return machuyenbay; } set { machuyenbay = value; } }
        public string Mahangve { get { return mahangve; } set { mahangve = value; OnPropertyChanged("Mahangve"); } }
        public string Soluong { get { return soluong; } set { soluong = value; OnPropertyChanged("Soluong"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string newname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newname));
            }
        }
    }
}
