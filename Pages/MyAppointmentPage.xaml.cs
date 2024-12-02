using System;
using Microsoft.Maui.Controls;

namespace MauiAppMyRF.Pages
{
    public partial class MyAppointmentPage : ContentPage
    {
        private DateTime _currentMonth;

        public MyAppointmentPage()
        {
            InitializeComponent();
            _currentMonth = DateTime.Now;
            UpdateCalendar();
        }

        private void UpdateCalendar()
        {
            // Clear existing children and rows
            CalendarGrid.Children.Clear();
            CalendarGrid.RowDefinitions.Clear();

            // Add row for day-of-week labels (header)
            CalendarGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            // Add labels for the days of the week (Sun to Sat)
            string[] daysOfWeek = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            for (int i = 0; i < daysOfWeek.Length; i++)
            {
                var label = new Label
                {
                    Text = daysOfWeek[i],
                    FontAttributes = FontAttributes.Bold,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Colors.White // Optional styling
                };
                CalendarGrid.Add(label, i, 0); // Add to the first row
            }

            // Calculate the number of rows required for the calendar
            DateTime firstDayOfMonth = new DateTime(_currentMonth.Year, _currentMonth.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(_currentMonth.Year, _currentMonth.Month);
            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;
            int totalDays = startDayOfWeek + daysInMonth;
            int totalRows = (int)Math.Ceiling(totalDays / 7.0);

            // Add rows dynamically for the weeks in the month
            for (int i = 0; i < totalRows; i++)
            {
                CalendarGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            }

            // Add buttons for each day of the month
            int currentRow = 1; // Start from the second row
            int currentColumn = startDayOfWeek;

            for (int day = 1; day <= daysInMonth; day++)
            {
                var dayButton = new Button
                {
                    Text = day.ToString(),
                    BackgroundColor = Colors.White,
                    TextColor = Colors.DarkGreen,
                    CornerRadius = 5,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                // Handle day button click
                dayButton.Clicked += (s, e) => OnDayClicked(day);

                // Add button to the grid
                CalendarGrid.Add(dayButton, currentColumn, currentRow);

                // Move to the next column
                currentColumn++;

                // If the column exceeds Saturday (6), reset to Sunday and move to the next row
                if (currentColumn > 6)
                {
                    currentColumn = 0;
                    currentRow++;
                }
            }

            // Update the month label
            MonthLabel.Text = _currentMonth.ToString("MMMM yyyy").ToUpper();
        }

        private void OnDayClicked(int day)
        {
            // Display the selected date as an appointment
            DisplayAlert("Appointment", $"You selected {new DateTime(_currentMonth.Year, _currentMonth.Month, day):D}", "OK");
        }

        private void OnPreviousMonthClicked(object sender, EventArgs e)
        {
            // Move to the previous month
            _currentMonth = _currentMonth.AddMonths(-1);
            UpdateCalendar();
        }

        private void OnNextMonthClicked(object sender, EventArgs e)
        {
            // Move to the next month
            _currentMonth = _currentMonth.AddMonths(1);
            UpdateCalendar();
        }
    }
}
