using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DataService.DAL
{
    public class Programs
    {
        public static List<BO.Programs>  SelectByKind(short ProgramsKind)
        {
            List<BO.Programs> RetList = new List<BO.Programs>();


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"Select * from Programs where Programs_Kind=" + ProgramsKind.ToString() + " order by Programs_Title";
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

        public static BO.Programs SelectById(int Media_Id)
        {
            BO.Programs Obj = new BO.Programs();


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

                    Obj.Programs_Active = short.Parse(Dr["Programs_Active"].ToString());
                    Obj.Programs_Description = Dr["Programs_Description"].ToString();
                    Obj.Programs_Id = int.Parse(Dr["Programs_Id"].ToString());
                    Obj.Programs_Kind = short.Parse(Dr["Programs_Kind"].ToString());
                    Obj.Programs_Provider_Id = int.Parse(Dr["Programs_Provider_Id"].ToString());
                    Obj.Programs_SiteSync = short.Parse(Dr["Programs_SiteSync"].ToString());
                    Obj.Programs_Title = Dr["Programs_Title"].ToString();

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