using GrindChat.Library.Models;
using GrindChat.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GrindChat.MAUI.ViewModels
{
    class TeamViewViewModel : INotifyPropertyChanged
    {
        public User User { get; set; }
        public Team SelectedTeam { get; set; }

        public ICommand SearchCommand { get; private set; }

        public string Query { get; set; }

        public void ExecuteSearchCommand()
        {
           // NotifyPropertyChanged(nameof(Teams));
        }
        public TeamViewViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand);
        }

/*        public ObservableCollection<TeamViewModel> Teams
        {
            get
            {
                return
                    new ObservableCollection<TeamViewModel>
                    (TeamService
                        .Current.Search(Query ?? string.Empty)
                        .Select(c => new TeamViewModel(c)).ToList());
            }
        }*/

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public TeamViewViewModel(int userId)
        {
/*            if (userId > 0)
            {
                User = UserService.Current.Get(userId);
            }
            else
            {
                User = new User();
            }*/

        }

        public void Delete()
        {
/*            if (SelectedTeam != null)
            {
                TeamService.Current.Delete(SelectedTeam.Id);
                SelectedTeam = null;
                NotifyPropertyChanged(nameof(Teams));
                NotifyPropertyChanged(nameof(SelectedTeam));
            }*/
        }

        public void RefreshTeamList()
        {
          //  NotifyPropertyChanged(nameof(Teams));
        }
    }
}