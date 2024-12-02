using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace MauiAppMyRF.Pages
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        // Button Click Animations
        private async void OnHistoryClicked(object sender, EventArgs e)
        {
            await AnimateButton(sender as Button);
            await DisplayAlert("History", "Navigating to History!", "OK");
        }

        private async void OnPersonalDetailsClicked(object sender, EventArgs e)
        {
            await AnimateButton(sender as Button);
            await DisplayAlert("Personal Details", "Navigating to Personal Details!", "OK");
        }

        private async void OnAddressClicked(object sender, EventArgs e)
        {
            await AnimateButton(sender as Button);
            await DisplayAlert("Address", "Navigating to Address!", "OK");
        }

        private async void OnAboutClicked(object sender, EventArgs e)
        {
            await AnimateButton(sender as Button);
            await DisplayAlert("About", "Navigating to About!", "OK");
        }

        private async void OnHelpClicked(object sender, EventArgs e)
        {
            await AnimateButton(sender as Button);
            await DisplayAlert("Help", "Navigating to Help!", "OK");
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Logout", "Are you sure you want to log out?", "Yes", "No");
            if (confirm)
            {
                await DisplayAlert("Logout", "You have been logged out.", "OK");
            }
        }

        // Animation for Buttons
        private async Task AnimateButton(Button button)
        {
            await button.ScaleTo(1.1, 150);  // Scale the button up a bit
            await button.ScaleTo(1, 100);    // Scale it back down
            await button.FadeTo(0.8, 100);  // Fade it to 80% opacity
            await button.FadeTo(1, 100);    // Fade it back to full opacity
        }
    }
}
