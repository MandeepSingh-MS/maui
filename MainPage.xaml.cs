namespace MAUI;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        GetWeather();
    }




    private void OnCounterClicked(object sender, EventArgs e)
    {
        WeatherLabel.Text = $"Current count: {count}";
        // sp();



    }

    private Task sp()
    {
        return Shell.Current.GoToAsync($"{nameof(Page2)}");
    }


    private async void GetWeather()
    {
        HttpClient httpClient = new();
        String data = await httpClient.GetStringAsync("https://www.accuweather.com/en/in/phillaur/2956111/weather-forecast/2956111");

        WeatherLabel.Text = data.Substring(data.IndexOf("class=\"phrase\""), 20);
    }
}

