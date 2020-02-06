using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_Application.Models.MongoDbModels
{
    public class MyPopInfo
    {
        public Dictionary<EMyPopSettings, bool> Items { get; private set; }

        public MyPopInfo()
        {
            Items = new Dictionary<EMyPopSettings, bool>();
        }

        public MyPopInfo(EMyPopSettings item, bool value)
        {
            if (Items.ContainsKey(item))
                Items[item] = value;
            else
                Items.Add(item, value);
        }

        public MyPopInfo(Dictionary<EMyPopSettings, bool> items)
        {
            Items = items;
        }

        //public void UpdateMealSetting(EMyPopSettings item, bool value)
        //{
        //    if (Items.ContainsKey(item))
        //        Items[item] = value;
        //    else
        //        Items.Add(item, value);

        //}

    }
}
