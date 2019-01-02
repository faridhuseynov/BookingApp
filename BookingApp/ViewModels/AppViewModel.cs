using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.ViewModels
{
    class AppViewModel : ViewModelBase
    {
        private ViewModelBase currentPage;
        public ViewModelBase CurrentPage { get => currentPage; set => Set(ref currentPage, value); }

    }
}
