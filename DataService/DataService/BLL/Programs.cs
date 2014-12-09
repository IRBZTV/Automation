using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataService.BLL
{
    public class Programs
    {
        public static List<BO.Programs> SelectByKind(short ProgramsKind)
        {
            return DAL.Programs.SelectByKind(ProgramsKind);
        }

        public static BO.Programs SelectById(int Media_Id)
        {
            return DAL.Programs.SelectById(Media_Id);
        }
    }
}