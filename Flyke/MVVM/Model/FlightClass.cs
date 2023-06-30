using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Flyke.MVVM.Model
{
    internal class FlightClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string classId;
        public string ClassId
        {
            get { return classId; }
            set
            {
                classId = value;
                RaisePropertyChanged();
            }
        }
        private string percent;
        public string Percent
        {
            get { return percent; }
            set
            {
                percent = value;
                RaisePropertyChanged();
            }
        }
        private string classColor;
        public string ClassColor
        {
            get { return classColor; }
            set
            {
                classColor = value;
                RaisePropertyChanged();
            }
        }
        private string className;
        public string ClassName
        {
            get { return className; }
            set
            {
                className = value;
                RaisePropertyChanged();
            }
        }
        public FlightClass() { }
        public FlightClass(string classId, string className, string percent, string classColor) {
            this.classId = classId;
            this.percent = percent; 
            this.className = className;
            this.classColor = classColor;   
        }
        public FlightClass(string className, string classColor)
        {
            this.className = className;
            this.classColor = classColor;
        }
    }
}
