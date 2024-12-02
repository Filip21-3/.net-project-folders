namespace MauiAppMyRF.Pages;

    public partial class LogoPage : ContentPage
    {
        public LogoPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            // Apply the scaling animation
            await button.ScaleTo(1.2, 150, Easing.SpringOut); // Scale to 120% of the size
            await button.ScaleTo(1, 100, Easing.SpringIn); // Scale back to 100% of the size

            // After animation, navigate (example)
            await Navigation.PushAsync(new LoginPage());
        }
    }



