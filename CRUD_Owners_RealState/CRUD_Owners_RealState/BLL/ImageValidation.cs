using System.IO;
using System.Web;

namespace CRUD_Owners_RealState.BLL
{
    public class ImageValidation
    {
        private const int preferedSize = 3000000;

        public bool IsValidImage(HttpPostedFileBase imageFile)
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

        public string SaveImageOnServer(HttpPostedFileBase imageFile)
        {
            //Get the filename
            string fileName = Path.GetFileName(imageFile.FileName);

            //Combine the path where you want to save the image
            string path = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedImages"), fileName);

            //Save the image to the server
            imageFile.SaveAs(path);

            return "~/UploadedImages/" + fileName;
        }



    }
}