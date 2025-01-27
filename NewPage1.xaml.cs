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
		var result = await Api_service.GetApi(47.6828, -122, 209);
        LblCity.Text = result.City.Name;
        weatherDescription.Text = result.List[0].Weather[0].Description;
	}
}