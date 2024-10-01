using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CRUD_Owners_RealState.Models
{
    public class Owner
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "CNIC is required")]
        public string CNIC { get; set; }

        [Required(ErrorMessage = "Cell No is required")]
        public string CellNo { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        public string ContactNo { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [DisplayName("Choose Image")]
        public string ImagePath { get; set; }
        public byte[] FingerPrint { get; set; }



        [Required(ErrorMessage = "So/Do/Wo is required")]
        [DisplayName("So/Do/Wo")]
        public string SODOWO { get; set; }  // S/o, D/o, W/o

        [Required(ErrorMessage = "D.O.B is required")]
        [DisplayName("D.O.B")]
        [DataType(DataType.Date)] // This ensures the input is a date
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Owner Type is required")]
        public string OwnerType { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}