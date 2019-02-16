using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativeBox.Domain.Interface;
using CreativeBox.Domain.Entity;
using CreativeBox.Utility;
using log4net;
using Newtonsoft.Json;
using System.IO;

namespace CreativeBox.Controllers
{
    public class UserController : BaseController
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(UserController));  //Declaring Log4Net

        protected IUser user { get; set; }
        protected IOrder Order { get; set; }

        public UserController(IUser iuser, IOrder iorder)
        {
            user = iuser;
            Order = iorder;
        }

        public ActionResult Dashboard()
        {
            try
            {
                //List<DataPoint> dataPoints = Order.SelectOrderReport();
                //ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
                //return View();
                if (Session["LoginUser"] == null)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    List<DataPoint> dataPoints = Order.SelectOrderReport();
                    ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
                    return View();
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: User
        public ActionResult Index()
        {
            List<UserEntity> objlist = user.SelectUserList();
            return View(objlist);
        }

        [HttpGet]
        public ActionResult UserDetailPartial(int Userid)
        {
            try
            {
                UserEntity obj = new UserEntity();
                if (Userid > 0)
                {
                    obj = user.FetchUserDetail(Userid);
                }

                ViewBag.objUserEntity = obj;

                return PartialView();

            }
            catch (Exception ex)
            {
                return PartialView();
            }
        }

        [HttpPost]
        public ActionResult OperationUser(UserEntity objUserEntity)
        {
            try
            {
                int returnvalue = user.OperationUser(objUserEntity);

                if (returnvalue > 0)
                    return Json(new { success = true, responseText = "Success!" }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { success = false, responseText = "Fail!" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteUser(UserEntity objUserEntity)
        {
            try
            {
                int returnvalue = user.OperationUserDelete(objUserEntity);

                if (returnvalue > 0)
                    return Json(new { success = true, responseText = "Success!" }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { success = false, responseText = "Fail!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserEntity objUserEntity)
        {
            try
            {
                if (objUserEntity.UserName != null && objUserEntity.Password != null && objUserEntity.UserName.Trim() != "" && objUserEntity.Password.Trim() != "")
                {
                    UserEntity objLogin = new UserEntity();
                    objLogin = user.UserLogin(objUserEntity.UserName.Trim(), objUserEntity.Password.Trim()); // user.FetchUserDetail(1);

                    if (objLogin.UserId > 0)
                    {
                        Session["LoginUser"] = objLogin;
                        return Json(new { success = true, responseText = "You are success fully logged in!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, responseText = "You have entered an invalid username or password!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = false, responseText = "Please enter username or password!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Logout()
        {
            string selPortal = null;
            Session.Abandon();

            //return RedirectToAction("eFiling");
            return RedirectToAction("Login", "User", new { refr = selPortal });
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserEntity objUserEntity)
        {
            try
            {
                int returnvalue = user.OperationUser(objUserEntity);

                if (returnvalue > 0)
                {
                    return Json(new { success = true, responseText = "Success!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Fail!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(UserEntity objUserEntity)
        {
            try
            {
                UserEntity objLogin = new UserEntity();
                objLogin = user.FetchUserDetail(0);

                if (objLogin.UserId > 0)
                {
                    return Json(new { success = true, responseText = "Success!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Fail!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(UserEntity objUserEntity)
        {
            try
            {
                UserEntity obj = new UserEntity();
                obj = (UserEntity)Session["LoginUser"];
                objUserEntity.UserId = obj.UserId;
                Int32 retVal = user.UserChangePassword(objUserEntity);

                if (retVal > 0)
                {
                    return Json(new { success = true, responseText = "Success!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Old password is not match!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult MyProfile()
        {
            if (Session["LoginUser"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                UserEntity obj = new UserEntity();
                obj = (UserEntity)Session["LoginUser"];
                ViewBag.objUserEntity = obj;

                return View();

            }
        }

        [HttpPost]
        public ActionResult MyProfile(UserEntity objUserEntity)
        {
            try
            {
                int returnvalue = user.OperationUser(objUserEntity);

                if (returnvalue > 0)
                {
                    UserEntity obj = new UserEntity();
                    obj = user.FetchUserDetail(returnvalue);
                    Session["LoginUser"] = obj;

                    return Json(new { success = true, responseText = "Success!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Fail!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult LogOut(UserEntity objUserEntity)
        {
            Session.Abandon();
            return Json(new { success = true, responseText = "Success!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadFiles()
        {
            string _tmpPath = System.Configuration.ConfigurationManager.AppSettings["ImageUploadPath"].ToString() + "images/user";
            string targetpath = string.Empty;

            string _guid = "";
            string _uploadImagePath = string.Empty;

            try
            {
                if (Request.Files.Count > 0)
                {
                    if (!Directory.Exists(_tmpPath))
                    {
                        Directory.CreateDirectory(_tmpPath);
                    }

                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string _fname;
                        string fileExt = "";
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] _files = file.FileName.Split(new char[] { '\\' });
                            _fname = _files[_files.Length - 1];
                        }
                        else
                        {
                            _fname = Path.GetFileName(file.FileName);
                            //fileExt = Path.GetExtension(file.FileName);
                            //_guid = "AL" + DateTime.Now.ToString("MMddyyHHmm");
                        }
                        TempData["tmpImageName"] = _fname;

                        targetpath = Path.Combine(_tmpPath + "/" + _fname);
                        file.SaveAs(targetpath);

                        _uploadImagePath = targetpath;

                        TempData["tmpImagePath"] = _uploadImagePath;

                    }
                    return Json(_uploadImagePath);
                }
                else
                {
                    return Json("No file selected.");
                }
            }
            catch (Exception)
            {
                return Json("ERROR OCCURED DURING UPLOAD.");
            }
            /*
            if (Request.Files.Count > 0)
            {
                try
                {
                    string ImageName = "";
                    string Webpath = ConfigurationManager.AppSettings["WebPath"] + Constant.EducationalContentImagePath;
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  
                        //fname = Path.Combine(Server.MapPath(Constant.EducationalContentImage), fname);
                        if (!Directory.Exists(Webpath))
                        {
                            Directory.CreateDirectory(Webpath);
                        }
                        fname = Path.Combine(Webpath, fname);
                        file.SaveAs(fname);

                        ImageName = Constant.EducationalContentImagePath + fname;
                    }
                    // Returns message that successfully uploaded  
                    return Json(ImageName);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }*/
        }
    }
}