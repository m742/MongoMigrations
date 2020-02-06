using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_Application.Models.MongoDbModels
{
    public class MealSettingPeriod
    {
        public Dictionary<EMealTypePeriodSettings, bool> Items { get; set; }

        public MealSettingPeriod()
        {
            Items = new Dictionary<EMealTypePeriodSettings, bool>();

        }

        public MealSettingPeriod(EMealTypePeriodSettings item, bool value)
        {
            if (Items.ContainsKey(item))
                Items[item] = value;
            else
                Items.Add(item, value);
        }

        public MealSettingPeriod(Dictionary<EMealTypePeriodSettings, bool> items)
        {
            Items = items;
        }

        //public void UpdateMealSetting(EMealTypePeriodSettings item, bool value)
        //{
        //    if (Items.ContainsKey(item))
        //        Items[item] = value;
        //    else
        //        Items.Add(item, value);

        //}


    }
}
