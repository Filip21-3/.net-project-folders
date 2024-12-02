namespace MauiAppMyRF.Pages;

using Microsoft.Maui.Controls;
public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
    }
    private void OnBackClicked(object sender, EventArgs e)
    {
        // Navigate back to the previous page
        Navigation.PopAsync();
    }
    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        // Navigate back to the previous page
        await Navigation.PushAsync(new LoginPage());
    }
    private void OnCountryCodeChanged(object sender, EventArgs e)
    {
        // Get the selected country code from the picker
        string selectedCountryCode = CountryCodePicker.SelectedItem.ToString();

        // Extract the country code (e.g. +386) from the selected string
        string countryCode = selectedCountryCode.Split(' ')[0];

        // Prepend the country code to the mobile number entry
        MobileNumberEntry.Text = countryCode;
    }
}
