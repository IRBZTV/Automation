using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web;

namespace BO
{
   
    public class Review_Comments
    {
       
        public int Review_Comments_Id { get; set; }

     
        public int Review_Comments_Review_Id { get; set; }

       
        public string Review_Comments_Text { get; set; }

    
        public int Review_Comments_User_Id { get; set; }

      
        public string Review_Comments_Datetime { get; set; }

     
        public int Review_Comments_TimeCode { get; set; }

     
        public string Review_Comments_Reply { get; set; }

        public string Review_Comments_Reply_Datetime { get; set; }

     
        public int Review_Comments_Reply_UserId { get; set; }
    }
}