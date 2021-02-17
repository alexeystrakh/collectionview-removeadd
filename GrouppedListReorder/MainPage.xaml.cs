using System;
using System.Diagnostics;
using GrouppedListReorder.ViewModels;
using Xamarin.Forms;

namespace GrouppedListReorder
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}
