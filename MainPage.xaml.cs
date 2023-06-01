using CommunityToolkit.Maui.Alerts;

namespace ColorPicker;

public partial class MainPage : ContentPage
{
	bool isRandom;
    string hexValue;


	public MainPage()
	{
		InitializeComponent();
	}

    public void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		if(!isRandom)
		{
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);

            setColor(color);
        }
    }

    private void setColor(Color color)
    {
		btnRandom.BackgroundColor = color;
		Container.BackgroundColor = color;

        hexValue = color.ToHex();
		lblHex.Text = hexValue;
    }

    void btnRandom_Clicked(Object sender, EventArgs e)
    {
		isRandom = true;
		var random = new Random();
		var color = Color.FromRgb(
			random.Next(0, 256),
            random.Next(0, 256),
            random.Next(0, 256)

            );

		setColor(color);

		sldRed.Value = color.Red;
		sldGreen.Value = color.Green;
		sldBlue.Value = color.Blue;

		isRandom = false;


    }

    private async void ImageButton_Clicked(Object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(hexValue);

        var toast = Toast.Make("Color copied", CommunityToolkit.Maui.Core.ToastDuration.Short,
            12);
        await toast.Show();
    }
}


