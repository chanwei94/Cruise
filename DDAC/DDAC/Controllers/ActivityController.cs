using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDAC.Models;

namespace DDAC.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity

        MyDatabaseEntities db = new MyDatabaseEntities();
        

        public ActionResult HomePage()
        {
            List<Cruise> cruiselist = db.Cruises.ToList();
            CruiseView cruiseview = new CruiseView();
            List<CruiseView> cruiseviewlist = cruiselist.Select(a => new CruiseView
            {
                CruiseID = a.CruiseID,
                DestinationID = a.DestinationID,
                DestinationName = a.Destination.DestinationName,
                PortID = a.PortID,
                PortName = a.Port.PortName,
                ShipID = a.ShipID,
                ShipName = a.Ship.ShipName,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                Price = a.Price
            }).ToList();


            return View(cruiseviewlist);
        }


        public ActionResult History()
        {
            var userID = @Session["LogedUserID"].ToString();
            List<PurchaseHistory> historylist = db.PurchaseHistories.ToList();
            HistoryView historyview = new HistoryView();
            List<HistoryView> historyviewlist = historylist.Where(a => a.UserID.ToString().Equals(userID)).Select(a => new HistoryView
            {
                CruiseID = a.CruiseID,
                DestinationName = a.Cruise.Destination.DestinationName,
                PortName = a.Cruise.Port.PortName,
                ShipName = a.Cruise.Ship.ShipName,
                StartDate = a.Cruise.StartDate,
                EndDate = a.Cruise.EndDate,
                Price = a.Cruise.Price
            }).ToList();

            return View(historyviewlist);
        }

        public ActionResult UpdateUser()
        {
            var userID = @Session["LogedUserID"].ToString();
            UserData userdata = db.UserDatas.FirstOrDefault(a => a.UserID.ToString().Equals(userID));

            
            Models.UpdateUser updateuser = new Models.UpdateUser();
            updateuser.FullName = userdata.FullName;
            updateuser.Email = userdata.Email;
            return View(updateuser);
        }

        [HttpPost]
        public ActionResult UpdateUser(Models.UpdateUser updateuser)
        {
            if (ModelState.IsValid)
            {
                var userID = @Session["LogedUserID"].ToString();
                UserData userdata = db.UserDatas.FirstOrDefault(a => a.UserID.ToString().Equals(userID));

                userdata.FullName = updateuser.FullName;
                userdata.Email = updateuser.Email;

                db.Entry(userdata).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("HomePage", "Activity");
            }
            return View(updateuser);
        }



        public ActionResult Purchase(int id = 0)
        {
            Cruise cruise = db.Cruises.FirstOrDefault(a => a.CruiseID.Equals(id));
            Models.Purchase purchase = new Models.Purchase();
            purchase.DestinationName = cruise.Destination.DestinationName;
            purchase.PortName = cruise.Port.PortName;
            purchase.ShipName = cruise.Ship.ShipName;
            purchase.StartDate = cruise.StartDate;
            purchase.EndDate = cruise.EndDate;
            purchase.Price = cruise.Price;
            Session["CruiseID"] = id;

            return View(purchase);
        }


        [HttpPost]
        public ActionResult Purchase(DDAC.Models.Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                var userID = Convert.ToInt32(@Session["LogedUserID"]);
                var cruiseID = Convert.ToInt32(@Session["CruiseID"]);

                PurchaseHistory purchasehistory = new PurchaseHistory();

                purchase.UserID = userID;
                purchase.CruiseID = cruiseID;

                purchasehistory.UserID = purchase.UserID;
                purchasehistory.CruiseID = purchase.CruiseID;

                db.PurchaseHistories.Add(purchasehistory);
                db.SaveChanges();
            }
            return RedirectToAction("HomePage");

        }

    }
}