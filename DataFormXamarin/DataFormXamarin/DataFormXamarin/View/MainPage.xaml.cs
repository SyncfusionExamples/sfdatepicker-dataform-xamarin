using Syncfusion.XForms.Pickers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DataFormXamarin
{
    public partial class MainPage : ContentPage
    {
        public SfDatePicker Picker
        {
            get { return picker; }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
