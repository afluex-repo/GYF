using GYF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GYF.Controllers
{
    public class WalletController : Controller
    {
        // GET: Wallet
        public ActionResult EWalletRequest()
        {
            #region ddlpaymentmode
            List<SelectListItem> ddlpaymentmode = Common.BindPaymentMode();
            ViewBag.ddlpaymentmode = ddlpaymentmode;
            #endregion
            Wallet obj = new Wallet();
            obj.LoginId = Session["LoginId"].ToString();
            return View(obj);
        }
        [HttpPost]
        public ActionResult SaveEwalletRequest(Wallet obj, HttpPostedFileBase fileProfilePicture)
        {

            try
            {
                if (fileProfilePicture != null && fileProfilePicture.ContentLength > 0)
                {
                    obj.DocumentImg = "/KYCDocuments/" + Guid.NewGuid() + Path.GetExtension(fileProfilePicture.FileName);
                    fileProfilePicture.SaveAs(Path.Combine(Server.MapPath(obj.DocumentImg)));
                }
                obj.AddedBy = Session["Pk_UserId"].ToString();
                obj.DDChequeDate = string.IsNullOrEmpty(obj.DDChequeDate) ? null : Common.ConvertToSystemDate(obj.DDChequeDate, "dd/MM/yyyy");
                DataSet ds = obj.SaveEWalletRequest();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        TempData["Ewallet"] = "Wallet Requested Successfully.";

                    }
                    else
                    {
                        TempData["Ewallet"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();


                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Ewallet"] = ex.Message;

            }
            return RedirectToAction("EWalletRequest", "Wallet");
        }

        public ActionResult EwalletRequestList()
        {
            Wallet objewallet = new Wallet();

            objewallet.Fk_UserId = Session["Pk_UserId"].ToString();

            List<Wallet> lst = new List<Wallet>();
            DataSet ds = objewallet.GetEWalletRequest();
            if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Wallet Objload = new Wallet();
                    Objload.Amount = dr["Amount"].ToString();
                    Objload.RequestCode = dr["RequestCode"].ToString();
                    Objload.PaymentMode = dr["PaymentMode"].ToString();
                    Objload.Status = dr["Status"].ToString();
                    Objload.DocumentImg = dr["ImageURL"].ToString();
                    Objload.BankName = dr["BankName"].ToString();
                    Objload.BankBranch = dr["BankBranch"].ToString();
                    Objload.DDChequeNo = dr["ChequeDDNo"].ToString();
                    Objload.DDChequeDate = dr["ChequeDDDate"].ToString();
                    Objload.AddedOn = dr["CreatedDate"].ToString();
                    lst.Add(Objload);
                }
                objewallet.WalletRequestList = lst;
            }
            return View(objewallet);
        }
        public ActionResult GetMemberName(string LoginId)
        {
            Common obj = new Common();
            obj.ReferBy = LoginId;
            DataSet ds = obj.GetMemberDetails();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {


                obj.DisplayName = ds.Tables[0].Rows[0]["FullName"].ToString();

                obj.Result = "Yes";

            }
            else { obj.Result = "No"; }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EwalletLedger()
        {
            Wallet objewallet = new Wallet();
            //if (Session["LoginId"] == null)
            //{
            //    return RedirectToAction("login_new", "home");
            //}
            objewallet.Fk_UserId = Session["Pk_UserId"].ToString();
            //ViewBag.DigiWalletBalance = "0";
            //ViewBag.DigiCoin = "0";
            //ViewBag.FranchiseeBalance = "0";
            //DataSet dsBal = objewallet.GetDigiWalletBalance();
            //if (dsBal != null && dsBal.Tables.Count > 0)
            //{
            //    if (dsBal.Tables[0].Rows.Count > 0)
            //    {
            //        ViewBag.DigiWalletBalance = dsBal.Tables[0].Rows[0]["Balance"].ToString();
            //    }
            //    //if (dsBal.Tables[1].Rows.Count > 0)
            //    //{
            //    //    ViewBag.DigiCoin = dsBal.Tables[1].Rows[0]["Balance"].ToString();
            //    //}
            //    //if (dsBal.Tables[2].Rows.Count > 0)
            //    //{
            //    //    ViewBag.FranchiseeBalance = dsBal.Tables[2].Rows[0]["Balance"].ToString();

            //    //}
            //}
            List<Wallet> lst = new List<Wallet>();
            DataSet ds = objewallet.EwalletLedger();
            if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Wallet Objload = new Wallet();
                    Objload.Narration = dr["Narration"].ToString();
                    Objload.DrAmount = dr["DrAMount"].ToString();
                    Objload.CrAmount = dr["CrAmount"].ToString();
                    Objload.AddedOn = dr["CurrentDate"].ToString();
                    Objload.EwalletBalance = dr["Balance"].ToString();

                    lst.Add(Objload);
                }
                objewallet.lstewalletledger = lst;
            }
            return View(objewallet);
        }
    }
}