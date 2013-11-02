namespace Damienbod.Slab
{
    // Every const has a unique id. 
    public class GlobalType
    {
        public const int GlobalInformational = 1;
        public const int GlobalCritical = 2;
        public const int GlobalError = 3;
        public const int GlobalLogAlways = 4;
        public const int GlobalVerbose = 5;
        public const int GlobalWarning = 6;

    }

    public class WebType
    {
        public const int ControllerInformational = 7;
        public const int ControllerCritical = 8;
        public const int ControllerError = 9;
        public const int ControllerLogAlways = 10;
        public const int ControllerVerbose = 11;
        public const int ControllerWarning = 12;
    }
}
