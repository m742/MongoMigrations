
using Domain.Enums;
using Domain.Models;
using Domain_Application.Models.MongoDbModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class DiarySettingsPeriodDTO
    {
        public DiarySettingsPeriodDTO()
        {
            MealSettingPeriods = new MealSettingPeriod();
            NapSettingPeriods = new NapSettingPeriod();
            MyDayPeriods = new MyDayPeriod();
            MyPopInfos = new MyPopInfo();
        }

        public DiarySettingsPeriodDTO(int school, bool isGuarianAllowedToSendMessage, MealSettingPeriod mealSetting, NapSettingPeriod napSetting, MyDayPeriod myDayPeriods, MyPopInfo myPopInfos)
        {
            School = school;
            IsGuarianAllowedToSendMessage = isGuarianAllowedToSendMessage;
            MealSettingPeriods = mealSetting;
            NapSettingPeriods = napSetting;
            MyDayPeriods = myDayPeriods;
            MyPopInfos = myPopInfos;
        }


        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public int School { get; set; }
        public bool IsGuarianAllowedToSendMessage { get; set; }
        public MealSettingPeriod MealSettingPeriods { get; set; }
        public NapSettingPeriod NapSettingPeriods { get; set; }
        public MyDayPeriod MyDayPeriods { get; set; }
        public MyPopInfo MyPopInfos { get; set; }




    }
}
