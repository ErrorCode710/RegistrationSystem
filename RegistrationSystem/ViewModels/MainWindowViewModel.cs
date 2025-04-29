using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;

namespace RegistrationSystem.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {

        [ObservableProperty]
        private string _loggedInUsername = "Guest";
       
        [ObservableProperty]
        private bool _isPaneOpen = true;

        [ObservableProperty]
        private ViewModelBase _currentPage = new HomePageViewModel();

        public ObservableCollection<ListItemTemplate> Items { get; set; } = new()
        {
            new ListItemTemplate(typeof(HomePageViewModel),"home_regular"),
             new ListItemTemplate(typeof(UserPageViewModel),"person_regular"),
        };
        [ObservableProperty]
        private ListItemTemplate? _selectedListItem;

        partial void OnSelectedListItemChanged(ListItemTemplate? value)
        {
            if (value is null) return;
            var instance = Activator.CreateInstance(value.ModelType);
            if (instance is null) return;
            CurrentPage = (ViewModelBase)instance;
        }

        [RelayCommand]
        private void TriggerPane ()
        {
            IsPaneOpen = !IsPaneOpen;

        }


    }
    public class ListItemTemplate
    {
        public ListItemTemplate(Type type, string iconKey) { 

            ModelType = type;
            Label = type.Name.Replace("PageViewModel", "");

            Application.Current!.TryFindResource(iconKey, out var res);
            ListItemIcon = (StreamGeometry)res!;
        }

        public string Label { get; }
        public Type ModelType { get; set; }

        public StreamGeometry ListItemIcon { get; }

    }
}
