//using Telerik.UI.Xaml.Controls.DataVisualization;

namespace smeter_telerik;

public partial class MainPage : ContentPage
{
	Random random = new Random();
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}
	public async void Update()
	{
		await DisplayAlert("Leszek", "Korzan", "Webaily");
		dzazgometr.Value = 69;
	}


    private async void Start_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Leszek", "Korzan", "Webaily");
        dzazgometr.Value = random.Next(1,200);
    }
}

