using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DataService.BO
{
    [DataContract]
    [Serializable]
    public class Review_Comments
    {
        [DataMember]
        public int Review_Comments_Id { get; set; }

        [DataMember]
        public int Review_Comments_Review_Id { get; set; }

        [DataMember]
        public string Review_Comments_Text { get; set; }

        [DataMember]
        public int Review_Comments_User_Id { get; set; }

        [DataMember]
        public string Review_Comments_Datetime { get; set; }

        [DataMember]
        public int Review_Comments_TimeCode { get; set; }

        [DataMember]
        public string Review_Comments_Reply { get; set; }

        [DataMember]
        public string Review_Comments_Reply_Datetime { get; set; }

        [DataMember]
        public int Review_Comments_Reply_UserId { get; set; }
    }
}