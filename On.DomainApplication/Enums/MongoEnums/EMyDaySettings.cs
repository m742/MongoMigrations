﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum EMyDaySettings
    {
        MyDayInfoMorning,
        MyDayInfoEvening,
        MyDayInfoIntegral
    }
}
