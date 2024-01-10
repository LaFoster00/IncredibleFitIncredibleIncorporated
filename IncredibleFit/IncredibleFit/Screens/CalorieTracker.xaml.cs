using IncredibleFit.PopUps;
using IncredibleFit.SQL;
using IncredibleFit.Models;
using CommunityToolkit.Maui.Views;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;

namespace IncredibleFit.Screens;

public partial class CalorieTracker : ContentPage
{
    private User _currentUser = null;
    public ObservableCollection<CalorieTrack> weekCalorieTracks { get; set; } = new ObservableCollection<CalorieTrack>();
    public CalorieTracker()
	{
		InitializeComponent();
        DateTime monday = getStartOfWeek();
        for (int i = 0; i < 7; i++)
        {
            weekCalorieTracks.Add(new CalorieTrack(monday.AddDays(i),getWeekdayByIndex(i), 100, 0, 0, 0));
        }
        BindingContext = this;
        ChangeLabel();
    }

    private void ChangeLabel()
    {
        UserBasalMetabolicRate.Text = _currentUser.BasalMetabolicRate + " kcal";
        ChangeAverageData();
    }

    private void ChangeAverageData()
    {
        double averageKcal = 0;
        double averageKh = 0;
        double averageP = 0;
        double averageF = 0;

        for(int i=0; i<7; i++)
        {
            CalorieTrack current = weekCalorieTracks[i];
            averageKcal += current.Kcal;
            averageKh += current.Kh;
            averageP += current.P;
            averageF += current.F;
        }

        averageKcal = Math.Round(averageKcal/7, 2);
        averageKh = Math.Round( averageKh/7, 2);
        averageP = Math.Round(averageP/7, 2);
        averageF = Math.Round(averageF/7, 2);

        averageKcalText.Text = averageKcal.ToString();
        averageKhText.Text = averageKh.ToString();
        averagePText.Text = averageP.ToString();
        averageFText.Text = averageF.ToString();
    }


    public void setWeekCalorieTracks(int index, CalorieTrack track)
    {
        this.weekCalorieTracks[index] = track;
        BindingContext = this;
        ChangeAverageData();
    }

    void EditCaloriesClicked(object sender, EventArgs e)
    {
        ImageButton imgBtn = (ImageButton)sender;
        CalorieTrack currentTrack = (CalorieTrack)imgBtn.BindingContext;
        int index = getIndexOfWeekCalorieTracks(currentTrack);
        var popup = new EditCaloriesPopUp(this, currentTrack, index);
        this.ShowPopup(popup);
    }

    private DateTime getStartOfWeek()
    {
        DateTime dt = DateTime.Now;
        DayOfWeek startOfWeek = DayOfWeek.Monday;
        int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
        return dt.AddDays(-1 * diff).Date;
    }

    private string getWeekdayByIndex(int index)
    {
        switch (index)
        {
            case 0: return "Mo";
            case 1: return "Di";
            case 2: return "Mi";
            case 3: return "Do";
            case 4: return "Fr";
            case 5: return "Sa";
            case 6: return "So";
            default: return "Mo";
        }
    }

    private int getIndexOfWeekCalorieTracks(CalorieTrack track)
    {
        for(int i = 0;i<weekCalorieTracks.Count;i++)
        {
            if (track.Equals(weekCalorieTracks[i])) return i;
        }
        return -1;
    }
}