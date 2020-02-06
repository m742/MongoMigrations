using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using On.MongoMigrations.DAL.Configs;
using System;
using System.Data.SqlClient;
using System.IO;

namespace On.MongoMigrations.DAL.Util
{
    public class ServicesConfiguration
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static IServiceCollection services = new ServiceCollection();
        public static SqlConnection conexao;
        public static string Error002 = "Erro na passagem da Connection String do Sql";
        public static string Error001 = "Erro na Leitura do Arquivo AppSettings.JSON";
        public static string Success001 = "Efetuada a Leitura do Arquivo AppSettings.JSON";
        public static string Success002 = "Passagem das Connection Strings do Sql realizadas com sucesso";
        public static string Success003 = "Passagem das Connection String do Mongo realizadas com sucesso";
        public static string Error003 = "Erro na passagem da Connection String do Mongo";

        public static void ReadJson()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("./App_Settings/AppSettings.json");
                Configuration = builder.Build();
                Console.WriteLine(Success001);
            }
            catch (Exception e)
            {
                Console.WriteLine(Error001 + e);
            }
        }
        public static void SqlServerConfiguration()
        {
            try
            {
                SqlValidation();
                Console.WriteLine(Success002);
            }
            catch (Exception e)
            {
                Console.WriteLine(Error002 + e);
            }
        }

        public static void MongoConfiguration()
        {
            try
            {
                MongoValidation();
                Console.WriteLine(Success003);
            }
            catch (Exception e)
            {
                Console.WriteLine(Error003 + e);
            }

        }

       

        private static void MongoValidation()
        {
            if (String.IsNullOrEmpty(MongoSettingsConfig.ConnectionString) && String.IsNullOrEmpty(MongoSettingsConfig.Database))
            {
                MongoSettingsConfig.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                MongoSettingsConfig.Database = Configuration.GetSection("MongoConnection:Database").Value;
            }
        }


        private static void SqlValidation()
        {
            if (String.IsNullOrEmpty(SqlSettingsConfig.UserConnectionString))
            {
                SqlSettingsConfig.UserConnectionString = Configuration.GetSection("UserDb:ConnectionString").Value;
            }
            if (String.IsNullOrEmpty(SqlSettingsConfig.AccountConnectionString))
            {
                SqlSettingsConfig.AccountConnectionString = Configuration.GetSection("AccountDB:ConnectionString").Value;
            }

            if (String.IsNullOrEmpty(SqlSettingsConfig.AzureBusConnectionString))
            {
                SqlSettingsConfig.AzureBusConnectionString = Configuration.GetSection("AzureBusClient:ConnectionString").Value;
            }

            if (String.IsNullOrEmpty(SqlSettingsConfig.LogsApiConnectionString))
            {
                SqlSettingsConfig.LogsApiConnectionString = Configuration.GetSection("LogsApi:ConnectionString").Value;
            }

            if (String.IsNullOrEmpty(SqlSettingsConfig.TaskConnectionString))
            {
                SqlSettingsConfig.TaskConnectionString = Configuration.GetSection("TaskDB:ConnectionString").Value;
            }

            if (String.IsNullOrEmpty(SqlSettingsConfig.ManagerConnectionString))
            {
                SqlSettingsConfig.ManagerConnectionString = Configuration.GetSection("ManagerDB:ConnectionString").Value;
            }

            if (String.IsNullOrEmpty(SqlSettingsConfig.ConfigurationConnectionString))
            {
                SqlSettingsConfig.ConfigurationConnectionString = Configuration.GetSection("ConfigurationDB:ConnectionString").Value;
            }

            if (String.IsNullOrEmpty(SqlSettingsConfig.EvaluationConnectionString))
            {
                SqlSettingsConfig.EvaluationConnectionString = Configuration.GetSection("EvaluationDB:ConnectionString").Value;
            }

            if (String.IsNullOrEmpty(SqlSettingsConfig.ScoreConnectionString))
            {
                SqlSettingsConfig.ScoreConnectionString = Configuration.GetSection("ScoreDB:ConnectionString").Value;
            }

            if (String.IsNullOrEmpty(SqlSettingsConfig.NavigationConnectionString))
            {
                SqlSettingsConfig.NavigationConnectionString = Configuration.GetSection("NavigationDB:ConnectionString").Value;
            }

            if (String.IsNullOrEmpty(SqlSettingsConfig.NotificationConnectioString))
            {
                SqlSettingsConfig.NotificationConnectioString = Configuration.GetSection("NotificationDB:ConnectionString").Value;
            }

        }
    }
}
