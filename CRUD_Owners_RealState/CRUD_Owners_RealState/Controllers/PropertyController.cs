using CRUD_Owners_RealState.GlobalMethods;
using CRUD_Owners_RealState.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Owners_RealState.Controllers
{
    public class PropertyController : Controller
    {
        DbContextClass db = new DbContextClass();
        // GET: Property
        public ActionResult AddProperty()
        {
            ViewBag.PropertyType = HelperMethods.GetListFromEnum<PropertyType>();
            ViewBag.PropertyStatus = HelperMethods.GetListFromEnum<PropertyStatus>();

            var property = CreateDummyData();
            return View(property);
        }

        [HttpPost]
        public ActionResult AddProperty(Property property)
        {
            if(ModelState.IsValid)
            {
                db.Properties.Add(property);
                var isDataInserted = Convert.ToBoolean(db.SaveChanges());

                ViewBag.Message = isDataInserted ? "<script>alert('Record Inserted')</script>" : "<script>alert('Record not Inserted')</script>";
            }
            return View();
        }


            private Property CreateDummyData()
        {
            return new Property { 
                PlotNo = "D-97",
                PropertyType = PropertyType.Commercial,
                PropertyStatus = PropertyStatus.Available
            };

        }
    }
}