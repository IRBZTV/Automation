using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BO
{
    [DataContract]
    public class Programs
    {
        [DataMember]
        public int Programs_Id { get; set; }


        [DataMember]
        public string Programs_Title { get; set; }


        [DataMember]
        public string Programs_Description { get; set; }


        [DataMember]
        public int Programs_Provider_Id { get; set; }


        [DataMember]
        public short Programs_Active { get; set; }


        [DataMember]
        public short Programs_Kind { get; set; }


        [DataMember]
        public short Programs_SiteSync { get; set; }

    }
}