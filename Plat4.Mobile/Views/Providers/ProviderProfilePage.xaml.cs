using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plat4.Mobile.Views.Shared;
using ShellItem = Microsoft.Maui.Controls.ShellItem;

namespace Plat4.Mobile.Views.Providers;

public partial class ProviderProfilePage : ContentPage
{
    public ProviderProfilePage()
    {
        InitializeComponent();
    }

    private async void BtnProviderSignOut_OnClicked(object? sender, EventArgs e)
    {
        Application.Current.MainPage = new LoginPage();
    }
}