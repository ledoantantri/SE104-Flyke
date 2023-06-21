using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyke.Data
{
    internal class BANGTHAMSO
    {
        static int thoiGianBayToiThieu = 30;
        static int thoiGianBayToiDa = 2;
        static int thoiGianDungToiThieu = 10;
        static int thoiGianDungToiDa = 20;
        static int soGioTruocKhoiHanhChoPhepDatVe = 24;
        static int soGioTruocKhoiHanhHuyPhieuDat = 24;
        public static int ThoiGianBayToiThieu
        {
            get
            {
                return thoiGianBayToiThieu;
            }
            set
            {
                thoiGianBayToiThieu = value;
            }
        }
        public static int ThoiGianBayToiDa
        {
            get
            {
                return thoiGianBayToiDa;
            }
            set
            {
                thoiGianBayToiDa = value;
            }
        }
        public static int ThoiGianDungToiThieu
        {
            get
            {
                return thoiGianDungToiThieu;
            }
            set
            {
                thoiGianDungToiThieu = value;
            }
        }
        public static int ThoiGianDungToiDa
        {
            get
            {
                return thoiGianDungToiDa;
            }
            set
            {
                thoiGianDungToiDa = value;
            }
        }
        public static int SoGioTruocKhoiHanhChoPhepDatVe
        {
            get
            {
                return soGioTruocKhoiHanhChoPhepDatVe;
            }
            set
            {
                soGioTruocKhoiHanhChoPhepDatVe = value;
            }
        }
        public static int SoGioTruocKhoiHanhHuyPhieuDat
        {

            get
            {
                return soGioTruocKhoiHanhHuyPhieuDat;
            }
            set
            {
                soGioTruocKhoiHanhHuyPhieuDat = value;
            }
        }
    }
}
