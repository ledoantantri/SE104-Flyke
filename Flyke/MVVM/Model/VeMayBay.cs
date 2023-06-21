using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Flyke.MVVM.Model
{
    internal class VeMayBay
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string tuyen;
        public string Tuyen
        {
            get { return tuyen; }
            set { tuyen = value; RaisePropertyChanged(); }
        }
        private string soGhe;
        public string SoGhe
        {
            get { return soGhe; }
            set { soGhe = value; RaisePropertyChanged(); }
        }
        private string hangVe;
        public string HangVe
        {
            get { return hangVe; }
            set { hangVe = value; RaisePropertyChanged(); }
        }
        private string tenHK;
        public string TenHK
        {
            get { return tenHK; }
            set { tenHK = value; RaisePropertyChanged(); }
        }
        private string ngayGio;
        public string NgayGio
        {
            get { return ngayGio; }
            set { ngayGio = value; RaisePropertyChanged(); }
        }
        private string maVe;
        public string MaVe { get { return maVe; } set { maVe = value; } }
        public VeMayBay(string maVe, string tuyen, string ngayGio, string soGhe, string hangVe, string tenHK)
        {
            this.maVe = maVe;
            this.tuyen = tuyen;
            this.ngayGio = ngayGio;
            this.soGhe = soGhe;
            this.hangVe = hangVe;
            this.tenHK = tenHK;
        }

        public VeMayBay(string maVe, string soGhe, string hangVe, string tenHK)
        {
            this.maVe=maVe;
            this.hangVe=hangVe;
            this.soGhe=soGhe;
            this.tenHK=tenHK;
        }
    }
}