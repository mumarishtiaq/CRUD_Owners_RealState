using CRUD_Owners_RealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CRUD_Owners_RealState.Controllers
{
    public class HomeController : Controller
    {
       


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewOwners()
        {
            var owners = db.Owners.ToList();
            return View(owners);
        }

        public ActionResult AddOwner()
        {
            var ownerTypes = Enum.GetValues(typeof(OwnerType)).
                Cast<OwnerType>().
                Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                }).ToList();

            ViewBag.OwnerTypes = ownerTypes as List<SelectListItem>;
            return View();
        }
        [HttpPost]
        public ActionResult AddOwner(Owner ownerData)
        {
            if (ModelState.IsValid)
            {
                if (ownerData.ImageFile != null)
                {
                    //image validaton logic (checks for prefered extension and size)
                    if (IsValidImage(ownerData.ImageFile))
                    {
                        var path = SaveImageOnServer(ownerData.ImageFile);
                        var isDataInserted = InsertOwnerData(ownerData, path);


                        ViewBag.Message = isDataInserted ? "<script>alert('Record Inserted')</script>" : "<script>alert('Record not Inserted')</script>";
                    }
                    else
                        ViewBag.Message = "<script>alert('Invalid Image type, only png, jpg and jpeg files are supported')</script>";
                }
                else
                {
                    var isDataInserted = InsertOwnerData(ownerData);

                    ViewBag.Message = isDataInserted ? "<script>alert('Record Inserted')</script>" : "<script>alert('Record not Inserted')</script>";
                }
            }

            return View();
        }

       

        public ActionResult EditOwner(int id)
        {
            var owner = db.Owners.Where(row =>row.ID ==id).FirstOrDefault();
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
                    if (IsValidImage(ownerData.ImageFile))
                    {
                        var path = SaveImageOnServer(ownerData.ImageFile);

                            var isDataUpdated = UpdateOwnerData(ownerData, path);
                            ViewBag.Message = isDataUpdated ? "<script>alert('Record Updated')</script>" : "<script>alert('Record not Updated')</script>";
                            return RedirectToAction("ViewOwners");
                       
                    }
                    else
                        ViewBag.Message = "<script>alert('Invalid Image type, only png, jpg and jpeg files are supported')</script>";
                }

                else
                {
                    var isDataUpdated = UpdateOwnerData(ownerData, Session["image"].ToString());
                    ViewBag.Message = isDataUpdated ? "<script>alert('Record Updated')</script>" : "<script>alert('Record not Updated')</script>";
                    return RedirectToAction("ViewOwners");
                }
            }
            return View();
        }

        private string SaveImageOnServer(HttpPostedFileBase imageFile)
        {
            //Get the filename
            string fileName = Path.GetFileName(imageFile.FileName);

            //Combine the path where you want to save the image
            string path = Path.Combine(Server.MapPath("~/UploadedImages"), fileName);

            //Save the image to the server
            imageFile.SaveAs(path);

            return "~/UploadedImages/" + fileName;
        }



        #region BusinessLogic

        private const int preferedSize = 3000000;

        private bool IsValidImage(HttpPostedFileBase imageFile)
        {
            var ext = Path.GetExtension(imageFile.FileName);
            var contentLenght = imageFile.ContentLength;

            return IsValidExtension(ext) && IsPreferredSize(contentLenght);
        }


        private bool IsValidExtension(string ext)
        {
            return ext.ToLower().Equals(".png") || ext.ToLower().Equals(".jpg") || ext.ToLower().Equals(".jpeg");
        }

        private bool IsPreferredSize(int contentLenght)
        {
            return contentLenght <= preferedSize;
        }



        #endregion BusinessLogic

        #region DataAccessLayer

        private const string ownerDefaultImagePath = "~/SystemImages/NoUserImage.png";
        private DbContextClass db = new DbContextClass();
        private bool InsertOwnerData(Owner ownerData, string imagePath = ownerDefaultImagePath)
        {
            ownerData.ImagePath = imagePath;
            ownerData.EntryTime = DateTime.UtcNow;
            db.Owners.Add(ownerData);
            int rowInserted = db.SaveChanges();

            return rowInserted > 0;
        }

        private bool UpdateOwnerData(Owner ownerData,string imagePath)
        {
            ownerData.ImagePath = imagePath;
            db.Entry(ownerData).State = EntityState.Modified;
            int rowsUpdated = db.SaveChanges();

            return rowsUpdated > 0;
        }


        #endregion DataAccessLayer
    }
}