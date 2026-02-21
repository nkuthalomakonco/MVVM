using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace MVVM_CommunityToolkit.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        // Observable property
        [ObservableProperty]
        private string newName;

        // Observable collection
        public ObservableCollection<string> People { get; } = new();

        // Command
        [RelayCommand]
        private void AddPerson()
        {
            if (!string.IsNullOrWhiteSpace(NewName))
            {
                People.Add(NewName);
                //NewName = string.Empty;
            }
        }
    }
}
