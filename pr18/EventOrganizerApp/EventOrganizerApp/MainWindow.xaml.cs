using EventOrganizerApp.ViewModels;
using System.Windows;

namespace EventOrganizerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new EventViewModel();
        }
    }
}