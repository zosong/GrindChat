using GrindChat.Library.Models;
using GrindChat.Library.Services;
using GrindChat.MAUI.Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GrindChat.MAUI.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public User Model { get; set; }

        public string RetypedPassword { get; set; }

        public bool PasswordsMatch
        {
            get
            {
                return Model?.Password == RetypedPassword;
            }
        }

        private readonly UserService _userService;

        public UserViewModel() : this(new User(), null)
        {
        }

        public UserViewModel(User user) : this(user, null)
        {
        }

        public UserViewModel(UserService userService) : this(new User(), userService)
        {
        }

        public UserViewModel(int userId)
        {
            // Fetch the user by the given userId (you'll need an instance of UserService here)
            // Model = fetchedUser;
            SetupCommands();
        }


        public UserViewModel(User user, UserService userService)
        {
            Model = user ?? new User();
            _userService = userService;
            SetupCommands();
        }

        public UserViewModel(int userId, UserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            // Fetch the user by the given userId using _userService and assign to Model
            Model = _userService.GetUserAsync(userId.ToString()).Result; // Note: this is not ideal, but for brevity.
            SetupCommands();
        }

        private void SetupCommands()
        {
            AddCommand = new Command(ExecuteAdd);
            // Setup other commands similarly
        }

        public ICommand AddCommand { get; private set; }
        // Other ICommand properties

        private async void ExecuteAdd()
        {
            await Shell.Current.GoToAsync($"//UserDetail?userId={Model.Id}");
        }

        public async Task AddOrUpdate()
        {
            if (!PasswordsMatch)
            {
                throw new InvalidOperationException("Passwords do not match.");
            }

            var success = await _userService.RegisterAsync(Model);
            if (!success)
            {
                // Handle failure here, like showing an error message
            }
            else
            {
                // You might want to redirect or do something else upon success
            }
        }

        // Other methods and command executions, like Update, Delete, etc.

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
