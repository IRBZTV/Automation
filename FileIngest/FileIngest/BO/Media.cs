using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BO
{

    [DataContract]
    public class Media
    {
        [DataMember]
        public int Media_Id { get; set; }


        [DataMember]
        public string Media_Title { get; set; }


        [DataMember]
        public DateTime Media_Datetime_Insert { get; set; }


        [DataMember]
        public string Media_Description { get; set; }


        [DataMember]
        public string Media_Description_Adver { get; set; }
        

        [DataMember]
        public int Media_Programs_Id { get; set; }


        [DataMember]
        public int Media_Session_Number { get; set; }


        [DataMember]
        public int Media_Duration { get; set; }

        [DataMember]
        public int Media_User_Id { get; set; }

        [DataMember]
        public DateTime Media_Expire_Date { get; set; }

    }
}

