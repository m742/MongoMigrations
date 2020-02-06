using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MealSetting
    {
        public Dictionary<EMealType, bool> Items { get; private set; }

        public MealSetting()
        {
            Items = new Dictionary<EMealType, bool>();

            foreach (EMealType mealType in Enum.GetValues(typeof(EMealType)))
            {
                Items.Add(mealType, true);
            }
        }

        public MealSetting(Dictionary<EMealType, bool> items)
        {
            Items = items;
        }

        public void UpdateMealSetting(EMealType item, bool value)
        {
            if (Items.ContainsKey(item))
                Items[item] = value;
            else
                Items.Add(item, value);

        }
    }
}
