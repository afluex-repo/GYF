using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GYF.Models
{
    public class Wallet : Common
    {
        public string MobileNo { get; set; }

        public string ProductWalletBalance { get; set; }
        public string PlotNumber { get; set; }
        public string Leg { get; set; }
        public bool IsDownline { get; set; }
        public string TransactionNo { get; set; }
        public string TransactionDate { get; set; }
        public string Description { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentToDate { get; set; }
        public string PaymentFromDate { get; set; }
        public string LoginId { get; set; }
        public string Amount { get; set; }
        public string EwalletBalance { get; set; }
        public string PayoutBalance { get; set; }
        public string PaymentMode { get; set; }
        public string BankName { get; set; }
        public string DDChequeNo { get; set; }
        public string DDChequeDate { get; set; }
        public string BankBranch { get; set; }
        public string DocumentImg { get; set; }
        public string Package { get; set; }
        public string TopUpDate { get; set; }
        public string NoofPins { get; set; }
        public string FinalAmount { get; set; }
        //public string CouponPrice { get; set; }
        //public string CouponCode { get; set; }
        //public string EventName { get; set; }
        public string ErrorMessage { get; set; }

        public string CouponCode { get; set; }
        public string CategoryName { get; set; }
        public int CategoryCode { get; set; }
        public string CreatedDate { get; set; }
        public string CuopnStatus { get; set; }
        public string EventName { get; set; }
        public string CouponPrice { get; set; }
        public string NFCCode { get; set; }
        public string UsedDate { get; set; }
        public string BookingDetailsId { get; set; }
        public string WalletBalance { get; set; }
        public string Coin { get; set; }
        public string FranchiseeBalance { get; set; }
        public string ReceiverMobile { get; set; }
        public string SenderMobile { get; set; }
        public string ReceiverName { get; set; }
        public string SenderName { get; set; }
        public List<Wallet> lstPayoutWalletLedger { get; set; }

        public DataSet PayoutWalletLedger()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_UserId", Fk_UserId),
                                     };
            DataSet ds = DBHelper.ExecuteQuery("GePayoutWalletLedger", para);
            return ds;
        }
        
        public DataSet GetDigiWalletBalance()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_UserId", Fk_UserId)
                                     };
            DataSet ds = DBHelper.ExecuteQuery("GetEWalletBalance", para);
            return ds;
        }
        public DataSet SaveProductWalletRequest()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", LoginId),
                                      new SqlParameter("@Amount", Amount),
                                      new SqlParameter("@PaymentMode", PaymentMode) ,
                                      new SqlParameter("@DDChequeNo", DDChequeNo) ,
                                      new SqlParameter("@DDChequeDate", DDChequeDate) ,
                                      new SqlParameter("@BankBranch", BankBranch) ,
                                      new SqlParameter("@DocumentImg", DocumentImg),
                                      new SqlParameter("@BankName", BankName),
                                      new SqlParameter("@AddedBy", AddedBy)
                                     };
            DataSet ds = DBHelper.ExecuteQuery("ProductWalletRequest", para);
            return ds;
        }
        public DataSet GetCouponDetails()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@CouponCode", ReferBy),

                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetCouponDetails", para);

            return ds;
        }
        public DataSet SaveEWalletRequest()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", LoginId),
                                      new SqlParameter("@Amount", Amount),
                                      new SqlParameter("@PaymentMode", PaymentMode) ,
                                      new SqlParameter("@DDChequeNo", DDChequeNo) ,
                                      new SqlParameter("@DDChequeDate", DDChequeDate) ,
                                      new SqlParameter("@BankBranch", BankBranch) ,
                                      new SqlParameter("@DocumentImg", DocumentImg),
                                          new SqlParameter("@BankName", BankName),
                                            new SqlParameter("@AddedBy", AddedBy)

                                     };
            DataSet ds = DBHelper.ExecuteQuery("EwalletRequest", para);
            return ds;
        }

        public List<Wallet> WalletRequestList { get; set; }

        public DataSet GetEWalletRequest()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_UserId", Fk_UserId),

                                     };
            DataSet ds = DBHelper.ExecuteQuery("GetEwalletRequest", para);
            return ds;
        }
        public DataSet GetFranchiseeWalletRequest()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_UserId", Fk_UserId),

                                     };
            DataSet ds = DBHelper.ExecuteQuery("GetFranchiseeWalletRequest", para);
            return ds;
        }
        public DataSet GetProductWalletRequest()
        {
            SqlParameter[] para = { new SqlParameter("@Fk_UserId", Fk_UserId), };
            DataSet ds = DBHelper.ExecuteQuery("GetProductWalletRequest", para);
            return ds;
        }
        public string Status { get; set; }

        public string RequestCode { get; set; }

        public string Narration { get; set; }
        public string UserCode { get; set; }

        public string DrAmount { get; set; }

        public string CrAmount { get; set; }

        public List<Wallet> lstewalletledger { get; set; }

        public DataSet EwalletLedger()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_UserId", Fk_UserId),

                                     };
            DataSet ds = DBHelper.ExecuteQuery("GetEwalletLedger", para);
            return ds;
        }
        public DataSet ShoppingWalletLedger()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_UserId", Fk_UserId),

                                     };
            DataSet ds = DBHelper.ExecuteQuery("GetShoppingWalletLedger", para);
            return ds;
        }
        public DataSet RealEstateWalletLedger()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_UserId", Fk_UserId),

                                     };
            DataSet ds = DBHelper.ExecuteQuery("GetRealEstateWalletLedger", para);
            return ds;
        }
        public DataSet ProductWalletLedger()
        {
            SqlParameter[] para = { new SqlParameter("@Fk_UserId", Fk_UserId), };
            DataSet ds = DBHelper.ExecuteQuery("GetProductWalletLedger", para);
            return ds;
        }
        public DataSet CouponTopupByAdmin()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@AddedBy", AddedBy),
                                    new SqlParameter("@CouponCode", CouponCode),
                                    new SqlParameter("@TopupDate", TopUpDate),
                                    new SqlParameter("@CouponPrice", CouponPrice),
                                    new SqlParameter("@Description", Description) };
            DataSet ds = DBHelper.ExecuteQuery("CouponTopUpByAdmin", para);
            return ds;
        }
        public DataSet GetEwalletBalnce()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_UserId", Fk_UserId),

                                     };
            DataSet ds = DBHelper.ExecuteQuery("GetEwalletBalance", para);
            return ds;
        }

        public DataSet TransferEwalletToEwallet()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", MobileNo),
                                      new SqlParameter("@Amount", Amount),
                                      new SqlParameter("@AddedBy", AddedBy),

                                     };
            DataSet ds = DBHelper.ExecuteQuery("TransferEwalletToEwallet", para);
            return ds;
        }

        public DataSet GetpayoutBalance()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_UserId", Fk_UserId),

                                     };
            DataSet ds = DBHelper.ExecuteQuery("GetPayoutBalance", para);
            return ds;
        }

        public DataSet SavePayoutRequest()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", LoginId),
                                      new SqlParameter("@Amount", Amount),
                                      new SqlParameter("@AddedBy", AddedBy)

                                     };
            DataSet ds = DBHelper.ExecuteQuery("PayoutRequest", para);
            return ds;
        }

        public List<Wallet> lstPayoutrequest { get; set; }

        public DataSet GetPayoutRequest()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_UserId", Fk_UserId),


                                     };
            DataSet ds = DBHelper.ExecuteQuery("GetPayoutRequest", para);
            return ds;
        }

        public List<Wallet> lstpayoutledger { get; set; }

        public DataSet PayoutLedger()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_UserId", Fk_UserId),
                                       new SqlParameter("@FromDate", FromDate),
                                        new SqlParameter("@ToDate", ToDate),

                                     };
            DataSet ds = DBHelper.ExecuteQuery("GetPayoutLedger", para);
            return ds;
        }

        public DataSet BindPriceByProduct()
        {
            SqlParameter[] para = { new SqlParameter("@ProductId", Package) };
            DataSet ds = DBHelper.ExecuteQuery("GetProductList", para);
            return ds;
        }

        public DataSet TopUpIdByEWallet()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", LoginId),
                                       new SqlParameter("@AddedBy", AddedBy),
                                        new SqlParameter("@Fk_ProductId", Package)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("TopUpIdByEWallet", para);
            return ds;
        }

        public DataSet TopUpIdByAdmin()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@AddedBy", AddedBy),
                                    new SqlParameter("@Fk_ProductId", Package),
                                    new SqlParameter("@TopupDate", TopUpDate),
                                    new SqlParameter("@Amount", Amount),
                                    new SqlParameter("@PaymentMode", PaymentMode) ,
                                      new SqlParameter("@DDChequeNo", DDChequeNo) ,
                                      new SqlParameter("@DDChequeDate", DDChequeDate) ,
                                      new SqlParameter("@BankBranch", BankBranch) ,
                                      new SqlParameter("@BankName", BankName),
                                    new SqlParameter("@PlotNumber", PlotNumber),
                                    new SqlParameter("@Description", Description) };
            DataSet ds = DBHelper.ExecuteQuery("CouponTopUpByAdmin", para);
            return ds;
        }
        public DataSet TopUpIdByAdminProduct()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@AddedBy", AddedBy),
                                    new SqlParameter("@Fk_ProductId", Package),
                                    new SqlParameter("@TopupDate", TopUpDate),
                                    new SqlParameter("@Amount", Amount),
                                    new SqlParameter("@PlotNumber", PlotNumber),
                                    new SqlParameter("@Description", Description) };
            DataSet ds = DBHelper.ExecuteQuery("ProductTopUpByAdmin", para);
            return ds;
        }
        public DataSet ReTopup()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@AddedBy", AddedBy),
                                    new SqlParameter("@Fk_ProductId", Package),
                                    new SqlParameter("@TopupDate", TopUpDate),
                                    new SqlParameter("@Amount", Amount),
                                    new SqlParameter("@PlotNumber", PlotNumber),
                                    new SqlParameter("@Description", Description) };
            DataSet ds = DBHelper.ExecuteQuery("ReTopup", para);
            return ds;
        }

        public DataSet TransferCoupon()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@CouponCode", CouponCode),
                                    new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("TransferCoupon", para);
            return ds;
        }
        public string Pk_RequestId { get; set; }

        public DataSet ApprovePayputRequest()
        {
            SqlParameter[] para = {

                                       new SqlParameter("@AddedBy", AddedBy),
                                        new SqlParameter("@Pk_RequestId", Pk_RequestId),
                                         new SqlParameter("@Status", Status)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("ApproveDeclinePayoutRequest", para);
            return ds;
        }

        public DataSet ApproveEwalletRequest()
        {
            SqlParameter[] para = {

                                       new SqlParameter("@AddedBy", AddedBy),
                                        new SqlParameter("@Pk_RequestId", Pk_RequestId),
                                         new SqlParameter("@Status", Status)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("ApproveDeclineEwalletRequest", para);
            return ds;
        }
        public DataSet ApproveFranchiseewalletRequest()
        {
            SqlParameter[] para = {

                                       new SqlParameter("@AddedBy", AddedBy),
                                        new SqlParameter("@Pk_RequestId", Pk_RequestId),
                                         new SqlParameter("@Status", Status)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("ApproveDeclineFranchiseewalletRequest", para);
            return ds;
        }
        public DataSet CreatePin()
        {
            SqlParameter[] para = {

                                       new SqlParameter("@Fk_PackageId", Package),
                                        new SqlParameter("@NoofPins", NoofPins),
                                         new SqlParameter("@LoginId", LoginId),
                                         new SqlParameter("@CreatedBy", AddedBy),
                                         new SqlParameter("@Amount", Amount)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GenerateEPinByAdmin", para);
            return ds;
        }
        public DataSet GetEWalletBalance()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_UserId", Fk_UserId)
                                     };
            DataSet ds = DBHelper.ExecuteQuery("GetEWalletBalance", para);
            return ds;
        }
        public List<Wallet> lstBooster { get; set; }
        public List<Wallet> lstunusedpins { get; set; }

        public string ePinNo { get; set; }

        public string RegisteredTo { get; set; }
        public string RegisteredToName { get; set; }
        public string OwnerID { get; set; }
        public string OwnerName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string SenderEmail { get;  set; }
        public string ReceiverEmail { get;  set; }

        public DataSet GetUsedUnUsedPins()
        {
            SqlParameter[] para = {

                                        new SqlParameter("@Status", Status),
                                        new SqlParameter("@Fk_UserId", Fk_UserId),
                                        new SqlParameter("@EPinNo", ePinNo),
                                        new SqlParameter("@Package", Package),
                                        new SqlParameter("@OwnerID", OwnerID ),
                                        new SqlParameter("@OwnrName",OwnerName ),
                                        new SqlParameter("@RegToId", RegisteredTo ),
                                        new SqlParameter("@RegToName",RegisteredToName ),

                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetUnusedUsedCoupons");
            return ds;
        }

        public DataSet GetUsedcoupons()
        {
            SqlParameter[] para = {

                                        new SqlParameter("@CouponCode", CouponCode),
                                        new SqlParameter("@Pk_CategoryId", CategoryCode)
                                        //--new SqlParameter("@UserId", Fk_UserId)
                                        //new SqlParameter("@EPinNo", ePinNo),
                                        //new SqlParameter("@Package", Package),
                                        //new SqlParameter("@OwnerID", OwnerID ),
                                        //new SqlParameter("@OwnrName",OwnerName ),
                                        //new SqlParameter("@RegToId", RegisteredTo ),
                                        //new SqlParameter("@RegToName",RegisteredToName ),

                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetUsedCoupons", para);
            return ds;
        }
        public DataSet GetUsedUnUsedcoupons()
        {
            SqlParameter[] para = {

                                        new SqlParameter("@CouponCode", CouponCode),
                                        new SqlParameter("@Pk_CategoryId", CategoryCode)                                   
                                        //new SqlParameter("@Package", Package),
                                        //new SqlParameter("@OwnerID", OwnerID ),
                                        //new SqlParameter("@OwnrName",OwnerName ),
                                        //new SqlParameter("@RegToId", RegisteredTo ),
                                        //new SqlParameter("@RegToName",RegisteredToName ),

                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetUnusedUsedCoupons", para);
            return ds;
        }

        public DataSet GetUsedUnUsedcouponsAssociate()
        {
            SqlParameter[] para = {

                                        new SqlParameter("@CouponCode", CouponCode),
                                        new SqlParameter("@Pk_CategoryId", CategoryCode),
                                        new SqlParameter("@UserId", Fk_UserId),
                                        //new SqlParameter("@OwnerID", OwnerID ),
                                        //new SqlParameter("@OwnrName",OwnerName ),
                                        //new SqlParameter("@RegToId", RegisteredTo ),
                                        //new SqlParameter("@RegToName",RegisteredToName ),

                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetUnusedUsedCouponsAssociate", para);
            return ds;
        }
        public DataSet GetcouponsAssociate()
        {
            SqlParameter[] para = {

                                        new SqlParameter("@CouponCode", CouponCode),
                                        new SqlParameter("@Pk_CategoryId", CategoryCode),
                                        new SqlParameter("@UserId", Fk_UserId),
                                        //new SqlParameter("@OwnerID", OwnerID ),
                                        //new SqlParameter("@OwnrName",OwnerName ),
                                        //new SqlParameter("@RegToId", RegisteredTo ),
                                        //new SqlParameter("@RegToName",RegisteredToName ),

                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetCouponsAssociate", para);
            return ds;
        }
        public DataSet GetUsedcouponsAssociate()
        {
            SqlParameter[] para = {

                                        new SqlParameter("@CouponCode", CouponCode),
                                        new SqlParameter("@Pk_CategoryId", CategoryCode),
                                        new SqlParameter("@UserId", Fk_UserId),
                                        //new SqlParameter("@OwnerID", OwnerID ),
                                        //new SqlParameter("@OwnrName",OwnerName ),
                                        //new SqlParameter("@RegToId", RegisteredTo ),
                                        //new SqlParameter("@RegToName",RegisteredToName ),

                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetUsedCouponsAssociate", para);
            return ds;
        }

        public DataSet TopupByEpinByAdmin()
        {
            SqlParameter[] para = {

                                       new SqlParameter("@ePinNo", ePinNo),
                                        new SqlParameter("@TopUpTo", LoginId),
                                         new SqlParameter("@CreatedBy", AddedBy),

                                  };
            DataSet ds = DBHelper.ExecuteQuery("TopupByEpinByAdmin", para);
            return ds;
        }
        public DataSet TopupByEpin()
        {
            SqlParameter[] para = {

                                       new SqlParameter("@ePinNo", ePinNo),
                                        new SqlParameter("@TopUpTo", LoginId),
                                         new SqlParameter("@CreatedBy", AddedBy),

                                  };
            DataSet ds = DBHelper.ExecuteQuery("TopupByEpin", para);
            return ds;
        }
        public DataSet TransferPin()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@Epino", ePinNo), };
            DataSet ds = DBHelper.ExecuteQuery("ePinTransfer", para);
            return ds;
        }
        public DataSet GetPaidBooster()
        {
            SqlParameter[] para = { new SqlParameter("@Fk_UserId", Fk_UserId),
                                      new SqlParameter("@LoginId", LoginId),
                                      new SqlParameter("@FromDate", FromDate),
                                      new SqlParameter("@ToDate", ToDate),
                                      new SqlParameter("@FromPaymentDate", PaymentFromDate),
                                      new SqlParameter("@ToPaymentDate", PaymentToDate),
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetPaidBoosterDetails", para);
            return ds;
        }

        #region PaidPayout
        public DataSet GetPaidPayout()
        {
            SqlParameter[] para = { new SqlParameter("@Fk_UserId", Fk_UserId),
                                    new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate), };
            DataSet ds = DBHelper.ExecuteQuery("GetPaidPayoutDetails", para);
            return ds;
        }
        #endregion

        public DataSet SaveAdvancePayment()
        {
            SqlParameter[] para = { new SqlParameter("@LoginID", LoginId),
                                    new SqlParameter("@Amount", Amount),
                                    new SqlParameter("@Description", Description),
                                    new SqlParameter("@PaymentMode", PaymentMode),
                                    new SqlParameter("@TransactionNo", TransactionNo),
                                    new SqlParameter("@TransactionDate", TransactionDate),
                                    new SqlParameter("@BankName", BankName),
                                    new SqlParameter("@BankBranch", BankBranch),
                                    new SqlParameter("@AddedBy", AddedBy), };
            DataSet ds = DBHelper.ExecuteQuery("AdvancePayment", para);
            return ds;
        }

        public DataSet AdvancePaymentReport()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate), };
            DataSet ds = DBHelper.ExecuteQuery("AdvancePaymentReport", para);
            return ds;
        }
        public DataSet GetPaidProductBooster()
        {
            SqlParameter[] para = { new SqlParameter("@Fk_UserId", Fk_UserId),
                                      new SqlParameter("@LoginId", LoginId),
                                      new SqlParameter("@FromDate", FromDate),
                                      new SqlParameter("@ToDate", ToDate),
                                      new SqlParameter("@FromPaymentDate", PaymentFromDate),
                                      new SqlParameter("@ToPaymentDate", PaymentToDate),
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetProductPaidBoosterDetails", para);
            return ds;
        }
        public DataSet GetCoinwalletLedger()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_UserId", Fk_UserId),

                                     };
            DataSet ds = DBHelper.ExecuteQuery("GetDDCoinWalletLedger", para);
            return ds;
        }
        public DataSet GetFranchiseeWalletLedger()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_UserId", Fk_UserId),

                                     };
            DataSet ds = DBHelper.ExecuteQuery("GetFranchiseeWalletLedger", para);
            return ds;
        }
        public DataSet GetFranchiseeWalletLedgerByAdmin()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", LoginId),
                                      new SqlParameter("@FromDate", FromDate),
                                      new SqlParameter("@ToDate", ToDate)

                                     };
            DataSet ds = DBHelper.ExecuteQuery("GetFranchiseeWalletLedgerByAdmin", para);
            return ds;
        }
        public DataSet GetDDCoinWalletLedgerByAdmin()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", LoginId),
                                      new SqlParameter("@FromDate", FromDate),
                                      new SqlParameter("@ToDate", ToDate)

                                     };
            DataSet ds = DBHelper.ExecuteQuery("GetDDCoinWalletLedgerByAdmin", para);
            return ds;
        }
        public DataSet SaveFranchiseeFund()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", LoginId),
                                      new SqlParameter("@Amount", Amount),
                                      new SqlParameter("@PaymentMode", PaymentMode) ,
                                      new SqlParameter("@DDChequeNo", DDChequeNo) ,
                                      new SqlParameter("@DDChequeDate", DDChequeDate) ,
                                      new SqlParameter("@BankBranch", BankBranch) ,
                                      new SqlParameter("@DocumentImg", DocumentImg),
                                          new SqlParameter("@BankName", BankName),
                                            new SqlParameter("@AddedBy", AddedBy)

                                     };
            DataSet ds = DBHelper.ExecuteQuery("SaveFranchiseeFund", para);
            return ds;
        }
    }
    public class WalletMobile
    {
        public string LoginId { get; set; }
        public string Amount { get; set; }
        public string PaymentMode { get; set; }
        public string DDChequeNo { get; set; }
        public string DDChequeDate { get; set; }
        public string BankBranch { get; set; }
        public string DocumentImg { get; set; }
        public string BankName { get; set; }
        public string AddedBy { get; set; }
        public string RequestCode { get; set; }
        public string Status { get; set; }
        public string AddedOn { get; set; }

        public DataSet SaveEWalletRequest()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", LoginId),
                                      new SqlParameter("@Amount", Amount),
                                      new SqlParameter("@PaymentMode", PaymentMode) ,
                                      new SqlParameter("@DDChequeNo", DDChequeNo) ,
                                      new SqlParameter("@DDChequeDate", DDChequeDate) ,
                                      new SqlParameter("@BankBranch", BankBranch) ,
                                      new SqlParameter("@DocumentImg", DocumentImg),
                                          new SqlParameter("@BankName", BankName),
                                            new SqlParameter("@AddedBy", AddedBy)

                                     };
            DataSet ds = DBHelper.ExecuteQuery("EwalletRequest", para);
            return ds;
        }
    }
    public class TransferEwallet
    {
        public string LoginId { get; set; }
        public string Amount { get; set; }
        public string AddedBy { get; set; }
        

        public DataSet TransferEwalletToEwallet()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", LoginId),
                                      new SqlParameter("@Amount", Amount),
                                      new SqlParameter("@AddedBy", AddedBy),

                                     };
            DataSet ds = DBHelper.ExecuteQuery("TransferEwalletToEwallet", para);
            return ds;
        }
    }

    public class WalletLedgerMobile
    {
        public string AddedOn { get; set; }
        public string CrAmount { get; set; }
        public string DrAmount { get; set; }
        public string EwalletBalance { get; set; }
        public string Narration { get; set; }
    }
    public class DirectListRequest
    {
        public string LoginId { get; set; }
        public string Name { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Narration { get; set; }
        public string FromActivationDate { get; set; }
        public string ToActivationDate { get; set; }
        public string Leg { get; set; }
        public string Status { get; set; }
        public DataSet GetDirectList()
        {

            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@Name", Name),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),
                                    new SqlParameter("@FromActivationDate", FromActivationDate),
                                    new SqlParameter("@ToActivationDate", ToActivationDate),
                                    new SqlParameter("@Leg", Leg),
                                    new SqlParameter("@Status", Status),
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetDirectList", para);
            return ds;
        }
        public DataSet GetDirectListL2()
        {

            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@Name", Name),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),
                                    new SqlParameter("@FromActivationDate", FromActivationDate),
                                    new SqlParameter("@ToActivationDate", ToActivationDate),
                                    new SqlParameter("@Leg", Leg),
                                    new SqlParameter("@Status", Status),
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetDirectListL2", para);
            return ds;
        }
        public DataSet GetDownlineList()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@Name", Name),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),
                                    new SqlParameter("@Leg", Leg),
                                    new SqlParameter("@Status", Status), };
            DataSet ds = DBHelper.ExecuteQuery("DownlineList", para);
            return ds;
        }
       
    }
    public class DirectListMobile
    {
        public string Email { get; set; }
        public string JoiningDate { get; set; }
        public string Leg { get; set; }
        public string LoginId { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string Package { get; set; }
        public string PermanentDate { get; set; }
        public string SponsorId { get; set; }
        public string SponsorName { get; set; }
        public string Status { get; set; }
    }
    public class PayoutReportData
    {
        public string BinaryIncome { get; set; }
        public string ClosingDate { get; set; }
        public string DirectIncome { get; set; }
        public string DisplayName { get; set; }
        public string EncryptLoginID { get; set; }
        public string EncryptPayoutNo { get; set; }
        public string GrossAmount { get; set; }
        public string LeadershipBonus { get; set; }
        public string LoginId { get; set; }
        public string NetAmount { get; set; }
        public string PayoutNo { get; set; }
        public string ProcessingFee { get; set; }
        public string ProductWallet { get; set; }
        public string TDSAmount { get; set; }
    }
    public class ActivateUserid
    {
        public string LoginId { get; set; }
        public string CouponCode { get; set; }
        public string CouponPrice { get; set; }
        public string AddedBy { get; set; }
        public string Result { get; set; }
        public string TopupDate { get; set; }
        public DataSet ActivateUserId()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@CouponCode", CouponCode),
                                    new SqlParameter("@CouponPrice", CouponPrice),
                                    new SqlParameter("@AddedBy",AddedBy),
                                     new SqlParameter("@TopupDate",TopupDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("CouponTopUpByUser", para);
            return ds;
        }

      
    }



}
