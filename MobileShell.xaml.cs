namespace MAUI;

public partial class MobileShell : ContentPage
{

    public MobileShell()
    {
        InitializeComponent();
    }

    async private void OnCounterClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Alert", "You have been alerted", "OK");
    }
    async private void OnCounterClicked2(object sender, EventArgs e)
    {
        await DisplayAlert("Alert", "You have been alerted 2", "OK");
    }
}

