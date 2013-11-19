using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using PortableSignalR.ViewModel;
using SignalRDataProvider.DataProvider;

namespace SignalRClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public string Host = "http://localhost:8089/";

       // public IHubProxy Proxy { get; set; }
        //public HubConnection Connection { get; set; }

        public bool Active { get; set; }

        private MainViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();

            _vm = new MainViewModel( new SignalRHubSync());
            this.DataContext = _vm;
            _vm.Load();
        }


        //private async void ActionHeartbeatButtonClick(object sender, RoutedEventArgs e)
        //{
        //    await SendHeartbeat();
        //}

        //private async void ActionSendButtonClick(object sender, RoutedEventArgs e)
        //{
        //    await SendMessage();
        //}

        //private async void ActionSendObjectButtonClick(object sender, RoutedEventArgs e)
        //{
        //    await SendMessage();
        //}     

        //private async Task SendMessage()
        //{
        //    await Proxy.Invoke("Addmessage", ClientNameTextBox.Text , MessageTextBox.Text);
        //}

        //private async Task SendHeartbeat()
        //{
        //    await Proxy.Invoke("Heartbeat");
        //}

        //private async Task SendHelloObject()
        //{
        //    HelloModel hello = new HelloModel { Age = Convert.ToInt32(HelloTextBox.Text), Molly = HelloMollyTextBox.Text };
        //    await Proxy.Invoke("sendHelloObject", hello);
        //}

        //private async void ActionWindowLoaded(object sender, RoutedEventArgs e)
        //{
        //    Active = true;
        //    Thread = new System.Threading.Thread(() =>
        //    {
        //        Connection = new HubConnection(Host);
        //        Proxy = Connection.CreateHubProxy("MyHub");

        //        Proxy.On<string, string>("addmessage", (name, message) => OnSendData("Recieved addMessage: " + name + ": " + message ));
        //        Proxy.On("heartbeat", () => OnSendData("Recieved heartbeat"));
        //        Proxy.On<HelloModel>("sendHelloObject", hello => OnSendData("Recieved sendHelloObject " + hello.Molly +  " " + hello.Age));

        //        Connection.Start();

        //        while (Active)
        //        {
        //            System.Threading.Thread.Sleep(10);
        //        }
        //    }) { IsBackground = true };
        //    Thread.Start();

        //}

        //private void OnSendData(string message)
        //{
        //    Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() => MessagesListBox.Items.Insert(0, message)));
        //}

        //private async void ActionMessageTextBoxOnKeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter || e.Key == Key.Return)
        //    {
        //        await SendMessage();
        //        MessageTextBox.Text = "";
        //    }
        //}
    }
}
