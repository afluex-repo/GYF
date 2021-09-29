using GYF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GYF.Filter;
using System.IO;

using System.Data;

namespace GYF.Controllers
{
    public class AdminReportsController : AdminBaseController
    {
        public ActionResult GetStateCityByPincode(string PinCode)
        {
            AdminReports model = new AdminReports();
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
        // GET: AdminReports
        public ActionResult AssociateList(AdminReports model)
        {
            List<AdminReports> list = new List<AdminReports>();
            DataSet ds = model.GettingAssociateList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
                    obj.Password = Crypto.Decrypt(r["Password"].ToString());
                    obj.LoginId = r["LoginId"].ToString();
                    obj.Name = r["Name"].ToString();
                    obj.Mobile = r["Mobile"].ToString();
                    obj.Email = r["Email"].ToString();
                    obj.SponsorID = r["SponsorId"].ToString();
                    obj.SponsorName = r["SponsorName"].ToString();
                    obj.Fk_UserId = r["PK_UserId"].ToString();
                    obj.IsBlocked = r["IsBlocked"].ToString();
                    obj.PermanentDate = r["PermanentDate"].ToString();
                    list.Add(obj);
                }
                model.AssociateList = list;
            }
            return View(model);
        }

        [HttpPost]
        [OnAction(ButtonName = "btnDetails")]
        [ActionName("AssociateList")]
        public ActionResult FilterAssociateList(AdminReports model)
        {
            List<AdminReports> list = new List<AdminReports>();
            model.LoginId = model.LoginId;
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
            DataSet ds = model.GettingAssociateList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
                    obj.Password = Crypto.Decrypt(r["Password"].ToString());
                    obj.LoginId = r["LoginId"].ToString();
                    obj.Name = r["Name"].ToString();
                    obj.Mobile = r["Mobile"].ToString();
                    obj.Email = r["Email"].ToString();
                    obj.SponsorID = r["SponsorId"].ToString();
                    obj.SponsorName = r["SponsorName"].ToString();
                    obj.Fk_UserId = r["PK_UserId"].ToString();
                    obj.IsBlocked = r["IsBlocked"].ToString();
                    list.Add(obj);
                }
                model.AssociateList = list;
            }
            return View(model);
        }

        public ActionResult BlockAssociate(string Fk_UserId)
        {
            AdminReports model = new AdminReports();
            model.Fk_UserId = Fk_UserId;
            model.UpdatedBy = Session["Pk_AdminId"].ToString();
            DataSet ds = model.BlockUser();
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                {
                    TempData["AssociateList"] = "Associate Blocked";
                }
                else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                {
                    TempData["AssociateList"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            return RedirectToAction("AssociateList");
        }

        public ActionResult UnBlockAssociate(string Fk_UserId)
        {
            AdminReports model = new AdminReports();
            model.Fk_UserId = Fk_UserId;
            model.UpdatedBy = Session["Pk_AdminId"].ToString();
            DataSet ds = model.UnBlockUser();
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                {
                    TempData["AssociateList"] = "Associate UnBlocked";
                }
                else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                {
                    TempData["AssociateList"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            return RedirectToAction("AssociateList");
        }

        public ActionResult AssociateProfile(string Fk_UserId)
        {
            AdminReports model = new AdminReports();
            model.Fk_UserId = Fk_UserId;
            DataSet ds = model.GettingProfile();
            if (ds != null && ds.Tables.Count > 0)
            {
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
                model.Fk_UserId = ds.Tables[0].Rows[0]["PK_UserId"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                model.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                model.DOB = ds.Tables[0].Rows[0]["DOB"].ToString();
            }
            return View(model);
        }

        [HttpPost]
        [OnAction(ButtonName = "btnUpdateProfile")]
        [ActionName("AssociateProfile")]
        public ActionResult UpdateAssociateProfile(AdminReports model, IEnumerable<HttpPostedFileBase> Image)
        {
            model.Fk_UserId = model.Fk_UserId;
            model.UpdatedBy = Session["Pk_AdminId"].ToString();
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
                        TempData["AssociateList"] = "Profile Updated Successfully";
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


            return RedirectToAction("AssociateList");
        }


        public ActionResult DirectReport(AdminReports model)

        {
            return View(model);
        }



        [HttpPost]
        [OnAction(ButtonName = "GetDirect")]
        [ActionName("DirectReport")]
        public ActionResult GetDirectList(AdminReports model)
        {
            List<AdminReports> list = new List<AdminReports>();
            model.LoginId = model.LoginId;
            DataSet ds = model.GetDirectList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
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


        public ActionResult Downline(AdminReports model)
        {
            return View(model);
        }


        [HttpPost]
        [OnAction(ButtonName = "GetDownline")]
        [ActionName("Downline")]
        public ActionResult GetDownlineList(AdminReports model)
        {
            List<AdminReports> list = new List<AdminReports>();
            model.LoginId = model.LoginId;
            DataSet ds = model.GetDownlineList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
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

        public ActionResult TopupReport(AdminReports model)
        {

            List<AdminReports> list = new List<AdminReports>();
            DataSet ds = model.GetTopupreport();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
                    obj.LoginId = r["LoginId"].ToString();
                    obj.Name = r["Name"].ToString();
                    obj.UpgradtionDate = r["UpgradtionDate"].ToString();
                    obj.Package = r["Package"].ToString();
                    obj.Amount = r["Amount"].ToString();
                    obj.BV = r["BV"].ToString();
                    obj.TopupBy = r["TopupBy"].ToString();
                    obj.Pk_InvestmentId = r["Pk_InvestmentId"].ToString();
                    obj.Status = r["Status"].ToString();
                    list.Add(obj);
                }
                model.TopupList = list;
            }

            #region BindddlPackageName


            List<SelectListItem> ddlPackageName = new List<SelectListItem>();
            ddlPackageName.Add(new SelectListItem { Text = "Select Package", Value = "0" });
            DataSet ds1 = model.GetPackage();
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds1.Tables[0].Rows)
                {

                    ddlPackageName.Add(new SelectListItem { Text = r["ProductName"].ToString(), Value = r["PK_ProductID"].ToString() });

                }
            }

            ViewBag.ddlPackageName = ddlPackageName;

            #endregion BindddlPackageName
            return View(model);
        }

        [HttpPost]
        [OnAction(ButtonName = "GetDetails")]
        [ActionName("TopupReport")]
        public ActionResult GetTopupReport(AdminReports model)
        {
            #region BindddlPackageName

            AdminReports mod = new AdminReports();
            List<SelectListItem> ddlPackageName = new List<SelectListItem>();
            ddlPackageName.Add(new SelectListItem { Text = "Select Package", Value = "0" });
            DataSet ds1 = mod.GetPackage();
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds1.Tables[0].Rows)
                {

                    ddlPackageName.Add(new SelectListItem { Text = r["ProductName"].ToString(), Value = r["PK_ProductID"].ToString() });

                }
            }

            ViewBag.ddlPackageName = ddlPackageName;

            #endregion BindddlPackageName

            List<AdminReports> list = new List<AdminReports>();
            model.LoginId = model.LoginId;
            if (model.Fk_PackageId == "0")
            {
                model.Package = null;
            }
            else
            {
                model.Package = model.Fk_PackageId;
            }
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
            DataSet ds = model.GetTopupreport();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
                    obj.LoginId = r["LoginId"].ToString();
                    obj.Name = r["Name"].ToString();
                    obj.UpgradtionDate = r["UpgradtionDate"].ToString();
                    obj.Package = r["Package"].ToString();
                    obj.Amount = r["Amount"].ToString();
                    obj.BV = r["BV"].ToString();
                    obj.TopupBy = r["TopupBy"].ToString();
                    obj.Pk_InvestmentId = r["Pk_InvestmentId"].ToString();
                    obj.Status = r["Status"].ToString();
                    list.Add(obj);
                }
                model.TopupList = list;
            }


            return View(model);
        }


        public ActionResult PinTransferReport(AdminReports model)
        {
            List<AdminReports> list = new List<AdminReports>();
            DataSet ds = model.GetTransferPinReport();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
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
        public ActionResult PinTransferReportDetails(AdminReports model)
        {
            List<AdminReports> list = new List<AdminReports>();

            DataSet ds = model.GetTransferPinReport();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
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


        public ActionResult DirectIncome(AdminReports model)
        {
            List<AdminReports> list = new List<AdminReports>();
            DataSet ds = model.GetDirectIncomeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
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
        public ActionResult FilterDirectIncome(AdminReports model)
        {
            List<AdminReports> list = new List<AdminReports>();
            model.LoginId = model.LoginId;
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");

            DataSet ds = model.GetDirectIncomeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
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

        public ActionResult SingleLegIncome(AdminReports model)
        {
            List<AdminReports> list = new List<AdminReports>();

            DataSet ds = model.GetSingleIncomeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
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

        public ActionResult FilterSingleLegIncome(AdminReports model)
        {
            List<AdminReports> list = new List<AdminReports>();
            model.LoginId = model.LoginId;
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");

            DataSet ds = model.GetSingleIncomeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
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


        public ActionResult LevelIncome(AdminReports model)
        {
            List<AdminReports> list = new List<AdminReports>();

            DataSet ds = model.GetLevelIncomeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
                    obj.CurrentDate = r["CurrentDate"].ToString();
                    obj.FromId = r["FromId"].ToString();
                    obj.Amount = r["Amount"].ToString();
                    obj.FromName = r["FromName"].ToString();
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
        public ActionResult FilterLevelIncome(AdminReports model)
        {
            List<AdminReports> list = new List<AdminReports>();
            model.LoginId = model.LoginId;
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");

            DataSet ds = model.GetLevelIncomeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
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

        public ActionResult AutoPoolIncome(AdminReports model)
        {
            List<AdminReports> list = new List<AdminReports>();
            DataSet ds = model.GetAutoPoolIncomeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
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
        public ActionResult FilterAutoPoolIncome(AdminReports model)
        {
            List<AdminReports> list = new List<AdminReports>();
            model.LoginId = model.LoginId;
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");

            DataSet ds = model.GetAutoPoolIncomeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    AdminReports obj = new AdminReports();
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


        public ActionResult PayoutDetails(AdminReports model)
        {
            List<AdminReports> lst1 = new List<AdminReports>();
            DataSet ds11 = model.GetPayoutReport();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    AdminReports Obj = new AdminReports();

                    Obj.LoginId = r["LoginId"].ToString();
                    Obj.ROI = r["ROI"].ToString();
                    Obj.FirstName = r["FirstName"].ToString();
                    Obj.PayoutNo = r["PayoutNo"].ToString();
                    Obj.ClosingDate = r["ClosingDate"].ToString();
                    Obj.DirectIncome = r["DirectIncome"].ToString();
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
        public ActionResult FilterPayoutDetails(AdminReports model)
        {
            List<AdminReports> lst1 = new List<AdminReports>();
            model.LoginId = model.LoginId;
            model.PayoutNo = model.PayoutNo;
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");

            DataSet ds11 = model.GetPayoutReport();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    AdminReports Obj = new AdminReports();

                    Obj.LoginId = r["LoginId"].ToString();
                    Obj.FirstName = r["FirstName"].ToString();
                    Obj.ROI = r["ROI"].ToString();
                    Obj.PayoutNo = r["PayoutNo"].ToString();
                    Obj.ClosingDate = r["ClosingDate"].ToString();
                    Obj.DirectIncome = r["DirectIncome"].ToString();
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


        public ActionResult PayPayout(AdminReports model)
        {
            List<AdminReports> lst1 = new List<AdminReports>();
            DataSet ds11 = model.GetBalancePayoutforPayment();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    AdminReports Obj = new AdminReports();

                    Obj.LoginId = r["LoginId"].ToString();
                    Obj.Pk_UserId = r["Pk_UserId"].ToString();
                    Obj.Name = r["Name"].ToString();
                    Obj.BankHolderName = r["BankHolderName"].ToString();
                    Obj.AccountNo = r["MemberAccNo"].ToString();
                    Obj.IFSC = r["IFSCCode"].ToString();
                    Obj.BankBranch = r["MemberBranch"].ToString();
                    Obj.BankName = r["MemberBankName"].ToString();
                    Obj.Amount = r["Amount"].ToString();
                    lst1.Add(Obj);
                }
                model.lstPayoutDetail = lst1;
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("PayPayout")]
        [OnAction(ButtonName = "btnDetails")]
        public ActionResult FilterPayPayout(AdminReports model)
        {
            List<AdminReports> lst1 = new List<AdminReports>();
            model.LoginId = model.LoginId;
            DataSet ds11 = model.GetBalancePayoutforPayment();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    AdminReports Obj = new AdminReports();

                    Obj.LoginId = r["LoginId"].ToString();
                    Obj.Pk_UserId = r["Pk_UserId"].ToString();
                    Obj.Name = r["Name"].ToString();
                    Obj.BankHolderName = r["BankHolderName"].ToString();
                    Obj.AccountNo = r["MemberAccNo"].ToString();
                    Obj.IFSC = r["IFSCCode"].ToString();
                    Obj.BankBranch = r["MemberBranch"].ToString();
                    Obj.BankName = r["MemberBankName"].ToString();
                    Obj.Amount = r["Amount"].ToString();
                    lst1.Add(Obj);
                }
                model.lstPayoutDetail = lst1;
            }
            return View(model);
        }



        [HttpPost]
        [OnAction(ButtonName = "PayAmount")]
        [ActionName("PayPayout")]
        public ActionResult SavePayPayout(AdminReports model)
        {

            try
            {
                string hdrows = Request["hdRows"].ToString();
                string chkselect = "";

                for (int i = 1; i < int.Parse(hdrows); i++)
                {
                    try
                    {

                        model.AddedBy = Session["Pk_AdminId"].ToString();

                        chkselect = Request["chkSelect_ " + i].ToString();


                        model.Payamount = Request["payamount_ " + i].ToString();
                        model.Pk_UserId = Request["Pk_UserId_ " + i].ToString();
                        model.TransactionNo = Request["TransactionNo_ " + i].ToString();
                        model.TransactionDate = Request["TransactionDate_ " + i].ToString();
                        if (string.IsNullOrWhiteSpace(model.Payamount) || string.IsNullOrWhiteSpace(model.TransactionNo) || string.IsNullOrWhiteSpace(model.TransactionDate))
                        {

                        }
                        else
                        {
                            DataSet ds = model.PayPayout();
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                                {
                                    TempData["PayPayout"] = "Pay Successfully";
                                }
                                else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                                {
                                    TempData["PayPayout"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                                    return View(model);
                                }
                            }
                        }
                    }
                    catch { chkselect = "0"; }
                }
            }
            catch (Exception ex)
            {
                TempData["PayPayout"] = ex.Message;
                return View(model);
            }

            return RedirectToAction("PayPayout");
        }

        public ActionResult PaidPayoutDetails(AdminReports model)
        {
            List<AdminReports> lst1 = new List<AdminReports>();
            DataSet ds11 = model.PaidPayoutDetailsList();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    AdminReports Obj = new AdminReports();

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
        public ActionResult FilterPaidPayoutDetails(AdminReports model)
        {
            List<AdminReports> lst1 = new List<AdminReports>();
            model.LoginId = model.LoginId;
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
            DataSet ds11 = model.PaidPayoutDetailsList();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    AdminReports Obj = new AdminReports();

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

        public ActionResult PayoutLedger(AdminReports model)
        {

            List<AdminReports> lst1 = new List<AdminReports>();
            DataSet ds11 = model.PayoutLedgerList();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    AdminReports Obj = new AdminReports();

                   // Obj.Fk_UserId = r["FK_UserId"].ToString();
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
        public ActionResult FilterPayoutLedger(AdminReports model)
        {

            List<AdminReports> lst1 = new List<AdminReports>();
            model.LoginId = model.LoginId;
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
            DataSet ds11 = model.PayoutLedgerList();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    AdminReports Obj = new AdminReports();
                    
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


        public ActionResult LevelWiseTeam(AdminReports model)
        {

            List<SelectListItem> ddlLevel = Common.GetLevel();
            ViewBag.ddlLevel = ddlLevel;

            return View(model);
        }


        [HttpPost]
        [ActionName("LevelWiseTeam")]
        [OnAction(ButtonName = "btnDetails")]
        public ActionResult FilterLevelWiseTeam(AdminReports model)
        {

            List<SelectListItem> ddlLevel = Common.GetLevel();
            ViewBag.ddlLevel = ddlLevel;

            List<AdminReports> lst1 = new List<AdminReports>();
            model.LoginId = model.LoginId;
            model.levelId = model.levelId;
            DataSet ds11 = model.GetLevelWiseReport();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    AdminReports Obj = new AdminReports();

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

        public ActionResult Support(AdminReports model)
        {

            List<AdminReports> lst1 = new List<AdminReports>();
            DataSet ds11 = model.SupportList();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    AdminReports Obj = new AdminReports();

                    Obj.LoginId = r["LoginId"].ToString();
                    Obj.Name = r["Name"].ToString();
                    Obj.PK_SupportId = r["PK_SupportId"].ToString();
                    Obj.Fk_UserId = r["FK_UserId"].ToString();
                    Obj.Subject = r["Subject"].ToString();
                    Obj.Msg = r["Msg"].ToString();
                    Obj.SupportTokenId = r["SupportTokenId"].ToString();
                    Obj.Status = r["Status"].ToString();
                    lst1.Add(Obj);
                }
                model.lstReplySupport = lst1;
            }
            return View(model);
        }

        public ActionResult SupportReply(string SupportTokenId, string Subject, string Msg, string Fk_UserId, string LoginId, string Name)
        {
            AdminReports model = new AdminReports();
            model.SupportTokenId = SupportTokenId;
            model.Subject = Subject;
            model.Msg = Msg;
            model.LoginId = LoginId;
            model.Name = Name;
            model.Fk_UserId = Fk_UserId;
            return View(model);
        }

        [HttpPost]
        [ActionName("SupportReply")]
        [OnAction(ButtonName = "btnReply")]
        public ActionResult ReplyToUser(AdminReports model)
        {
            try
            {
                model.AddedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = model.ReplyingMsg();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["Support"] = "Message Sent";
                    }
                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        TempData["SupportReply"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        return View(model);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["SupportReply"] = ex.Message;
            }
            return RedirectToAction("Support");
        }

        public ActionResult PayoutWalletRequest(AdminReports model)
        {
            List<AdminReports> lst1 = new List<AdminReports>();

            DataSet ds11 = model.GetPayoutRequest();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    AdminReports Obj = new AdminReports();

                    Obj.LoginId = r["LoginId"].ToString();
                    Obj.Name = r["Name"].ToString();
                    Obj.Pk_RequestId = r["Pk_RequestId"].ToString();
                    Obj.Amount = r["Amount"].ToString();
                    Obj.RequestedDate = r["RequestedDate"].ToString();
                    Obj.Status = r["Status"].ToString();
                    lst1.Add(Obj);
                }
                model.PayoutRequestlist = lst1;
            }
            return View(model);
        }

        public ActionResult ApproveRequest(string Pk_RequestId)
        {
            AdminReports model = new AdminReports();
            model.Pk_RequestId = Pk_RequestId;
            try
            {

                model.Status = "Approved";
                model.AddedBy = Session["Pk_AdminId"].ToString();

                DataSet ds = model.ApproveDeclinePayoutRequest();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["PayoutWalletRequest"] = "Approved Successfully";
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


        public ActionResult DeclineRequest(string Pk_RequestId)
        {
            AdminReports model = new AdminReports();
            model.Pk_RequestId = Pk_RequestId;
            try
            {

                model.Status = "Declined";
                model.AddedBy = Session["Pk_AdminId"].ToString();

                DataSet ds = model.ApproveDeclinePayoutRequest();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["PayoutWalletRequest"] = "Declined Successfully";
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


        public ActionResult AutoPoolStructure(AdminReports model)
        {

            List<SelectListItem> ddlStep = Common.GetAutoPool();
            ViewBag.ddlStep = ddlStep;

            return View(model);
        }


        [HttpPost]
        [ActionName("AutoPoolStructure")]
        [OnAction(ButtonName = "GetAutopoolStructure")]
        public ActionResult AutoPoolStructureFilter(AdminReports model)
        {


            List<SelectListItem> ddlStep = Common.GetAutoPool();
            ViewBag.ddlStep = ddlStep;

            List<AdminReports> lst1 = new List<AdminReports>();
            model.LoginId = model.LoginId;
            model.step = model.step;
            DataSet ds11 = model.GetAutoPoolFilter();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    AdminReports Obj = new AdminReports();

                    Obj.LoginId = r["LoginId"].ToString();
                    Obj.Name = r["Name"].ToString();
                    Obj.JoiningDate = r["JoiningDate"].ToString();
                    Obj.PermanentDate = r["PermanentDate"].ToString();
                    Obj.entrydate = r["entrydate"].ToString();
                    Obj.EntryAmount = r["EntryAmount"].ToString();
                    Obj.step = r["Step"].ToString();
                    lst1.Add(Obj);
                }
                model.ListAutopool = lst1;
            }
            return View(model);
        }
        public ActionResult ROI()
        {
            return View();
        }
        [HttpPost]
        [OnAction(ButtonName ="Details")]
        [ActionName("ROI")]
        public ActionResult RoiDetails(AdminReports model)
        {
            try
            {
                List<AdminReports> list = new List<AdminReports>();
                model.LoginId = model.LoginId;
                model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
                model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
                DataSet ds = model.GetRoiDetails();
                if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                {
                    foreach(DataRow r in ds.Tables[0].Rows)
                    {
                        AdminReports obj = new AdminReports();
                        obj.LoginId = r["LoginId"].ToString();
                        obj.RoIDate = r["roidate"].ToString();
                        obj.NoOfDays = r["noofdays"].ToString();
                        obj.ROI = r["ROI"].ToString();
                        list.Add(obj);
                    }
                    model.ListRoiDetails = list;
                }
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
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