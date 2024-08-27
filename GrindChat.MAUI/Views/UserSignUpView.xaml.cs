using GrindChat.MAUI.Services;
using GrindChat.MAUI.ViewModels;
using System;

namespace GrindChat.MAUI.Views
{
    [QueryProperty(nameof(UserId), "userId")]
    public partial class UserSignUpView : ContentPage
    {
        public int UserId { get; set; }

        public UserSignUpView()
        {
            InitializeComponent();
            var userService = new UserService(new HttpClient());
            BindingContext = new UserViewModel(UserId, userService);
        }

        private async void createAccountButtonClicked(object sender, EventArgs e)
        {
            // Check if ViewModel is set
            var viewModel = BindingContext as UserViewModel;
            if (viewModel == null)
            {
                await DisplayAlert("Error", "ViewModel not set.", "OK");
                return;
            }

            // Check if passwords match using the ViewModel's logic
            if (!viewModel.PasswordsMatch)
            {
                await DisplayAlert("Error", "Passwords do not match!", "OK");
                return;
            }

            // If passwords match, delegate the user creation or update to the ViewModel
            viewModel.AddOrUpdate();

            await Shell.Current.GoToAsync("//MainPage");
        }

        private async void cancleButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }

        private void OnArrivingAsync(object sender, NavigatedToEventArgs e)
        {
            try
            {
                var userService = new UserService(new HttpClient());
                BindingContext = new UserViewModel(UserId, userService);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Log the error to see what's going on.
            }


            // Refresh any data if necessary, e.g.:
            //(BindingContext as UserViewModel)?.RefreshApplications();

            retypePasswordEntry.SetBinding(Entry.TextProperty, new Binding("RetypedPassword"));
        }
    }
}
