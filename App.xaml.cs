global using FaunaDB.Client;
global using FaunaDB.Types;
global using static FaunaDB.Query.Language;

namespace MAUI;

public partial class App : Application
{


    public App()
    {
        InitializeComponent();

        // MainPage = new MainPage();
        MainPage = new AppShell();


        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(AddCodePage), typeof(AddCodePage));



    }
}
