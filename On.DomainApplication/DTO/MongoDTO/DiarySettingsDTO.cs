using Domain.Models;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    [BsonIgnoreExtraElements]
    public class DiarySettingsDTO
    {
        public DiarySettingsDTO(int school, bool isGuarianAllowedToSendMessage, bool showMyDayInfo, MealSetting mealSetting, NapSetting napSetting, bool showPoopInfo)
        {
            School = school;
            IsGuarianAllowedToSendMessage = isGuarianAllowedToSendMessage;
            ShowMyDayInfo = showMyDayInfo;
            MealSetting = mealSetting;
            NapSetting = napSetting;
            ShowPoopInfo = showPoopInfo;
        }

        public DiarySettingsDTO(int school, bool isGuarianAllowedToSendMessage, bool showMyDayInfo, bool showPoopInfo)
        {
            School = school;
            IsGuarianAllowedToSendMessage = isGuarianAllowedToSendMessage;
            ShowMyDayInfo = showMyDayInfo;
            MealSetting = new MealSetting();
            NapSetting = new NapSetting();
            ShowPoopInfo = showPoopInfo;
        }

        public string ID { get; set; }
        public int School { get; set; }
        public bool IsGuarianAllowedToSendMessage { get; set; }
        public bool ShowMyDayInfo { get; set; }
        public MealSetting MealSetting { get; set; }
        public NapSetting NapSetting { get; set; }
        public bool ShowPoopInfo { get; set; }

    }
}
