using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GYF.Models;
using GYF.Filter;
using System.Data;
using System.IO;
using BusinessLayer;

namespace GYF.Controllers
{
    public class AssociateController : AssociateBaseController
    {
        // GET: Associate
        public ActionResult AssociateDashBoard(DashBoard model)
        {
            List<DashBoard> list = new List<DashBoard>();
            List<DashBoard> list1 = new List<DashBoard>();
            model.Fk_UserId = Session["Pk_userId"].ToString();
            DataSet ds = model.GetDashboardDetails();


            //   ViewBag.TotalDirect = ds.Tables[1].Rows[0]["TotalDirect"].ToString();
            ViewBag.TotalROI = ds.Tables[1].Rows[0]["TotalROI"].ToString();
            ViewBag.TotalActiveDirect = ds.Tables[1].Rows[0]["TotalActiveDirect"].ToString();
            ViewBag.TotalTeam = ds.Tables[1].Rows[0]["TotalTeam"].ToString();
            ViewBag.TotalActiveSingleLegTeam = ds.Tables[1].Rows[0]["TotalActiveSingleLegTeam"].ToString();

            ViewBag.TotalDirectIncome = ds.Tables[1].Rows[0]["TotalDirectIncome"].ToString();
            ViewBag.TotalSingleLegIncome = ds.Tables[1].Rows[0]["TotalSingleLegIncome"].ToString();
            ViewBag.SingleLegRank = ds.Tables[1].Rows[0]["SingleLegRank"].ToString();
            ViewBag.GrandTotalIncome = ds.Tables[1].Rows[0]["GrandTotalIncome"].ToString();

            if (ViewBag.SingleLegRank == "")
            {
                ViewBag.SingleLegRank = "0";
            }
            ViewBag.TotalLevelIncome = ds.Tables[1].Rows[0]["TotalLevelIncome"].ToString();
            ViewBag.TotalPoolIncome = ds.Tables[1].Rows[0]["TotalPoolIncome"].ToString();
            ViewBag.CurrentIncome = ds.Tables[1].Rows[0]["CurrentIncome"].ToString();
            ViewBag.BankWithdrawal = ds.Tables[1].Rows[0]["BankWithdraw"].ToString();
            ViewBag.MyReward = ds.Tables[1].Rows[0]["MyReward"].ToString();
            //    ViewBag.WalletBalance = ds.Tables[1].Rows[0]["WalletBalance"].ToString();
            //ViewBag.TotalJoinings = ds.Tables[1].Rows[0]["TotalJoinings"].ToString();
            //ViewBag.TodayJoinings = ds.Tables[1].Rows[0]["TodayJoinings"].ToString();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    DashBoard obj = new DashBoard();
                    obj.LoginId = r["LoginId"].ToString();
                    obj.Name = r["Name"].ToString();
                    obj.JoiningDate = r["JoiningDate"].ToString();
                    obj.PermanentDate = r["PermanentDate"].ToString();
                    obj.Package = r["Package"].ToString();
                    obj.Status = r["Status"].ToString();
                    list.Add(obj);
                }
                model.DashboardList = list;
            }


            if (ds != null && ds.Tables.Count > 0 && ds.Tables[2].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[2].Rows)
                {
                    DashBoard obj1 = new DashBoard();
                    //  obj1.pk_singlelegIncomeId = r["pk_singlelegIncomeId"].ToString();
                    obj1.Rank = r["RankName"].ToString();
                    obj1.TargetTeam = r["TargetTeam"].ToString();
                    obj1.MyTeam = r["MyTeam"].ToString();
                    obj1.DirectSponsor = r["DirectSponsor"].ToString();
                    obj1.Amount = r["Amount"].ToString();
                    obj1.ForDays = r["ForDays"].ToString();
                    obj1.SingleLegStatus = r["Status"].ToString();
                    list1.Add(obj1);
                }
                model.SingleLegDashboardList = list1;
            }
            return View(model);
        }

        public ActionResult GetStateCityByPincode(string PinCode)
        {
            Associate model = new Associate();
            try
            {

                model.PinCode = PinCode;



                DataSet ds = model.GetStateCityByPincode();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    model.State = ds.Tables[0].Rows[0]["StateName"].ToString();
                    model.City = ds.Tables[0].Rows[0]["CityName"].ToString();
                    model.Result = "Yes";
                }

            }
            catch (Exception ex)
            {

            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewProfile(Associate model)
        {
            model.Fk_UserId = Session["Pk_userId"].ToString();
            DataSet ds = model.GettingProfile();
            if (ds != null && ds.Tables.Count > 0)
            {
                model.ProductName = ds.Tables[0].Rows[0]["ProductName"].ToString();
                model.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.SponsorID = ds.Tables[0].Rows[0]["SponsorId"].ToString();
                model.SponsorName = ds.Tables[0].Rows[0]["SponsorName"].ToString();
                model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                model.BankHolderName = ds.Tables[0].Rows[0]["BankHolderName"].ToString();
                model.AccountNo = ds.Tables[0].Rows[0]["AccountNo"].ToString();
                model.IFSC = ds.Tables[0].Rows[0]["IFSC"].ToString();
                model.BankBranch = ds.Tables[0].Rows[0]["BankBranch"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.PinCode = ds.Tables[0].Rows[0]["PinCode"].ToString();
                model.State = ds.Tables[0].Rows[0]["State"].ToString();
                model.City = ds.Tables[0].Rows[0]["City"].ToString();
                model.PanNumber = ds.Tables[0].Rows[0]["PanNumber"].ToString();
                model.PAYTMNo = ds.Tables[0].Rows[0]["PAYTMNo"].ToString();
                model.Phonepay = ds.Tables[0].Rows[0]["Phonepay"].ToString();
                model.GooglePay = ds.Tables[0].Rows[0]["GooglePay"].ToString();
                model.NomineName = ds.Tables[0].Rows[0]["NomineName"].ToString();
                model.NomineRealation = ds.Tables[0].Rows[0]["NomineRealation"].ToString();
            }
            return View(model);
        }


        public ActionResult UpdateProfile(Associate model, IEnumerable<HttpPostedFileBase> Image)
        {
            model.Fk_UserId = Session["Pk_userId"].ToString();
            DataSet ds = model.GettingProfile();
            if (ds != null && ds.Tables.Count > 0)
            {
                model.ProductName = ds.Tables[0].Rows[0]["ProductName"].ToString();
                model.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.SponsorID = ds.Tables[0].Rows[0]["SponsorId"].ToString();
                model.SponsorName = ds.Tables[0].Rows[0]["SponsorName"].ToString();
                model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                model.BankHolderName = ds.Tables[0].Rows[0]["BankHolderName"].ToString();
                model.AccountNo = ds.Tables[0].Rows[0]["AccountNo"].ToString();
                model.IFSC = ds.Tables[0].Rows[0]["IFSC"].ToString();
                model.BankBranch = ds.Tables[0].Rows[0]["BankBranch"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.PinCode = ds.Tables[0].Rows[0]["PinCode"].ToString();
                model.State = ds.Tables[0].Rows[0]["State"].ToString();
                model.City = ds.Tables[0].Rows[0]["City"].ToString();
                model.PanNumber = ds.Tables[0].Rows[0]["PanNumber"].ToString();
                model.PAYTMNo = ds.Tables[0].Rows[0]["PAYTMNo"].ToString();
                model.Phonepay = ds.Tables[0].Rows[0]["Phonepay"].ToString();
                model.GooglePay = ds.Tables[0].Rows[0]["GooglePay"].ToString();
                model.NomineName = ds.Tables[0].Rows[0]["NomineName"].ToString();
                model.NomineRealation = ds.Tables[0].Rows[0]["NomineRealation"].ToString();
                model.DOB = ds.Tables[0].Rows[0]["DOB"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.ProfilePic = ds.Tables[0].Rows[0]["ProfilePic"].ToString();
            }



            return View(model);
        }

        [HttpPost]
        [OnAction(ButtonName = "btnUpdateProfile")]
        [ActionName("UpdateProfile")]
        public ActionResult UpdateUserProfile(Associate model, IEnumerable<HttpPostedFileBase> Image)
        {
            model.Fk_UserId = Session["Pk_userId"].ToString();
            model.UpdatedBy = Session["Pk_userId"].ToString();
            try
            {
                foreach (var file in Image)
                {
                    if (file != null && file.ContentLength > 0)
                    {

                        model.ProfilePic = "../AssociatePic/" + Guid.NewGuid() + Path.GetExtension(file.FileName);
                        file.SaveAs(Path.Combine(Server.MapPath(model.ProfilePic)));
                    }
                }
                model.DOB = string.IsNullOrEmpty(model.DOB) ? null : Common.ConvertToSystemDate(model.DOB, "dd/MM/yyyy");
                DataSet ds = model.UpdatingProfile();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["UpdateProfile"] = "Profile Updated Successfully";
                    }
                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        TempData["UpdateProfile"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        return View(model);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["UpdateProfile"] = ex.Message;
                return View(model);
            }


            return View(model);
        }

        public ActionResult ChangePassword(Associate model)
        {
            return View(model);
        }

        [HttpPost]
        [ActionName("ChangePassword")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult SaveChangePassword(Associate model)
        {
            try
            {

                model.UpdatedBy = Session["Pk_userId"].ToString();
                model.OldPassword = Crypto.Encrypt(model.OldPassword);
                model.NewPassword = Crypto.Encrypt(model.NewPassword);
                DataSet ds = model.UpdatePassword();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["ChangePassword"] = "Password is changed successfully";
                    }
                    else
                    {
                        TempData["ChangePassword"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        return View(model);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ChangePassword"] = ex.Message;
                return View(model);
            }
            return RedirectToAction("ChangePassword");

        }


        public ActionResult UpdateBankDetails(Associate model)
        {
            model.Fk_UserId = Session["Pk_userId"].ToString();
            DataSet ds = model.GettingProfile();
            if (ds != null && ds.Tables.Count > 0)
            {
                model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                model.BankHolderName = ds.Tables[0].Rows[0]["BankHolderName"].ToString();
                model.AccountNo = ds.Tables[0].Rows[0]["AccountNo"].ToString();
                model.IFSC = ds.Tables[0].Rows[0]["IFSC"].ToString();
                model.BankBranch = ds.Tables[0].Rows[0]["BankBranch"].ToString();
                model.PAYTMNo = ds.Tables[0].Rows[0]["PAYTMNo"].ToString();
                model.Phonepay = ds.Tables[0].Rows[0]["Phonepay"].ToString();
                model.GooglePay = ds.Tables[0].Rows[0]["GooglePay"].ToString();
            }
            return View(model);
        }

        [HttpPost]
        [OnAction(ButtonName = "btnBankDetails")]
        [ActionName("UpdateBankDetails")]
        public ActionResult BtnUpdateBankDetails(Associate model)
        {
            model.Fk_UserId = Session["Pk_userId"].ToString();
            model.UpdatedBy = Session["Pk_userId"].ToString();
            try
            {
                DataSet ds = model.UpdatingBankDetails();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["UpdateBankDetails"] = "Bank Details Updated";
                    }
                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        TempData["UpdateBankDetails"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        return View(model);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["UpdateBankDetails"] = ex.Message;
                return View(model);
            }


            return View(model);
        }

        public ActionResult DirectReport(Associate model)
        {
            List<Associate> list = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            DataSet ds = model.GetDirectList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Associate obj = new Associate();
                    obj.LoginId = r["LoginId"].ToString();
                    obj.Mobile = r["Mobile"].ToString();
                    obj.JoiningDate = r["JoiningDate"].ToString();
                    obj.PermanentDate = r["PermanentDate"].ToString();
                    obj.Name = r["Name"].ToString();
                    list.Add(obj);
                }
                model.DirectReportList = list;
            }
            return View(model);
        }

        public ActionResult Downline(Associate model)
        {
            List<Associate> list = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            DataSet ds = model.GetDownlineList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Associate obj = new Associate();
                    obj.LoginId = r["LoginId"].ToString();
                    obj.Mobile = r["Mobile"].ToString();
                    obj.JoiningDate = r["JoiningDate"].ToString();
                    obj.RefferBy = r["RefferBy"].ToString();
                    obj.RefferByName = r["RefferByName"].ToString();
                    obj.AssociateName = r["AssociateName"].ToString();
                    obj.ParentLoginId = r["ParentLoginId"].ToString();
                    obj.ParentName = r["ParentName"].ToString();
                    obj.Status = r["Status"].ToString();
                    list.Add(obj);
                }
                model.DownlineList = list;
            }
            return View(model);
        }

        public ActionResult UnusedPin(AdminReports model)
        {
            List<AdminReports> list = new List<AdminReports>();
            model.LoginId = Session["LoginId"].ToString();
            model.Status = "UnUsed";
            DataSet ds = model.GetUnusedPins();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
                    obj.ePinNo = r["ePinNo"].ToString();
                    obj.PinAmount = r["PinAmount"].ToString();
                    obj.AddedOn = r["CreatedDate"].ToString();
                    obj.tOwner = r["tOwner"].ToString();
                    list.Add(obj);
                }
                model.lstdetails = list;
            }
            return View(model);
        }

        public ActionResult UsedPins(AdminReports model)
        {
            List<AdminReports> list = new List<AdminReports>();
            model.LoginId = Session["LoginId"].ToString();
            model.Status = "Used";
            DataSet ds = model.GetUnusedPins();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
                    obj.ePinNo = r["ePinNo"].ToString();
                    obj.PinAmount = r["PinAmount"].ToString();
                    obj.AddedOn = r["CreatedDate"].ToString();
                    obj.Name = r["tRegTo"].ToString();
                    obj.tOwner = r["tOwner"].ToString();
                    obj.UsedDate = r["UsedDate"].ToString();
                    list.Add(obj);
                }
                model.lstdetails = list;
            }
            return View(model);
        }

        public ActionResult TopUp(string ePinNo)
        {
            Associate model = new Associate();
            model.ePinNo = ePinNo;
            return View(model);
        }

        public ActionResult getLoggerName(string LoginId)
        {
            Associate model = new Associate();
            try
            {

                model.LoginId = LoginId;
                DataSet ds = model.GetUserName();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    model.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }

            }
            catch (Exception ex)
            {

            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [OnAction(ButtonName = "btnTopup")]
        [ActionName("TopUp")]
        public ActionResult TopUpUser(Associate model)
        {
            model.AddedBy = Session["Pk_userId"].ToString();
            try
            {
                DataSet ds = model.TopUpUser();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["UnusedPin"] = "Topup Successfully";
                        try
                        {
                            string str2 = BLSMS.TOPUP(ds.Tables[0].Rows[0]["Name"].ToString());
                            BLSMS.SendSMSNew(ds.Tables[0].Rows[0]["Mobile"].ToString(), str2);
                        }
                        catch (Exception ex) { }
                    }
                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        TempData["UnusedPin"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                TempData["UnusedPin"] = ex.Message;

            }
            return RedirectToAction("UnusedPin");
        }

        public ActionResult TransferPin(string ePinNo)
        {
            Associate model = new Associate();
            model.ePinNo = ePinNo;
            return View(model);
        }


        [HttpPost]
        [OnAction(ButtonName = "btnTransfer")]
        [ActionName("TransferPin")]
        public ActionResult TransferUser(Associate model)
        {
            model.ParentLoginId = Session["LoginId"].ToString();
            model.LoginId = model.LoginId;
            if (model.LoginId != model.ParentLoginId)
            {
                model.AddedBy = Session["Pk_userId"].ToString();
                try
                {
                    DataSet ds = model.ePinTransfer();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                        {
                            TempData["UnusedPin"] = "Transfer Successfully";
                        }
                        else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                        {
                            TempData["UnusedPin"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                            return RedirectToAction("UnusedPin");
                        }
                    }
                }
                catch (Exception ex)
                {
                    TempData["UnusedPin"] = ex.Message;
                    return RedirectToAction("UnusedPin");
                }
            }
            else
            {
                TempData["UnusedPin"] = "You cannot Tranfer to Yourself";
            }

            return RedirectToAction("UnusedPin");
        }

        public ActionResult PinTransferReport(Associate model)
        {
            List<Associate> list = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            DataSet ds = model.GetTransferPinReport();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Associate obj = new Associate();
                    obj.ePinNo = r["EpinNo"].ToString();
                    obj.FromId = r["FromId"].ToString();
                    obj.FromName = r["FromName"].ToString();
                    obj.ToId = r["ToId"].ToString();
                    obj.ToName = r["ToName"].ToString();
                    obj.TransferDate = r["TransferDate"].ToString();
                    list.Add(obj);
                }
                model.PinTransferList = list;
            }
            return View(model);
        }

        [HttpPost]
        [OnAction(ButtonName = "GetDetails")]
        [ActionName("PinTransferReport")]
        public ActionResult PinTransferReportDetails(Associate model)
        {
            List<Associate> list = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            DataSet ds = model.GetTransferPinReport();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Associate obj = new Associate();
                    obj.ePinNo = r["EpinNo"].ToString();
                    obj.FromId = r["FromId"].ToString();
                    obj.FromName = r["FromName"].ToString();
                    obj.ToId = r["ToId"].ToString();
                    obj.ToName = r["ToName"].ToString();
                    obj.TransferDate = r["TransferDate"].ToString();
                    list.Add(obj);
                }
                model.PinTransferList = list;
            }
            return View(model);
        }

        public ActionResult DirectIncome(Associate model)
        {
            List<Associate> list = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            DataSet ds = model.GetDirectIncomeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Associate obj = new Associate();
                    obj.CurrentDate = r["CurrentDate"].ToString();
                    obj.FromId = r["FromId"].ToString();
                    obj.Amount = r["Amount"].ToString();
                    obj.Status = r["Status"].ToString();
                    if (obj.Status == "False")
                    {
                        obj.Status = "Unpaid";
                    }
                    else
                    {
                        obj.Status = "Paid";
                    }
                    list.Add(obj);
                }
                model.DirectIncomeList = list;
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("DirectIncome")]
        [OnAction(ButtonName = "btnDetails")]
        public ActionResult FilterDirectIncome(Associate model)
        {
            List<Associate> list = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");

            DataSet ds = model.GetDirectIncomeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Associate obj = new Associate();
                    obj.CurrentDate = r["CurrentDate"].ToString();
                    obj.FromId = r["FromId"].ToString();
                    obj.Amount = r["Amount"].ToString();
                    obj.Status = r["Status"].ToString();
                    if (obj.Status == "False")
                    {
                        obj.Status = "Unpaid";
                    }
                    else
                    {
                        obj.Status = "Paid";
                    }
                    list.Add(obj);
                }
                model.DirectIncomeList = list;
            }
            return View(model);
        }

        public ActionResult SingleLegIncome(Associate model)
        {
            List<Associate> list = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            DataSet ds = model.GetSingleIncomeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Associate obj = new Associate();
                    obj.CurrentDate = r["CurrentDate"].ToString();
                    obj.FromId = r["FromId"].ToString();
                    obj.Amount = r["Amount"].ToString();
                    obj.Status = r["Status"].ToString();
                    obj.Rank = r["RankId"].ToString();
                    if (obj.Status == "False")
                    {
                        obj.Status = "Unpaid";
                    }
                    else
                    {
                        obj.Status = "Paid";
                    }
                    list.Add(obj);
                }
                model.SingleLegIncomeList = list;
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("SingleLegIncome")]
        [OnAction(ButtonName = "btnDetails")]

        public ActionResult FilterSingleLegIncome(Associate model)
        {
            List<Associate> list = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");

            DataSet ds = model.GetSingleIncomeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Associate obj = new Associate();
                    obj.CurrentDate = r["CurrentDate"].ToString();
                    obj.FromId = r["FromId"].ToString();
                    obj.Amount = r["Amount"].ToString();
                    obj.Status = r["Status"].ToString();
                    obj.Rank = r["RankId"].ToString();
                    if (obj.Status == "False")
                    {
                        obj.Status = "Unpaid";
                    }
                    else
                    {
                        obj.Status = "Paid";
                    }
                    list.Add(obj);
                }
                model.SingleLegIncomeList = list;
            }
            return View(model);
        }


        public ActionResult LevelIncome(Associate model)
        {
            List<Associate> list = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            DataSet ds = model.GetLevelIncomeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Associate obj = new Associate();
                    obj.CurrentDate = r["CurrentDate"].ToString();
                    obj.FromId = r["FromId"].ToString();
                    obj.FromName = r["FromName"].ToString();
                    obj.Amount = r["Amount"].ToString();
                    obj.Status = r["Status"].ToString();
                    obj.level = r["Lvl"].ToString();
                    if (obj.Status == "False")
                    {
                        obj.Status = "Unpaid";
                    }
                    else
                    {
                        obj.Status = "Paid";
                    }
                    list.Add(obj);
                }
                model.LevelIncomeList = list;
            }
            return View(model);
        }


        [HttpPost]
        [ActionName("LevelIncome")]
        [OnAction(ButtonName = "btnDetails")]
        public ActionResult FilterLevelIncome(Associate model)
        {
            List<Associate> list = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");

            DataSet ds = model.GetLevelIncomeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Associate obj = new Associate();
                    obj.CurrentDate = r["CurrentDate"].ToString();
                    obj.FromId = r["FromId"].ToString();
                    obj.FromName = r["FromName"].ToString();
                    obj.Amount = r["Amount"].ToString();
                    obj.Status = r["Status"].ToString();
                    obj.level = r["Lvl"].ToString();
                    if (obj.Status == "False")
                    {
                        obj.Status = "Unpaid";
                    }
                    else
                    {
                        obj.Status = "Paid";
                    }
                    list.Add(obj);
                }
                model.LevelIncomeList = list;
            }
            return View(model);
        }

        public ActionResult AutoPoolIncome(Associate model)
        {
            List<Associate> list = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            DataSet ds = model.GetAutoPoolIncomeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Associate obj = new Associate();
                    obj.CurrentDate = r["CurrentDate"].ToString();
                    obj.FromId = r["FromId"].ToString();
                    obj.Amount = r["Amount"].ToString();
                    obj.Status = r["Status"].ToString();
                    obj.Pool = r["Pool"].ToString();
                    if (obj.Status == "False")
                    {
                        obj.Status = "Unpaid";
                    }
                    else
                    {
                        obj.Status = "Paid";
                    }
                    list.Add(obj);
                }
                model.AutopoolList = list;
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("AutoPoolIncome")]
        [OnAction(ButtonName = "btnDetails")]
        public ActionResult FilterAutoPoolIncome(Associate model)
        {
            List<Associate> list = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");

            DataSet ds = model.GetAutoPoolIncomeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Associate obj = new Associate();
                    obj.CurrentDate = r["CurrentDate"].ToString();
                    obj.FromId = r["FromId"].ToString();
                    obj.Amount = r["Amount"].ToString();
                    obj.Status = r["Status"].ToString();
                    obj.Pool = r["Pool"].ToString();
                    if (obj.Status == "False")
                    {
                        obj.Status = "Unpaid";
                    }
                    else
                    {
                        obj.Status = "Paid";
                    }
                    list.Add(obj);
                }
                model.AutopoolList = list;
            }
            return View(model);
        }

        public ActionResult PayoutDetails(Associate model)
        {
            List<Associate> lst1 = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            DataSet ds11 = model.GetPayoutReport();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    Associate Obj = new Associate();

                    Obj.LoginId = r["LoginId"].ToString();
                    Obj.FirstName = r["FirstName"].ToString();
                    Obj.PayoutNo = r["PayoutNo"].ToString();
                    Obj.ClosingDate = r["ClosingDate"].ToString();
                    Obj.DirectIncome = r["DirectIncome"].ToString();
                    Obj.SingleLegIncome = r["SingleLegIncome"].ToString();
                    Obj.LevelIncome = r["LevelIncome"].ToString();
                    Obj.AutoPoolIncome = r["AutoPoolIncome"].ToString();
                    Obj.ROI = r["ROI"].ToString();
                    Obj.GrossAmount = r["GrossAmount"].ToString();
                    Obj.GrossAmount = r["GrossAmount"].ToString();
                    Obj.TDSAmount = r["TDSAmount"].ToString();
                    Obj.AdminFee = r["AdminFee"].ToString();
                    Obj.NetAmount = r["NetAmount"].ToString();
                    Obj.SingleLegIncome = r["SingleLegIncome"].ToString();
                    Obj.LevelIncome = r["LevelIncome"].ToString();
                    Obj.AutoPoolIncome = r["AutoPoolIncome"].ToString();

                    lst1.Add(Obj);
                }
                model.lstPayoutDetail = lst1;
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("PayoutDetails")]
        [OnAction(ButtonName = "btnDetails")]
        public ActionResult FilterPayoutDetails(Associate model)
        {
            List<Associate> lst1 = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            model.PayoutNo = model.PayoutNo;
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");

            DataSet ds11 = model.GetPayoutReport();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    Associate Obj = new Associate();

                    Obj.LoginId = r["LoginId"].ToString();
                    Obj.FirstName = r["FirstName"].ToString();
                    Obj.PayoutNo = r["PayoutNo"].ToString();
                    Obj.ClosingDate = r["ClosingDate"].ToString();
                    Obj.DirectIncome = r["DirectIncome"].ToString();
                    //Obj.SingleLegIncome = r["SingleLegIncome"].ToString();
                    Obj.LevelIncome = r["LevelIncome"].ToString();
                    //Obj.AutoPoolIncome = r["AutoPoolIncome"].ToString();
                    Obj.GrossAmount = r["GrossAmount"].ToString();
                    Obj.TDSAmount = r["TDSAmount"].ToString();
                    //Obj.ROI = r["ROI"].ToString();
                    Obj.AdminFee = r["AdminFee"].ToString();
                    Obj.NetAmount = r["NetAmount"].ToString();
                    Obj.SingleLegIncome = r["SingleLegIncome"].ToString();
                    Obj.LevelIncome = r["LevelIncome"].ToString();
                    Obj.AutoPoolIncome = r["AutoPoolIncome"].ToString();

                    lst1.Add(Obj);
                }
                model.lstPayoutDetail = lst1;
            }
            return View(model);
        }


        public ActionResult PayoutLedger(Associate model)
        {

            List<Associate> lst1 = new List<Associate>();

            model.Fk_UserId = Session["Pk_userId"].ToString();
            DataSet ds11 = model.PayoutLedgerList();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    Associate Obj = new Associate();

                    Obj.TransactionDate = r["TransactionDate"].ToString();
                    Obj.Narration = r["Narration"].ToString();
                    Obj.CrAmount = r["CrAmount"].ToString();
                    Obj.DrAmount = r["DrAMount"].ToString();
                    Obj.PayoutBalance = r["PayoutBalance"].ToString();
                    lst1.Add(Obj);
                }
                model.lstPayoutLedger = lst1;
            }
            return View(model);
        }


        [HttpPost]
        [ActionName("PayoutLedger")]
        [OnAction(ButtonName = "btnDetails")]
        public ActionResult FilterPayoutLedger(Associate model)
        {

            List<Associate> lst1 = new List<Associate>();
            model.Fk_UserId = Session["Pk_userId"].ToString();
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
            DataSet ds11 = model.PayoutLedgerList();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    Associate Obj = new Associate();

                    Obj.TransactionDate = r["TransactionDate"].ToString();
                    Obj.Narration = r["Narration"].ToString();
                    Obj.CrAmount = r["CrAmount"].ToString();
                    Obj.DrAmount = r["DrAMount"].ToString();
                    Obj.PayoutBalance = r["PayoutBalance"].ToString();
                    lst1.Add(Obj);
                }
                model.lstPayoutLedger = lst1;
            }
            return View(model);
        }


        public ActionResult PaidPayoutDetails(Associate model)
        {
            List<Associate> lst1 = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            DataSet ds11 = model.PaidPayoutDetailsList();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    Associate Obj = new Associate();

                    Obj.Amount = r["Amount"].ToString();
                    Obj.Description = r["Description"].ToString();
                    Obj.Paymentdate = r["Paymentdate"].ToString();
                    Obj.TransactionDate = r["TransactionDate"].ToString();
                    Obj.TransactionNo = r["TransactionNo"].ToString();
                    Obj.LoginId = r["LoginId"].ToString();
                    Obj.Name = r["Name"].ToString();
                    lst1.Add(Obj);
                }
                model.PaidPayoutlist = lst1;
            }
            return View(model);
        }


        [HttpPost]
        [ActionName("PaidPayoutDetails")]
        [OnAction(ButtonName = "btnDetails")]
        public ActionResult FilterPaidPayoutDetails(Associate model)
        {
            List<Associate> lst1 = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
            DataSet ds11 = model.PaidPayoutDetailsList();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    Associate Obj = new Associate();

                    Obj.Amount = r["Amount"].ToString();
                    Obj.Description = r["Description"].ToString();
                    Obj.Paymentdate = r["Paymentdate"].ToString();
                    Obj.TransactionDate = r["TransactionDate"].ToString();
                    Obj.TransactionNo = r["TransactionNo"].ToString();
                    Obj.LoginId = r["LoginId"].ToString();
                    Obj.Name = r["Name"].ToString();
                    lst1.Add(Obj);
                }
                model.PaidPayoutlist = lst1;
            }
            return View(model);
        }

        public ActionResult LevelWiseTeam(Associate model)
        {

            List<SelectListItem> ddlLevel = Common.GetLevel();
            ViewBag.ddlLevel = ddlLevel;
            model.LoginId = Session["LoginId"].ToString();

            return View(model);
        }


        [HttpPost]
        [ActionName("LevelWiseTeam")]
        [OnAction(ButtonName = "btnDetails")]
        public ActionResult FilterLevelWiseTeam(Associate model)
        {

            List<SelectListItem> ddlLevel = Common.GetLevel();
            ViewBag.ddlLevel = ddlLevel;

            List<Associate> lst1 = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            model.levelId = model.levelId;
            DataSet ds11 = model.GetLevelWiseReport();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    Associate Obj = new Associate();

                    Obj.LoginId = r["LoginId"].ToString();
                    Obj.Name = r["Name"].ToString();
                    Obj.JoiningDate = r["JoiningDate"].ToString();
                    Obj.PermanentDate = r["PermanentDate"].ToString();
                    Obj.Mobile = r["Mobile"].ToString();
                    Obj.level = r["Lvl"].ToString();
                    lst1.Add(Obj);
                }
                model.LevelWiselist = lst1;
            }
            return View(model);
        }

        public ActionResult Support(Associate model)
        {
            List<Associate> lst1 = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            DataSet ds11 = model.SupportList();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    Associate Obj = new Associate();

                    Obj.Reply = r["ReplyMsg"].ToString();
                    Obj.Subject = r["Subject"].ToString();
                    Obj.SupportTokenId = r["SupportTokenId"].ToString();
                    Obj.ReplyDate = r["ReplyDate"].ToString();
                    Obj.LoginId = r["LoginId"].ToString();
                    Obj.Name = r["Name"].ToString();
                    Obj.Msg = r["Msg"].ToString();
                    lst1.Add(Obj);
                }
                model.SupportListM = lst1;
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Support")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult SaveSupport(Associate model)
        {
            try
            {
                model.AddedBy = Session["Pk_UserId"].ToString();
                model.Fk_UserId = Session["Pk_UserId"].ToString();
                model.TokenId = Common.GenerateRandom();
                DataSet ds = model.SavingSupportQuery();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["Support"] = "Query Send Successfully";
                    }
                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        TempData["Support"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        return View(model);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Support"] = ex.Message;
                return View(model);
            }
            return RedirectToAction("Support");
        }


        public ActionResult Reward(Associate model)
        {
            List<Associate> lst1 = new List<Associate>();
            model.Fk_UserId = Session["Pk_userId"].ToString();
            DataSet ds11 = model.RewardList();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    Associate Obj = new Associate();

                    Obj.pk_RewardId = r["pk_RewardId"].ToString();
                    Obj.TargetLevel = r["TargetLevel"].ToString();
                    Obj.TargetDirect = r["TargetDirect"].ToString();
                    Obj.TargetDays = r["TargetDays"].ToString();
                    Obj.Status = r["Status"].ToString();
                    Obj.RewardImage = r["RewardImage"].ToString();
                    Obj.RewardAmount = r["RewardAmount"].ToString();
                    lst1.Add(Obj);
                }
                model.Rewardlist = lst1;
            }
            return View(model);
        }



        public ActionResult PayoutWalletRequest(Associate model)
        {
            List<Associate> lst1 = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            model.Fk_UserId = Session["Pk_userId"].ToString();
            DataSet ds11 = model.GetPayoutBalance();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                model.Balance = ds11.Tables[0].Rows[0]["Balance"].ToString();
            }

            DataSet ds1 = model.GetPayoutRequest();

            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds1.Tables[0].Rows)
                {
                    Associate Obj = new Associate();

                    Obj.LoginId = r["LoginId"].ToString();
                    Obj.Name = r["Name"].ToString();
                    Obj.Pk_RequestId = r["Pk_RequestId"].ToString();
                    // Obj.Fk_UserId = r["FK_UserId"].ToString();
                    Obj.Amount = r["Amount"].ToString();
                    Obj.RequestedDate = r["RequestedDate"].ToString();
                    Obj.Status = r["Status"].ToString();
                    lst1.Add(Obj);
                }
                model.PayoutRequestlist = lst1;
            }
            return View(model);
        }


        [HttpPost]
        [ActionName("PayoutWalletRequest")]
        [OnAction(ButtonName = "btnRequest")]
        public ActionResult RequestWallet(Associate model)
        {
            try
            {
                model.AddedBy = Session["Pk_UserId"].ToString();
                DataSet ds = model.PayoutRequest();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["PayoutWalletRequest"] = "Request Successfully";
                    }
                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        TempData["PayoutWalletRequest"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        return View(model);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["PayoutWalletRequest"] = ex.Message;
                return View(model);
            }
            return RedirectToAction("PayoutWalletRequest");
        }


        public ActionResult AutoPoolStructure(Associate model)
        {
            List<Associate> list = new List<Associate>();
            List<SelectListItem> ddlStep = Common.GetAutoPool();
            ViewBag.ddlStep = ddlStep;
            model.LoginId = Session["LoginId"].ToString();
            DataSet ds = model.getUserAutoPool();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Associate obj = new Associate();
                    model.LoginId = r["LoginId"].ToString();
                    model.JoiningDate = r["JoiningDate"].ToString();
                    model.Name = r["Name"].ToString();
                    model.entrydate = r["entrydate"].ToString();
                    model.EntryAmount = r["EntryAmount"].ToString();
                    model.step = r["Step"].ToString();
                    list.Add(obj);
                }
                model.ListAutopool = list;
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("AutoPoolStructure")]
        [OnAction(ButtonName = "btnDetails")]
        public ActionResult AutoPoolFilter(Associate model)
        {
            List<Associate> list = new List<Associate>();
            List<SelectListItem> ddlStep = Common.GetAutoPool();
            ViewBag.ddlStep = ddlStep;
            model.LoginId = Session["LoginId"].ToString();
            DataSet ds = model.getUserAutoPool();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Associate obj = new Associate();
                    obj.LoginId = r["LoginId"].ToString();
                    obj.JoiningDate = r["JoiningDate"].ToString();
                    obj.Name = r["Name"].ToString();
                    obj.entrydate = r["entrydate"].ToString();
                    obj.EntryAmount = r["EntryAmount"].ToString();
                    obj.step = r["Step"].ToString();
                    obj.PermanentDate = r["PermanentDate"].ToString();
                    list.Add(obj);
                }
                model.ListAutopool = list;
            }

            return View(model);
        }

        public ActionResult MultiplePinTransfer(Associate model)
        {

            List<Associate> list = new List<Associate>();
            model.LoginId = Session["LoginId"].ToString();
            model.Status = "UnUsed";
            DataSet ds = model.GetUnusedPins();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Associate obj = new Associate();
                    obj.ePinNo = r["ePinNo"].ToString();
                    obj.PinAmount = r["PinAmount"].ToString();
                    obj.AddedOn = r["CreatedDate"].ToString();
                    obj.tOwner = r["tOwner"].ToString();
                    list.Add(obj);
                }
                model.MultiplePinList = list;
            }
            return View(model);
        }

        [HttpPost]
        [OnAction(ButtonName = "btnMutipleTranser")]
        [ActionName("MultiplePinTransfer")]
        public ActionResult TransferMultiplePin(Associate model)
        {
            model.ParentLoginId = Session["LoginId"].ToString();

            if (model.ToLoginId != model.ParentLoginId)
            {
                try
                {
                    string hdrows = Request["hdRows"].ToString();
                    string chkselect = "";
                    model.LoginId = model.ToLoginId;
                    for (int i = 1; i < int.Parse(hdrows); i++)
                    {
                        try
                        {



                            chkselect = Request["chkSelect_ " + i];
                            if (chkselect == "on")
                            {
                                model.ePinNo = Request["ePinNo_ " + i].ToString();


                                DataSet ds = model.ePinTransfer();
                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                                    {
                                        TempData["MultiplePinTransfer"] = "Transfer Successfully";
                                    }
                                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                                    {
                                        TempData["MultiplePinTransfer"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                                        return RedirectToAction("MultiplePinTransfer");
                                    }
                                }
                            }




                        }
                        catch { chkselect = "0"; }
                    }
                }
                catch (Exception ex)
                {
                    TempData["MultiplePinTransfer"] = ex.Message;
                    return RedirectToAction("MultiplePinTransfer");
                }
            }
            else
            {
                TempData["MultiplePinTransfer"] = "You Can't transfer on the same Id";
            }
            return RedirectToAction("MultiplePinTransfer");
        }
        public ActionResult ROI(Associate model)
        {
            try
            {
                List<Associate> list = new List<Associate>();
                model.LoginId = Session["LoginId"].ToString();
                DataSet ds = model.Roidetails();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Associate obj = new Associate();
                        obj.LoginId = r["LoginId"].ToString();
                        obj.NoofDays = r["NoOfDays"].ToString();
                        obj.ROI = r["ROI"].ToString();
                        obj.ROIDate = r["roidate"].ToString();
                        list.Add(obj);
                    }
                    model.ListROI = list;
                }
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult UploadKYC()
        {
            Associate model = new Associate();
            model.Pk_RequestId = Session["Pk_userId"].ToString();
            Associate obj = new Associate();
            DataSet ds = model.GetKYCDocuments();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                obj.AdharNumber = ds.Tables[0].Rows[0]["AdharNumber"].ToString();
                obj.AdharImage = ds.Tables[0].Rows[0]["AdharImage"].ToString();
                obj.AdharStatus = "Status : " + ds.Tables[0].Rows[0]["AdharStatus"].ToString();
                obj.PanNumber = ds.Tables[0].Rows[0]["PanNumber"].ToString();
                obj.PanImage = ds.Tables[0].Rows[0]["PanImage"].ToString();
                obj.PanStatus = "Status : " + ds.Tables[0].Rows[0]["PanStatus"].ToString();
                obj.DocumentNumber = ds.Tables[0].Rows[0]["DocumentNumber"].ToString();
                obj.DocumentImage = ds.Tables[0].Rows[0]["DocumentImage"].ToString();
                obj.DocumentStatus = "Status : " + ds.Tables[0].Rows[0]["DocumentStatus"].ToString();
            }
            return View(obj);
        }
        [HttpPost]
        [ActionName("UploadKYC")]
        [OnAction(ButtonName = "btnUpdateAdhar")]
        public ActionResult KYCDocuments(IEnumerable<HttpPostedFileBase> postedFile, Associate obj)
        {
            string FormName = "";
            string Controller = "";

            try
            {
                foreach (var file in postedFile)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        //E:\BitBucket\TejInfraZone\TejInfra\files\assets\images\

                        obj.AdharImage = "/KYCDocuments/" + Guid.NewGuid() + Path.GetExtension(file.FileName);
                        file.SaveAs(Path.Combine(Server.MapPath(obj.AdharImage)));

                    }

                }

                obj.Pk_RequestId = Session["Pk_userId"].ToString();
                obj.ActionStatus = "Adhar";
                DataSet ds = obj.UploadKYCDocuments();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["DocumentUpload"] = "Document uploaded successfully..";
                        FormName = "UploadKYC";
                        Controller = "Associate";
                    }
                    else
                    {
                        TempData["DocumentUpload"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        FormName = "UploadKYC";
                        Controller = "Associate";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["DocumentUpload"] = ex.Message;
                FormName = "UploadKYC";
                Controller = "Associate";
            }
            return RedirectToAction(FormName, Controller);
        }
        [HttpPost]
        [ActionName("UploadKYC")]
        [OnAction(ButtonName = "btnUpdatePan")]
        public ActionResult KYCDocuments2(IEnumerable<HttpPostedFileBase> postedFile, Associate obj)
        {
            string FormName = "";
            string Controller = "";

            try
            {
                foreach (var file in postedFile)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        //E:\BitBucket\TejInfraZone\TejInfra\files\assets\images\

                        obj.PanImage = "/KYCDocuments/" + Guid.NewGuid() + Path.GetExtension(file.FileName);
                        file.SaveAs(Path.Combine(Server.MapPath(obj.PanImage)));


                    }

                }

                obj.Pk_RequestId = Session["Pk_userId"].ToString();
                obj.ActionStatus = "Pan";
                DataSet ds = obj.UploadKYCDocuments();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["DocumentUpload"] = "Document uploaded successfully..";
                        FormName = "UploadKYC";
                        Controller = "Associate";
                    }
                    else
                    {
                        TempData["DocumentUpload"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        FormName = "UploadKYC";
                        Controller = "Associate";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["DocumentUpload"] = ex.Message;
                FormName = "UploadKYC";
                Controller = "Associate";
            }
            return RedirectToAction(FormName, Controller);
        }
        [HttpPost]
        [ActionName("UploadKYC")]
        [OnAction(ButtonName = "btnUpdateDoc")]
        public ActionResult KYCDocuments3(IEnumerable<HttpPostedFileBase> postedFile, Associate obj)
        {
            string FormName = "";
            string Controller = "";

            try
            {
                foreach (var file in postedFile)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        //E:\BitBucket\TejInfraZone\TejInfra\files\assets\images\

                        obj.DocumentImage = "/KYCDocuments/" + Guid.NewGuid() + Path.GetExtension(file.FileName);
                        file.SaveAs(Path.Combine(Server.MapPath(obj.DocumentImage)));


                    }

                }

                obj.Pk_RequestId = Session["Pk_userId"].ToString();
                obj.ActionStatus = "Doc";
                DataSet ds = obj.UploadKYCDocuments();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["DocumentUpload"] = "Document uploaded successfully..";
                        FormName = "UploadKYC";
                        Controller = "Associate";
                    }
                    else
                    {
                        TempData["DocumentUpload"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        FormName = "UploadKYC";
                        Controller = "Associate";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["DocumentUpload"] = ex.Message;
                FormName = "UploadKYC";
                Controller = "Associate";
            }
            return RedirectToAction(FormName, Controller);
        }
        public ActionResult Tree()
        {
            ViewBag.Fk_UserId = Session["Pk_userId"].ToString();
            return View();
        }
        public ActionResult Registration()
        {

            Home model = new Home();
            model.UserId= Session["Pk_userId"].ToString();
            #region ddlgender
            List<SelectListItem> ddlgender = Common.BindGender();
            ViewBag.ddlgender = ddlgender;
            #endregion ddlgender
            List<SelectListItem> Package = new List<SelectListItem>();
            Package.Add(new SelectListItem { Text = "Select", Value = "0" });
            DataSet ds2 = model.GetProductList();
            if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds2.Tables[0].Rows)
                {
                    Package.Add(new SelectListItem { Text = r["ProductName"].ToString(), Value = r["PK_ProductID"].ToString() });

                }
            }
            ViewBag.Package = Package;


            DataSet ds3 = model.WalletBalanceNew();
            if (ds3 != null && ds3.Tables.Count > 0 && ds3.Tables[0].Rows.Count > 0)
            {
                ViewBag.WalletBalanceNew = ds3.Tables[0].Rows[0]["BalanceAmount"].ToString();
            }




            return View(model);
        }
        public ActionResult ConfirmRegistration()
        {
            return View();
        }

        public ActionResult RegistrationAction(string SponsorId, string FirstName, string LastName, string Email, string MobileNo,  string Gender, string PinCode, string Password,string PackageId)
        {
            Home obj = new Home();
            #region ddlgender
            List<SelectListItem> ddlgender = Common.BindGender();
            ViewBag.ddlgender = ddlgender;
            #endregion ddlgender
            List<SelectListItem> Package = new List<SelectListItem>();
            Package.Add(new SelectListItem { Text = "Select", Value = "0" });
            DataSet ds2 = obj.GetProductList();
            if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds2.Tables[0].Rows)
                {
                    Package.Add(new SelectListItem { Text = r["ProductName"].ToString(), Value = r["PK_ProductID"].ToString() });

                }
            }
            ViewBag.Package = Package;
            try
            {
                obj.SponsorId = SponsorId;
                obj.FirstName = FirstName;
                obj.LastName = LastName;
                obj.Email = Email;
                obj.MobileNo = MobileNo;
                obj.Gender = Gender;
                obj.RegistrationBy = Session["Pk_userId"].ToString();
                obj.PinCode = PinCode;
                obj.PackageId = PackageId;
                //obj.PanNo = PanNo;
                //obj.AdharNo = AdharNo;
                obj.Password = Crypto.Encrypt(Password);
                obj.Fk_ParentId = Session["Pk_userId"].ToString();

                DataSet ds = obj.Registration();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        Session["Login_Id"] = ds.Tables[0].Rows[0]["LoginId"].ToString();
                        Session["DisplayName"] = ds.Tables[0].Rows[0]["Name"].ToString();
                        Session["PassWord"] = Crypto.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString());
                        Session["Transpassword"] = Crypto.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString());

                        obj.Response = "1";
                        try
                        {
                            string str2 = BLSMS.Registration(ds.Tables[0].Rows[0]["Name"].ToString(), ds.Tables[0].Rows[0]["LoginId"].ToString(), Crypto.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString()));
                            BLSMS.SendSMSNew(MobileNo, str2);
                        }
                        catch (Exception ex) { }

                    }
                    else
                    {
                        obj.Response = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                obj.Response = ex.Message;
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }


        public ActionResult BonusDetails()
        {
            return View();
        }

        public ActionResult FounderClub()
        {
            return View();
        }


    }

}