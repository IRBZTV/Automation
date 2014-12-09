using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DataService.DAL
{
    public class Media
    {
        public static List<BO.Programs> SelectByKind(int Media_Id)
        {
            List<BO.Programs> RetList = new List<BO.Programs>();


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"Select * from Media where Media_Id=" + Media_Id;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = new SqlConnection(WebConfigurationManager.AppSettings["MainConnectionString"].ToString());


            try
            {
                sqlCommand.Connection.Open();
                SqlDataReader Dr = sqlCommand.ExecuteReader();
                while (Dr.Read())
                {
                    BO.Programs Obj = new BO.Programs();
                    Obj.Programs_Active = short.Parse(Dr["Programs_Active"].ToString());
                    Obj.Programs_Description = Dr["Programs_Description"].ToString();
                    Obj.Programs_Id = int.Parse(Dr["Programs_Id"].ToString());
                    Obj.Programs_Kind = short.Parse(Dr["Programs_Kind"].ToString());
                    Obj.Programs_Provider_Id = int.Parse(Dr["Programs_Provider_Id"].ToString());
                    Obj.Programs_SiteSync = short.Parse(Dr["Programs_SiteSync"].ToString());
                    Obj.Programs_Title = Dr["Programs_Title"].ToString();
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


        public static BO.Media Insert(BO.Media MediaItem)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"INSERT INTO [dbo].[Media]
               ([Media_Title]
               ,[Media_Datetime_Insert]
               ,[Media_Description]
               ,[Media_Programs_Id]
               ,[Media_Session_Number]
               ,[Media_Duration]
               ,[Media_User_Id]
               ,[Media_Expire_Date]
               ,[Media_Description_Adver])
                   VALUES
                       (" +
                       "N'" + MediaItem.Media_Title + "'," +
                       "getdate()," +
                       "N'" + MediaItem.Media_Description + "'," +
                       "" + MediaItem.Media_Programs_Id + "," +
                       "" + MediaItem.Media_Session_Number + "," +
                       "" + MediaItem.Media_Duration + "," +
                       "" + MediaItem.Media_User_Id + "," +
                       "DATEADD(YEAR,2,getdate())," +
                       "N'" + MediaItem.Media_Description_Adver + "'" + ")  select @@identity";
           
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = new SqlConnection(WebConfigurationManager.AppSettings["MainConnectionString"].ToString());

            //try
            //{
            sqlCommand.Connection.Open();
            MediaItem.Media_Id = int.Parse(sqlCommand.ExecuteScalar().ToString());

            //}
            //catch (Exception ex)
            //{

            //}
            //finally
            //{
            sqlCommand.Connection.Close();
            sqlCommand.Dispose();
            // }
            return MediaItem;
        }


        public static BO.Media SelectById(int Media_Id)
        {
            BO.Media Obj = new BO.Media();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"Select * from Media where Media_Id=" + Media_Id;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = new SqlConnection(WebConfigurationManager.AppSettings["MainConnectionString"].ToString());


            try
            {
                sqlCommand.Connection.Open();
                SqlDataReader Dr = sqlCommand.ExecuteReader();
                while (Dr.Read())
                {

                    Obj.Media_Datetime_Insert = Dr["Media_Datetime_Insert"].ToString();
                    Obj.Media_Description = Dr["Media_Description"].ToString();
                    Obj.Media_Description_Adver = Dr["Media_Description_Adver"].ToString();
                    Obj.Media_Duration = int.Parse(Dr["Media_Duration"].ToString());
                    Obj.Media_Expire_Date = Dr["Media_Expire_Date"].ToString();
                    Obj.Media_Id = int.Parse(Dr["Media_Id"].ToString());
                    Obj.Media_Programs_Id =int.Parse(Dr["Media_Programs_Id"].ToString());

                    Obj.Media_Session_Number =int.Parse(Dr["Media_Session_Number"].ToString());
                    Obj.Media_Title = Dr["Media_Title"].ToString();
                    Obj.Media_User_Id = int.Parse(Dr["Media_User_Id"].ToString());
                
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
            return Obj;
        }

    }
}