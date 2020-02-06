using Domain.DTO;
using MongoDB.Driver;
using On.MongoMigrations.DAL.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;
using System.Text;

namespace On.MongoMigrations.DAL.MongoDataManager.Context
{
    public class MongoContext
    {
        private readonly MongoClient mongoClient;
        protected readonly IMongoDatabase database;
        public static string Sucess001 = "Conexão do Mongo Realizada com Sucesso";
        public static string Error001 = "Houve um erro ao realizar a conexão";

        public MongoContext()
        {
            try
            {
                mongoClient = new MongoClient(MongoSettingsConfig.ConnectionString);
                database = mongoClient.GetDatabase(MongoSettingsConfig.Database);
                Map();
                Console.WriteLine(Sucess001);
            }
            catch (Exception e)
            {
                Console.WriteLine(Error001 + e);
            }

        }


        private void Map()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var classMaps = assembly
                .GetTypes()
                .Where(t => t.BaseType != null && t.BaseType.IsGenericType &&
                            t.BaseType.GetGenericTypeDefinition() == typeof(MongoDbClassMap<>));

            foreach (var classMap in classMaps)
                Activator.CreateInstance(classMap);
        }


        public IMongoCollection<DiarySettingsDTO> Settings
        {
            get
            {
                return database.GetCollection<DiarySettingsDTO>("Settings");
            }
        }

        public IMongoCollection<DiarySettingsPeriodDTO> PeriodSettings
        {
            get
            {
                return database.GetCollection<DiarySettingsPeriodDTO>("Settings");
            }
        }

        //public IMongoCollection<DiarySettingsDTO> Teste
        //{
        //    get
        //    {
        //        return database.GetCollection<DiarySettingsDTO>("Teste");
        //    }
        //}

    }
}
