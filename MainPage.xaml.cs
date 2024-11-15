using CommunityToolkit.Maui.Alerts;

namespace Colour_Picker
{
    public partial class MainPage : ContentPage
    {
        private bool isRandom;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (isRandom is false)
            {
                var red = slider_Red.Value;
                var green = slider_Green.Value;
                var blue = slider_Blue.Value;

                var colour = Color.FromRgb(red, green, blue);
                SetColour(colour);
            }
        }

        private void SetColour(Color color)
        {
            // Set background colours
            button_RandomColour.BackgroundColor = color;
            Container.BackgroundColor = color;

            // Red Value
            var redColor = Color.FromRgb(color.Red, 0, 0);
            label_RedValue.FormattedText = new FormattedString
            {
                Spans =
                {
                    new Span { Text = "Red Value: ", TextColor = Colors.LightGrey },
                    new Span { Text = redColor.ToHex(), TextColor = Colors.LightGrey },
                },
            };

            // Green Value
            var greenColor = Color.FromRgb(0, color.Green, 0);
            label_GreenValue.FormattedText = new FormattedString
            {
                Spans =
                {
                    new Span { Text = "Green Value: ", TextColor = Colors.LightGrey },
                    new Span { Text = greenColor.ToHex(), TextColor = Colors.LightGrey },
                },
            };

            // Blue Value
            var blueColor = Color.FromRgb(0, 0, color.Blue);
            label_BlueValue.FormattedText = new FormattedString
            {
                Spans =
                {
                    new Span { Text = "Blue Value: ", TextColor = Colors.LightGrey },
                    new Span { Text = blueColor.ToHex(), TextColor = Colors.LightGrey },
                },
            };

            // Full Hex Value
            label_HexValue.Text = color.ToHex();
        }

        private void Button_RandomColour_Clicked(object sender, EventArgs e)
        {
            isRandom = true;
            var random = new Random();

            var colour = Color.FromRgb(
                random.Next(0, 265),
                random.Next(0, 265),
                random.Next(0, 265)
            );

            SetColour(colour);

            slider_Red.Value = colour.Red;
            slider_Green.Value = colour.Green;
            slider_Blue.Value = colour.Blue;
            isRandom = false;
        }

        private async void ImageButtonCopy_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(label_HexValue.Text);
            var toast = Toast.Make(
                "Colour Copied",
                CommunityToolkit.Maui.Core.ToastDuration.Short,
                12
            );

            await toast.Show();
        }
    }
}
