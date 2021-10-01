using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace GYF.Models
{
    public class AdminReports : Common
    {
        #region Properties
        public string ePinNo { get; set; }

        public string ProductName { get; set; }
        public string LoginId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string SponsorID { get; set; }
        public string SponsorName { get; set; }
        public string Email { get; set; }
        public List<AdminReports> AssociateList { get; set; }
        public string IsBlocked { get; set; }
        public string BankName { get; set; }
        public string BankHolderName { get; set; }
        public string AccountNo { get; set; }
        public string IFSC { get; set; }
        public string BankBranch { get; set; }
        public string PanNumber { get; set; }
        public string PAYTMNo { get; set; }
        public string Phonepay { get; set; }
        public string GooglePay { get; set; }
        public string NomineName { get; set; }
        public string NomineRealation { get; set; }
        public string DOB { get; set; }
        public string LastName { get; set; }
        public string ProfilePic { get; set; }
        public string FirstName { get; set; }
        public List<AdminReports> DownlineList { get; set; }
        public List<AdminReports> lstdetails { get; set; }
        public string AssociateName { get; set; }
        public string ParentLoginId { get; set; }
        public string ParentName { get; set; }
        public string RefferBy { get; set; }
        public string RefferByName { get; set; }
        public string Status { get; set; }
        public string JoiningDate { get; set; }
        public string PermanentDate { get; set; }
        public List<AdminReports> DirectReportList { get; set; }
        public string PinAmount { get; set; }
        public string UsedDate { get; set; }
        public string tOwner { get; set; }
        public string Pk_InvestmentId { get; set; }
        public string UpgradtionDate { get; set; }
        public string Package { get; set; }
        public string Amount { get; set; }
        public string BV { get; set; }
        public string TopupBy { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public List<AdminReports> TopupList { get; set; }
        public string Fk_PackageId { get; set; }

        public string FromId { get; set; }
        public string FromName { get; set; }
        public string ToId { get; set; }
        public string ToName { get; set; }
        public string TransferDate { get; set; }
        public string ToLoginId { get; set; }
        public List<AdminReports> PinTransferList { get; set; }


        public List<AdminReports> DirectIncomeList { get; set; }
        public string CurrentDate { get; set; }
        public string Rank { get; set; }
        public List<AdminReports> SingleLegIncomeList { get; set; }

        public List<AdminReports> LevelIncomeList { get; set; }
        public string level { get; set; }
        public List<AdminReports> AutopoolList { get; set; }
        public string Pool { get; set; }

        public List<AdminReports> lstPayoutDetail { get; set; }
        public string PayoutNo { get; set; }

        public string ROI { get; set; }
        public string RoIDate { get; set; }
        public string NoOfDays { get; set; }
        public List<AdminReports> ListRoiDetails { get; set; }
        public string ClosingDate { get; set; }
        public string DirectIncome { get; set; }
        public string BinaryIncome { get; set; }
        public string GrossAmount { get; set; }
        public string TDSAmount { get; set; }
        public string NetAmount { get; set; }
        public string ProcessingFee { get; set; }
        public string EncryptLoginID { get; set; }
        public string EncryptPayoutNo { get; set; }
        public string AdminFee { get; set; }
        public string SingleLegIncome { get; set; }
        public string LevelIncome { get; set; }
        public string AutoPoolIncome { get; set; }

        public string IsDownline { get; set; }
        public string Leg1 { get; set; }
        public string Pk_UserId { get; set; }
        public string Payamount { get; set; }
        public string TransactionNo { get; set; }

        public string TransactionDate { get; set; }
        public string SelectedValue { get; set; }
        public List<AdminReports> PaidPayoutlist { get; set; }
        public string Description { get; set; }
        public string Paymentdate { get; set; }
        public string Narration { get; set; }
        public string CrAmount { get; set; }
        public string DrAmount { get; set; }
        public string PayoutBalance { get; set; }

        public string levelId { get; set; }

        public List<AdminReports> lstPayoutLedger { get; set; }
        public List<AdminReports> LevelWiselist { get; set; }
        public string PK_SupportId { get; set; }
        public string SupportTokenId { get; set; }
        public string Msg { get; set; }
        public string Subject { get; set; }
        public List<AdminReports> lstReplySupport { get; set; }
        public string Reply { get; set; }
        public string Pk_RequestId { get; set; }
        public string RequestedDate { get; set; }
        public List<AdminReports> PayoutRequestlist { get; set; }
        public string Password { get; set; }
        public List<AdminReports>ListAutopool { get; set; }
        public string step { get; set; }
        public string entrydate { get; set; }
        public string EntryAmount { get; set; }
        public List<AdminReports> GetPayoutRequestList { get; set; }
        public string PK_ProductId { get; set; }
        public List<SelectListItem> ProductLst { get; set; }
        #endregion

        public DataSet GetStateCityByPincode()
        {
            SqlParameter[] para ={
                                   new SqlParameter("@pincode",PinCode)
                               };
            DataSet ds = DBHelper.ExecuteQuery("GetStateCity", para);
            return ds;

        }
        public DataSet GetRoiDetails()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@LoginId",LoginId),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate)

            };
            DataSet ds = DBHelper.ExecuteQuery("GetRoiDetailsForAdmin", para);
            return ds;
        }
        public DataSet GettingAssociateList()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@FK_UserId",Fk_UserId),
                 new SqlParameter("@LoginId",LoginId),
                  new SqlParameter("@FromDate",FromDate),
                   new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("AssociateList",para);
            return ds;

        }

        public DataSet BlockUser()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Fk_UserId",Fk_UserId),
                new SqlParameter("@UpdatedBy",UpdatedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("BlockUser", para);
            return ds;

        }

        public DataSet UnBlockUser()
        {
            SqlParameter[] para =
              {
                new SqlParameter("@Fk_UserId",Fk_UserId),
                new SqlParameter("@UpdatedBy",UpdatedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("UnBlockUser", para);
            return ds;

        }

        public DataSet GettingProfile()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@LoginId",LoginId),
                  new SqlParameter("@FromDate",FromDate),
                   new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@FK_UserId",Fk_UserId)
            };
            DataSet ds = DBHelper.ExecuteQuery("AssociateList", para);
            return ds;
        }
        public DataSet UpdatingProfile()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Fk_userId",Fk_UserId),
                new SqlParameter("@UpdatedBy",UpdatedBy),
                new SqlParameter("@DOB",DOB),
                new SqlParameter("@ProfilePic",ProfilePic),
                new SqlParameter("@Address",Address),
                new SqlParameter("@PinCode",PinCode),
                  new SqlParameter("@State",State),
                    new SqlParameter("@City",City),
                new SqlParameter("@MobileNo",Mobile),
                 new SqlParameter("@EmailId",Email),
                  new SqlParameter("@NomineeName",NomineName),
                  new SqlParameter("@NomineeRealation",NomineRealation),
                  new SqlParameter("@IFSC",IFSC),
                  new SqlParameter("@BankName",BankName),
                  new SqlParameter("@BranchName",BankBranch),
                  new SqlParameter("@BankHolderName",BankHolderName),
                  new SqlParameter("@AccountNo",AccountNo),
                  new SqlParameter("@PAYTMNo",PAYTMNo),
                  new SqlParameter("@Phonepay",Phonepay),
                  new SqlParameter("@GooglePay",GooglePay),
                  new SqlParameter("@FirstName",FirstName),
                   new SqlParameter("@LastName",LastName)
            };
            DataSet ds = DBHelper.ExecuteQuery("UpdateProfileByAdmin", para);
            return ds;
        }


        public DataSet GetDirectList()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@LoginId",LoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetDirectList", para);
            return ds;
        }

        public DataSet GetDownlineList()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@LoginId",LoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetDownlineDetails", para);
            return ds;
        }
        public DataSet GetUnusedPins()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Status",Status),
                new SqlParameter("@LoginID",LoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetUnusedUsedPins", para);
            return ds;
        }
        public DataSet GetTopupreport()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@LoginID",LoginId),
                new SqlParameter("@Package",Package),
                new SqlParameter("@ClaculationStatus",Status),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetTopupreport", para);
            return ds;
        }

        public DataSet GetPackage()
        {

            DataSet ds = DBHelper.ExecuteQuery("GetPackage");
            return ds;
        }

        public DataSet GetTransferPinReport()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@FromLoginId",LoginId),
                new SqlParameter("@ToLoginId",ToLoginId),
                new SqlParameter("@EpinNo",ePinNo)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetTransferPinReport", para);
            return ds;
        }


        public DataSet GetDirectIncomeList()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@FromLoginId",LoginId),
                new SqlParameter("@FromDate",FromDate),
                  new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetDirectIncome", para);
            return ds;
        }

        public DataSet GetSingleIncomeList()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@FromLoginId",LoginId),
                new SqlParameter("@FromDate",FromDate),
                  new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetSingleIncome", para);
            return ds;
        }
        public DataSet GetLevelIncomeList()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@FromLoginId",LoginId),
                 new SqlParameter("@FromDate",FromDate),
                  new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetLevelIncome", para);
            return ds;
        }
        public DataSet GetAutoPoolIncomeList()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@FromLoginId",LoginId),
                 new SqlParameter("@FromDate",FromDate),
                  new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetAutoPoolIncome", para);
            return ds;
        }

        public DataSet GetPayoutReport()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                      new SqlParameter("@PayoutNo", PayoutNo),

                                         new SqlParameter("@FromDate", FromDate),
                                         new SqlParameter("@ToDate", ToDate),
                                          new SqlParameter("@Name", Name),
            };
            DataSet ds = DBHelper.ExecuteQuery("GetPayoutReport", para);
            return ds;
        }

        public DataSet GetBalancePayoutforPayment()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                         new SqlParameter("@IsDownline", IsDownline),
                                          new SqlParameter("@Leg", Leg1),
            };
            DataSet ds = DBHelper.ExecuteQuery("GetBalancePayoutforPayment", para);
            return ds;
        }


        public DataSet PayPayout()
        {
            SqlParameter[] para = { new SqlParameter("@Fk_UserId", Pk_UserId),
                                         new SqlParameter("@TransactionNo", TransactionNo),
                                          new SqlParameter("@TransactionDate", TransactionDate),
                                            new SqlParameter("@Amount", Payamount),
                                              new SqlParameter("@AddedBy", AddedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("PayPayout", para);
            return ds;
        }

        public DataSet PaidPayoutDetailsList()
        {
            SqlParameter[] para = {
                new SqlParameter("@LoginId",LoginId),
                 new SqlParameter("@FromDate",FromDate),
                  new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetPaidPayoutDetails", para);
            return ds;
        }

        public DataSet PayoutLedgerList()
        {
            SqlParameter[] para = {
                new SqlParameter("@FK_UserId",Fk_UserId),
                 new SqlParameter("@FromDate",FromDate),
                  new SqlParameter("@ToDate",ToDate),
                  new SqlParameter("@LoginId",LoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("PayoutLedger", para);
            return ds;
        }

        public DataSet GetLevelWiseReport()
        {
            SqlParameter[] para = {
                new SqlParameter("@LoginId",LoginId),
                 new SqlParameter("@Level",levelId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetLevelWiseReport", para);
            return ds;
        }

        public DataSet SupportList()
        {
            SqlParameter[] para =
             {
                new SqlParameter("@LoginId",LoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("SupportList",para);
            return ds;
        }

        public DataSet ReplyingMsg()
        {
            SqlParameter[] para = {
                new SqlParameter("@AddedBy",AddedBy),
                 new SqlParameter("@Reply",Reply),
                 new SqlParameter("@SupportTokenId",SupportTokenId),
                  new SqlParameter("@FK_UserId",Fk_UserId)
            };
            DataSet ds = DBHelper.ExecuteQuery("ReplyToUser", para);
            return ds;
        }

        public DataSet GetPayoutRequest()
        {
            SqlParameter[] para = {
                  new SqlParameter("@FK_UserId",Fk_UserId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetPayoutRequest",para);
            return ds;
        }

        public DataSet ApproveDeclinePayoutRequest()
        {
            SqlParameter[] para = {
                new SqlParameter("@AddedBy",AddedBy),
                 new SqlParameter("@Pk_RequestId",Pk_RequestId),
                 new SqlParameter("@Status",Status)
            };
            DataSet ds = DBHelper.ExecuteQuery("ApproveDeclinePayoutRequest", para);
            return ds;
        }
        public DataSet GetAutoPoolFilter()
        {
            SqlParameter[] para = {
                new SqlParameter("@LoginId",LoginId),
                 new SqlParameter("@Step",step)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetAutoPoolTeam", para);
            return ds;
        }
        public DataSet GEtEwalletRequestList()
        {
            SqlParameter[] para = {
                  new SqlParameter("@FK_UserId",Fk_UserId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetEwalletRequestList", para);
            return ds;
        }

        public DataSet ApproveDeclineEwalletRequest()
        {
            SqlParameter[] para = {
                new SqlParameter("@AddedBy",AddedBy),
                 new SqlParameter("@Pk_RequestId",Pk_RequestId),
                 new SqlParameter("@Status",Status)
            };
            DataSet ds = DBHelper.ExecuteQuery("ApproveDeclineEwalletRequest", para);
            return ds;
        }


        public DataSet GetPayoutRequestLists()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Fk_UserId",Pk_UserId),
                 new SqlParameter("@LoginId",LoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetPayoutRequest", para);
            return ds;
        }


        public DataSet ApprovePayoutRequest()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Pk_RequestId",Pk_RequestId),
                 new SqlParameter("@Status",Status),
                  new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("ApproveDeclinePayoutRequest", para);
            return ds;
        }



        public DataSet ProductNameDetails()
        {
            DataSet ds = DBHelper.ExecuteQuery("CreateProductMaster");
            return ds;
        }
        

        public DataSet SaveTopUp()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@FK_ProductId",PK_ProductId),
                 new SqlParameter("@PinAmount",PinAmount),
                  new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("SaveTopUp", para);
            return ds;
        }
    }
}