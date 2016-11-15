//New
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kinetic_Energy
{
    class KECalc : INotifyPropertyChanged
    {
        private string _mass;
        private string _velocity;
        private string _ke;


        public string Mass
        {
            get { return _mass; }
            set { _mass = value; calculate(); OnPropertyChanged(); }
        }

        public string Velocity
        {
            get { return _velocity; }
            set { _velocity = value; calculate(); OnPropertyChanged(); }
        }

        public string KE
        {
            get { return _ke; }
            set { _ke = value; OnPropertyChanged(); }
        }

        public void calculate()
        {
            try
            {
                double m = double.Parse(_mass);
                double v = double.Parse(_velocity);
                double ke = 0.5 * m * Math.Pow(2,v);
                KE = Convert.ToString(ke);
            }
            catch
            {
                KE = "Error";
            }
        }

        #region Propertychanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(caller));
        }
        #endregion
    }
}
