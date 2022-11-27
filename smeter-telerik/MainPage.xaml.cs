﻿//using Telerik.UI.Xaml.Controls.DataVisualization;
namespace smeter_telerik;
public partial class MainPage : ContentPage
{
	Random random = new Random();
    bool czy = true;
    double sus;

	public MainPage()
	{
		InitializeComponent();
        //dzazgometr.Value= 200;
        sus = 250;
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
        //else { await DisplayAlert("accelerometer", "aint", "supported homie"); }
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
                sus -= random.Next(1,5);
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
                //switch (sus)
                //{
                    /*case <= 100: {*/ while (1 <= sus && sus <= 100) { HapticFeedback.Default.Perform(HapticFeedbackType.Click); await Task.Delay(1500); } 
                    /*case <= 200: {*/ while (100 <= sus && sus <= 200) { HapticFeedback.Default.Perform(HapticFeedbackType.LongPress); await Task.Delay(800); } 
                    /*case <= 300: {*/ while (200 <= sus && sus <= 300) { Vibration.Vibrate(100); await Task.Delay(400); }  
                //}
            }
            else { break; }
        }
    }
    private void Start_Clicked(object sender, EventArgs e)
    {
       //czy = true;
       sus += 30;
    }

    void Accelerometer_ShakeDetected(object sender,EventArgs args )
    {
        sus += random.Next(1,50);
    }

    private void Stop_Clicked(object sender, EventArgs e)
    {
		//czy = false;
       //Accelerometer.Stop();
       sus -= 30;
    }

    private void Start_Accel(object sender, EventArgs e)
    {
        AccelerometerStart();
    }
}

