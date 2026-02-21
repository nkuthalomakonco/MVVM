using Inventory_POS_system.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfTodoApp.Models;

namespace MVVM_TodoList.ViewModels
{
    public class ToDoViewModel : BaseViewModel
    {
        private ObservableCollection<TodoItem> _tasks;
        public ObservableCollection<TodoItem> Tasks
        {
            get => _tasks;
            set { _tasks = value; OnPropertyChanged(); }
        }

        private string _title;
        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); (AddTaskCommand as RelayCommand)?.RaiseCanExecuteChanged(); }
        }

        public ICommand AddTaskCommand { get; }

        public ToDoViewModel()
        {
            Tasks = new ObservableCollection<TodoItem>
            {
                new TodoItem { Title = "Learn MVVM", IsCompleted = false },
                new TodoItem { Title = "Build ToDo App", IsCompleted = false }
            };

            AddTaskCommand = new RelayCommand(AddTask, CanAddTask);
        }

        private void AddTask()
        {
            Tasks.Add(new TodoItem { Title = Title, IsCompleted = false });
            Title = string.Empty;
        }

        private bool CanAddTask()
        {
            return !string.IsNullOrWhiteSpace(Title);
        }
    }
}
