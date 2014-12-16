using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BO
{
    public class Review
    {
        public int Review_Id { get; set; }


        public int Review_Media_Id { get; set; }


  
        public short Review_Approved { get; set; }


        public int Review_User_Id { get; set; }


  
        public DateTime Review_Datetime_Insert { get; set; }



        public DateTime Review_Datetime_Approve { get; set; }

    }
}

