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

    }
}