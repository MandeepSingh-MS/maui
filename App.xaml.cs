namespace MAUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // MainPage = new MainPage();
        MainPage = new AppShell();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(Page2), typeof(Page2));
    }
}
