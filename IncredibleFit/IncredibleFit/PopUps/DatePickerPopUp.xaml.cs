using CommunityToolkit.Maui.Views;
using IncredibleFit.Screens;
using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IncredibleFit.PopUps;

public partial class DatePickerPopUp : Popup
{
	private Recipe _recipe;
	private User _user;
    public DatePickerPopUp(Recipe recipe, User user)
	{
		InitializeComponent();
		_recipe = recipe;
		_user = user;
		DatePicker.MinimumDate = DateTime.Today;
		DatePicker.Date = DateTime.Today;
	}

    void SaveEditClicked(object sender, EventArgs e)
	{
        DateTime selectedDate = DatePicker.Date;
		SQLNutrition.addRecipeAppointment(_recipe, _user, selectedDate);
		this.Close();
    }
}