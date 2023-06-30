using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Flyke.MVVM.Model
{
    internal class Ve : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string ticketID;
        public string TiketID
        {
            get { return ticketID; }
            set
            {
                ticketID = value;
                RaisePropertyChanged();
            }
        }
        private string flightClass;
        public string FlightClass
        {
            get { return flightClass; }
            set
            {
                flightClass = value;
                RaisePropertyChanged();
            }
        }
        private int seatNumber;
        public int SeatNumber
        {
            get { return seatNumber; }
            set
            {
                seatNumber = value;
                RaisePropertyChanged();
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                RaisePropertyChanged();
            }
        }
        private string color;
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                RaisePropertyChanged();
            }
        }

        private string hkID;
        public string HkID
        {
            get { return hkID; }
            set { hkID = value; }
        }
        private string hkName;
        public string HkName
        {
            get { return hkName; }
            set { hkName = value; }
        }

        private string cmnd;
        public string CMND
        {
            get { return cmnd; }
            set { cmnd = value; }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public Ve() { }
        public Ve(string ticketID, string flightClass, int seatNumber, string status, string color)
        {
            this.ticketID = ticketID;
            this.flightClass = flightClass;
            this.seatNumber = seatNumber;
            this.status = status;
            this.color = color;
        }

        public Ve(string ticketID, string flightClass, int seatNumber, string status, string hkID, string hkName, string cmnd, string phoneNumber)
        {
            this.ticketID = ticketID;
            this.flightClass = flightClass;
            this.seatNumber = seatNumber;
            this.status = status;
            this.hkID = hkID;
            this.hkName = hkName;
            this.cmnd = cmnd;
            this.phoneNumber = phoneNumber;
        }
    }
}