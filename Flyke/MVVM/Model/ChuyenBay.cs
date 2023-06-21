using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Flyke.MVVM.Model
{
    internal class Flight : INotifyPropertyChanged
    {
        private string flightID;
        public string FlightID
        {
            get { return flightID; }
            set
            {
                flightID = value;
                RaisePropertyChanged();
            }
        }
        private string airlineLogo;
        public string AirlineLogo
        {
            get { return airlineLogo; }
            set
            {
                airlineLogo = value;
                RaisePropertyChanged();
            }
        }
        private string airlineName;
        public string AirlineName
        {
            get { return airlineName; }
            set
            {
                airlineName = value;
                RaisePropertyChanged();
            }
        }
        private string airportDepartureName;
        public string AirportDepartureName
        {
            get { return airportDepartureName; }
            set
            {
                airportDepartureName = value;
                RaisePropertyChanged();
            }
        }

        private string airportDestinationName;
        public string AirportDestinationName
        {
            get { return airportDestinationName; }
            set
            {
                airportDestinationName = value;
                RaisePropertyChanged();
            }
        }

        private string timeDeparture;
        public string TimeDeparture
        {
            get { return timeDeparture; }
            set
            {
                timeDeparture = value;
                RaisePropertyChanged();
            }
        }

        private string timeDestination;
        public string TimeDestination
        {
            get { return timeDestination; }
            set
            {
                timeDestination = value;
                RaisePropertyChanged();
            }
        }

        private DateTime dateTimeDestination;
        public DateTime DateTimeDestination
        {
            get { return dateTimeDestination; }
            set
            {
                dateTimeDestination = value;
                RaisePropertyChanged();
            }
        }
        private DateTime dateTimeDeparture;
        public DateTime DateTimeDeparture
        {
            get { return dateTimeDeparture; }
            set
            {
                dateTimeDeparture = value;
                RaisePropertyChanged();
            }
        }
        private TimeSpan time;
        public TimeSpan Time
        {
            get { return time; }
            set
            {
                time = value;
                RaisePropertyChanged();
            }
        }
        private int stop;

        public int Stop
        {
            get { return stop; }
            set
            {
                stop = value;
                RaisePropertyChanged();
            }
        }
        private long price;

        public long Price
        {
            get { return price; }
            set
            {
                price = value;
                RaisePropertyChanged();
            }
        }
        private int availableSeats;

        public int AvailableSeats
        {
            get { return availableSeats; }
            set
            {
                availableSeats = value;
                RaisePropertyChanged();
            }
        }
        private int bookedSeats;

        public int BookedSeats
        {
            get { return bookedSeats; }
            set
            {
                bookedSeats = value;
                RaisePropertyChanged();
            }
        }
        public Flight() { }
        public Flight(string flightID, string airlineLogo, string airlineName, string airportDepartureName, string airportDestinationName, string timeDestination, string timeDeparture, TimeSpan time, DateTime dateTimeDeparture, DateTime dateTimeDestination, int stop, long price)
        {
            this.flightID = flightID;
            this.airlineLogo = airlineLogo;
            this.airlineName = airlineName;
            this.airportDepartureName = airportDepartureName;
            this.airportDestinationName = airportDestinationName;
            this.timeDestination = timeDestination;
            this.timeDeparture = timeDeparture;
            this.time= time;
            this.stop = stop;
            this.price = price;
            this.dateTimeDeparture = dateTimeDeparture; 
            this.dateTimeDestination = dateTimeDestination; 
        }
        public Flight(string flightID, string airlineLogo, string airlineName, string airportDepartureName, string airportDestinationName, string timeDestination, string timeDeparture, TimeSpan time, DateTime dateTimeDeparture, DateTime dateTimeDestination, int stop, long price, int availableSeats, int bookedSeats)
        {
            this.flightID = flightID;
            this.airlineLogo = airlineLogo;
            this.airlineName = airlineName;
            this.airportDepartureName = airportDepartureName;
            this.airportDestinationName = airportDestinationName;
            this.timeDestination = timeDestination;
            this.timeDeparture = timeDeparture;
            this.time = time;
            this.stop = stop;
            this.price = price;
            this.dateTimeDeparture = dateTimeDeparture;
            this.dateTimeDestination = dateTimeDestination;
            this.availableSeats = availableSeats;
            this.bookedSeats = bookedSeats;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
