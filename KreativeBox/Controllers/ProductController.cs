using CreativeBox.Domain.Entity;
using CreativeBox.Domain.Interface;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreativeBox.Controllers
{
    public class ProductController : Controller
    {

        ILog logger = log4net.LogManager.GetLogger(typeof(ProductController));  //Declaring Log4Net

        protected IProduct Product { get; set; }

        public ProductController(IProduct iproduct)
        {
            Product = iproduct;
        }

        // GET: Product
        public ActionResult Index()
        {
            List<ProductEntity> objlist = Product.SelectProductList();
            return View(objlist);
        }

        [HttpGet]
        public ActionResult ProductDetailPartial(int idproduct)
        {
            try
            {
                ProductEntity obj = new ProductEntity();
                if (idproduct > 0)
                {
                    obj = Product.FetchProductDetail(idproduct);
                }

                ViewBag.objProductEntity = obj;

                return PartialView();

            }
            catch (Exception ex)
            {
                return PartialView();
            }
        }


        [HttpPost]
        public ActionResult OperationProduct(ProductEntity objProductEntity)
        {
            try
            {
                int returnvalue = Product.OperationProduct(objProductEntity);

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
        public ActionResult DeleteProduct(ProductEntity objProductEntity)
        {
            try
            {
                int returnvalue = Product.OperationProductDelete(objProductEntity);

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
            string _tmpPath = System.Configuration.ConfigurationManager.AppSettings["ImageUploadPath"].ToString() + "images/product";
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