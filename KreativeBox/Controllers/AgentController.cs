using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativeBox.Domain.Interface;
using CreativeBox.Domain.Entity;
using CreativeBox.Utility;
using log4net;
using System.Configuration;
using System.IO;

namespace CreativeBox.Controllers
{
    public class AgentController : Controller
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(AgentController));  //Declaring Log4Net

        protected IAgent Agent { get; set; }

        public AgentController(IAgent iagent)
        {
            Agent = iagent;
        }

        // GET: Agent
        public ActionResult Index()
        {
            List<AgentEntity> objlist = Agent.SelectAgentList();
            return View(objlist);
        }

        [HttpGet]
        public ActionResult AgentDetailPartial(int agentid)
        {
            try
            {
                AgentEntity obj = new AgentEntity();
                if (agentid > 0)
                {
                    obj = Agent.FetchAgentDetail(agentid);
                }

                ViewBag.objAgentEntity = obj;

                return PartialView();

            }
            catch (Exception ex)
            {
                return PartialView();
            }
        }


        [HttpPost]
        public ActionResult OperationAgent(AgentEntity objAgentEntity)
        {
            try
            {
                int returnvalue = Agent.OperationAgent(objAgentEntity);

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
        public ActionResult DeleteAgent(AgentEntity objAgentEntity)
        {
            try
            {
                int returnvalue = Agent.OperationAgentDelete(objAgentEntity);

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
        public ActionResult UploadFiles()
        {
            string _tmpPath = System.Configuration.ConfigurationManager.AppSettings["ImageUploadPath"].ToString() + "images/agent";
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
                        string fileExt= "";
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