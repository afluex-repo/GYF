using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace GYF.Models
{
    public class DashBoard:Common
    {
        public List<DashBoard> DashboardList { get; set; }
        public string LoginId { get; set; }
        public string Name { get; set; }
        public string JoiningDate { get; set; }
        public string Package { get; set; }
        public string Status { get; set; }
        public string PermanentDate { get; set; }
        public string pk_singlelegIncomeId { get; set; }
        public string Rank { get; set; }
        public string TargetTeam { get; set; }
        public string MyTeam { get; set; }
        public string DirectSponsor { get; set; }
        public string Amount { get; set; }
        public string ForDays { get; set; }
        public string SingleLegStatus { get; set; }
        public List<DashBoard> SingleLegDashboardList { get; set; }


        public DataSet GetDashboardDetails()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Fk_UserId",Fk_UserId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetUserDashBoardDetails", para);
            return ds;
        }

    }
}