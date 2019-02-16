using CreativeBox.Domain.Entity;
using CreativeBox.Domain.Interface;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreativeBox.Controllers
{
    public class OrderController : Controller
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(OrderController));  //Declaring Log4Net

        protected IOrder Order { get; set; }
        protected IAgent Agent { get; set; }

        #region Order
        public OrderController(IOrder iorder, IAgent iagent)
        {
            Order = iorder;
            Agent = iagent;
        }

        // GET: Order
        public ActionResult Index()
        {
            TempData["lstAgent"] = Agent.SelectAgentList();
            List<OrderEntity> objlist = Order.SelectOrderList();
            return View(objlist);
        }

        public ActionResult OrderDetailPartial(int Orderid)
        {
            try
            {
                OrderEntity obj = new OrderEntity();
                if (Orderid > 0)
                {
                    obj = Order.FetchOrderDetail(Orderid);
                }

                ViewBag.objOrderEntity = obj;

                return PartialView();

            }
            catch (Exception ex)
            {
                return PartialView();
            }
        }

        [HttpPost]
        public ActionResult OperationOrder(OrderEntity objOrderEntity)
        {
            try
            {
                int returnvalue = Order.OperationOrder(objOrderEntity);

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
        public ActionResult DeleteOrder(OrderEntity objOrderEntity)
        {
            try
            {
                int returnvalue = Order.OperationOrderDelete(objOrderEntity);

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
        #endregion

        #region ADDRESS
        public ActionResult AddressList()
        {
            List<AddressEntity> objlist = Order.SelectAddressList();
            return View(objlist);
        }

        public ActionResult AddressDetailPartial(int addressid)
        {
            try
            {
                AddressEntity obj = new AddressEntity();
                if (addressid > 0)
                {
                    obj = Order.FetchAddressDetail(addressid);
                }

                ViewBag.objAddressEntity = obj;

                return PartialView();

            }
            catch (Exception ex)
            {
                return PartialView();
            }
        }

        [HttpPost]
        public ActionResult OperationAddress(AddressEntity objAddressEntity)
        {
            try
            {
                int returnvalue = Order.OperationAddress(objAddressEntity);

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
        public ActionResult DeleteAddress(AddressEntity objAddressEntity)
        {
            try
            {
                int returnvalue = Order.OperationAddressDelete(objAddressEntity);

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
        #endregion

        #region QUOTATION
        public ActionResult QuotationList()
        {
            List<QuotationEntity> objlist = Order.SelectQuotationList();
            return View(objlist);
        }

        public ActionResult QuotationDetailPartial(int Quotationid)
        {
            try
            {
                QuotationEntity obj = new QuotationEntity();
                if (Quotationid > 0)
                {
                    obj = Order.FetchQuotationDetail(Quotationid);
                }

                ViewBag.objQuotationEntity = obj;

                return PartialView();

            }
            catch (Exception ex)
            {
                return PartialView();
            }
        }

        [HttpPost]
        public ActionResult OperationQuotation(QuotationEntity objQuotationEntity)
        {
            try
            {
                int returnvalue = Order.OperationQuotation(objQuotationEntity);

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
        public ActionResult DeleteQuotation(QuotationEntity objQuotationEntity)
        {
            try
            {
                int returnvalue = Order.OperationQuotationDelete(objQuotationEntity);

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
        #endregion

        #region Order Report
        public ActionResult ActivityReport()
        {
            TempData["lstAgent"] = Agent.SelectAgentList();
            List<OrderEntity> objlist = Order.SelectOrderList();
            return View(objlist);
        }

        public ActionResult ProductReport()
        {
            TempData["lstAgent"] = Agent.SelectAgentList();
            List<OrderEntity> objlist = Order.SelectOrderList();
            return View(objlist);
        }

        public ActionResult InvoiceReport()
        {
            TempData["lstAgent"] = Agent.SelectAgentList();
            List<OrderEntity> objlist = Order.SelectOrderList();
            return View(objlist);
        }

        public ActionResult StockReport()
        {
            TempData["lstAgent"] = Agent.SelectAgentList();
            List<OrderEntity> objlist = Order.SelectOrderList();
            return View(objlist);
        }

        public ActionResult FreightOrder()
        {            
            return View();
        }
        #endregion
    }
}