﻿using BookingApp.Models;
using BookingApp.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BookingApp.ViewModels
{
    class SignUpViewModel:ViewModelBase
    {
        private readonly INavigationService navigation;
        private readonly AppDbContext db;

        private User newUser=new User();
        public User NewUser { get => newUser; set => Set(ref newUser, value); }     

        void UserDataClear()
        {
            newUser.Email = newUser.Name = newUser.Password = newUser.PhotoLink = newUser.Surname = newUser.UserName = "";
        }

        public SignUpViewModel(INavigationService navigation, AppDbContext db)
        {
            this.navigation = navigation;
            this.db = db;
        }

        private RelayCommand<PasswordBox> registerCommand;
        public RelayCommand<PasswordBox> RegisterCommand
        {
            get => registerCommand ?? (registerCommand = new RelayCommand<PasswordBox>(
                param =>
                {
                    newUser.Password = param.Password;
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    UserDataClear();
                    navigation.Navigate<StartPageViewModel>();
                }
            ));
        }

        private RelayCommand cancelCommand;
        public RelayCommand CancelCommand
        {
            get => cancelCommand ?? (cancelCommand = new RelayCommand(
                () =>
                {
                    UserDataClear();
                    navigation.Navigate<StartPageViewModel>();
                }
            ));
        }
        
    }
}
