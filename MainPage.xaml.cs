﻿namespace MAUI;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }




    private Task OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        CounterLabel.Text = $"Current count: {count}";

        return Shell.Current.GoToAsync($"{nameof(Page2)}");

    }
}

