using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataService.BLL
{
    public class Review_Comments
    {
        public static BO.Review_Comments Insert(BO.Review_Comments CmntObj)
        {
            return DAL.Review_Comments.Insert(CmntObj);
        }
        public static List<BO.Review_Comments> SelectByReviewId(int reviewId)
        {
            return DAL.Review_Comments.SelectByReviewId(reviewId);
        }
        public static BO.Review_Comments Update(BO.Review_Comments CmntObj)
        {
            return DAL.Review_Comments.Update(CmntObj);
        }
    }
}