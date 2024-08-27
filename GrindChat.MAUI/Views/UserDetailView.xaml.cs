using GrindChat.MAUI.ViewModels;
using GrindChat.Library.Services;
using static System.Net.Mime.MediaTypeNames;

namespace GrindChat.MAUI.Views;
[QueryProperty(nameof(UserId), "userId")]
public partial class UserDetailView : ContentPage
{
    //public int UserId { get; set; }


    public UserDetailView()
    {
        InitializeComponent();
        this.SizeChanged += OnPageSizeChanged;
    }

    private void OnPageSizeChanged(object sender, EventArgs e)
    {
        TeamsListView.HeightRequest = this.Height * 0.7;
    }

    private void SettingsClicked(object sender, EventArgs e)
    {
        //BindingContext = new UserViewModel(UserId);
    }




    private void OpenClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//TeamDetail");
    }
    private async void ExitClicked(object sender, EventArgs e)
    {
/*        try
        {
            if (BindingContext is UserViewModel viewModel)
            {
                viewModel.Update();
                await Shell.Current.GoToAsync("//MainPage");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }*/
    }




    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as TeamViewViewModel).RefreshTeamList();
    }
    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        //BindingContext = new UserViewModel(UserId);

        //(BindingContext as UserViewModel).RefreshTeams();
    }

    private void AddTeamClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//TeamDetail?userId={UserId}");
    }

    private void RefreshClicked(object sender, EventArgs e)
    {
/*        var viewModel = BindingContext as UserViewModel;
        viewModel?.RefreshTeams();*/
    }

    private int userId;
    public int UserId
    {
        get { return userId; }
        set
        {
            userId = value;
            OnUserIdChanged();
        }
    }

    private void OnUserIdChanged()
    {

        //try
        //{
        //    BindingContext = new UserViewModel(UserId);
        //    Console.WriteLine($"Fetched User Name: {(BindingContext as UserViewModel)?.Model?.Name}");
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Error fetching user data: {ex.Message}");
        //}
    }



    private void OpenTeamClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.BindingContext is TeamViewModel appViewModel)
        {
            var teamId = appViewModel.Model.Id;
            var userId = appViewModel.Model.AdminId;

            Shell.Current.GoToAsync($"//TeamDetail?userId={userId}&teamId={teamId}");
        }
    }
    private void DeleteClicked(object sender, EventArgs e)
    {
        //var button = sender as Button;
        //var team = button?.BindingContext as TeamViewModel;
        //if (team != null)
        //{
        //    TeamService.Current.Delete(team.Model.Id);
        //    var viewModel = BindingContext as UserViewModel;
        //    viewModel.RefreshTeams();
        //}
    }


}