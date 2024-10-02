using CRUD_Owners_RealState.Models;
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
            return View();
        }
        [HttpPost]
        public ActionResult AddOwner(Owner ownerData)
        {
            if (ModelState.IsValid)
            {
                if (ownerData.ImageFile != null)
                {
                    if (IsValidExtension(ownerData.ImageFile))
                    {
                        if (IsPreferredSize(ownerData.ImageFile))
                        {
                            var path = SaveImageOnServer(ownerData.ImageFile);
                            var isDataInserted = InsertOwnerData(ownerData, path);


                            ViewBag.Message = isDataInserted ? "<script>alert('Record Inserted')</script>" : "<script>alert('Record not Inserted')</script>";
                        }
                        else
                            ViewBag.Message = "<script>alert('Large Size Image, upto 3 MB image is supported')</script>";

                    }
                    else
                        ViewBag.Message = "<script>alert('Invalid Image type, only png, jpg and jpeg files are supported')</script>";
                }
                else
                {
                    var isDataInserted = InsertOwnerData(ownerData, ownerDefaultImagePath);

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
                    if (IsValidExtension(ownerData.ImageFile))
                    {
                        if (IsPreferredSize(ownerData.ImageFile))
                        {
                            var path = SaveImageOnServer(ownerData.ImageFile);

                            var isDataUpdated = UpdateOwnerData(ownerData, path);
                            ViewBag.Message = isDataUpdated ? "<script>alert('Record Updated')</script>" : "<script>alert('Record not Updated')</script>";
                            return RedirectToAction("ViewOwners");
                        }
                        else
                            ViewBag.Message = "<script>alert('Large Size Image, upto 3 MB image is supported')</script>";

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



        #region BusinessLogic

        private string ownerDefaultImagePath = "~/SysremImages/NoUserImage.png";
       
        private bool IsValidExtension(HttpPostedFileBase imageFile)
        {
            var ext = Path.GetExtension(imageFile.FileName);

            return ext.ToLower().Equals(".png") || ext.ToLower().Equals(".jpg") || ext.ToLower().Equals(".jpeg");
        }

        private bool IsPreferredSize(HttpPostedFileBase imageFile)
        {
            var contentLenght = imageFile.ContentLength;

            return contentLenght <= 3000000;
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


        #endregion BusinessLogic

        #region DataAccessLayer
        private DbContextClass db = new DbContextClass();
        private bool InsertOwnerData(Owner ownerData,string imagePath)
        {
            ownerData.ImagePath = imagePath;
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