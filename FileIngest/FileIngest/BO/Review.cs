using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BO
{
    [DataContract]
    public class Review
    {
        [DataMember]
        public int Review_Id { get; set; }


        [DataMember]
        public int Review_Media_Id { get; set; }


        [DataMember]
        public short Review_Approved { get; set; }


        [DataMember]
        public int Review_User_Id { get; set; }


        [DataMember]
        public DateTime Review_Datetime_Insert { get; set; }


        [DataMember]
        public DateTime Review_Datetime_Approve { get; set; }

    }
}

