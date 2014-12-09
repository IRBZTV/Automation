using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DataService.PL
{
    [ServiceContract]
    public interface IDBSrv
    {

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Programs_Kind/List")]
        List<BO.Programs_Kind> Programs_Kind_List();



        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Programs/Kind/{Kind}")]
        List<BO.Programs> Programs_List_ByKind(string Kind);


        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Media/insert")]
        BO.Media Media_Insert(Stream Data);



        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Review/Insert")]
        bool Review_Insert(Stream Data);




        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Review/List/Rejected/{IsApproved}")]
        List<BO.Review> Review_Select(string IsApproved);



        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Programs/{ID}")]
        BO.Programs Programs_SelectById(string ID);



        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Review/List/{Approved}")]
        List<BO.ReviewClient> SelectReviewList(string Approved);


        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Review/Comment/Insert")]
        BO.Review_Comments Review_Comments_Insert(Stream Data);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Review/Comment/List/{revId}")]
        List<BO.Review_Comments> Review_Comments_List(string revId);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Review/update/status/{status}/{revId}")]
        void Review_Update_Status(string revId, string status);


        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Review/Comment/Update")]
        BO.Review_Comments Review_Comments_Update(Stream Data);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Media/{mediaId}")]
        BO.Media Media_SelectById(string mediaId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Review/Comment/copy/{revIdSrc}/{revIdDest}")]
        void Review_Comments_Copy(string revIdSrc, string revIdDest);
    }
}
