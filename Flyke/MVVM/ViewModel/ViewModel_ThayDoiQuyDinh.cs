using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyke.MVVM.ViewModel
{
    internal class RuleChangeViewModel : INotifyPropertyChanged
    {
        private int _thoiGianBayToiThieu;
        private int _soSanBayTrungGianToiDa;
        private int _thoiGianDungToiThieu;
        private int _thoiGianDungToiDa;
        private int _soGioTruocKhoiHanhChoPhepDatVe;
        private int _soGioTruocKhoiHanhChoPhepHuyVe;
        public int ThoiGianBayToiThieu
        {
            get { return _thoiGianBayToiThieu; }
            set
            {
                if (_thoiGianBayToiThieu != value)
                {
                    _thoiGianBayToiThieu = value;
                    OnPropertyChanged("ThoiGianBayToiThieu");
                }
            }
        }
        public int SoSanBayTrungGianToiDa
        {
            get { return _soSanBayTrungGianToiDa; }
            set
            {
                if (_soSanBayTrungGianToiDa != value)
                {
                    _soSanBayTrungGianToiDa = value;
                    OnPropertyChanged("SoSanBayTrungGianToiDa");
                }
            }
        }
        public int ThoiGianDungToiThieu
        {
            get { return _thoiGianDungToiThieu; }
            set
            {
                if (_thoiGianDungToiThieu != value)
                {
                    _thoiGianDungToiThieu = value;
                    OnPropertyChanged("ThoiGianDungToiThieu");
                }
            }
        }
        public int ThoiGianDungToiDa
        {
            get { return _thoiGianDungToiDa; }
            set
            {
                if (_thoiGianDungToiDa != value)
                {
                    _thoiGianDungToiDa = value;
                    OnPropertyChanged("ThoiGianDungToiDa");
                }
            }
        }
        public int SoGioTruocKhoiHanhChoPhepHuyVe
        {
            get { return _soGioTruocKhoiHanhChoPhepHuyVe; }
            set
            {
                if (_soGioTruocKhoiHanhChoPhepHuyVe != value)
                {
                    _soGioTruocKhoiHanhChoPhepHuyVe = value;
                    OnPropertyChanged("SoGioTruocKhoiHanhChoPhepHuyVe");
                }
            }
        }
        public int SoGioTruocKhoiHanhChoPhepDatVe
        {
            get { return _soGioTruocKhoiHanhChoPhepDatVe; }
            set
            {
                if (_soGioTruocKhoiHanhChoPhepDatVe != value)
                {
                    _soGioTruocKhoiHanhChoPhepDatVe = value;
                    OnPropertyChanged("SoGioTruocKhoiHanhChoPhepDatVe");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

