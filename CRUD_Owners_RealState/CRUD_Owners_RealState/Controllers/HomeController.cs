using CRUD_Owners_RealState.Models;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_Owners_RealState.Controllers
{
    public class HomeController : Controller
    {
        private DbContextClass db = new DbContextClass();


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
                // Check if an image file is provided
                if (ownerData.ImageFile != null)
                {
                    //Get the filename
                    string fileName = Path.GetFileName(ownerData.ImageFile.FileName);

                    //Combine the path where you want to save the image
                    string path = Path.Combine(Server.MapPath("~/UploadedImages"), fileName);

                    //Set the image path in the owner object
                    ownerData.ImagePath = "~/UploadedImages/" + fileName;

                    //Save the image to the server
                    ownerData.ImageFile.SaveAs(path);
                }

                // Save the owner data to the database (excluding ImageFile)
                db.Owners.Add(ownerData);
                int rowInserted = db.SaveChanges();

                if (rowInserted > 0)
                {
                    ViewBag.Message = "<script>alert('Record Inserted')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Message = "<script>alert('Record not Inserted')</script>";
                }
            }

            return View();
        }

        public ActionResult EditOwner(int id)
        {
            var owner = db.Owners.Where(row =>row.ID ==id).FirstOrDefault();
            return View(owner);
        }
        [HttpPost]
        public ActionResult EditOwner(Owner owner)
        {
            return View();
        }


    }
}