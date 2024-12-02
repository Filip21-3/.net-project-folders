using Microsoft.Maui.Controls;

namespace MauiAppMyRF.Pages
{
    public partial class TattooStudioPage : ContentPage
    {
        public TattooStudioPage()
        {
            InitializeComponent();
        }

        private async void OnAppointmentButtonClicked(object sender, EventArgs e)
        {
            // Navigate to MyAppointmentPage
            await Navigation.PushAsync(new MyAppointmentPage());
        }
    }
}
