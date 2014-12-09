using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace DataService.PL
{
    public class DBSrv : IDBSrv
    {
        public List<BO.Programs_Kind> Programs_Kind_List()
        {
            return BLL.Programs_Kind.Select();
        }

        public List<BO.Programs> Programs_List_ByKind(string Kind)
        {
            return BLL.Programs.SelectByKind(short.Parse(Kind));
        }

        public BO.Media Media_Insert(Stream Data)
        {
            string body = new StreamReader(Data).ReadToEnd();
            NameValueCollection nvc = HttpUtility.ParseQueryString(body);

            BO.Media Md = new BO.Media() { Media_Datetime_Insert = DateTime.Now.ToString(), Media_Expire_Date = DateTime.Now.AddYears(2).ToString() };

            Md.Media_Description = nvc["Media_Description"].ToString();
            Md.Media_Description_Adver = nvc["Media_Description_Adver"].ToString();
            Md.Media_Duration = int.Parse(nvc["Media_Duration"].ToString());
            Md.Media_Programs_Id = int.Parse(nvc["Media_Programs_Id"].ToString());
            Md.Media_Session_Number = int.Parse(nvc["Media_Session_Number"].ToString());
            Md.Media_Title = nvc["Media_Title"].ToString();
            Md.Media_User_Id = int.Parse(nvc["Media_User_Id"].ToString());

            Md = BLL.Media.Insert(Md);
            return Md;
        }

        public bool Review_Insert(Stream Data)
        {
            //Review_Approved
            //0=new
            //1=pass
            //2=rejected
            //3=

            string body = new StreamReader(Data).ReadToEnd();
            NameValueCollection nvc = HttpUtility.ParseQueryString(body);

            BO.Review Md = new BO.Review() { };

            Md.Review_Media_Id = int.Parse(nvc["Review_Media_Id"].ToString());
            Md.Review_User_Id = 0;
            Md.Review_Approved = 0;

            Md = BLL.Review.Insert(Md);
            //return Md;
            return true;
        }

        public List<BO.ReviewClient> SelectReviewList(string IsApproved)
        {
            List<BO.ReviewClient> Lst = BLL.Review.SelectReviewList(IsApproved);
            foreach (BO.ReviewClient item in Lst)
            {
                item.FilePath = @"c:\files\tmp\Automation\" + DateTime.Parse(item.Media_Datetime_Insert).ToString("yyyy-MM-dd") + @"\" + item.Media_Id + ".mp4";
            }
            return Lst;
        }

        public BO.Programs Programs_SelectById(string ID)
        {
            return BLL.Programs.SelectById(int.Parse(ID));
        }

        public BO.Review_Comments Review_Comments_Insert(Stream Data)
        {
            string body = new StreamReader(Data).ReadToEnd();
            NameValueCollection nvc = HttpUtility.ParseQueryString(body);

            BO.Review_Comments Rc = new BO.Review_Comments() { };

            Rc.Review_Comments_Review_Id = int.Parse(nvc["Review_Comments_Review_Id"].ToString());
            Rc.Review_Comments_Text = nvc["Review_Comments_Text"].ToString();
            Rc.Review_Comments_TimeCode = int.Parse(nvc["Review_Comments_TimeCode"].ToString());
            Rc.Review_Comments_User_Id = int.Parse(nvc["Review_Comments_User_Id"].ToString());

            Rc = BLL.Review_Comments.Insert(Rc);

            return Rc;
        }

        public List<BO.Review_Comments> Review_Comments_List(string revId)
        {
            return BLL.Review_Comments.SelectByReviewId(int.Parse(revId));
        }

        public void Review_Update_Status(string revId, string status)
        {
            BLL.Review.updateStatus(int.Parse(revId), int.Parse(status));
        }

        public List<BO.Review> Review_Select(string IsApproved)
        {
            return DAL.Review.SelectRejected(IsApproved);
        }

        public BO.Review_Comments Review_Comments_Update(Stream Data)
        {
            string body = new StreamReader(Data).ReadToEnd();
            NameValueCollection nvc = HttpUtility.ParseQueryString(body);

            BO.Review_Comments Rc = new BO.Review_Comments() { };

            Rc.Review_Comments_Id = int.Parse(nvc["Review_Comments_Id"].ToString());
            Rc.Review_Comments_Reply = nvc["Review_Comments_Reply"].ToString();
            //Rc.Review_Comments_Reply_Datetime = nvc["Review_Comments_Reply_Datetime"].ToString();
            Rc.Review_Comments_Reply_UserId = int.Parse(nvc["Review_Comments_Reply_UserId"].ToString());

            Rc = BLL.Review_Comments.Update(Rc);

            return Rc;
        }
        public BO.Media Media_SelectById(string mediaId)
        {
            return BLL.Media.SelectById(int.Parse(mediaId));
        }
        public void Review_Comments_Copy(string revIdSrc, string revIdDest)
        {
            List<BO.Review_Comments> oldReviewComments = BLL.Review_Comments.SelectByReviewId(int.Parse(revIdSrc));

            foreach (BO.Review_Comments item in oldReviewComments)
            {
                item.Review_Comments_Review_Id = int.Parse(revIdDest);
                BLL.Review_Comments.Insert(item);
            }
        }
    }
}