using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativeBox.Domain.Interface;
using CreativeBox.Domain.Entity;
using CreativeBox.Utility;
using log4net;

namespace CreativeBox.Controllers
{
    public class WareHouseController : Controller
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(WareHouseController));  //Declaring Log4Net

        protected IWareHouse WareHouse { get; set; }

        public WareHouseController(IWareHouse iWareHouse)
        {
            WareHouse = iWareHouse;
        }

        // GET: WareHouse
        public ActionResult Index()
        {
            List<WareHouseEntity> objlist = WareHouse.SelectWareHouseList();
            return View(objlist);
        }

        [HttpGet]
        public ActionResult WareHouseDetailPartial(int WareHouseid)
        {
            try
            {
                WareHouseEntity obj = new WareHouseEntity();
                if (WareHouseid > 0)
                {
                    obj = WareHouse.FetchWareHouseDetail(WareHouseid);
                }

                ViewBag.objWareHouseEntity = obj;

                return PartialView();

            }
            catch (Exception ex)
            {
                return PartialView();
            }
        }


        [HttpPost]
        public ActionResult OperationWareHouse(WareHouseEntity objWareHouseEntity)
        {
            try
            {
                int returnvalue = WareHouse.OperationWareHouse(objWareHouseEntity);

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
        public ActionResult DeleteWareHouse(WareHouseEntity objWareHouseEntity)
        {
            try
            {
                int returnvalue = WareHouse.OperationWareHouseDelete(objWareHouseEntity);

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
    }
}