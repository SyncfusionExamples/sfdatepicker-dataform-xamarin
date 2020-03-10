using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataFormXamarin
{
    class DataFormModel : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private string dateValue;
        public string Date
        {
            get { return dateValue; }
            set
            {
                dateValue = value;
                OnPropertyChanged("Date");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
