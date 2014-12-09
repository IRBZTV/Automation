using System;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.Web;

namespace BO
{
    
    public class Programs
    {
     
        public int Programs_Id { get; set; }


        
        public string Programs_Title { get; set; }


     
        public string Programs_Description { get; set; }


       
        public int Programs_Provider_Id { get; set; }


        public short Programs_Active { get; set; }


       
        public short Programs_Kind { get; set; }


       
        public short Programs_SiteSync { get; set; }

    }
}