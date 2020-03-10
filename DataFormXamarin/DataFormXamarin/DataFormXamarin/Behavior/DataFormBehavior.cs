using Syncfusion.XForms.DataForm;
using Syncfusion.XForms.Pickers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DataFormXamarin
{
    class DataFormBehavior : Behavior<ContentPage>
    {
        SfDataForm dataForm;
        SfDatePicker datePicker;
        public ICommand OkCommand => new Command(OkButton);
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            dataForm = bindable.FindByName<SfDataForm>("dataForm");
            datePicker = bindable.FindByName<SfDatePicker>("picker");
            dataForm.RegisterEditor("DateEditor", new CustomPickerEditor(dataForm));
            dataForm.RegisterEditor("Date", "DateEditor");
            datePicker.OkCommand = this.OkCommand;
        }
        private void OkButton()
        {
            dataForm.Commit("Date");
        }
    }
}
