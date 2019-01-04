using BookingApp.Models;
using BookingApp.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookingApp.ViewModels
{
    class StartPageViewModel:ViewModelBase
    {
        private readonly INavigationService navigation;
        private readonly AppDbContext db;

        private string photoPath= @"C:\Users\Farid\Desktop\Structure.jpg";
        public string PhotoPath { get => photoPath; set => Set(ref photoPath, value); }

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
        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get => loginCommand ?? (loginCommand = new RelayCommand(
                () =>
                {
                    var check = db.Users.FirstOrDefault(x => x.UserName == checkUser);
                    if (check!=null)
                    {
                        PhotoPath = check.PhotoLink;
                        if (check.Password == CheckPassword)
                        {
                            navigation.Navigate<SignUpViewModel>();
                        }
                        else
                            MessageBox.Show("Password is incorrect!");
                    }
                    else
                        MessageBox.Show("Username is incorrect!");
                }
            ));
        }
    }
}
