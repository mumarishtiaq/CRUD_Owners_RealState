using CRUD_Owners_RealState.Models;
using System.IO;
using System.Web;
using System.Web.Mvc;
using CRUD_Owners_RealState.GlobalMethods;
using CRUD_Owners_RealState.BLL;
using CRUD_Owners_RealState.DatabaseService;
using System;

namespace CRUD_Owners_RealState.Controllers
{
    public class HomeController : Controller
    {
        private ImageValidation _imageValidation = new ImageValidation();
        private DBOperations_Owners _dbOperations = new DBOperations_Owners();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewOwners()
        {
            var owners = _dbOperations.GetOwners();
            return View(owners);
        }

        public ActionResult AddOwner()
        {
            Owner ownerDummy  = new Owner { 
                FirstName = "Haider",
                LastName = "ALi",
                CNIC = "6556546",
                CellNo = "35265656",
                Gender = "Male",
                ContactNo = "654856485",
                Address = "Gulshan hadeed",
                ImagePath = "~/SystemImages/NoUserImage.png",
                SODOWO = "jsdujsdh",
                DOB = DateTime.Now.ToString("yyyy-MM-dd"),

            };
            ViewBag.OwnerTypes = HelperMethods.GetListFromEnum<OwnerType>();

            return View(ownerDummy);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddOwner(Owner ownerData)
        {

            if (ModelState.IsValid)
            {
                if (ownerData.ImageFile != null)
                {
                    //image validaton logic (checks for prefered extension and size)
                    if (_imageValidation.IsValidImage(ownerData.ImageFile))
                    {
                        var path = _imageValidation.SaveImageOnServer(ownerData.ImageFile);
                        var isDataInserted = _dbOperations.InsertOwnerData(ownerData, path);


                        ViewBag.Message = isDataInserted ? "<script>alert('Record Inserted')</script>" : "<script>alert('Record not Inserted')</script>";
                    }
                    else
                        ViewBag.Message = "<script>alert('Invalid Image type, only png, jpg and jpeg files are supported')</script>";
                }
                else
                {
                    var isDataInserted = _dbOperations.InsertOwnerData(ownerData);

                    ViewBag.Message = isDataInserted ? "<script>alert('Record Inserted')</script>" : "<script>alert('Record not Inserted')</script>";
                }
                TempData["ownerId"] = ownerData.OwnerId;
                return RedirectToAction("AddNominee", "Nominee"/*, new { ownerID = ownerData.OwnerId }*/);
            }

            ViewBag.OwnerTypes = HelperMethods.GetListFromEnum<OwnerType>();

            return View();
        }

        public ActionResult EditOwner(int id)
        {
            var owner = _dbOperations.GetOwnerById(id);
            Session["image"] = owner.ImagePath;
            return View(owner);
        }
        [HttpPost]
        public ActionResult EditOwner(Owner ownerData)
        {
            if (ModelState.IsValid)
            {
                if (ownerData.ImageFile != null)
                {
                    //image validaton logic (checks for prefered extension and size)
                    if (_imageValidation.IsValidImage(ownerData.ImageFile))
                    {
                        var path = _imageValidation.SaveImageOnServer(ownerData.ImageFile);

                            var isDataUpdated = _dbOperations.UpdateOwnerData(ownerData, path);
                            ViewBag.Message = isDataUpdated ? "<script>alert('Record Updated')</script>" : "<script>alert('Record not Updated')</script>";
                            return RedirectToAction("ViewOwners");
                       
                    }
                    else
                        ViewBag.Message = "<script>alert('Invalid Image type, only png, jpg and jpeg files are supported')</script>";
                }

                else
                {
                    var isDataUpdated = _dbOperations.UpdateOwnerData(ownerData, Session["image"].ToString());
                    ViewBag.Message = isDataUpdated ? "<script>alert('Record Updated')</script>" : "<script>alert('Record not Updated')</script>";
                    return RedirectToAction("ViewOwners");
                }
            }
            return View();
        }
    }
}