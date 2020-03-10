using Syncfusion.XForms.DataForm;
using Syncfusion.XForms.DataForm.Editors;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DataFormXamarin
{
    class CustomPickerEditor : DataFormEditor<Button>
    {
        public CustomPickerEditor(SfDataForm dataForm) : base(dataForm)
        {

        }
        protected override Button OnCreateEditorView(DataFormItem dataFormItem)
        {
            return new Button();
        }
        protected override void OnInitializeView(DataFormItem dataFormItem, Button view)
        {
            view.BackgroundColor = Color.LightGray;
            view.FontSize = 14;
        }
        protected override void OnCommitValue(Button view)
        {
            var date = (App.Current.MainPage as MainPage).Picker.Date;
            view.Text = date != null ? date.ToString("dd-MM-yyyy") : null;
            var dataFormItemView = view.Parent as DataFormItemView;
            this.DataForm.ItemManager.SetValue(dataFormItemView.DataFormItem, view.Text);
        }
        protected override void OnWireEvents(Button view)
        {
            base.OnWireEvents(view);
            view.Clicked += OnButtonClicked;
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            (App.Current.MainPage as MainPage).Picker.IsOpen = true;
        }
        protected override void OnUnWireEvents(Button view)
        {
            view.Clicked -= OnButtonClicked;
        }
    }
}
