using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Xml.Linq;

namespace MVVM_Community_Toolkit
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string surname;

        [ObservableProperty]
        private string result;

        [RelayCommand(CanExecute = nameof(CanSubmit))]
        private void Submit()
        {
            Result = $"Hello {Name} {Surname}!";
        }

        private bool CanSubmit()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Surname);
        }

        partial void OnNameChanged(string value)
        {
            SubmitCommand.NotifyCanExecuteChanged();
        }

        partial void OnSurnameChanged(string value)
        {
            SubmitCommand.NotifyCanExecuteChanged();
        }
    }
}
