using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_Application.Models.MongoDbModels
{
    public class MyDayPeriod
    {
        public Dictionary<EMyDaySettings, bool> Items { get; private set; }

        public MyDayPeriod()
        {
            Items = new Dictionary<EMyDaySettings, bool>();
        }

        public MyDayPeriod(EMyDaySettings item, bool value)
        {
            if (Items.ContainsKey(item))
                Items[item] = value;
            else
                Items.Add(item, value);
        }


        public MyDayPeriod(Dictionary<EMyDaySettings, bool> items)
        {
            Items = items;
        }


        //public void UpdateMealSetting(EMyDaySettings item, bool value)
        //{
        //    if (Items.ContainsKey(item))
        //        Items[item] = value;
        //    else
        //        Items.Add(item, value);

        //}
    }
}
