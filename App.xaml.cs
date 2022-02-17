global using FaunaDB.Client;
global using FaunaDB.Types;
global using static FaunaDB.Query.Language;

namespace MAUI;

public partial class App : Application
{

    static readonly string ENDPOINT = "https://db.fauna.com:443";
    // NOTE: use the correct endpoint for your database's Region Group.
    static readonly string SECRET = "<<YOUR-SECRET-HERE>>";

    public App()
    {
        InitializeComponent();

        // MainPage = new MainPage();
        MainPage = new AppShell();


        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(AddCodePage), typeof(AddCodePage));



    }
}
