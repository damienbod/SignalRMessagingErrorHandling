using PortableSignalR.Base;

namespace PortableSignalR.Model
{
    public class MyMessage : Observable
    {
        private string _name;
        private string _message;

        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value);
            }
        }
    }
}
