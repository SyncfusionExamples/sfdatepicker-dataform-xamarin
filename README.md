# How to add SfDatePicker in Xamarin.Forms DataForm (SfDataForm) ?

You can add custom date picker using [SfDatePicker](https://help.syncfusion.com/xamarin/datepicker/overview?_ga=2.80486035.589794553.1583728862-1204678185.1570168583) in Xamarin.Forms [DataForm](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfDataForm.XForms~Syncfusion.XForms.DataForm.SfDataForm.html?_ga=2.80486035.589794553.1583728862-1204678185.1570168583) by using Custom editor.

The following article explains you how to add SfDatePicker in Xamarin.Forms

https://www.syncfusion.com/kb/11199/how-to-add-sfdatepicker-to-xamarin-forms-dataform-sfdataform

You can create and add custom editor to DataForm by overriding the [DataFormEditor](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfDataForm.XForms~Syncfusion.XForms.DataForm.Editors.DataFormEditor%601.html?_ga=2.121854735.589794553.1583728862-1204678185.1570168583) class, where custom editor (CustomPickerEditor) is inherited using the DataFormEditor<Button>. Refer to the [online user guide documentation](https://help.syncfusion.com/xamarin/sfdataform/editors?_ga=2.121854735.589794553.1583728862-1204678185.1570168583#custom-editor) for creating new custom editor in DataForm.
  
  ``` c#
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
  ```
Refer to the following code example for binding [DataObject](https://help.syncfusion.com/xamarin-android/sfdataform/getting-started?_ga=2.89985439.589794553.1583728862-1204678185.1570168583#setting-data-object) and register the editor using [RegisterEditor](https://help.syncfusion.com/cr/cref_files/xamarin-android/Syncfusion.SfDataForm.Android~Syncfusion.Android.DataForm.SfDataForm~RegisterEditor.html?_ga=2.89985439.589794553.1583728862-1204678185.1570168583) as CustomPickerEditor to make data form item as custom editor in DataForm.

``` c#
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
```
You can add picker dialog using SfDatePicker to the Main page.
``` xml
<Grid>
    <Grid.RowDefinitions>
    <RowDefinition Height="0.1*"/>
    <RowDefinition Height="0.9*"/>
    </Grid.RowDefinitions>
    <dataForm:SfDataForm x:Name="dataForm" 
                                           Grid.Row="1" 
                                           LayoutOptions="Default" 
                                           DataObject="{Binding Contacts}"/>
    <picker:SfDatePicker x:Name="picker"
    BackgroundColor="Silver"
    ShowHeader="false"
    PickerMode="Dialog"
    ShowFooter="true"
    PickerWidth="250"
    PickerHeight="200">
    </picker:SfDatePicker>
</Grid>
```
