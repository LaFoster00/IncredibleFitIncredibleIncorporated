// SwitchableField.xaml.cs

using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Input;

namespace IncredibleFit.ContentViews
{
    public partial class EditableField : ContentView
    {
        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public string EditValue
        {
            get => (string)GetValue(EditValueProperty);
            set => SetValue(EditValueProperty, value);
        }

        public bool IsLabelVisible
        {
            get => (bool)GetValue(IsLabelVisibleProperty);
            set => SetValue(IsLabelVisibleProperty, value);
        }

        public bool IsEditMode
        {
            get => (bool)GetValue(IsEditModeProperty);
            set => SetValue(IsEditModeProperty, value);
        }


        public static readonly BindableProperty LabelProperty = BindableProperty.Create(
            nameof(Label),
            typeof(string),
            typeof(EditableField),
            string.Empty, BindingMode.TwoWay);

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            nameof(Placeholder),
            typeof(string),
            typeof(EditableField),
            string.Empty, BindingMode.TwoWay);

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            nameof(Value),
            typeof(string),
            typeof(EditableField),
            string.Empty, BindingMode.TwoWay);

        public static readonly BindableProperty EditValueProperty = BindableProperty.Create(
            nameof(EditValue),
            typeof(string),
            typeof(EditableField),
            string.Empty, BindingMode.TwoWay);

        public static readonly BindableProperty IsLabelVisibleProperty = BindableProperty.Create(
            nameof(IsLabelVisible),
            typeof(bool),
            typeof(EditableField),
            true, BindingMode.TwoWay);

        public static readonly BindableProperty IsEditModeProperty = BindableProperty.Create(
            nameof(IsEditMode),
            typeof(bool),
            typeof(EditableField),
            false, BindingMode.TwoWay);


        public EditableField()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            switch (propertyName)
            {
                case nameof(Label):
                    MLabel.Text = Label;
                    break;
                case nameof(Value):
                    MValue.Text = Value;
                    break;
                case nameof(Placeholder):
                    MEditValue.Placeholder = Placeholder;
                    break;
            }
        }

        [RelayCommand]
        public async Task Edit()
        {
            if (IsEditMode)
                return;

            EditValue = Value;

            IsLabelVisible = false;
            IsEditMode = true;
        }

        [RelayCommand]
        public async Task Apply()
        {
            if (!IsEditMode)
                return;

            Value = EditValue;

            IsLabelVisible = true;
            IsEditMode = false;
        }
    }
}
