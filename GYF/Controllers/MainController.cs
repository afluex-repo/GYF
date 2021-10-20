using BusinessLayer;
using GYF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GYF.Controllers
{
    public class MainController : Controller
    {
        // GET: Main


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CompanyOverView()
        {
            return View();
        }
        public ActionResult VissionMission()
        {
            return View();
        }
        public ActionResult BankDetails()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult Login()
        {
            Session.Abandon();
            return View();
        }

        public ActionResult LoginAction(Home obj)
        {
            string FormName = "";
            string Controller = "";
            try
            {
                Home Modal = new Home();
                DataSet ds = obj.Login();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        if ((ds.Tables[0].Rows[0]["UserType"].ToString() == "Associate"))
                        {
                            if (obj.Password == Crypto.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString()))
                            {
                                Session["LoginId"] = ds.Tables[0].Rows[0]["LoginId"].ToString();
                                Session["Pk_userId"] = ds.Tables[0].Rows[0]["Pk_userId"].ToString();
                                Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();
                                Session["FullName"] = ds.Tables[0].Rows[0]["FullName"].ToString();
                                Session["Password"] = ds.Tables[0].Rows[0]["Password"].ToString();
                                Session["TransPassword"] = ds.Tables[0].Rows[0]["TransPassword"].ToString();
                                Session["Profile"] = ds.Tables[0].Rows[0]["Profile"].ToString();

                                FormName = "AssociateDashboard";
                                Controller = "Associate";
                                //Controller = "Associate";
                                // TempData["Login"] = "Site has been closed . Please Contact to Administrator...";
                            }
                            else
                            {
                                TempData["Login"] = "Incorrect Password";
                                FormName = "Login";
                                Controller = "Main";

                            }
                        }
                        else if (ds.Tables[0].Rows[0]["UserType"].ToString() == "Admin")
                        {
                            Session["LoginId"] = ds.Tables[0].Rows[0]["LoginId"].ToString();
                            Session["Pk_AdminId"] = ds.Tables[0].Rows[0]["Pk_adminId"].ToString();
                            Session["UsertypeName"] = ds.Tables[0].Rows[0]["UsertypeName"].ToString();
                            Session["Name"] = ds.Tables[0].Rows[0]["Name"].ToString();

                            //  TempData["Login"] = "Site has been closed . Please Contact to Administrator...";
                            FormName = "AdminDashBoard";
                            Controller = "Admin";

                        }
                        else
                        {
                            TempData["Login"] = "Incorrect LoginId Or Password";
                            FormName = "Login";
                            Controller = "Main";
                        }
                    }
                    else
                    {
                        TempData["Login"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        FormName = "Login";
                        Controller = "Main";
                    }

                }

                else
                {
                    TempData["Login"] = "Incorrect LoginId Or Password";
                    FormName = "Login";
                    Controller = "Main";

                }
            }
            catch (Exception ex)
            {
                TempData["Login"] = ex.Message;
                FormName = "Login";
                Controller = "Main";
            }

            return RedirectToAction(FormName, Controller);



        }

        public virtual PartialViewResult Menu()
        {
            Home Menu = null;

            if (Session["_Menu"] != null)
            {
                Menu = (Home)Session["_Menu"];
            }
            else
            {

                Menu = Home.GetMenus(Session["PK_AdminID"].ToString(), Session["UsertypeName"].ToString()); // pass employee id here
                Session["_Menu"] = Menu;
            }
            return PartialView("_Menu", Menu);
        }



        public ActionResult Registration(string Pid)
        {
            Home obj = new Home();
            if (Pid != "" && Pid != null)
            {

                Common obj1 = new Common();
                obj1.ReferBy = Pid;
                DataSet ds = obj1.GetMemberDetails();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        obj.SponsorName = ds.Tables[0].Rows[0]["Name"].ToString();
                        obj.SponsorId = Pid;

                    }
                    else
                    {

                    }

                }
                else { }

            }

            return View(obj);
        }

        public ActionResult GetSponserDetails(string ReferBy)
        {
            Common obj = new Common();
            obj.ReferBy = ReferBy;
            DataSet ds = obj.GetMemberDetails();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                {
                    obj.DisplayName = ds.Tables[0].Rows[0]["Name"].ToString();

                    obj.Result = "Yes";
                }
                else
                {
                    obj.Result = "Invalid SponsorId";
                }

            }
            else { obj.Result = "Invalid SponsorId"; }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RegistrationAction(string SponsorId, string FirstName, string LastName, string Email, string MobileNo, string PinCode, string Leg, string Password)

        {
            Home obj = new Home();

            try
            {
                obj.SponsorId = SponsorId;
                obj.FirstName = FirstName;
                obj.LastName = LastName;
                obj.Email = Email;
                obj.MobileNo = MobileNo;

                obj.RegistrationBy = "Web";

                obj.PinCode = PinCode;
                obj.Leg = Leg;

                obj.Password = Crypto.Encrypt(Password);
                DataSet ds = obj.Registration();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
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

        public ActionResult ConfirmRegistration()
        {
            return View();
        }

        public ActionResult GetStateCity(string PinCode)
        {
            Common obj = new Common();
            obj.PinCode = PinCode;
            DataSet ds = obj.GetStateCity();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                {
                    obj.State = ds.Tables[0].Rows[0]["StateName"].ToString();
                    obj.City = ds.Tables[0].Rows[0]["CityName"].ToString();
                    obj.Result = "1";
                }
                else
                {
                    obj.Result = "Invalid PinCode";
                }
            }
            else
            {
                obj.Result = "Invalid PinCode";
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetNewsList()
        {
            Admin model = new Admin();

            List<Admin> list = new List<Admin>();
            DataSet ds = model.GetNewsList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.Result = "1";

            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public virtual PartialViewResult NewsMasterList()
        {
            Admin model = new Admin();

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
            return PartialView("NewsMasterList", model);
        }
        public ActionResult Product(Home Model)
        {
            try
            {
                List<Admin> list = new List<Admin>();
                Model.FromDate = string.IsNullOrEmpty(Model.FromDate) ? null : Common.ConvertToSystemDate(Model.FromDate, "dd/MM/yyyy");
                Model.ToDate = string.IsNullOrEmpty(Model.ToDate) ? null : Common.ConvertToSystemDate(Model.ToDate, "dd/MM/yyyy");
                DataSet ds = Model.GetProductList();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Admin obj = new Admin();
                        obj.ProductName = r["ProductName"].ToString();
                        obj.EncrptProductId = Crypto.Encrypt(r["PK_ProductId"].ToString());
                        obj.ProductPrice = r["ProductPrice"].ToString();
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
        public ActionResult GeneratDailyROIAF(Associate model)
        {
            DataSet ds = model.GeneratDailyROI();
            return View(model);
        }
        public ActionResult AutoDistributePaymentAF(Associate model)
        {
            DataSet ds = model.AutoDistributePayment();
            return View(model);
        }
        public ActionResult CalculateLevelIncomeDailyAF(Associate model)
        {
            DataSet ds = model.CalculateLevelIncome();
            return View(model);

        }


        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [ActionName("ChangePassword")]
        public ActionResult ChangePassword(Admin model)
        {
            try
            {
                model.UpdatedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = model.ChangePassword();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["Error"] = "Password Changed  Successfully";
                    }
                    else
                    {
                        TempData["Error"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("ChangePassword", "Main");
        }
        public ActionResult Banner()
        {
            Admin obj = new Admin();
            List<Admin> lst = new List<Admin>();
            DataSet ds = obj.GetBannerImage();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Admin model = new Admin();
                    model.BannerImage = "/BannerImage/"+r["BannerImage"].ToString();
                    lst.Add(model);
                }
                obj.lstBanner = lst;
            }
            return View(obj);
        }
    }
}