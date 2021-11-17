using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GYF.Models
{
    public class Home
    {
        public string Fk_ParentId { get; set; }
        public string SponsorId { get; set; }
        public string LoginId { get; set; }
        public string Leg { get; set; }
        public string SponsorName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string RegistrationBy { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string Result { get; set; }
        public string MenuId { get; set; }
        public string Pk_AdminId { get; set; }
        public string UserType { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public List<Admin> lstProduct { get; set; }
        public List<Home> lstProject { get; set; }
        public string Icons { get; set; }
        public string SubMenuName { get; set; }
        public string SubMenuId { get; set; }
        public List<Home> lstMenu { get; set; }
        public List<Home> lstsubmenu { get; set; }
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
        public string PanNo { get; set; }
        public string AdharNo { get; set; }
        public string PackageId { get; set; }
        public string WalletBalance { get; set; }
        public string UserId { get; set; }
        public string AddedBy { get; set; }

        public string Name { get; set; }
        public string Subject { get; set; }
        public string Address { get; set; }
        public string AdminName { get; set; }
        public string Experience { get; set; }
        public string Image { get; set; }



        public DataSet Login()
        {
            SqlParameter[] param = { new SqlParameter("@LoginID",LoginId),
                                         new SqlParameter("@Password",Password),

            };
            DataSet ds = DBHelper.ExecuteQuery("Login", param);
            return ds;
        }
        public DataSet loadHeaderMenu()
        {
            SqlParameter[] para = {
                                new SqlParameter("@PK_AdminId", Pk_AdminId),
                                 new SqlParameter("@UserType", UserType)
            };

            DataSet ds = DBHelper.ExecuteQuery("GetMenuUserWise", para);
            return ds;
        }
        public static Home GetMenus(string Pk_AdminId, string UserType)
        {
            Home model = new Home();
            List<Home> lstmenu = new List<Home>();
            List<Home> lstsubmenu = new List<Home>();

            model.Pk_AdminId = Pk_AdminId;
            model.UserType = UserType;
            DataSet dsHeader = model.loadHeaderMenu();
            if (dsHeader != null && dsHeader.Tables.Count > 0)
            {
                if (dsHeader.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in dsHeader.Tables[0].Rows)
                    {
                        Home obj = new Home();

                        obj.MenuId = r["PK_FormTypeId"].ToString();
                        obj.MenuName = r["FormType"].ToString();
                        obj.Url = r["Url"].ToString();
                        obj.Icons = r["Icon"].ToString();
                        lstmenu.Add(obj);
                    }

                    model.lstMenu = lstmenu;
                    foreach (DataRow r in dsHeader.Tables[1].Rows)
                    {
                        Home obj = new Home();
                        obj.Url = r["Url"].ToString();
                        obj.MenuId = r["FK_FormTypeId"].ToString();
                        obj.SubMenuId = r["PK_FormId"].ToString();
                        obj.SubMenuName = r["FormName"].ToString();
                        lstsubmenu.Add(obj);
                    }

                    model.lstsubmenu = lstsubmenu;

                }


            }
            return model;

        }

        public DataSet Registration()
        {
            SqlParameter[] para = {

                                   new SqlParameter("@SponsorId",SponsorId),
                                   new SqlParameter("@EmailId",Email),
                                   new SqlParameter("@MobileNo",MobileNo),
                                   new SqlParameter("@FirstName",FirstName),
                                   new SqlParameter("@LastName",LastName),

                                    new SqlParameter("@RegisterBy",RegistrationBy),

                                     new SqlParameter("@PinCode",PinCode),

                                     new SqlParameter("@Password",Password),
                                     new SqlParameter("@PackageId",PackageId)
                                   };
            DataSet ds = DBHelper.ExecuteQuery("Registration", para);
            return ds;
        }
        public DataSet GetProductList()
        {
            DataSet ds = DBHelper.ExecuteQuery("ProductListNew");
            return ds;
        }

        public string Response { get; set; }

        public DataSet RegistrationNew()
        {
            SqlParameter[] para = {

                                   new SqlParameter("@SponsorId",SponsorId),
                                   new SqlParameter("@FirstName",FirstName),
                                   new SqlParameter("@LastName",LastName),
                                   new SqlParameter("@EmailId",Email),
                                   new SqlParameter("@MobileNo",MobileNo),
                                     new SqlParameter("@PinCode",PinCode),
                                       new SqlParameter("@Gender",Gender),
                                       new SqlParameter("@PanNo",PanNo),
                                       new SqlParameter("@AdharNo",AdharNo),
                                      new SqlParameter("@Password",Password),
                                      new SqlParameter("@Fk_ParentId",Fk_ParentId),
                                    new SqlParameter("@RegisterBy",RegistrationBy),
                                   };
            DataSet ds = DBHelper.ExecuteQuery("RegistrationNew", para);
            return ds;
        }
        public DataSet GetProduct()
        {
            DataSet ds = DBHelper.ExecuteQuery("GetProduct");
            return ds;
        }


        public DataSet WalletBalanceNew()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@UserId",UserId)
            };
            DataSet ds = DBHelper.ExecuteQuery("WalletBalance", para);
            return ds;
        }


        public DataSet SaveContact()
        {
            SqlParameter[] param = { new SqlParameter("@Name",Name),
                                         new SqlParameter("@Email",Email),
                                          new SqlParameter("@Subject",Subject),
                                           new SqlParameter("@Address",Address),
                                           new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("SaveContact", param);
            return ds;
        }

        public DataSet SaveCareer()
        {
            SqlParameter[] param = { new SqlParameter("@Name",Name),
                  new SqlParameter("@Mobile",MobileNo),
                                         new SqlParameter("@Email",Email),
                                          new SqlParameter("@Experience",Experience),
                                           new SqlParameter("@Resume",Image),
                                           new SqlParameter("@Address",Address),
                                           new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("SaveCareer", param);
            return ds;
        }
        public DataSet GetProjectDetails()
        {
            DataSet ds = DBHelper.ExecuteQuery("GetProjectDetails");
            return ds;
        }
        

    }
}