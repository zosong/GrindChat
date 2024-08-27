using GrindChat.Library.Models;
using GrindChat.Library.Services;
using GrindChat.MAUI.ViewModels;
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
    class UserViewViewModel : INotifyPropertyChanged
    {

        public User SelectedUser { get; set; }

        public ICommand SearchCommand { get; private set; }

        public string Query { get; set; }

        public void ExecuteSearchCommand()
        {

          // NotifyPropertyChanged(nameof(TeamViewViewModel.Teams));
        }


        //public ObservableCollection<UserViewModel> Users
        //{
        //    get
        //    {
        //        return
        //            new ObservableCollection<UserViewModel>
        //            (UserService
        //                .Current.Search(Query ?? string.Empty)
        //                .Select(c => new UserViewModel(c)).ToList());
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Delete()
        {
            //if (SelectedUser != null)
            //{
            //    UserService.Current.Delete(SelectedUser.Id);
            //    SelectedUser = null;
            //    NotifyPropertyChanged(nameof(Users));
            //    NotifyPropertyChanged(nameof(SelectedUser));
            //}
        }


        public void RefreshUser()
        {
            //NotifyPropertyChanged(nameof(Users));
        }
    }
}