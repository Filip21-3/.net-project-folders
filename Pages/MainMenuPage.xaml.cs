using Microsoft.Maui.Controls;

namespace MauiAppMyRF.Pages
{
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private async void OnProfileClicked(object sender, EventArgs e)
        {
            // Navigate to ProfilePage
            await Navigation.PushAsync(new ProfilePage());
        }

        private async void OnTattooCategoryClicked(object sender, EventArgs e)
        {
            try
            {
                // Attempt to navigate to TattooStudioPage
                var TattooStudiosMenuPage = new TattooStudiosMenuPage();

                // Navigate to the TattooStudioPage if it exists
                await Navigation.PushAsync(TattooStudiosMenuPage);

                // Optionally show a message after navigating
                DisplayAlert("Tattoo Artists", "Navigating to Tattoo Artists!", "OK");
            }
            catch (Exception ex)
            {
                // In case of any error (page not found, etc.), show an alert
                DisplayAlert("Error", $"Navigation failed: {ex.Message}", "OK");
            }
        }

        private void OnRestaurantCategoryClicked(object sender, EventArgs e)
        {
            DisplayAlert("Restaurants", "Navigating to Restaurants!", "OK");
            // Add navigation to Restaurants page here
        }

        private void OnBarCategoryClicked(object sender, EventArgs e)
        {
            DisplayAlert("Bars", "Navigating to Bars!", "OK");
            // Add navigation to Bars page here
        }
        private void OnBarberCategoryClicked(object sender, EventArgs e)
        {
            DisplayAlert("Bars", "Navigating to Barbers!", "OK");
            // Add navigation to Bars page here
        }
    }
}
