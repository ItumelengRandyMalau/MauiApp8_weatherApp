using MauiApp8_weatherApp.Services;

namespace MauiApp8_weatherApp;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}
	protected async override void OnAppearing()
	{
		base.OnAppearing();
		var result = await Api_service.GetApi(47.6828, -122.2097);
        LblCity.Text = result.city.name;
        weatherDescription.Text = result.list[0].weather[0].description;
        TemparatureLabel.Text = result.list[0].main.temperature + "°C";
		HumidityLabel.Text = result.list[0].main.humidity + "%";
		WindLabel.Text = result.list[0].wind.speed + "km/h";
        ImageWeatherIpon.Source = result.list[0].weather[0].iconUrl;
	}
}