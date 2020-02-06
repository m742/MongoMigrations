using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_Application.Models.MongoDbModels
{
    public class NapSettingPeriod
    {
        public Dictionary<EPeriodSettings, bool> Items { get; private set; }

        public NapSettingPeriod()
        {
            Items = new Dictionary<EPeriodSettings, bool>();

        }

        public NapSettingPeriod(EPeriodSettings item, bool value)
        {
            if (Items.ContainsKey(item))
                Items[item] = value;
            else
                Items.Add(item, value);
        }

        public NapSettingPeriod(Dictionary<EPeriodSettings, bool> items)
        {
            Items = items;
        }


        //public void UpdateMealSettingPeriod(EPeriodSettings item, bool value)
        //{
        //    if (Items.ContainsKey(item))
        //        Items[item] = value;
        //    else
        //        Items.Add(item, value);

        //}
    }
}
