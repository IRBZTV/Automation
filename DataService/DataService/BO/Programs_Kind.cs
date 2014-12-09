using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DataService.BO
{
    [DataContract]
    public class Programs_Kind
    {
       [DataMember]
        public short Programs_Kind_Id { get; set; }
        [DataMember]
        public string Programs_Kind_Title { get; set; }
        [DataMember]
        public short Programs_Kind_Active { get; set; }
    }
}