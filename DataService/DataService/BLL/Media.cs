using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataService.BLL
{
    public class Media
    {
        public static BO.Media Insert(BO.Media MediaItem)
        {
            return DAL.Media.Insert(MediaItem);
        }
        public static BO.Media SelectById(int Media_Id)
        {
            return DAL.Media.SelectById(Media_Id);
        }
      
    }
}