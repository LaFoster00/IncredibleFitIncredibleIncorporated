using IncredibleFit.IncredibleFit.SQL;

namespace IncredibleFit;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        Window window = base.CreateWindow(activationState);

        window.Created += (s, e) =>
        {
            OracleDatabase.Connect("incrediblefit", "IncFitIncInc");
            var reader = OracleDatabase.ExecuteQuery(OracleDatabase.CreateCommand("SELECT * FROM ANGESTELLTER"));
            var employees = reader.ToObjectList<Angestellter>();
            var testDieter = new Angestellter("John", "Doe", 50000, 0.1, null);
            OracleDatabase.InsertObject(testDieter);
            testDieter.Name = "Test Dieter 3 but changed";
            OracleDatabase.UpdateObject(testDieter);
        };

        window.Destroying += (sender, args) =>
        {
            OracleDatabase.CloseConnection();
        };

        return window;
    }
}