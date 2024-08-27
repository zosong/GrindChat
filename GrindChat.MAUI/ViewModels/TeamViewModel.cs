using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GrindChat.Library.Models;
using GrindChat.Library.Services;

namespace GrindChat.MAUI.ViewModels
{
    class TeamViewModel : INotifyPropertyChanged
    {
        public Team Model { get; set; }

/*        public ObservableCollection<TeamViewModel> Teams
        {
            get
            {
                if (Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<TeamViewModel>();
                }
                return new ObservableCollection<TeamViewModel>(TeamService
                    .Current.Teams.Where(p => p.AdminId == Model.Id)
                    .Select(r => new TeamViewModel(r)));
            }
        }*/



        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand AddCommand { get; private set; }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public void ExecuteDelete()
        {
/*            TeamService.Current.Delete(Model.Id);
*/        }

        private void ExecuteAdd()
        {
/*            TeamService.Current.AddOrUpdate(Model);
            Shell.Current.GoToAsync($"//UserDetail?userId={Model.AdminId}");*/
        }

        public void ExecuteEdit(int id)
        {
/*            TeamService.Current.AddOrUpdate(Model);
            Shell.Current.GoToAsync($"//TeamDetail?userId={Model.AdminId}&projectId={Model.Id}");*/
        }



        public void RefreshTeams()
        {
/*            NotifyPropertyChanged(nameof(Teams));*/
        }

        public void SetupCommands()
        {
            /*            DeleteCommand = new Command(
                            (c) => ExecuteDelete((c as TeamViewModel).Model.Id));*/
            DeleteCommand = new Command(ExecuteDelete);
            EditCommand = new Command(
                (c) => ExecuteEdit((c as TeamViewModel).Model.Id));
            AddCommand = new Command(ExecuteAdd);
        }

        public void AddOrUpdate()
        {
            /*TeamService.Current.AddOrUpdate(Model);*/
        }

        public void Update()
        {
            /*TeamService.Current.Update(Model);*/
        }

        public TeamViewModel()
        {
            Model = new Team();
            SetupCommands();
        }
        public TeamViewModel(int userId, int applicationId)
        {
/*            if (applicationId == 0)
            {
                Model = new Team { AdminId = userId };
            }
            else
            {
                Model = TeamService.Current.Get(applicationId);
            }
            SetupCommands();*/
        }



        public TeamViewModel(Team model)
        {
            Model = model;
            SetupCommands();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
