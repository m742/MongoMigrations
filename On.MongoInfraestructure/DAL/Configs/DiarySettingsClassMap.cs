using Domain.DTO;
using Domain.Enums;
using Domain_Application.Models.MongoDbModels;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace On.MongoMigrations.DAL.Configs
{
    public class DiarySettingsClassMap : MongoDbClassMap<DiarySettingsPeriodDTO>
    {
        public override void Map(BsonClassMap<DiarySettingsPeriodDTO> cm)
        {
            cm.AutoMap();
            cm.MapCreator(d => new DiarySettingsPeriodDTO(d.School, d.IsGuarianAllowedToSendMessage, d.MealSettingPeriods, d.NapSettingPeriods, d.MyDayPeriods, d.MyPopInfos));
            cm.SetIgnoreExtraElements(true);
            MapNestedObjects();
        }

        private static void MapNestedObjects()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(MealSettingPeriod)))
                BsonClassMap.RegisterClassMap<MealSettingPeriod>(cm =>
                {
                    cm.AutoMap();
                    cm.MapCreator(d => new MealSettingPeriod());
                    cm.MapMember(c => c.Items).SetSerializer(new DictionaryInterfaceImplementerSerializer<Dictionary<EMealTypePeriodSettings, bool>>(DictionaryRepresentation.ArrayOfDocuments));

                });
            if (!BsonClassMap.IsClassMapRegistered(typeof(NapSettingPeriod)))
                BsonClassMap.RegisterClassMap<NapSettingPeriod>(cm =>
                {
                    cm.AutoMap();
                    cm.MapCreator(d => new NapSettingPeriod());
                    cm.MapMember(c => c.Items).SetSerializer(new DictionaryInterfaceImplementerSerializer<Dictionary<EPeriodSettings, bool>>(DictionaryRepresentation.ArrayOfDocuments));

                });

            if (!BsonClassMap.IsClassMapRegistered(typeof(MyPopInfo)))
                BsonClassMap.RegisterClassMap<MyPopInfo>(cm =>
                {
                    cm.AutoMap();
                    cm.MapCreator(d => new MyPopInfo());
                    cm.MapMember(c => c.Items).SetSerializer(new DictionaryInterfaceImplementerSerializer<Dictionary<EMyPopSettings, bool>>(DictionaryRepresentation.ArrayOfDocuments));

                });
            if (!BsonClassMap.IsClassMapRegistered(typeof(MyDayPeriod)))
                BsonClassMap.RegisterClassMap<MyDayPeriod>(cm =>
                {
                    cm.AutoMap();
                    cm.MapCreator(d => new MyDayPeriod());
                    cm.MapMember(c => c.Items).SetSerializer(new DictionaryInterfaceImplementerSerializer<Dictionary<EMyDaySettings, bool>>(DictionaryRepresentation.ArrayOfDocuments));

                });
        }
    }
}
