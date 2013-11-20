using PortableSignalR.Model;
using PortableSignalR.ViewModel;

namespace PortableSignalR.Base
{
    public interface IContext
    {
        void SendConnectionEvent(MainViewModel mainViewModel, bool connected);
        void RecieveMessageEvent(MainViewModel mainViewModel, MyMessage myMessage);
    }
}