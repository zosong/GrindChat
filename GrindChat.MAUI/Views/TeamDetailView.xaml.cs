using GrindChat.MAUI.ViewModels;

namespace GrindChat.MAUI.Views;


[QueryProperty(nameof(UserId), "userId")]

[QueryProperty(nameof(TeamId), "teamId")]
public partial class TeamDetailView : ContentPage
{
    public int UserId { get; set; }

    public int TeamId { get; set; }
    public TeamDetailView()
    {
        InitializeComponent();
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new TeamViewModel(UserId, TeamId);
        var viewModel = BindingContext as TeamViewModel;
        if (viewModel != null)
        {
            viewModel.Model.AdminId = UserId;
            viewModel.Model.Id = TeamId; // Ensure the Id is set
            viewModel.RefreshTeams();
        }
    }

    private void OkClicked(object sender, EventArgs e)
    {
        var viewModel = BindingContext as TeamViewModel;
        if (viewModel != null)
        {
            viewModel.AddOrUpdate();
            Shell.Current.GoToAsync($"//UserDetail?userId={UserId}");
        }
    }

}