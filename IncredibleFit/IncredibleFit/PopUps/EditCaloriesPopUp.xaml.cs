// Written by Lisa Weickenmeier https://github.com/LisaWckn

using CommunityToolkit.Maui.Views;
using IncredibleFit.SQL.Entities;
using IncredibleFit.Screens;

namespace IncredibleFit.PopUps;

public partial class EditCaloriesPopUp : Popup
{
	private CalorieTracker _calorieTracker;
	private Track _calorieTrack;
	private int _index;

    public EditCaloriesPopUp(CalorieTracker calorieTracker, Track calorieTrack, int index)
	{
		InitializeComponent();
		this._calorieTrack = calorieTrack;
		this._calorieTracker = calorieTracker;
		this._index = index;
        ChangeEntryTexts();

    }

	private void ChangeEntryTexts()
	{
        NewKCAL.Text = _calorieTrack.Calories.ToString();
		NewKH.Text = _calorieTrack.Carbonhydrates.ToString();
		NewP.Text = _calorieTrack.Protein.ToString();
		NewF.Text = _calorieTrack.Fat.ToString();
    }

	void KcalEntryChanged(object sender, TextChangedEventArgs e)
	{
        _calorieTrack.Calories = EntryStringToShort(e.NewTextValue);
	}

    void KhEntryChanged(object sender, TextChangedEventArgs e)
    {
        _calorieTrack.Carbonhydrates = EntryStringToShort(e.NewTextValue);
    }

    void PEntryChanged(object sender, TextChangedEventArgs e)
    {
        _calorieTrack.Protein = EntryStringToShort(e.NewTextValue);
    }

    void FEntryChanged(object sender, TextChangedEventArgs e)
    {
        _calorieTrack.Fat = EntryStringToShort(e.NewTextValue);
    }


    void SaveEditClicked(object sender, EventArgs e)
	{
		_calorieTracker.setWeekCalorieTracks(_index, _calorieTrack);
        this.Close();
	}

    private short EntryStringToShort(string str)
    {
        short number = 0;
        if (short.TryParse(str, out number))
            return number;
        else
            return -1;
    }
}