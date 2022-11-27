//using Telerik.UI.Xaml.Controls.DataVisualization;
using Plugin.Maui.Audio;
using System.Reflection;

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
        sus = 300;
        Vibrate();
        gaug.AnimationSettings.Duration = 200;
        //InitializeAudio();
        Update();
	}
    Stream GetStreamFromFile(string filename)
    {
        var assembly = typeof(App).GetTypeInfo().Assembly;
        var stream = assembly.GetManifestResourceStream("smeter-telerik." + filename);
        return stream;
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
                if(sus <= 0) { sus += 20; }
                if (sus >= 300) { sus -= 20; }
                //dzazgometr.Value = random.Next(1, 200);
                dzazgometr.Value = sus;
                sus -= random.Next(1,5);
                await Task.Delay(1000);
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
        var green = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("d3.mp3"));
        var yellow = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("d4.mp3"));
        var red = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("d5.mp3"));
        while (true)
        {
            if (Vibration.Default.IsSupported == true)
            {
                //switch (sus)
                //{
                    /*case <= 100: {*/ while (1 <= sus && sus <= 100) { green.Play(); HapticFeedback.Default.Perform(HapticFeedbackType.Click); await Task.Delay(1500); } 
                    /*case <= 200: {*/ while (100 <= sus && sus <= 200) { yellow.Play(); HapticFeedback.Default.Perform(HapticFeedbackType.LongPress); await Task.Delay(800); } 
                    /*case <= 300: {*/ while (200 <= sus && sus <= 300) { red.Play(); Vibration.Vibrate(100); await Task.Delay(400); }  
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
        //ISimpleAudioPlayer green = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        //ISimpleAudioPlayer yellow = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        //ISimpleAudioPlayer red = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        //green.Load(await FileSystem.OpenAppPackageFileAsync("d3.mp3"));
        //yellow.Load(await FileSystem.OpenAppPackageFileAsync("d4.mp3"));
        //red.Load(await FileSystem.OpenAppPackageFileAsync("d5.mp3"));
