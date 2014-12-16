using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BO
{

    public class Media
    {
     
        public int Media_Id { get; set; }


        public string Media_Title { get; set; }


     
        public DateTime Media_Datetime_Insert { get; set; }


        public string Media_Description { get; set; }


   
        public string Media_Description_Adver { get; set; }
        

       
        public int Media_Programs_Id { get; set; }


        public int Media_Session_Number { get; set; }


        public int Media_Duration { get; set; }

      
        public int Media_User_Id { get; set; }

       
        public DateTime Media_Expire_Date { get; set; }

    }
}

