//using Telerik.UI.Xaml.Controls.DataVisualization;
namespace smeter_telerik;
public partial class MainPage : ContentPage
{
	Random random = new Random();
    bool czy = true;
    int sus;

	public MainPage()
	{
		InitializeComponent();
        //dzazgometr.Value= 200;
        sus = 10;
        Vibrate();
        Update();
	}
    public async void AccelerometerStart()
    {
        Accelerometer.Start(SensorSpeed.Fastest);
        Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
    }
	public async void Update()
	{
        //Vibrate();
        while (true)
        {
            if (czy)
            {
                await Task.Delay(1000);
                //dzazgometr.Value = random.Next(1, 200);
                dzazgometr.Value = sus;
                sus -= 3;
            }
            else
            {
                dzazgometr.Value = 0;
            }
        }
    }

    private async void Vibrate()
    {
        while (true)
        {
            if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            {
                switch (sus)
                {
                    case <= 100: { while (sus <= 100) { Vibration.Default.Vibrate(100); await Task.Delay(700); } break; }
                    case <= 200: { while (sus <= 200) { Vibration.Default.Vibrate(100); await Task.Delay(500); } break; }
                    case <= 300: { while (sus <= 300) { Vibration.Default.Vibrate(100); await Task.Delay(300); } break; }
                }
            }
        }
    }
    private void Start_Clicked(object sender, EventArgs e)
    {
       //czy = true;
       sus += 15;
    }

    void Accelerometer_ShakeDetected(object sender,EventArgs args )
    {
        sus += 15;
    }

    private void Stop_Clicked(object sender, EventArgs e)
    {
		//czy = false;
       Accelerometer.Stop();
       sus -= 15;
    }

    private void Stop_Accel(object sender, EventArgs e)
    {
        Accelerometer.Stop();
    }

    private void Start_Accel(object sender, EventArgs e)
    {
        AccelerometerStart();
    }
}

