using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DataService.DAL
{
    public class Review_Comments
    {
        public static BO.Review_Comments Insert(BO.Review_Comments CmntObj)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"INSERT INTO Review_Comments
               (Review_Comments_Review_Id
               ,Review_Comments_Text
               ,Review_Comments_User_Id
               ,Review_Comments_TimeCode
              )
                   VALUES
                       (" + CmntObj.Review_Comments_Review_Id +
                         ",N'" + CmntObj.Review_Comments_Text +
                         "'," + CmntObj.Review_Comments_User_Id +
                         "," + CmntObj.Review_Comments_TimeCode + ")";

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
            return CmntObj;
        }

        public static List<BO.Review_Comments> SelectByReviewId(int reviewId)
        {
            List<BO.Review_Comments> RetList = new List<BO.Review_Comments>();


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"Select * from Review_Comments where Review_Comments_Review_Id=" + reviewId + "  order by Review_Comments_Datetime desc";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = new SqlConnection(WebConfigurationManager.AppSettings["MainConnectionString"].ToString());

            try
            {
                sqlCommand.Connection.Open();
                SqlDataReader Dr = sqlCommand.ExecuteReader();
                while (Dr.Read())
                {
                    BO.Review_Comments Obj = new BO.Review_Comments();

                    Obj.Review_Comments_Datetime = Dr["Review_Comments_Datetime"].ToString();
                    Obj.Review_Comments_Id = int.Parse(Dr["Review_Comments_Id"].ToString());
                    Obj.Review_Comments_Review_Id = int.Parse(Dr["Review_Comments_Review_Id"].ToString());
                    Obj.Review_Comments_Text = Dr["Review_Comments_Text"].ToString();
                    Obj.Review_Comments_TimeCode = int.Parse(Dr["Review_Comments_TimeCode"].ToString());
                    Obj.Review_Comments_User_Id = int.Parse(Dr["Review_Comments_User_Id"].ToString());
                    Obj.Review_Comments_Reply = Dr["Review_Comments_Reply"].ToString();
                    Obj.Review_Comments_Reply_Datetime = Dr["Review_Comments_Reply_Datetime"].ToString();
                    Obj.Review_Comments_Reply_UserId = int.Parse(Dr["Review_Comments_Reply_UserId"].ToString());

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


        public static BO.Review_Comments Update(BO.Review_Comments CmntObj)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"Update Review_Comments  set
               Review_Comments_Reply=N'" + CmntObj.Review_Comments_Reply + "' , Review_Comments_Reply_Datetime=getdate() , Review_Comments_Reply_UserId=" + CmntObj.Review_Comments_Reply_UserId + " where Review_Comments_Id=" + CmntObj.Review_Comments_Id;

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = new SqlConnection(WebConfigurationManager.AppSettings["MainConnectionString"].ToString());

            sqlCommand.Connection.Open();
            sqlCommand.ExecuteScalar();
            sqlCommand.Connection.Close();
            sqlCommand.Dispose();

            return CmntObj;
        }
    }
}