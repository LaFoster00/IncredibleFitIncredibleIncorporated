// Written by Lisa Weickenmeier https://github.com/LisaWckn

using CommunityToolkit.Maui.Views;
using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;

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
		SQLTimeline.addRecipeAppointment(_recipe, _user, selectedDate);
		this.Close();
    }
}