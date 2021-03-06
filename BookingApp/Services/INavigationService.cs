﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Services
{
    interface INavigationService
    {
        void Navigate<T>();
        void Navigate(Type type);
        void Register<T>(ViewModelBase viewModel);
    }
}
