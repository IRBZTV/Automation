using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DataService.BO
{
    [DataContract]
    public class ReviewClient
    {
        [DataMember]
        public int Review_Id { get; set; }
        [DataMember]
        public string Review_Datetime_Insert { get; set; }

        [DataMember]
        public string Programs_Title { get; set; }

        [DataMember]
        public string Media_Title { get; set; }

        [DataMember]
        public int Media_Session_Number { get; set; }

        [DataMember]
        public int Media_Duration { get; set; }

        [DataMember]
        public string Programs_Kind_Title { get; set; }

        [DataMember]
        public string FilePath { get; set; }

        [DataMember]
        public string Media_Datetime_Insert { get; set; }
        [DataMember]
        public int Media_Id { get; set; }

    }
}