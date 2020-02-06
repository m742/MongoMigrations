using System;
using System.Collections.Generic;
using System.Text;

namespace On.MongoMigrations.DAL.Configs
{
    public class SqlSettingsConfig
    {
        public static string AccountConnectionString { get; set; }
        public static string UserConnectionString { get; set; }
        public static string ManagerConnectionString { get; set; }
        public static string ConfigurationConnectionString { get; set; }
        public static string NavigationConnectionString { get; set; }
        public static string ScoreConnectionString { get; set; }
        public static string TaskConnectionString { get; set; }
        public static string EvaluationConnectionString { get; set; }
        public static string NotificationConnectioString { get; set; }
        public static string LogsApiConnectionString { get; set; }
        public static string AzureBusConnectionString { get; set; }

    }
}
