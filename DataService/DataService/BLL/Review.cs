using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataService.BLL
{
    public class Review
    {
        public static BO.Review Insert(BO.Review ReviewItem)
        {
            return DAL.Review.Insert(ReviewItem);
        }
        public static List<BO.Review> SelectRejected(string IsApproved)
        {
            return DAL.Review.SelectRejected(IsApproved);
        }
        public static List<BO.ReviewClient> SelectReviewList(string IsApproved)
        {
            return DAL.Review.SelectReviewList(IsApproved);
        }
        public static void updateStatus(int reviewId, int status)
        {
            DAL.Review.updateStatus(reviewId, status);
        }
    }

}