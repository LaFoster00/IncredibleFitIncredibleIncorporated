using IncredibleFit.PopUps;
using IncredibleFit.SQL.Entities;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using IncredibleFit.SQL;

namespace IncredibleFit.Screens;

public partial class CalorieTracker : ContentPage
{
    private readonly SessionInfo _sessionInfo;
    public ObservableCollection<Track> weekCalorieTracks { get; set; } = new ObservableCollection<Track>();
    public CalorieTracker(SessionInfo info)
	{
        _sessionInfo = info;

        InitializeComponent();
        DateTime monday = getStartOfWeek();
        for (int i = 0; i < 7; i++)
        {
            Track currentTrack = SQLNutrition.getTrackByDate(monday.AddDays(i), _sessionInfo.User);
            if(currentTrack == null ) 
            {
                currentTrack = new Track(_sessionInfo.User!.Email, monday.AddDays(i),0,0,0,0);
            }
            currentTrack.Weekday = getWeekdayByIndex(i);
            weekCalorieTracks.Add(currentTrack);
        }
        BindingContext = this;
        ChangeLabel();
    }

    private void ChangeLabel()
    {
        if(_sessionInfo.User != null)
        {
            UserBasalMetabolicRate.Text = _sessionInfo.User.BasalMetabolicRate + " kcal";
        }
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
            Track current = weekCalorieTracks[i];
            averageKcal += current.Calories;
            averageKh += current.Carbonhydrates;
            averageP += current.Protein;
            averageF += current.Fat;
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


    public void setWeekCalorieTracks(int index, Track track)
    {
        this.weekCalorieTracks[index] = track;
        SQLNutrition.SaveCalorieTrack(track);
        ChangeAverageData();
    }

    void EditCaloriesClicked(object sender, EventArgs e)
    {
        ImageButton imgBtn = (ImageButton)sender;
        Track currentTrack = (Track)imgBtn.BindingContext;
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
            case 1: return "Tu";
            case 2: return "We";
            case 3: return "Th";
            case 4: return "Fr";
            case 5: return "Sa";
            case 6: return "Su";
            default: return "Mo";
        }
    }

    private int getIndexOfWeekCalorieTracks(Track track)
    {
        for(int i = 0;i<weekCalorieTracks.Count;i++)
        {
            if (track.Equals(weekCalorieTracks[i])) return i;
        }
        return -1;
    }
}