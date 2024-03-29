﻿using System.Collections.ObjectModel;

namespace MAUI;

public partial class MainPage : ContentPage
{


    // List<string> titles = new();
    ObservableCollection<string> titles = new();


    public MainPage()
    {
        titles.Add("A");
        titles.Add("B");
        InitializeComponent();
        TitleView.ItemsSource = titles;

        // GetWeather();
    }




    private void GoToAddCodePage(object sender, EventArgs e)
    {
        LoadAddCodePage();
    }

    void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        OnItemclicked(e.CurrentSelection.FirstOrDefault().ToString());

    }
    async private void OnItemclicked(string k)
    {
        await DisplayAlert("Alert", k, "OK");
    }
    async private void SearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string NewText = e.NewTextValue;

        if (NewText.Length >= 3)
        {
            try
            {
                await GetFilteredCodeData(NewText);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(System.Net.Http.HttpRequestException))
                {
                    await DisplayAlert("Alert", "Internet error", "OK");

                }
                else
                {
                    await DisplayAlert("Alert", ex.ToString(), "OK");
                }
            }
        }
    }

    async Task<bool> GetFilteredCodeData(string text)
    {

        Value value = await CodeDataRepository.GetCodeDataWithTitleMatching(text);


        titles.Clear();


        Value[] data = value.At("data").To<Value[]>().Value;


        List<CodeData> codeData = new();

        foreach (var item in data)
        {
            codeData.Add(item.At("data").To<CodeData>().Value);
        }

        foreach (CodeData item in codeData)
        {
            titles.Add(item.Title);
        }
        // TitleView.ItemsSource = titles;
        return true;

    }

    private Task LoadAddCodePage()
    {
        return Shell.Current.GoToAsync($"{nameof(AddCodePage)}");
    }


    // private async void GetWeather()
    // {
    //     HttpClient httpClient = new();
    //     String data = await httpClient.GetStringAsync("https://www.accuweather.com/en/in/phillaur/2956111/weather-forecast/2956111");

    //     WeatherLabel.Text = data.Substring(data.IndexOf("class=\"phrase\""), 20);
    // }
}

