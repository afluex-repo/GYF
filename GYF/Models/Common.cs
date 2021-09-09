using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GYF.Models
{
    public class Common
    {
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string ReferBy { get; set; }
        public string Result { get; set; }
        public string DisplayName { get; set; }
        public string AddedOn { get; set; }
        public static string GenerateRandom()
        {
            Random r = new Random();
            string s = "";
            for (int i = 0; i < 6; i++)
            {
                s = string.Concat(s, r.Next(10).ToString());
            }
            return s;
        }
        public static string ConvertToSystemDate(string InputDate, string InputFormat)
        {
            string DateString = "";
            DateTime Dt;

            string[] DatePart = (InputDate).Split(new string[] { "-", @"/" }, StringSplitOptions.None);

            if (InputFormat == "dd-MMM-yyyy" || InputFormat == "dd/MMM/yyyy" || InputFormat == "dd/MM/yyyy" || InputFormat == "dd-MM-yyyy" || InputFormat == "DD/MM/YYYY" || InputFormat == "dd/mm/yyyy")
            {
                string Day = DatePart[0];
                string Month = DatePart[1];
                string Year = DatePart[2];

                if (Month.Length > 2)
                    DateString = InputDate;
                else
                    DateString = Month + "/" + Day + "/" + Year;
            }
            else if (InputFormat == "MM/dd/yyyy" || InputFormat == "MM-dd-yyyy")
            {
                DateString = InputDate;
            }
            else
            {
                throw new Exception("Invalid Date");
            }

            try
            {
                //Dt = DateTime.Parse(DateString);
                //return Dt.ToString("MM/dd/yyyy");
                return DateString;
            }
            catch
            {
                throw new Exception("Invalid Date");
            }

        }
        public DataSet BindUserTypeForRegistration()
        {

            DataSet ds = DBHelper.ExecuteQuery("GetUserTypeForRegistration");

            return ds;

        }
        public DataSet BindFormMaster()
        {
            SqlParameter[] para = { new SqlParameter("@Parameter", 4) };
            DataSet ds = DBHelper.ExecuteQuery("FormMasterManage", para);

            return ds;

        }
        public DataSet BindFormTypeMaster()
        {
            SqlParameter[] para = { new SqlParameter("@Parameter", 4) };
            DataSet ds = DBHelper.ExecuteQuery("FormTypeMasterManage", para);

            return ds;

        }
        #region Form Permissions By User
        public DataSet FormPermissions(string FormName, string AdminId)
        {
            try
            {
                SqlParameter[] para = {
                                          new SqlParameter("@FormName", FormName) ,
                                          new SqlParameter("@AdminId", AdminId) 
                                      };

                DataSet ds = DBHelper.ExecuteQuery("PermissionsOfForm", para);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        public DataSet GetMemberDetails()
        {
            SqlParameter[] para = { 
                                      new SqlParameter("@LoginId", ReferBy),
                                    
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetUserName", para);

            return ds;
        }
        public DataSet GetMemberDetailsForSale()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", ReferBy), };
            DataSet ds = DBHelper.ExecuteQuery("GetMemberNameForSale", para);
            return ds;
        }
        public DataSet GetMemberDetailsForFranchiseSale()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", ReferBy), };
            DataSet ds = DBHelper.ExecuteQuery("GetMemberDetailsForFranchiseSale", para);
            return ds;
        }
        public DataSet BindProduct()
        {
            DataSet ds = DBHelper.ExecuteQuery("GetProductList");
            return ds;
        }

        public DataSet BindProductForFranchisee()
        {
            DataSet ds = DBHelper.ExecuteQuery("GetProductListForFranchisee");
            return ds;
        }
        public DataSet BindFranchiseType()
        {
            DataSet ds = DBHelper.ExecuteQuery("GetFranchiseType");
            return ds;
        }
        public static List<SelectListItem> BindPaymentMode()
        {
            List<SelectListItem> PaymentMode = new List<SelectListItem>();
            PaymentMode.Add(new SelectListItem { Text = "Select Payment Mode", Value = "0" });
            PaymentMode.Add(new SelectListItem { Text = "Cash", Value = "Cash" });
            PaymentMode.Add(new SelectListItem { Text = "Cheque", Value = "Cheque" });
            PaymentMode.Add(new SelectListItem { Text = "NEFT", Value = "NEFT" });
            PaymentMode.Add(new SelectListItem { Text = "RTGS", Value = "RTGS" });
            PaymentMode.Add(new SelectListItem { Text = "Demand Draft", Value = "DD" });
            return PaymentMode;
        }
        public static List<SelectListItem> BindPaymentModeForList()
        {
            List<SelectListItem> PaymentMode = new List<SelectListItem>();
            PaymentMode.Add(new SelectListItem { Text = "All", Value = null  });
            PaymentMode.Add(new SelectListItem { Text = "Cash", Value = "Cash" });
            PaymentMode.Add(new SelectListItem { Text = "Supplier", Value = "Supplier" });
          
            
            return PaymentMode;
        }
        
        public static List<SelectListItem> BindGender()
        {
            List<SelectListItem> Gender = new List<SelectListItem>();
            Gender.Add(new SelectListItem { Text = "Male", Value = "M" });
            Gender.Add(new SelectListItem { Text = "Female", Value = "F" });
           
            return Gender;
        }
        public static List<SelectListItem> BindPasswordType()
        {
            List<SelectListItem> PasswordType = new List<SelectListItem>();
            PasswordType.Add(new SelectListItem { Text = "Select", Value = "0" });
            PasswordType.Add(new SelectListItem { Text = "Profile Password", Value = "P" });
            PasswordType.Add(new SelectListItem { Text = "Transaction Password", Value = "T" });

            return PasswordType;
        }
        public static List<SelectListItem> TransactionType()
        {
            List<SelectListItem> TransactionType = new List<SelectListItem>();
            TransactionType.Add(new SelectListItem { Text = "Select", Value = "0" });
            TransactionType.Add(new SelectListItem { Text = "Credit", Value = "Credit" });
            TransactionType.Add(new SelectListItem { Text = "Debit", Value = "Debit" });

            return TransactionType;
        }
        public static List<SelectListItem> BindKYCStatus()
        {
            List<SelectListItem> PasswordType = new List<SelectListItem>();
            PasswordType.Add(new SelectListItem { Text = "Select", Value = "0" });
            PasswordType.Add(new SelectListItem { Text = "Not Uploaded", Value = "N" });
            PasswordType.Add(new SelectListItem { Text = "Pending", Value = "P" });
            PasswordType.Add(new SelectListItem { Text = "Approved", Value = "A" });

            return PasswordType;
        }
        public static List<SelectListItem> AssociateStatus()
        {
            List<SelectListItem> AssociateStatus = new List<SelectListItem>();
            AssociateStatus.Add(new SelectListItem { Text = "All", Value = null });
            AssociateStatus.Add(new SelectListItem { Text = "Active", Value = "P" });
            AssociateStatus.Add(new SelectListItem { Text = "Inactive", Value = "T" });

            return AssociateStatus;
        }
        public static List<SelectListItem> Leg()
        {
            List<SelectListItem> Leg = new List<SelectListItem>();
            Leg.Add(new SelectListItem { Text = "All", Value = null });
            Leg.Add(new SelectListItem { Text = "Left", Value = "L" });
            Leg.Add(new SelectListItem { Text = "Right", Value = "R" });

            return Leg;
        }
        public static List<SelectListItem> BindTopupStatus()
        {
            List<SelectListItem> IncomeStatus = new List<SelectListItem>();
            IncomeStatus.Add(new SelectListItem { Text = "All", Value = null });
            IncomeStatus.Add(new SelectListItem { Text = "Calculated", Value = "1" });
            IncomeStatus.Add(new SelectListItem { Text = "Pending", Value = "0" });

            return IncomeStatus;
        }
        public static List<SelectListItem> BindRealation()
        {
            List<SelectListItem> PaymentMode = new List<SelectListItem>();
            PaymentMode.Add(new SelectListItem { Text = "S/O", Value = "S/O" });
            PaymentMode.Add(new SelectListItem { Text = "D/O", Value = "D/O" });
            PaymentMode.Add(new SelectListItem { Text = "W/O", Value = "W/O" });
           
            return PaymentMode;
        }
        public static List<SelectListItem> PaidStatus()
        {
            List<SelectListItem> PaidStatus = new List<SelectListItem>();
            PaidStatus.Add(new SelectListItem { Text = "All", Value = "null" });
            PaidStatus.Add(new SelectListItem { Text = "Paid", Value = "1" });
            PaidStatus.Add(new SelectListItem { Text = "Unpaid", Value = "0" });

            return PaidStatus;
        }

        public static List<SelectListItem> GetStatus()
        {
            List<SelectListItem> ddlStatus = new List<SelectListItem>();
            ddlStatus.Add(new SelectListItem { Text = "All", Value = null });
            ddlStatus.Add(new SelectListItem { Text = "Used", Value = "Used" });
            ddlStatus.Add(new SelectListItem { Text = "UnUsed", Value = "UnUsed" });

            return ddlStatus;
        }

        public static List<SelectListItem> GetLevel()
        {
            List<SelectListItem> ddlLevel = new List<SelectListItem>();
            ddlLevel.Add(new SelectListItem { Text = "Select Level", Value = null });
            ddlLevel.Add(new SelectListItem { Text = "Level-1", Value = "1" });
            ddlLevel.Add(new SelectListItem { Text = "Level-2", Value = "2" });
            ddlLevel.Add(new SelectListItem { Text = "Level-3", Value = "3" });
            ddlLevel.Add(new SelectListItem { Text = "Level-4", Value = "4" });
            ddlLevel.Add(new SelectListItem { Text = "Level-5", Value = "5" });
            ddlLevel.Add(new SelectListItem { Text = "Level-6", Value = "6" });
            ddlLevel.Add(new SelectListItem { Text = "Level-7", Value = "7" });
            ddlLevel.Add(new SelectListItem { Text = "Level-8", Value = "8" });
            ddlLevel.Add(new SelectListItem { Text = "Level-9", Value = "9" });
            ddlLevel.Add(new SelectListItem { Text = "Level-10", Value = "10" });
            ddlLevel.Add(new SelectListItem { Text = "Level-11", Value = "11" });
            ddlLevel.Add(new SelectListItem { Text = "Level-12", Value = "12" });
            ddlLevel.Add(new SelectListItem { Text = "Level-13", Value = "13" });
            ddlLevel.Add(new SelectListItem { Text = "Level-14", Value = "14" });
            ddlLevel.Add(new SelectListItem { Text = "Level-15", Value = "15" });
            ddlLevel.Add(new SelectListItem { Text = "Level-16", Value = "16" });
            ddlLevel.Add(new SelectListItem { Text = "Level-17", Value = "17" });
            ddlLevel.Add(new SelectListItem { Text = "Level-18", Value = "18" });
            ddlLevel.Add(new SelectListItem { Text = "Level-19", Value = "19" });
            ddlLevel.Add(new SelectListItem { Text = "Level-20", Value = "20" });
            ddlLevel.Add(new SelectListItem { Text = "Level-21", Value = "21" });
            

            return ddlLevel;
        }

        public static List<SelectListItem> GetAutoPool()
        {
            List<SelectListItem> ddlStep = new List<SelectListItem>();
            ddlStep.Add(new SelectListItem { Text = "Select Step", Value = null });
            ddlStep.Add(new SelectListItem { Text = "Step-1", Value = "1" });
            ddlStep.Add(new SelectListItem { Text = "Step-2", Value = "2" });
            ddlStep.Add(new SelectListItem { Text = "Step-3", Value = "3" });
            ddlStep.Add(new SelectListItem { Text = "Step-4", Value = "4" });
            ddlStep.Add(new SelectListItem { Text = "Step-5", Value = "5" });
            ddlStep.Add(new SelectListItem { Text = "Step-6", Value = "6" });
            ddlStep.Add(new SelectListItem { Text = "Step-7", Value = "7" });
            ddlStep.Add(new SelectListItem { Text = "Step-8", Value = "8" });
            ddlStep.Add(new SelectListItem { Text = "Step-9", Value = "9" });
            ddlStep.Add(new SelectListItem { Text = "Step-10", Value = "10" });
            ddlStep.Add(new SelectListItem { Text = "Step-11", Value = "11" });
            ddlStep.Add(new SelectListItem { Text = "Step-12", Value = "12" });
            ddlStep.Add(new SelectListItem { Text = "Step-13", Value = "13" });
            ddlStep.Add(new SelectListItem { Text = "Step-14", Value = "14" });
            ddlStep.Add(new SelectListItem { Text = "Step-15", Value = "15" });

            return ddlStep;
        }

        public string Fk_UserId { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public DataSet GetStateCity()
        {
            SqlParameter[] para = { 
                                      new SqlParameter("@PinCode", PinCode),
                                    
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetStateCity", para);

            return ds;
        }
        public int GenerateRandomNo()
        {
            int _min = 0000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }

    public class SMSCredential
    {
        public static string UserName = "";
        public static string Password = "";
        public static string SenderId = "";
    }

    public class SoftwareDetails
    {
        public static string CompanyName = "";
        public static string CompanyAddress = "";
        public static string Pin1 = "";
        public static string State1 = "";
        public static string City1 = "";
        public static string ContactNo = "";
        public static string LandLine = "";
        public static string GSTNO = "";
        public static string Website = "";
        public static string EmailID = "";
    }
    public class EncKey
    {
        public static string KeyName = "ALMKOLKJ12345ANB";
        public static string ProfilePicURL = "http://demo3.afluex.com/";
    }

}