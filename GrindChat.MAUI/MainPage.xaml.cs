using GrindChat.Library.Services;
using GrindChat.MAUI.Services;
using GrindChat.MAUI.ViewModels;
using GrindChat.MAUI.Views;
using Microsoft.Extensions.DependencyInjection;

namespace GrindChat.MAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly IUserRepository _userRepository;

        public MainPage()
        {
            InitializeComponent();

            // Getting an instance of the UserRepository
            var userService = ((App)App.Current).ServiceProvider.GetService<UserService>();
        }

        private async void SigninBtnClicked(object sender, EventArgs e)
        {
            try
            {
                string email = UsernameEntry.Text;
                string password = PasswordEntry.Text;

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    await DisplayAlert("Error", "Please enter both email and password.", "OK");
                    return;
                }

                // Use the UserRepository to check for user
                var user = _userRepository.GetAll().FirstOrDefault(u => u.EmailAddress == email && u.Password == password);

                if (user != null)
                {
                    var userViewPage = new UserDetailView();
                    userViewPage.BindingContext = new UserViewModel(user);
                    await Shell.Current.Navigation.PushAsync(userViewPage);
                }
                else
                {
                    await DisplayAlert("Error", "Invalid email or password!", "OK");
                }

                if (BindingContext is UserViewViewModel viewModel)
                {
                    viewModel.RefreshUser();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void SignupBtnClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//UserSignUpView");
        }
    }
}
