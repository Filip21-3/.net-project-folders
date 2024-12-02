namespace MauiAppMyRF.Pages
{
    public partial class ResetPasswordPage : ContentPage
    {
        public ResetPasswordPage()
        {
            InitializeComponent();
        }

        private void OnBackClicked(object sender, EventArgs e)
        {
            // Navigate back to the OTP page
            Navigation.PopAsync();
        }

        private void OnSubmitClicked(object sender, EventArgs e)
        {
            // You can navigate to the login page or display a success message here
            Navigation.PushAsync(new LoginPage());
        }
    }
}
