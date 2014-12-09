using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web;


namespace BO
{

    public class ReviewClient
    {

        public int Review_Id { get; set; }

        public string Review_Datetime_Insert { get; set; }


        public string Programs_Title { get; set; }



        public string Media_Title { get; set; }


        public int Media_Session_Number { get; set; }


        public int Media_Duration { get; set; }


        public string Programs_Kind_Title { get; set; }


        public string FilePath { get; set; }

        public string Media_Datetime_Insert { get; set; }

        public int Media_Id { get; set; }


    }
}