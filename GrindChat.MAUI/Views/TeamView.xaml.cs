using GrindChat.MAUI.ViewModels;
namespace GrindChat.MAUI.Views;
[QueryProperty(nameof(UserId), "userId")]
public partial class TeamView : ContentPage
{

	public int UserId { get; set; }
	public TeamView()
	{
		InitializeComponent();
    }
}