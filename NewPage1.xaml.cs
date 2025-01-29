using MauiApp8_weatherApp.Services;
using Microsoft.Maui.Devices.Sensors;

namespace MauiApp8_weatherApp;

public partial class NewPage1 : ContentPage
{

	public List<Models.List> weatherListHourly;
	private double latitude;
	private double longitude;
	public NewPage1()
	{
		InitializeComponent();
		weatherListHourly = new List<Models.List>();
    }
	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await GetLocation();
        await GetWeatherDataByLocation(latitude, longitude);

    }

	public async Task GetLocation()
	{
        /*var location = await GetLocation.GetLocationAsync();
		latitude = location.latitude;
		longitude = location.longitude;
		*/
        var location = await Geolocation.GetLastKnownLocationAsync();

        if (location != null)
        {
            latitude = location.Latitude;
            longitude = location.Longitude;
        }
    }

    private async void TaponLocation_Tapped(object sender, TappedEventArgs e)
    {
        await GetLocation();
        await GetWeatherDataByLocation(latitude, longitude);
    }

	public async Task GetWeatherDataByLocation(double latitude, double longitude)
	{
        var result = await Api_service.GetApi(latitude, longitude);
        //await GetWeatherDataByLocation(latitude, longitude);
        UpdateUi(result);
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var response = await DisplayPromptAsync(title: "", message: "", placeholder: "Search weather by city", accept: "Search", cancel: "Cancel");
        if (response != null) 
        {
           await GetweatherDataByCityName(response);
        }
    }


    public async Task GetweatherDataByCityName(string city)
    {
        var result = await Api_service.GetWeatherByCity(city);
        UpdateUi(result);
    }

    public void UpdateUi(dynamic result)
    {
        //looping through the list of hourly weather forcast consumed by the API call stored in result var
        foreach (var item in result.list)
        {
            weatherListHourly.Add(item);
        }
        Cvweather.ItemsSource = weatherListHourly; //Cvweather is a collection name in the xaml file

        LblCity.Text = result.city.name;
        weatherDescription.Text = result.list[0].weather[0].description;
        TemparatureLabel.Text = result.list[0].main.temperature + "°C";
        HumidityLabel.Text = result.list[0].main.humidity + "%";
        WindLabel.Text = result.list[0].wind.speed + "km/h";
        //using custom icons instead of openweathermap icons
        ImageWeatherIpon.Source = result.list[0].weather[0].myIcons;
    }
}