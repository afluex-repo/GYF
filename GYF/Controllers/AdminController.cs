using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GYF.Models;
using GYF.Filter;
using System.Data;
using System.IO;

namespace GYF.Controllers
{
    public class AdminController : AdminBaseController
    {
        // GET: Admin
        public ActionResult AdminDashBoard(Admin model)
        {
            DataSet ds = model.GetAdminDashboard();
            if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count > 0)
            {

                ViewBag.TotalDrAmount = ds.Tables[0].Rows[0]["TotalDrAmount"].ToString();
                ViewBag.TotalCrAmount = ds.Tables[0].Rows[0]["TotalCrAmount"].ToString();

                if (ViewBag.TotalDrAmount == "")
                {
                    ViewBag.TotalDrAmount = 0;
                }
                if (ViewBag.TotalCrAmount == "")
                {
                    ViewBag.TotalCrAmount = 0;
                }
                ViewBag.ActiveAssociate = ds.Tables[0].Rows[0]["ActiveAssociate"].ToString();
                ViewBag.InActiveAssociate = ds.Tables[0].Rows[0]["InActiveAssociate"].ToString();

                ViewBag.BlockedAssociate = ds.Tables[0].Rows[0]["BlockedAssociate"].ToString();
                ViewBag.TotalAssociate = ds.Tables[0].Rows[0]["TotalAssociate"].ToString();
            }

            return View(model);
        }

        public ActionResult CreatePin(Admin model)
        {

            #region BindPaymentmode


            List<SelectListItem> ddlpaymentmode = new List<SelectListItem>();
            ddlpaymentmode.Add(new SelectListItem { Text = "Select Payment Mode", Value = "0" });
            DataSet ds2 = model.GetPaymentMode();
            if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds2.Tables[0].Rows)
                {



                    ddlpaymentmode.Add(new SelectListItem { Text = r["PaymentMode"].ToString(), Value = r["PK_paymentID"].ToString() });

                }
            }

            ViewBag.ddlpaymentmode = ddlpaymentmode;

            #endregion BindPaymentmode

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

        public ActionResult getLoggerName(string LoginId)
        {
            Admin model = new Admin();
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
        [OnAction(ButtonName = "btnCreatePin")]
        [ActionName("CreatePin")]
        public ActionResult SaveCreatePin(Admin model)
        {            
            model.AddedBy = Session["Pk_AdminId"].ToString();


            #region BindPaymentmode

            Admin obj = new Admin();
            List<SelectListItem> ddlpaymentmode = new List<SelectListItem>();
            ddlpaymentmode.Add(new SelectListItem { Text = "Select Payment Mode", Value = "0" });
            DataSet ds2 = obj.GetPaymentMode();
            if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds2.Tables[0].Rows)
                {
                    
                    ddlpaymentmode.Add(new SelectListItem { Text = r["PaymentMode"].ToString(), Value = r["PK_paymentID"].ToString() });

                }
            }

            ViewBag.ddlpaymentmode = ddlpaymentmode;

            #endregion BindPaymentmode

            #region BindddlPackageName


            List<SelectListItem> ddlPackageName = new List<SelectListItem>();
            ddlPackageName.Add(new SelectListItem { Text = "Select Package", Value = "0" });
            DataSet ds1 = obj.GetPackage();
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds1.Tables[0].Rows)
                {

                    ddlPackageName.Add(new SelectListItem { Text = r["ProductName"].ToString(), Value = r["PK_ProductID"].ToString() });

                }
            }

            ViewBag.ddlPackageName = ddlPackageName;

            #endregion BindddlPackageName

            try
            {
                model.TransactionDate = string.IsNullOrEmpty(model.TransactionDate) ? null : Common.ConvertToSystemDate(model.TransactionDate, "dd/MM/yyyy");
                DataSet ds = model.CreatePinByAdmin();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["CreatePin"] = "Pin Created Successfully   ";
                    }
                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        TempData["CreatePin"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        return View(model);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["CreatePin"] = ex.Message;
                return View(model);
            }

            return RedirectToAction("CreatePin");
        }

       
        public ActionResult UnusedPin(Admin model)
        {
            List<Admin> list = new List<Admin>();
            model.LoginId = null;/*Session["LoginId"].ToString();*/
            model.Status = null;
            DataSet ds = model.GetUnusedPins();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Admin obj = new Admin();
                    obj.ePinNo = r["ePinNo"].ToString();
                    obj.PinAmount = r["PinAmount"].ToString();
                    obj.AddedOn = r["CreatedDate"].ToString();

                    list.Add(obj);
                }
                model.lstdetails = list;
            }
            return View(model);
        }

        public ActionResult UsedPins(Admin model)
        {
            #region BindddlStatus
                        
            List<SelectListItem> ddlStatus = Common.GetStatus();
            ViewBag.ddlStatus = ddlStatus;
            #endregion

            List<Admin> list = new List<Admin>();
            model.LoginId = null;/*Session["LoginId"].ToString();*/
            model.Status = null;
            DataSet ds = model.GetUnusedPins();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Admin obj = new Admin();
                    obj.ePinNo = r["ePinNo"].ToString();
                    obj.PinAmount = r["PinAmount"].ToString();
                    obj.AddedOn = r["CreatedDate"].ToString();
                    obj.Name = r["tRegTo"].ToString();
                    obj.Status = r["PinStatus"].ToString();
                    obj.tOwner = r["tOwner"].ToString();
                    obj.UsedDate = r["UsedDate"].ToString();
                    list.Add(obj);
                }
                model.lstdetails = list;
            }
            return View(model);
        }


        [HttpPost]
        [OnAction(ButtonName = "GetPinList")]
        [ActionName("UsedPins")]
        public ActionResult GetPinList(Admin model)
        {
            List<Admin> list = new List<Admin>();
            model.LoginId = model.LoginId;
            model.Status = model.Status;
            DataSet ds = model.GetUnusedPins();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Admin obj = new Admin();
                    obj.ePinNo = r["ePinNo"].ToString();
                    obj.PinAmount = r["PinAmount"].ToString();
                    obj.AddedOn = r["CreatedDate"].ToString();
                    obj.Name = r["tRegTo"].ToString();
                    obj.Status = r["PinStatus"].ToString();
                    obj.tOwner = r["tOwner"].ToString();
                    obj.UsedDate = r["UsedDate"].ToString();
                    list.Add(obj);
                }
                model.lstdetails = list;
            }


            #region BindddlStatus

            List<SelectListItem> ddlStatus = Common.GetStatus();
            ViewBag.ddlStatus = ddlStatus;
            #endregion

            return View(model);
        }


        public ActionResult TopUp(string ePinNo)
        {
            Admin model = new Admin();
            model.ePinNo = ePinNo;
            return View(model);
        }
        
        [HttpPost]
        [OnAction(ButtonName = "btnTopup")]
        [ActionName("TopUp")]
        public ActionResult TopUpUser(Admin model)
        {
            model.AddedBy = Session["Pk_AdminId"].ToString();
            try
            {
                DataSet ds = model.TopUpUser();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["UsedPins"] = "Topup Successfully";
                    }
                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        TempData["UsedPins"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        return RedirectToAction("UsedPins");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["UsedPins"] = ex.Message;
                return RedirectToAction("UsedPins");
            }
            return RedirectToAction("UsedPins");
        }



        public ActionResult NewsMaster(string PK_NewsID)
        {
            Admin model = new Admin();

            if (PK_NewsID != null)
            {

                model.PK_NewsID = PK_NewsID;
                DataSet ds = model.GetNewsList();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    model.PK_NewsID = ds.Tables[0].Rows[0]["PK_NewsID"].ToString();
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                    model.ShortDescription = ds.Tables[0].Rows[0]["ShortDescription"].ToString();
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();

                }
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("NewsMaster")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult SaveNewsMaster(Admin model)
        {
            try
            {
                model.AddedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = model.SavingNews();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["NewsMaster"] = "Saved Successfully";
                    }
                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        TempData["NewsMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                TempData["NewsMaster"] = ex.Message;
            }
            return RedirectToAction("NewsMaster");
        }


        public ActionResult NewsMasterList(Admin model)
        {
            List<Admin> list = new List<Admin>();
            DataSet ds = model.GetNewsList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Admin obj1 = new Admin();
                    obj1.PK_NewsID = r["PK_NewsID"].ToString();
                    obj1.Title = r["Title"].ToString();
                    obj1.ShortDescription = r["ShortDescription"].ToString();
                    obj1.Description = r["Description"].ToString();
                    list.Add(obj1);
                }
                model.lstNewsList = list;
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("NewsMaster")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateNewsMaster(Admin model)
        {
            try
            {
                model.UpdatedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = model.UpdatingNewsMaster();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["NewsMasterList"] = "Updated Successfully";
                    }
                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        TempData["NewsMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        return View(model);
                    }
                }
            }
            catch (Exception ex)
            {

                TempData["NewsMaster"] = ex.Message;
                return View(model);
            }
            return RedirectToAction("NewsMasterList");
        }

        
        public ActionResult DeleteNewsMasterList(string PK_NewsID)
        {
            Admin model = new Admin();
            try
            {
                model.UpdatedBy = Session["Pk_AdminId"].ToString();
                model.PK_NewsID = PK_NewsID;
                DataSet ds = model.DeletingNewsMaster();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["NewsMasterList"] = "Deleted Successfully";
                    }
                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        TempData["NewsMasterList"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["NewsMasterList"] = ex.Message;
            }
            return RedirectToAction("NewsMasterList");
        }
        #region Product
        public ActionResult ProductMaster(string id)
        {
            Admin obj = new Admin();
            if (id!=null)
            {
                
                try
                {
                    obj.EncrptProductId = Crypto.Decrypt(id);
                    DataSet ds = obj.ProductDetailsbyId();
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                       
                        obj.ProductName = ds.Tables[0].Rows[0]["ProductName"].ToString();
                        obj.EncrptProductId = ds.Tables[0].Rows[0]["PK_ProductId"].ToString();
                        obj.ProductPrice = ds.Tables[0].Rows[0]["ProductPrice"].ToString();
                        obj.ProductImage = ds.Tables[0].Rows[0]["ProductImage"].ToString();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
              
            }
            return View(obj);
        }
        [HttpPost]
        [OnAction(ButtonName ="Product")]
        [ActionName("ProductMaster")]
        public ActionResult ProductSave(Admin Model, HttpPostedFileBase postedfile)
        {
            try
            {
                if (postedfile == null)
                {

                    Model.ProductImage = Model.ProductImage;
                }
                else
                {
                    HttpFileCollectionBase files = Request.Files;
                    DataTable dt = new DataTable { Columns = { new DataColumn("path") } };
                    for (int i = 0; i < files.Count; i++)
                    {
                        postedfile = files[i];
                        Model.ProductImage = "../Websitecss/images/product/" + Guid.NewGuid() + Path.GetExtension(postedfile.FileName);
                        dt.Rows.Add(postedfile.FileName);
                        postedfile.SaveAs(Path.Combine(Server.MapPath(Model.ProductImage)));
                    }
                }
                Model.EncrptProductId = Model.EncrptProductId;
                Model.AddedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = Model.SaveProduct();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["Product"] = "Product Save Successfully";
                        Model.ProductPrice = string.Empty;
                        Model.ProductName = string.Empty;
                      
                }
                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        TempData["Product"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }


            }
            catch (Exception ex)
            {

                TempData["Product"] = ex.Message;
            }
            return View(Model);
        }
        [HttpPost]
        [OnAction(ButtonName = "Update")]
        [ActionName("ProductMaster")]
        public ActionResult ProductUpdate(Admin Model, HttpPostedFileBase postedfile)
        {
            try
            {
                if (postedfile == null)
                {

                    Model.ProductImage = Model.ProductImage;
                }
                else
                {
                    HttpFileCollectionBase files = Request.Files;
                    DataTable dt = new DataTable { Columns = { new DataColumn("path") } };
                    for (int i = 0; i < files.Count; i++)
                    {
                        postedfile = files[i];
                        Model.ProductImage = "../Websitecss/images/product/" + Guid.NewGuid() + Path.GetExtension(postedfile.FileName);
                        dt.Rows.Add(postedfile.FileName);
                        postedfile.SaveAs(Path.Combine(Server.MapPath(Model.ProductImage)));
                    }
                }
                Model.EncrptProductId = Model.EncrptProductId;
                Model.UpdatedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = Model.UpdateProduct();
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                        {
                            TempData["Product"] = "Product Updated Successfully";
                        }
                        else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                        {
                            TempData["Product"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
               

            }
            catch (Exception ex)
            {

                TempData["Product"] = ex.Message;
            }
          
            return View(Model);
        }
        public ActionResult ProductList()
        {
            return View();
        }
        [HttpPost]
        [OnAction(ButtonName = "btnDetails")]
        [ActionName("ProductList")]
        public ActionResult ProductDetails(Admin Model)
        {
            try
            {
                List<Admin> list = new List<Admin>();
                Model.FromDate = string.IsNullOrEmpty(Model.FromDate) ? null : Common.ConvertToSystemDate(Model.FromDate, "dd/MM/yyyy");
                Model.ToDate = string.IsNullOrEmpty(Model.ToDate) ? null : Common.ConvertToSystemDate(Model.ToDate, "dd/MM/yyyy");
                DataSet ds = Model.GetProduct();
                if(ds!=null && ds.Tables[0].Rows.Count>0)
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Admin obj = new Admin();
                        obj.ProductName = r["ProductName"].ToString();
                        obj.EncrptProductId= Crypto.Encrypt(r["PK_ProductId"].ToString());
                        obj.ProductPrice = r["ProductPrice"].ToString();
                        obj.ProductDate = r["ProductDate"].ToString();
                        obj.ProductImage = r["ProductImage"].ToString();
                        list.Add(obj);
                    }
                    Model.lstProduct = list;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(Model);
        }
        public ActionResult Edit(string id)
        {
            Admin obj = new Admin();
            try
            {
                obj.EncrptProductId = Crypto.Decrypt(id);
                DataSet ds = obj.ProductDetailsbyId();
                if(ds !=null && ds.Tables[0].Rows.Count>0)
                {
                    obj.ProductName=
                    obj.ProductName = ds.Tables[0].Rows[0]["ProductName"].ToString();
                    obj.EncrptProductId = ds.Tables[0].Rows[0]["PK_ProductId"].ToString();
                    obj.ProductPrice = ds.Tables[0].Rows[0]["ProductPrice"].ToString();
                    obj.ProductImage = ds.Tables[0].Rows[0]["ProductImage"].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(obj);
        }
        public ActionResult ProductDelete(string Id)
        {
            Admin model = new Admin();
            try
            {
                model.UpdatedBy = Session["Pk_AdminId"].ToString();
                model.EncrptProductId = Crypto.Decrypt(Id);
                DataSet ds = model.DeletedProduct();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["Product"] = "Deleted Successfully";
                    }
                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        TempData["Product"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Product"] = ex.Message;
            }
            return RedirectToAction("ProductList");
        }
        public ActionResult DeleteImage(string Id)
        {
            Admin model = new Admin();
            try
            {
                model.UpdatedBy = Session["Pk_AdminId"].ToString();
                model.EncrptProductId =(Id);
                DataSet ds = model.DeletedProductImage();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["Product"] = "Deleted Successfully";
                    }
                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        TempData["Product"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Product"] = ex.Message;
            }
            return RedirectToAction("ProductList");
        }
        #endregion
        public ActionResult UploadKYCList()
        {
            List<SelectListItem> ddlKYCStatus = Common.BindKYCStatus();
            ViewBag.ddlKYCStatus = ddlKYCStatus;
            List<Admin> lst = new List<Admin>();

            return View();
        }
        [HttpPost]
        [ActionName("UploadKYCList")]
        [OnAction(ButtonName = "btnSearch")]
        public ActionResult AssociateListForKYC(Admin model)
        {
            List<SelectListItem> ddlKYCStatus = Common.BindKYCStatus();
            ViewBag.ddlKYCStatus = ddlKYCStatus;
            List<Admin> lst = new List<Admin>();

            DataSet ds = model.ListForKYC();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Admin obj = new Admin();
                    obj.PK_DocumentID = r["PK_UserDocumentID"].ToString();
                    obj.LoginId = r["LoginId"].ToString();
                    obj.DisplayName = r["FirstName"].ToString();
                    obj.DocumentNumber = r["DocumentNumber"].ToString();
                    obj.DocumentType = r["DocumentType"].ToString();
                    obj.DocumentImage = (r["DocumentImage"].ToString());
                    obj.Status = (r["Status"].ToString());

                    lst.Add(obj);
                }
                model.lstdetails = lst;
            }
            return View(model);
        }
        public ActionResult ApproveKYC(string Id, string DocumentType, string LoginID)
        {
            string FormName = "";
            string Controller = "";
            try
            {
                List<SelectListItem> ddlKYCStatus = Common.BindKYCStatus();
                ViewBag.ddlKYCStatus = ddlKYCStatus;
                List<Admin> lst = new List<Admin>();

                Admin model = new Admin();
                model.LoginId = LoginID;
                model.PK_DocumentID = Id;
                model.DocumentType = DocumentType;
                model.Status = "Approved";
                model.AddedBy = Session["Pk_AdminId"].ToString();

                DataSet ds = new DataSet();
                ds = model.ApproveKYC();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["KYCVerification"] = "KYC Approved Successfully..";
                        FormName = "UploadKYCList";
                        Controller = "Admin";
                    }
                    else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        TempData["KYCVerification"] = "Error : " + ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        FormName = "UploadKYCList";
                        Controller = "Admin";
                    }
                }

            }
            catch (Exception ex)
            {
                TempData["KYCVerification"] = ex.Message;
                FormName = "UploadKYCList";
                Controller = "Admin";
            }
            return RedirectToAction(FormName, Controller);
        }
        public ActionResult EwallwetRequestList(Admin model)
        {
            List<Admin> lst1 = new List<Admin>();

            DataSet ds11 = model.GEtEwalletRequestList();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    Admin Obj = new Admin();

                    Obj.LoginId = r["LoginId"].ToString();
                    Obj.Name = r["Name"].ToString();
                    Obj.Pk_RequestId = r["Pk_RequestId"].ToString();
                    Obj.Amount = r["Amount"].ToString();
                    Obj.RequestedDate = r["RequestedDate"].ToString();
                    Obj.Status = r["Status"].ToString();
                    lst1.Add(Obj);
                }
                model.EwalletRequestList = lst1;
            }
            return View(model);
        }
        public ActionResult ApproveRequest(string Pk_RequestId)
        {
            Admin model = new Admin();
            model.Pk_RequestId = Pk_RequestId;
            try
            {

                model.Status = "Approved";
                model.AddedBy = Session["Pk_AdminId"].ToString();

                DataSet ds = model.ApproveDeclineEwalletRequest();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["EWalletRequest"] = "Approved Successfully";
                    }
                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        TempData["EWalletRequest"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        return View(model);
                    }
                }


            }
            catch (Exception ex)
            {
                TempData["EWalletRequest"] = ex.Message;
                return View(model);
            }
            return RedirectToAction("EwallwetRequestList");
        }


        public ActionResult DeclineRequest(string Pk_RequestId)
        {
            Admin model = new Admin();
            model.Pk_RequestId = Pk_RequestId;
            try
            {

                model.Status = "Declined";
                model.AddedBy = Session["Pk_AdminId"].ToString();

                DataSet ds = model.ApproveDeclineEwalletRequest();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["EWalletRequest"] = "Declined Successfully";
                    }
                    else if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        TempData["EWalletRequest"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        return View(model);
                    }
                }


            }
            catch (Exception ex)
            {
                TempData["EWalletRequest"] = ex.Message;
                return View(model);
            }
            return RedirectToAction("EwallwetRequestList");
        }
    }
}