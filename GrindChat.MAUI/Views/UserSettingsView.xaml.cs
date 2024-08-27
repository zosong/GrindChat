using GrindChat.MAUI.ViewModels;
namespace GrindChat.MAUI.Views;
[QueryProperty(nameof(UserId), "userId")]
public partial class UserSettingsView : ContentPage
{
    private int userId;

    public int UserId
    {
        get { return userId; }
        set
        {
            userId = value;
            Console.WriteLine($"UserId set to: {userId}");
            OnUserIdChanged();
        }
    }

    private void OnUserIdChanged()
    {
        //BindingContext = new UserViewModel(UserId);
        //(BindingContext as UserViewModel)?.RefreshTeams();
    }
    public UserSettingsView()
    {
        InitializeComponent();
    }

    private async void saveChangesButtonClicked(object sender, EventArgs e)
    {
/*        (BindingContext as UserViewModel).Update();
        await Shell.Current.GoToAsync($"//UserDetail?userId={UserId}");*/
    }

    private void cancleButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//UserDetail?userId={UserId}");
    }

}