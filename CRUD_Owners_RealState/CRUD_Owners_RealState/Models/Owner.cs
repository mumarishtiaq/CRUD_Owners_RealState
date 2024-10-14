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
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 50 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name cannot contain numbers or special characters.")]
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
        public string DOB { get; set; }

        [Required(ErrorMessage = "Owner Type is required")]
        public OwnerType OwnerType { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public virtual ICollection<Nominee> Nominees { get; set; } /*= new List<Nominee>();*/

        public virtual ICollection<Property> Properties { get; set; }
        //public DateTime EntryTime { get; set; }
    }
}
public enum OwnerType
{
    Buyer = 0,
    Invester = 1
}