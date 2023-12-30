using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Views;
using IncredibleFit.IncredibleFit.Models;
using IncredibleFit.IncredibleFit.Screens;
using IncredibleFit.IncredibleFit.SQL;
using System.Globalization;

namespace IncredibleFit.IncredibleFit.PopUps;

public partial class EditCaloriesPopUp : Popup
{
	private CalorieTracker _calorieTracker;
	private CalorieTrack _calorieTrack;
	private int _index;

    public EditCaloriesPopUp(CalorieTracker calorieTracker, CalorieTrack calorieTrack, int index)
	{
		InitializeComponent();
		this._calorieTrack = calorieTrack;
		this._calorieTracker = calorieTracker;
		this._index = index;
        ChangeEntryTexts();

    }

	private void ChangeEntryTexts()
	{
        NewKCAL.Text = _calorieTrack.Kcal.ToString();
		NewKH.Text = _calorieTrack.Kh.ToString();
		NewP.Text = _calorieTrack.P.ToString();
		NewF.Text = _calorieTrack.F.ToString();
    }

	void KcalEntryChanged(object sender, TextChangedEventArgs e)
	{
        _calorieTrack.Kcal = EntryStringToDouble(e.NewTextValue);
	}

    void KhEntryChanged(object sender, TextChangedEventArgs e)
    {
        _calorieTrack.Kh = EntryStringToDouble(e.NewTextValue);
    }

    void PEntryChanged(object sender, TextChangedEventArgs e)
    {
        _calorieTrack.P = EntryStringToDouble(e.NewTextValue);
    }

    void FEntryChanged(object sender, TextChangedEventArgs e)
    {
        _calorieTrack.F = EntryStringToDouble(e.NewTextValue);
    }


    void SaveEditClicked(object sender, EventArgs e)
	{
		_calorieTracker.setWeekCalorieTracks(_index, _calorieTrack);
        SQLNutrition.SaveCalorieTrack(_calorieTrack);
        this.Close();
	}

    private double EntryStringToDouble(string str)
    {
        double number = 0;
        NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");
        if (Double.TryParse(str, style, culture, out number))
            return number;
        else
            return -1;
    }
}