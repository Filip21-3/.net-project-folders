namespace MauiAppMyRF.Pages
{
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        private void OnBackClicked(object sender, EventArgs e)
        {
            // Navigate back to the previous page
            Navigation.PopAsync();
        }

        private void OnSubmitClicked(object sender, EventArgs e)
        {
            // Navigate to the OTP page
            Navigation.PushAsync(new OTPPage());
        }
    }
}
