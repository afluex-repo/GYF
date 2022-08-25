using GYF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace GYF.Models
{
    public class Admin : Common
    {
        public string LoginId { get; set; }
        public string Fk_PackageId { get; set; }
        public string NoofPins { get; set; }
        public string PaymentMode { get; set; }
        public string TransactionNo { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string TransactionDate { get; set; }
        public string Name { get; set; }
        public List<Admin> lstdetails { get; set; }
        public string ePinNo { get; set; }
        public string PinAmount { get; set; }
        public string Status { get; set; }
        public string tOwner { get; set; }
        public string UsedDate { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public List<Admin> lstProduct { get; set; }
        public string ProductPrice { get; set; }
        public string ProductDate { get; set; }
        public string EncrptProductId { get; set; }
        public string ProductImage { get; set; }
        public string PK_NewsID { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public List<Admin> lstNewsList { get; set; }
        public string Description { get; set; }
        public string PK_DocumentID { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentType { get; set; }
        public string RequestedDate { get; set; }
        public string DocumentImage { get; set; }
        public string Pk_RequestId { get; set; }
        public string Amount { get; set; }
        public string ClosingDate { get; set; }
        public string ClosingDateValid { get; set; }
        public List<Admin> EwalletRequestList { get; set; }

        public string FirstName { get; set; }
        public string BinaryIncome { get; set; }
        public string DirectIncome { get; set; }
        public string DirectLeaderShipBonus { get; set; }
        public string GrossIncome { get; set; }
        public string Processing { get; set; }
        public string TDS { get; set; }
        public string NetIncome { get; set; }
        public string LastClosingDate { get; set; }
        public string PayoutNo { get; set; }
        public string LeadershipBonus { get; set; }
        public string DistPaymentPassword { get; set; }
        public string Image { get; set; }

        public string OfficeProjectNo { get; set; }
        public string OfficeProject { get; set; }


        public List<Admin> lstassociate { get; set; }
        public List<Admin> DistributePaymentList { get; set; }
        public string PK_BannerId { get; set; }
        public string BannerImage { get; set; }
        public HttpPostedFileBase postedFile { get; set; }
        public List<Admin> lstBanner { get; set; }
        public List<Admin> lstOfficeProject { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }

        public List<Admin> lstCreer { get; set; }
        public List<Admin> lstContact { get; set; }

        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Experience { get; set; }
        public string Resume { get; set; }
        public string CareerId { get; set; }
        public string Subject { get; set; }
        public string ContactId { get; set; }
        public string AddedOn { get; set; }

        





        public DataSet GetPaymentMode()
        {

            DataSet ds = DBHelper.ExecuteQuery("GetPaymentMode");
            return ds;
        }

        public DataSet GetPackage()
        {

            DataSet ds = DBHelper.ExecuteQuery("GetPackage");
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
        public DataSet GetUserName()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@LoginId",LoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetUserName", para);
            return ds;
        }

        public DataSet CreatePinByAdmin()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@LoginId",LoginId),
                new SqlParameter("@AddedBy",AddedBy),
                new SqlParameter("@Fk_PackageId",Fk_PackageId),
                new SqlParameter("@NoofPins",NoofPins),
                new SqlParameter("@PaymentMode",PaymentMode),
                new SqlParameter("@TransactionNo",TransactionNo),
                new SqlParameter("@BankName",BankName),
                 new SqlParameter("@BankBranch",BankBranch),
                  new SqlParameter("@TransactionDate",TransactionDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("CreatePinByAdmin", para);
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

        public DataSet GetStatuss()
        {
            DataSet ds = DBHelper.ExecuteQuery("GetStatus");
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

        public DataSet GetNewsList()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@PK_NewsID",PK_NewsID)
            };
            DataSet ds = DBHelper.ExecuteQuery("News", para);
            return ds;
        }
        public DataSet SavingNews()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@AddedBy",AddedBy),
                new SqlParameter("@Title",Title),
                new SqlParameter("@ShortDescription",ShortDescription),
                new SqlParameter("@Description",Description)
            };
            DataSet ds = DBHelper.ExecuteQuery("AddNews", para);
            return ds;
        }

        public DataSet UpdatingNewsMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@UpdatedBy",UpdatedBy),
                new SqlParameter("@Title",Title),
                new SqlParameter("@ShortDescription",ShortDescription),
                new SqlParameter("@Description",Description),
                 new SqlParameter("@PK_NewsID",PK_NewsID)
            };
            DataSet ds = DBHelper.ExecuteQuery("UpdateNews", para);
            return ds;
        }

        public DataSet DeletingNewsMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@DeletedBy",UpdatedBy),
                 new SqlParameter("@PK_NewsID",PK_NewsID)
            };
            DataSet ds = DBHelper.ExecuteQuery("DeleteNewsMaster", para);
            return ds;
        }

        public DataSet GetAdminDashboard()
        {
            DataSet ds = DBHelper.ExecuteQuery("AdminDashboard");
            return ds;
        }
        public DataSet SaveProduct()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@AddedBy",AddedBy),
                new SqlParameter("@ProductName",ProductName),
                new SqlParameter ("@ProductPrice",ProductPrice),
                new SqlParameter("@ProductImage",ProductImage)
            };
            DataSet ds = DBHelper.ExecuteQuery("AddProduct", para);
            return ds;
        }
        public DataSet UpdateProduct()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@UpdatedBy",UpdatedBy),
                new SqlParameter("@ProductName",ProductName),
                new SqlParameter ("@ProductPrice",ProductPrice),
                new SqlParameter("@ProductImage",ProductImage),
                new SqlParameter("@PK_ProductId",EncrptProductId)

            };
            DataSet ds = DBHelper.ExecuteQuery("UpdateProduct", para);
            return ds;
        }
        public DataSet GetProduct()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@ProductId",EncrptProductId),
                new SqlParameter("@ProductName",ProductName),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter ("@ToDate",ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetProduct", para);
            return ds;
        }
        public DataSet ProductDetailsbyId()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@ProductId",EncrptProductId),
                new SqlParameter("@ProductName",ProductName),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter ("@ToDate",ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetProduct", para);
            return ds;
        }
        public DataSet DeletedProduct()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@DeletedBy",UpdatedBy),
                new SqlParameter("@PK_ProductId",EncrptProductId)
            };
            DataSet ds = DBHelper.ExecuteQuery("DeleteProduct", para);
            return ds;
        }
        public DataSet DeletedProductImage()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@DeletedBy",UpdatedBy),
                new SqlParameter("@PK_ProductId",EncrptProductId)
            };
            DataSet ds = DBHelper.ExecuteQuery("DeleteProductImage", para);
            return ds;
        }
        public DataSet ListForKYC()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                      new SqlParameter("@Status", Status)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetListForKYC", para);
            return ds;
        }
        public DataSet ApproveKYC()
        {
            SqlParameter[] para = { new SqlParameter("@LoginID", LoginId),
                                      new SqlParameter("@PK_DocumentID", PK_DocumentID),
                                      new SqlParameter("@DocumentType", DocumentType),
                                      new SqlParameter("@Status", Status),
                                      new SqlParameter("@UpdatedBy", AddedBy)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("ApproveKYC", para);
            return ds;
        }






        public DataSet SaveDitributePayment()
        {
            SqlParameter[] para = { new SqlParameter("@ClosingDate", ToDate),
                                      };
            DataSet ds = DBHelper.ExecuteQuery("SaveDistributePayment", para);
            return ds;
        }


        public DataSet GetDitributePaymentList()
        {
            DataSet ds = DBHelper.ExecuteQuery("MakePaymentList");
            return ds;
        }

        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }

        public DataSet ChangePassword()
        {
            SqlParameter[] para = {new SqlParameter("@OldPassword",Password),
                                   new SqlParameter("@NewPassword",NewPassword),
                                   new SqlParameter("@UpdatedBy",UpdatedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("ChangePasswordForAdmin", para);
            return ds;

        }

        public DataSet ValidatePassword()
        {
            SqlParameter[] para = { new SqlParameter("@DistPaymentPassword", DistPaymentPassword) };
            DataSet ds = DBHelper.ExecuteQuery("ValidateDistributePassword", para);
            return ds;
        }

        public DataSet AutoDistributePayment()
        {
            SqlParameter[] para = { new SqlParameter("@ClosingDate", ClosingDate) };
            DataSet ds = DBHelper.ExecuteQuery("AutoDistributePayment", para);
            return null;
        }
        public DataSet UploadBanner()
        {
            SqlParameter[] para = {
                new SqlParameter("@Title", Title),
                new SqlParameter("@BannerImage", BannerImage),
                new SqlParameter("@AddedBy", AddedBy),
            };
            DataSet ds = DBHelper.ExecuteQuery("UploadBanner", para);
            return ds;
        }

        public DataSet GetBannerImage()
        {
            SqlParameter[] para = {
                new SqlParameter("@PK_BannerId", PK_BannerId),
            };
            DataSet ds = DBHelper.ExecuteQuery("GetBannerImage", para);
            return ds;
        }
        public DataSet DeleteBanner()
        {
            SqlParameter[] para = {
                new SqlParameter("@PK_BannerId", PK_BannerId),
                new SqlParameter("@AddedBy", AddedBy),
            };
            DataSet ds = DBHelper.ExecuteQuery("DeleteBanner", para);
            return ds;
        }


        public DataSet SaveProject()
        {
            SqlParameter[] param = { new SqlParameter("@ProjectNname",ProjectName),
                new SqlParameter("@Description",Description),
                   new SqlParameter("@ProjectType",ProjectType),
                                           new SqlParameter("@PostedFile",Image),
                                           new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("SaveProject", param);
            return ds;
        }


        public DataSet GetProjectDetails()
        {
            SqlParameter[] param = {
                new SqlParameter("@ProjectId",ProjectId),
                new SqlParameter("@ProjectName",ProjectName),
                new SqlParameter("@Description",Description),
                  new SqlParameter("@ProjectType",ProjectType),
                new SqlParameter("@ImageFile",Image)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetProjectDetails", param);
            return ds;
        }

        public DataSet DeleteProject()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@ProjectId",ProjectId),
                 new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("DeleteProject", para);
            return ds;
        }
        public DataSet UpdateProject()
        {
            SqlParameter[] param = {
                 new SqlParameter("@ProjectId",ProjectId),
                new SqlParameter("@ProjectNname",ProjectName),
                new SqlParameter("@Description",Description),
                   new SqlParameter("@ProjectType",ProjectType),
                                           new SqlParameter("@PostedFile",Image),
                                           new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("UpdateProject", param);
            return ds;
        }



        public DataSet GetCreerDetails()
        {
            SqlParameter[] param = {
                 new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetCareerDetails",param);
            return ds;
        }


        public DataSet GetContactDetails()
        {
            SqlParameter[] param = {
                  new SqlParameter("@PK_ContactId",ContactId),
                 new SqlParameter("@Name",Name),
                new SqlParameter("@Email",Email),
                 new SqlParameter("@Subject",Subject),
                new SqlParameter("@Address",Address),
                 new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate)
                
            };
            DataSet ds = DBHelper.ExecuteQuery("GetContactDetails",param);
            return ds;
        }


    }
}