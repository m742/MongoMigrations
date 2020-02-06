using Domain.DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using On.MongoMigrations.DAL.MongoDataManager.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace On.MongoMigrations.DAL
{
    public class SettingsRepository 
    {

        public MongoContext mongoContext = new MongoContext();

        public async Task<DiarySettingsDTO> GetBySchool(int schoolId)
        {
            var filter = Builders<DiarySettingsDTO>.Filter.Eq("School", schoolId);
            var filterDefault = Builders<DiarySettingsDTO>.Filter.Eq("School", 0);

            var settings = mongoContext.Settings.Find(filter).SingleOrDefault();
            

            return settings;
        }

        public async Task Upsert(DiarySettingsDTO settings)
        {
            var options = new UpdateOptions { IsUpsert = true };

            await mongoContext.Settings.ReplaceOneAsync(d => d.School == settings.School, settings, options);

        }

        public IList<DiarySettingsDTO> FindAll()
        {
            var list =  mongoContext.Settings.Find(new BsonDocument()).ToList();
            
            return list;
        }

        public void InsertOne(DiarySettingsPeriodDTO diary)
        {
            //mongoContext.TestePeriod.InsertOne(diary);
            mongoContext.PeriodSettings.InsertOne(diary);
        }

        public void DeletedAll(IEnumerable<int> teste)
        {
            var filter = Builders<DiarySettingsDTO>.Filter.In(d => d.School, teste);
            var result = mongoContext.Settings.DeleteMany(filter);
        }


        //public IList<DiarySettingsDTO> FindAllTeste()
        //{
        //    var list = mongoContext.Teste.Find(new BsonDocument()).ToList();
        //    return list;
        //}


        //public void DeletedAllTeste(IEnumerable<int> teste)
        //{
        //    var filter = Builders<DiarySettingsDTO>.Filter.In(d => d.School, teste);
        //    var result = mongoContext.Teste.DeleteMany(filter);
        //}








    }
}
