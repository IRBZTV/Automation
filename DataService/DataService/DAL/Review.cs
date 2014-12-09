using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DataService.DAL
{
    public class Review
    {

        public static BO.Review Insert(BO.Review ReviewItem)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"INSERT INTO [dbo].[Review]
           ([Review_Media_Id]
           ,[Review_Approved]
           ,[Review_User_Id]
           ,[Review_Datetime_Insert]
           ,[Review_Datetime_Approve])
     VALUES
           (" +
             "" + ReviewItem.Review_Media_Id + "," +
             "" + ReviewItem.Review_Approved + "," +
              "" + ReviewItem.Review_User_Id + "," +
              "getdate()," + ReviewItem.Review_Approved + ")";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = new SqlConnection(WebConfigurationManager.AppSettings["MainConnectionString"].ToString());

            //try
            //{
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteScalar();

            //}
            //catch (Exception ex)
            //{

            //}
            //finally
            //{
            sqlCommand.Connection.Close();
            sqlCommand.Dispose();
            // }
            return ReviewItem;
        }
        public static List<BO.Review> SelectRejected(string IsApproved)
        {
            List<BO.Review> RetList = new List<BO.Review>();


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"Select * from review where Review_Approved=" + IsApproved + "  order by Review_Id desc";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = new SqlConnection(WebConfigurationManager.AppSettings["MainConnectionString"].ToString());

            try
            {
                sqlCommand.Connection.Open();
                SqlDataReader Dr = sqlCommand.ExecuteReader();
                while (Dr.Read())
                {
                    BO.Review Obj = new BO.Review();
                    Obj.Review_Approved = short.Parse(Dr["Review_Approved"].ToString());
                    Obj.Review_Datetime_Approve = Dr["Review_Datetime_Approve"].ToString();
                    Obj.Review_Datetime_Insert = Dr["Review_Datetime_Insert"].ToString();
                    Obj.Review_Id = int.Parse(Dr["Review_Id"].ToString());
                    Obj.Review_Media_Id = int.Parse(Dr["Review_Media_Id"].ToString());
                    Obj.Review_User_Id = int.Parse(Dr["Review_User_Id"].ToString());
                    RetList.Add(Obj);

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

                sqlCommand.Connection.Close();
                sqlCommand.Dispose();
            }
            return RetList;
        }
        public static List<BO.ReviewClient> SelectReviewList(string IsApproved)
        {

            List<BO.ReviewClient> RetList = new List<BO.ReviewClient>();


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"SELECT        Media.Media_Id, Media.Media_Title, Media.Media_Datetime_Insert, Media.Media_Description, Media.Media_Programs_Id, Media.Media_Session_Number, 
                         Media.Media_Duration, Media.Media_User_Id, Media.Media_Expire_Date, Media.Media_Description_Adver, Review.Review_Id, Review.Review_Media_Id, 
                         Review.Review_Approved, Review.Review_User_Id, Review.Review_Datetime_Insert, Review.Review_Datetime_Approve, Programs.Programs_Id, 
                         Programs.Programs_Title, Programs.Programs_Description, Programs.Programs_Provider_Id, Programs.Programs_Active, Programs.Programs_SiteSync, 
                         Programs_Kind.Programs_Kind_Id, Programs_Kind.Programs_Kind_Title, Programs_Kind.Programs_Kind_Active
                         FROM            Media INNER JOIN
                         Review ON Media.Media_Id = Review.Review_Media_Id INNER JOIN
                         Programs ON Media.Media_Programs_Id = Programs.Programs_Id INNER JOIN
                         Programs_Kind ON Programs.Programs_Kind = Programs_Kind.Programs_Kind_Id
                          where Review.Review_Approved=" + IsApproved + "   ";

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = new SqlConnection(WebConfigurationManager.AppSettings["MainConnectionString"].ToString());

            try
            {
                sqlCommand.Connection.Open();
                SqlDataReader Dr = sqlCommand.ExecuteReader();
                while (Dr.Read())
                {
                    BO.ReviewClient Obj = new BO.ReviewClient();
                    Obj.Media_Duration = int.Parse(Dr["Media_Duration"].ToString());
                    Obj.Media_Session_Number = int.Parse(Dr["Media_Session_Number"].ToString());
                    Obj.Media_Title = Dr["Media_Title"].ToString();
                    Obj.Programs_Kind_Title = Dr["Programs_Kind_Title"].ToString();
                    Obj.Programs_Title = Dr["Programs_Title"].ToString();
                    Obj.Review_Datetime_Insert = Dr["Review_Datetime_Insert"].ToString();
                    Obj.Review_Id = int.Parse(Dr["Review_Id"].ToString());
                    Obj.Media_Datetime_Insert = Dr["Media_Datetime_Insert"].ToString();
                    Obj.Media_Id = int.Parse(Dr["Media_Id"].ToString());
                                        
                    RetList.Add(Obj);

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

                sqlCommand.Connection.Close();
                sqlCommand.Dispose();
            }
            return RetList;

        }

        public static void updateStatus(int reviewId,int status)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"update  [dbo].[Review] set Review_Approved=" + status + " where Review_Id=" + reviewId;
           
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = new SqlConnection(WebConfigurationManager.AppSettings["MainConnectionString"].ToString());

           
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();

            sqlCommand.Connection.Close();
            sqlCommand.Dispose();
          
        }


    }
}