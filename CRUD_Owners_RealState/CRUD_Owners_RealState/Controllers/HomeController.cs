using CRUD_Owners_RealState.Models;
using System.IO;
using System.Linq;
using System.Web;
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
                ownerData.ImagePath = ValidateAndGetFilePath(ownerData.ImageFile);

                if (ownerData.ImagePath == string.Empty)
                    ownerData.ImagePath = "~/ SysremImages / NoUserImage.png";


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



        #region BusinessLogic
        private string ValidateAndGetFilePath(HttpPostedFileBase imageFile)
        {
            if (imageFile != null)
            {
                var extension = Path.GetExtension(imageFile.FileName);

                if (isValidExtension(extension))
                {
                    //Get the filename
                    string fileName = Path.GetFileName(imageFile.FileName);

                    //Combine the path where you want to save the image
                    string path = Path.Combine(Server.MapPath("~/UploadedImages"), fileName);



                    //Save the image to the server
                    imageFile.SaveAs(path);

                    return "~/UploadedImages/" + fileName;
                }
                else
                {
                    ViewBag.Message = "<script>alert('Only files supported png,jpg,jpeg')</script>";
                    return string.Empty;
                }
            }
                return string.Empty;
            //"~/ SysremImages / NoUserImage.png"


        }
        private bool isValidExtension(string ext)
        {
            return ext.ToLower().Equals("png") || ext.ToLower().Equals("jpg") || ext.ToLower().Equals("jpeg");
        }

        //private bool isPreferredSize()
        //{

        //}
        #endregion BusinessLogic
    }
}