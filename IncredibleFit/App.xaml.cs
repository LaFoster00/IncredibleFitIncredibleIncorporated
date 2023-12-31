using IncredibleFit.IncredibleFit.SQL;

namespace IncredibleFit;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

        window.Created += (s, e) =>
        {
            OracleDatabase.Connect("", "");
            var reader = OracleDatabase.ExecuteQuery(OracleDatabase.CreateCommand("SELECT * FROM ANGESTELLTER"));
            var employees = reader.ToObjectList<Angestellter>();
        };

        window.Destroying += (sender, args) =>
        {
            OracleDatabase.CloseConnection();
        };

        return window;
    }
}