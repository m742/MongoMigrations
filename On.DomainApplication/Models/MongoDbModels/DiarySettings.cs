using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class DiarySettings
    {
        public string ID { get; set; }
        public int School { get; set; }
        public bool IsGuarianAllowedToSendMessage { get; set; }
        public bool ShowMyDayInfo { get; set; }

        public bool ShowPoopInfo { get; set; }
    }
}
