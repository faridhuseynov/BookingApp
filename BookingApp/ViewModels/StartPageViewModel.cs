using BookingApp.Models;
using BookingApp.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.ViewModels
{
    class StartPageViewModel:ViewModelBase
    {
        private readonly INavigationService navigation;
        private readonly AppDbContext db;

        private string checkUser;
        public string CheckUser { get => checkUser; set => Set(ref checkUser, value); }

        private string checkPassword;
        public string CheckPassword { get => checkPassword; set => Set(ref checkPassword, value); }

        public StartPageViewModel(INavigationService navigation,AppDbContext db)
        {
            this.navigation = navigation;
            this.db = db;
        }

        private RelayCommand signUpCommand;
        public RelayCommand SignUpCommand
        {
            get => signUpCommand ?? (signUpCommand = new RelayCommand(
                () =>
                {
                    navigation.Navigate<SignUpViewModel>();
                }
            ));
        }

    }
}
