using System.Windows;
using PortableSignalR.ViewModel;
using SignalRDataProvider.DataProvider;

namespace SignalRClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();
            Execute.InitializeWithDispatcher();

            _vm = new MainViewModel( new SignalRHubSync(), new WpfContext() );
            this.DataContext = _vm;
            _vm.Load();

        }
    }
}
