namespace MAUI;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    async private void OnCounterClicked2(object sender, EventArgs e)
    {
        await DisplayAlert("Alert", "You have been alerted", "OK");
    }


    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        CounterLabel.Text = $"Current count: {count}";

        SemanticScreenReader.Announce(CounterLabel.Text);
    }
}

