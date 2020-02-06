using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class NapSetting
    {
        public Dictionary<EPeriod, bool> Items { get; private set; }

        public NapSetting()
        {
            Items = new Dictionary<EPeriod, bool>();

            foreach (EPeriod period in Enum.GetValues(typeof(EPeriod)))
            {
                Items.Add(period, true);
            }
        }

        public NapSetting(Dictionary<EPeriod, bool> items)
        {
            Items = items;
        }

        public void UpdateMealSetting(EPeriod item, bool value)
        {
            if (Items.ContainsKey(item))
                Items[item] = value;
            else
                Items.Add(item, value);

        }

    }
}
