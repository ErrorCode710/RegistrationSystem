using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;

namespace RegistrationSystem.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isPaneOpen = true;

        [ObservableProperty]
        private ViewModelBase _currentPage = new HomePageViewModel();

        public ObservableCollection<ListItemTemplate> Items { get; set; } = new()
        {
            new ListItemTemplate(typeof(HomePageViewModel)),
        };


        [RelayCommand]
        private void TriggerPane ()
        {
            IsPaneOpen = !IsPaneOpen;

        }


    }
    public class ListItemTemplate
    {
        public ListItemTemplate(Type type) { 

            ModelType = type;
            Label = type.Name.Replace("PageViewModel", "");
        }

        public string Label { get; }
        public Type ModelType { get; set; }

    }
}
