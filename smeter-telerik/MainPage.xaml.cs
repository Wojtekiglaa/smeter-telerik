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
        sus = 300;
        Vibrate();
        gaug.AnimationSettings.Duration = 200;
        Update();
	}
    public async void AccelerometerStart()
    {
        if (Accelerometer.IsSupported)
        {
            if(!Accelerometer.IsMonitoring)
            {
                Accelerometer.Start(SensorSpeed.Fastest);
                Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            }
            else
            {
                Accelerometer.Default.Stop();
                Accelerometer.ShakeDetected-= Accelerometer_ShakeDetected;
            }
        }
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
                sus -= random.Next(1,10);
            }
            else
            {
                dzazgometr.Value = 0;
            }
        }
    }
    //todo: one button for start or stop, fix vibrate
    private async void Vibrate()
    {
        while (true)
        {
            if (Vibration.Default.IsSupported == true)
            {
                switch (sus)
                {
                    case <= 100: { while (sus <= 100) { Vibration.Default.Vibrate(100); await Task.Delay(700); } break; }
                    case <= 200: { while (sus <= 200) { Vibration.Default.Vibrate(100); await Task.Delay(500); } break; }
                    case <= 300: { while (sus <= 300) { Vibration.Default.Vibrate(100); await Task.Delay(300); } break; }
                }
            }
            else { break; }
        }
    }
    private void Start_Clicked(object sender, EventArgs e)
    {
       //czy = true;
       sus += 15;
    }

    void Accelerometer_ShakeDetected(object sender,EventArgs args )
    {
        sus += 50;
    }

    private void Stop_Clicked(object sender, EventArgs e)
    {
		//czy = false;
       //Accelerometer.Stop();
       sus -= 15;
    }

    private void Start_Accel(object sender, EventArgs e)
    {
        AccelerometerStart();
    }
}

