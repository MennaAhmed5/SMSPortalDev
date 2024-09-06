using SMSPortal.DAL.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Types;

namespace SMSPortal.BL.ViewModels.Reports
{
    public class ReportEditVM
    {
        public int Id { get; set; }
        public string SenderUsername { get; set; }

        public string PhoneNumber { get; set; }

        public string MessageContent { get; set; }
 
        public Status Status { get; set; }

        public string Details { get; set; }


        public ReportEditVM(int id, string senderUsername, string phoneNumber, string messageContent,  Status status, string details)
        {
            Id = id;
            SenderUsername = senderUsername;
            PhoneNumber = phoneNumber;
            MessageContent = messageContent;            
            Status = status;
            Details = details;

        }
    }
}
