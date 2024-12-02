using Microsoft.Maui.Controls;
using System;
using System.Timers;

namespace MauiAppMyRF.Pages
{
    public partial class OTPPage : ContentPage
    {
        private int _timeLeft = 25;
        private System.Timers.Timer _timer;

        // Predefined OTP code (for testing purposes)
        private const string PredefinedOTP = "1234"; // Predefined OTP to be entered

        public OTPPage()
        {
            InitializeComponent();
            StartTimer();
            OtpEntry.Focus(); // Focus on the OTP Entry field when page loads
        }

        // Start the countdown timer
        private void StartTimer()
        {
            _timer = new System.Timers.Timer(1000); // Timer interval of 1 second
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();
        }

        // Update the timer every second
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_timeLeft > 0)
            {
                _timeLeft--;
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ResendLabel.Text = $"Resend code in: 00:{_timeLeft:D2} sec";
                });
            }
            else
            {
                _timer.Stop();
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ResendLabel.Text = "You can resend the code now";
                });
            }
        }

        // Event handler for OTP entry completion
        private void OtpEntry_Completed(object sender, EventArgs e)
        {
            OnSubmitClicked(sender, e); // Trigger the submit action when the user presses "Enter" after typing the OTP
        }

        // Handle Submit button click
        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            // Get OTP entered by the user
            string otp = OtpEntry.Text;

            // Validate OTP length and ensure it contains only 4 digits
            if (otp.Length == 4)
            {
                // Check if the entered OTP matches the predefined OTP
                if (otp == PredefinedOTP)
                {
                    // OTP is valid, navigate to ResetPasswordPage
                    await DisplayAlert("Success", "OTP is correct!", "OK");
                    await Navigation.PushAsync(new ResetPasswordPage()); // Navigate to ResetPasswordPage
                }
                else
                {
                    // If OTP does not match
                    await DisplayAlert("Error", "The OTP you entered is incorrect. Please try again.", "OK");
                }
            }
            else
            {
                // If OTP is incomplete or invalid
                await DisplayAlert("Error", "Please enter a valid 4-digit OTP.", "OK");
            }
        }

        // Handle Resend OTP button click
        private void OnResendClicked(object sender, EventArgs e)
        {
            _timeLeft = 25;
            _timer.Start();
            ResendLabel.Text = $"Resend code in: 00:{_timeLeft:D2} sec";
        }

        // Handle Back button click
        private void OnBackClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(); // Go back to the previous page
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _timer?.Stop();
            _timer?.Dispose();
        }
    }
}
