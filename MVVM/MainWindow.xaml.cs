// Required namespaces for WPF and MVVM functionality
using System.ComponentModel;   // Provides INotifyPropertyChanged
using System.Windows;          // Core WPF classes (Window, MessageBox, etc.)
using System.Windows.Input;    // Provides ICommand interface

namespace MVVM
{
    // MainWindow is the View in MVVM
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set the DataContext to the ViewModel
            // This allows XAML bindings to access properties and commands
            DataContext = new MainViewModel();
        }
    }

    // Model class - represents business data
    public class Product
    {
        // Product name
        public string Name { get; set; }

        // Product price
        public double Price { get; set; }
    }

    // ViewModel class - connects View and Model
    // Implements INotifyPropertyChanged to notify UI when data changes
    public class MainViewModel : INotifyPropertyChanged
    {
        // Backing field for ProductName property
        private string _productName;

        // Property bound to the UI (e.g., TextBox)
        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;

                // Notify UI that ProductName has changed
                OnPropertyChanged(nameof(ProductName));
            }
        }

        // Command bound to a Button in the View
        public ICommand SaveCommand { get; }

        // Constructor
        public MainViewModel()
        {
            // Initialize command and assign method to execute
            SaveCommand = new RelayCommand(Save);
        }

        // Method executed when SaveCommand is triggered
        private void Save()
        {
            // Example logic (normally you would save to DB or service)
            MessageBox.Show($"Saved: {ProductName}");
        }

        // Event required by INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        // Method to raise PropertyChanged event
        protected void OnPropertyChanged(string name)
        {
            // Invoke event if there are subscribers (UI)
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    // RelayCommand class - reusable ICommand implementation
    public class RelayCommand : ICommand
    {
        // Stores the method to execute
        private readonly Action _execute;

        // Constructor accepts method to run when command executes
        public RelayCommand(Action execute)
        {
            _execute = execute;
        }

        // Event triggered when CanExecute state changes
        public event EventHandler CanExecuteChanged;

        // Determines whether the command can execute
        // Currently always returns true (button always enabled)
        public bool CanExecute(object parameter) => true;

        // Executes the assigned method
        public void Execute(object parameter) => _execute();
    }

}
