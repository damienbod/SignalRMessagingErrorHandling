using PortableSignalR.Base;

namespace PortableSignalR.Model
{
    public class HelloWpf : Observable
    {
        private string _molly;
        private int _age;

        public string Molly
        {
            get { return _molly; }
            set
            {
                SetProperty(ref _molly, value);
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                SetProperty(ref _age, value);
            }
        }
    }
}
