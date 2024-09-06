
using SMSPortal.DAL.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SMSPortal.DAL.Data.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string SenderUsername { get; set; }

        public string PhoneNumber { get; set; }

        public string MessageContent { get; set; }

        public DateTime SendingDate { get; set; }

        public Status  Status { get; set; }

        public string Details { get; set; }
    }
}
