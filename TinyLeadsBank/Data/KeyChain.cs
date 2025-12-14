namespace TinyLeadsBank.Data
{
    /// <summary>
    /// In-app settings not needed to be abstracted to user secrets
    /// </summary>
    public static class KeyChain
    {
        public static string AppName
        {
            get
            {
                return "Tiny Leads Bank";
            }
        }
        public static string AppCode
        {
            get
            {
                return "TinyLeads3";
            }
        }
        public static string Container
        {
            get
            {
                return "tlfilestorage";
            }
        }
        public static string OwnerEmail
        {
            get
            {
                return "prions48@gmail.com";
            }
        }
    }
    public enum Environ
    {
        MainApp
    }

}