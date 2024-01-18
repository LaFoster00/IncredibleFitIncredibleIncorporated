using IncredibleFit.SQL.Entities;
using Microsoft.Maui;
using System.Runtime.CompilerServices;

namespace IncredibleFit.ContentViews;

public partial class ExerciseUnitField : ContentView
{
    public ExerciseUnit ExerciseUnit
    {
        get => (ExerciseUnit)GetValue(ExerciseUnitProperty);
        set => SetValue(ExerciseUnitProperty, value);
    }

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public static readonly BindableProperty ExerciseUnitProperty = BindableProperty.Create(
            nameof(ExerciseUnit),
            typeof(ExerciseUnit),
            typeof(ExerciseUnitField),
            null);

    public static readonly BindableProperty NameProperty = BindableProperty.Create(
            nameof(Name),
            typeof(string),
            typeof(ExerciseUnitField),
            string.Empty);

    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            nameof(TextColor),
            typeof(Color),
            typeof(ExerciseUnitField),
            Color.FromArgb("#6E6E6E"));

    public ExerciseUnitField()
	{
		InitializeComponent();
	}

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        switch (propertyName)
        {
            case nameof(ExerciseUnit):
                Name = ExerciseUnit.Description;
                break;
        }
    }
}