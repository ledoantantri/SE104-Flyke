using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Flyke.MVVM.Model
{
    internal class SanBayTrungGian : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string flightId;
        public string FlightId
        {
            get { return flightId; }
            set
            {
                flightId = value;
                RaisePropertyChanged();
            }
        }
        private string airportID;
        public string AirportID
        {
            get { return airportID; }
            set
            {
                airportID = value;
                RaisePropertyChanged();
            }
        }
        private string airportName;
        public string AirportName
        {
            get { return airportName; }
            set
            {
                airportName = value;
                RaisePropertyChanged();
            }
        }
        private TimeSpan timeStop;
        public TimeSpan TimeStop
        {
            get { return timeStop; }
            set
            {
                timeStop = value;
                RaisePropertyChanged();
            }
        }
        private string note;
        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                RaisePropertyChanged();
            }
        }
        public SanBayTrungGian() { }
        public SanBayTrungGian(string airportName, TimeSpan timeStop)
        {
            this.airportName = airportName;
            this.timeStop = timeStop;
        }
    }
}
