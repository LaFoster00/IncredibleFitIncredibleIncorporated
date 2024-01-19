using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;
using System.Runtime.CompilerServices;

namespace IncredibleFit.ContentViews;

public partial class ExerciseUnitField : ContentView
{
    public ExerciseUnit Unit
    {
        get => (ExerciseUnit)GetValue(UnitProperty);
        set => SetValue(UnitProperty, value);
    }

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public static readonly BindableProperty UnitProperty = BindableProperty.Create(
            nameof(Unit),
            typeof(ExerciseUnit),
            typeof(ExerciseUnitField),
            null);

    public static readonly BindableProperty NameProperty = BindableProperty.Create(
            nameof(Name),
            typeof(string),
            typeof(ExerciseUnitField),
            string.Empty);

    public ExerciseUnitField()
	{
		InitializeComponent();
	}

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        switch (propertyName)
        {
            case nameof(Unit):
                Exercise ex = SQLTraining.getExerciseByExerciseUnit(Unit);
                Name = ex.Name;
                break;
        }
    }
}