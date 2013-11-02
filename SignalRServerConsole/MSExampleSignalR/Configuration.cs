namespace Damienbod.SignalR.Host
{
    using System;
    using System.Configuration;

    /// <summary>
    /// This is a helper class which decouples the App.Config from
    /// the application. All values read from the App.Config
    /// are got or set using this class.
    /// </summary>
    public class Configuration
    {
        private readonly AppSettingsReader configurationAppSettings;

        /// <summary>
        /// Implementation of the sigleton pattern
        /// </summary>
        private static Configuration instance;
     
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class. 
        /// default constructor
        /// </summary>
        public Configuration()
        {
            this.configurationAppSettings = new System.Configuration.AppSettingsReader();
        }

        /// <summary>
        /// Singleton pattern constructor
        /// </summary>
        /// <returns>Configuration</returns>
        public static Configuration GetInstance()
        {
            if (instance == null)
            {
                instance = new Configuration();
            }

            return instance;
        }

        public string MyHubServiceUrl()
        {
            return this.GetConfig("MyHubServiceUrl", typeof(string), "http://localhost:8089");
        }

        /// <summary>
        /// Returns a int for the config
        /// </summary>
        /// <param name="key">
        /// App.Settings key
        /// </param>
        /// <param name="type">
        /// Type of value to be returned
        /// </param>
        /// <param name="defaultValue">
        /// A default value if app.Setting is not configured or incorrect.
        /// </param>
        /// <returns>
        /// Returns a typed value for the app.Config
        /// </returns>
        private int GetConfig(string key, Type type, int defaultValue)
        {
            try
            {
                return int.Parse(this.configurationAppSettings.GetValue(key, type).ToString());
            }
            catch (Exception)
            {
                return defaultValue;
            }     
        }

        /// <summary>
        /// Returns a string for the config
        /// </summary>
        /// <param name="key">
        /// App.Settings key
        /// </param>
        /// <param name="type">
        /// Type of value to be returned
        /// </param>
        /// <param name="defaultValue">
        /// A default value if app.Setting is not configured or incorrect.
        /// </param>
        /// <returns>
        /// Returns a typed value for the app.Config
        /// </returns>
        private string GetConfig(string key, Type type, string defaultValue)
        {
            try
            {
                return this.configurationAppSettings.GetValue(key, type).ToString();
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Returns a bool for the config
        /// </summary>
        /// <param name="key">
        /// App.Settings key
        /// </param>
        /// <param name="type">
        /// Type of value to be returned
        /// </param>
        /// <param name="defaultValue">
        /// A default value if app.Setting is not configured or incorrect.
        /// </param>
        /// <returns>
        /// Returns a typed value for the app.Config
        /// </returns>
        private bool GetConfig(string key, Type type, bool defaultValue)
        {
            try
            {
                return bool.Parse(this.configurationAppSettings.GetValue(key, type).ToString());
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
    }
}
