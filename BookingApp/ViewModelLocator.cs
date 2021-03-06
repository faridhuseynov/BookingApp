﻿using Autofac;
using Autofac.Configuration;
using BookingApp.Services;
using BookingApp.ViewModels;
using GalaSoft.MvvmLight;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookingApp
{
    class ViewModelLocator
    {
        private AppViewModel appViewModel;
        private StartPageViewModel startPageViewModel;
        private SignUpViewModel signUpViewModel;
        private DashboardViewModel dashBoardViewModel;



        private INavigationService navigationService;
        public static IContainer Container;

        public ViewModelLocator()
        {
            try
            {
                var config = new ConfigurationBuilder();
                config.AddJsonFile("autofac.json");
                var module = new ConfigurationModule(config.Build());
                var builder = new ContainerBuilder();
                builder.RegisterModule(module);
                Container = builder.Build();

                navigationService = Container.Resolve<INavigationService>();
                appViewModel = Container.Resolve<AppViewModel>();
                startPageViewModel = Container.Resolve<StartPageViewModel>();
                signUpViewModel = Container.Resolve<SignUpViewModel>();
                dashBoardViewModel = Container.Resolve<DashboardViewModel>();

                navigationService.Register<StartPageViewModel>(startPageViewModel);
                navigationService.Register<SignUpViewModel>(signUpViewModel);
                navigationService.Register<DashboardViewModel>(dashBoardViewModel);

                navigationService.Navigate<StartPageViewModel>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public ViewModelBase GetAppViewModel()
        {
            return appViewModel;
        }
    }
}
