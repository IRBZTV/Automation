using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataService.BLL
{
    public class Programs_Kind
    {
        public static List<BO.Programs_Kind> Select()
        {
            return DAL.Programs_Kind.Select();
        }
    }
}