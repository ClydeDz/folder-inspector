namespace FolderInspector.Constants
{
    public class AppConstants
    {
        public const string DefaultConfigFile = "FolderInspector.exe.config";

        public partial class CommandLineConstants
        {
            public const string Help = "--help";
            public const string HelpShort = "-h";

            public const string Version = "--version";
            public const string VersionShort = "-v";

            public const string ConfigurationFile = "--config";
            public const string ConfigurationFileShort = "-c";
        }
    }
    public class CommandLineSettings
    {
        public bool VanityCommandRequested { get; set; }
        public bool ConfigSupplied { get; set; }
        public string ConfigFilePath { get; set; }
    }
}
