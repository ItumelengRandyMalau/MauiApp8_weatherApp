namespace MauiApp8_weatherApp;

public partial class NewPage2 : ContentPage
{
	public NewPage2()
	{
		InitializeComponent();
	}

    private void GetStartedButton_Clicked(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new NewPage1());
    }
}