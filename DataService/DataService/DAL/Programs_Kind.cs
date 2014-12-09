using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DataService.DAL
{
    public class Programs_Kind
    {
        public static List<BO.Programs_Kind>  Select()
        {
            List<BO.Programs_Kind> RetList = new List<BO.Programs_Kind>();


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"Select * from Programs_kind order by Programs_Kind_Title";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = new SqlConnection(WebConfigurationManager.AppSettings["MainConnectionString"].ToString());

            try
            {
                sqlCommand.Connection.Open();
                SqlDataReader Dr = sqlCommand.ExecuteReader();
                while (Dr.Read())
                {
                    BO.Programs_Kind Obj = new BO.Programs_Kind();
                    Obj.Programs_Kind_Id = short.Parse(Dr["Programs_Kind_Id"].ToString());
                    Obj.Programs_Kind_Title = Dr["Programs_Kind_Title"].ToString();
                    Obj.Programs_Kind_Active = short.Parse(Dr["Programs_Kind_Active"].ToString());
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
    }
}