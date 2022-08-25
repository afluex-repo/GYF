using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace GYF.Models
{
    public class Associate:Common
    {
        public string ProductName { get; set; }
        public string LoginId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string SponsorID { get; set; }
        public string SponsorName { get; set; }
        public string BankName { get; set; }
        public string BankHolderName { get; set; }
        public string AccountNo { get; set; }
        public string IFSC { get; set; }
        public string BankBranch { get; set; }
        public string PanNumber { get; set; }
        public string PAYTMNo { get; set; }
        public string Phonepay { get; set; }
        public string GooglePay { get; set; }
        public string UPINo { get; set; }
        public string NomineName { get; set; }
        public string NomineRealation { get; set; }
        public string DOB { get; set; }
        public string ProfilePic { get; set; }
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public List<Associate> DirectReportList { get; set; }
        public string JoiningDate { get; set; }
        public string PermanentDate { get; set; }
        public List<Associate> DownlineList { get; set; }
        public string AssociateName { get; set; }
        public string ActionStatus { get; set; }
        public string ParentLoginId { get; set; }
        public string ParentName { get; set; }
        public string RefferBy { get; set; }
        public string RefferByName { get; set; }
        public string Status { get; set; }
        public string ePinNo { get; set; }
        public string FromId { get; set; }
        public string FromName { get; set; }
        public string ToId { get; set; }
        public string ToName { get; set; }
        public string AdharNumber { get; set; }
        public string AdharImage { get; set; }
        public string AdharStatus { get; set; }
        public string PanImage { get; set; }
        public string PanStatus { get; set; }
        public string DocumentImage { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentStatus { get; set; }
        public string PK_DocumentID { get; set; }
        public string DocumentType { get; set; }
        public string TransferDate { get; set; }
        public string ToLoginId { get; set; }
        public List<Associate> PinTransferList { get; set; }
        public List<Associate> DirectIncomeList { get; set; }
        public string Amount { get; set; }
        public string CurrentDate { get; set; }
        public string FirstName { get; set; }
        public List<Associate> SingleLegIncomeList { get; set; }

        public List<Associate> LevelIncomeList { get; set; }
        public string level { get; set; }
        public List<Associate> AutopoolList { get; set; }
         public string Pool { get; set; }
        public string ToDate { get; set; }
        public string FromDate { get; set; }
        public List<Associate> lstPayoutDetail { get; set; }
        public string PayoutNo { get; set; }
        public string ROI { get; set; }
        public string NoofDays { get; set; }
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
        public string Rank { get; set; }

        public string Narration { get; set; }
        public string CrAmount { get; set; }
        public string DrAmount { get; set; }
        public string PayoutBalance { get; set; }
        public string TransactionDate { get; set; }
        public string Description { get; set; }
        public string Paymentdate { get; set; }
        public string TransactionNo { get; set; }
        public string Subject { get; set; }
        public string Msg { get; set; }
        public string TokenId { get; set; }
        public string Reply { get; set; }
        public string SupportTokenId { get; set; }
        public string PK_ProductId { get; set; }

        public string ReplyDate { get; set; }
        public List<Associate> SupportListM { get; set; }

        public List<Associate> PaidPayoutlist { get; set; }
        public List<Associate> LevelWiselist { get; set; }


        public List<Associate> lstPayoutLedger { get; set; }

        public string levelId { get; set; }

        public List<Associate> Rewardlist { get; set; }
        public string pk_RewardId { get; set; }
        public string TargetLevel { get; set; }
        public string TargetDirect { get; set; }
        public string TargetDays { get; set; }
        public string RewardAmount { get; set; }
        public string RewardImage { get; set; }

        public string Balance { get; set; }
        public string Pk_RequestId { get; set; }
        public string RequestedDate { get; set; }
        public List<Associate> PayoutRequestlist { get; set; }
        public string tOwner { get; set; }
        public string ROIDate { get; set; }
        public string step { get; set; }
        public List<Associate> ListAutopool { get; set; }
        public List<Associate> ListROI { get; set; }
        public string entrydate { get; set; }
        public string EntryAmount { get; set; }
        public List<Associate> MultiplePinList { get; set; }
        public string PinAmount { get; set; }
        public string SelectedValue { get; set; }

        public string PK_PayoutId { get; set; }
        public string PayoutWallet { get; set; }


        public string Password { get; set; }
        public string ConfirmNewPassword { get; set; }

        public DataSet GetStateCityByPincode()
        {
            SqlParameter[] para ={
                                   new SqlParameter("@pincode",PinCode)
                               };
            DataSet ds = DBHelper.ExecuteQuery("GetStateCity", para);
            return ds;

        }
        public DataSet ProductNameDetails()
        {
            DataSet ds = DBHelper.ExecuteQuery("CreateProductMaster");
            return ds;
        }
        public DataSet WalletBalanceNew()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@UserId",AddedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("WalletBalance", para);
            return ds;
        }
        public DataSet GettingProfile()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@FK_UserId",Fk_UserId)
            };
            DataSet ds = DBHelper.ExecuteQuery("ViewProfile",para);
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
                new SqlParameter("@MobileNo",Mobile),
                 new SqlParameter("@EmailId",Email),
                  new SqlParameter("@NomineeName",NomineName),
                  new SqlParameter("@NomineeRealation",NomineRealation)
            };
            DataSet ds = DBHelper.ExecuteQuery("UpdateProfile", para);
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
            DataSet ds = DBHelper.ExecuteQuery("SaveTopUpByUser", para);
            return ds;
        }
        public DataSet UpdatePassword()
        {
            SqlParameter[] para ={
                                   new SqlParameter("@OldPassword",OldPassword),
                                    new SqlParameter("@NewPassword",NewPassword),
                                       new SqlParameter("@UpdatedBy",UpdatedBy)
                               };
            DataSet ds = DBHelper.ExecuteQuery("ChangePassword", para);
            return ds;

        }

        public DataSet UpdatingBankDetails()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Fk_userId",Fk_UserId),
                new SqlParameter("@UpdatedBy",UpdatedBy),
                new SqlParameter("@IFSC",IFSC),
                new SqlParameter("@BankName",BankName),
                new SqlParameter("@BranchName",BankBranch),
                new SqlParameter("@BankHolderName",BankHolderName),
                new SqlParameter("@AccountNo",AccountNo),
                new SqlParameter("@PAYTMNo",PAYTMNo),
                new SqlParameter("@Phonepay",Phonepay),
                new SqlParameter("@GooglePay",GooglePay),
                 new SqlParameter("@UPINo",UPINo)
            };
            DataSet ds = DBHelper.ExecuteQuery("UpdateBankdetails", para);
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

        public DataSet GetUserName()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@LoginId",LoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetUserName", para);
            return ds;
        }

        public DataSet TopUpUser()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@ePinNo",ePinNo),
                new SqlParameter("@AddedBy",AddedBy),
                new SqlParameter("@TopUpTo",LoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("TopupByEpin", para);
            return ds;
        }

        public DataSet ePinTransfer()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Epino",ePinNo),
                new SqlParameter("@LoginId",LoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("ePinTransfer", para);
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

        public DataSet GetLevelWiseReport()
        {
            SqlParameter[] para = {
                new SqlParameter("@LoginId",LoginId),
                 new SqlParameter("@Level",levelId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetLevelWiseReport", para);
            return ds;
        }

        public DataSet SavingSupportQuery()
        {
            SqlParameter[] para = {
                new SqlParameter("@Fk_UserId",Fk_UserId),
                 new SqlParameter("@TokenId",TokenId),
                  new SqlParameter("@Subject",Subject),
                   new SqlParameter("@Msg",Msg),
                    new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("SaveSupport", para);
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

        public DataSet RewardList()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Fk_UserId",Fk_UserId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetRewardDetails", para);
            return ds;
        }

        public DataSet GetPayoutBalance()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Fk_UserId",Fk_UserId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetPayoutBalance", para);
            return ds;
        }

        public DataSet PayoutRequest()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@LoginId",LoginId),
                new SqlParameter("@Amount",Amount),
                new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("PayoutRequest", para);
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

        public DataSet getUserAutoPool()
        {
            SqlParameter[] para = {
                  new SqlParameter("@LoginId",LoginId),
                  new SqlParameter("@Step",step)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetAutoPoolTeam", para);
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

        public DataSet TransferMultiplePin()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Status",Status),
                new SqlParameter("@LoginID",LoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetUnusedUsedPins", para);
            return ds;
        }
        public DataSet Roidetails()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@LoginId",LoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("AssociateRoilist", para);
            return ds;
        }
        public DataSet GeneratDailyROI()
        {
           
            DataSet ds = DBHelper.ExecuteQuery("GeneratDailyROI");
            return ds;

        }
        public DataSet AutoDistributePayment()
        {

            DataSet ds = DBHelper.ExecuteQuery("AutoDistributePayment");
            return ds;

        }
        public DataSet CalculateLevelIncome()
        {
            DataSet ds = DBHelper.ExecuteQuery("CalculateLevelIncomeDaily");
            return ds;
        }
        public DataSet GetKYCDocuments()
        {
            SqlParameter[] para = { new SqlParameter("@FK_UserID",Pk_RequestId) };
            DataSet ds = DBHelper.ExecuteQuery("GetKYCDocuments", para);
            return ds;
        }
        public DataSet UploadKYCDocuments()
        {
            SqlParameter[] para = { new SqlParameter("@FK_UserID",Pk_RequestId ) ,
                                      new SqlParameter("@AdharNumber", AdharNumber) ,
                                      new SqlParameter("@AdharImage", AdharImage) ,
                                      new SqlParameter("@PanNumber", PanNumber),
                                      new SqlParameter("@PanImage", PanImage) ,
                                      new SqlParameter("@DocumentNumber", DocumentNumber) ,
                                      new SqlParameter("@DocumentImage", DocumentImage),
                                        new SqlParameter("@Action", ActionStatus),

                                  };
            DataSet ds = DBHelper.ExecuteQuery("UploadKYC", para);
            return ds;

        }

        public DataSet SavePayoutRequest()
        {

            SqlParameter[] para =
            {
                new SqlParameter("@LoginId",LoginId),
                new SqlParameter("@Amount",Amount),
                new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("PayoutRequest", para);
            return ds;
        }

        public DataSet PayoutWallets()
        {

            SqlParameter[] para =
            {
                new SqlParameter("@FK_UserId",Fk_UserId),
              
            };
            DataSet ds = DBHelper.ExecuteQuery("PayoutWallet", para);
            return ds;
        }

        public DataSet ChangePassword()
        {
            SqlParameter[] para = {new SqlParameter("@OldPassword",Password),
                                   new SqlParameter("@NewPassword",NewPassword),
                                   new SqlParameter("@UpdatedBy",UpdatedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("ChangePasswordForUser", para);
            return ds;

        }
    }
}