using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD_Owners_RealState.Models
{
    public class Nominee
    {
        [Key]
        public int NomineeId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name cannot contain numbers or special characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CNIC is required")]
        public string CNIC { get; set; }

        [Required(ErrorMessage = "Relation is required")]
        [DisplayName("Relation with owner")]
        public string Relation { get; set; }

        [Required(ErrorMessage = "So/Do/Wo is required")]
        [DisplayName("So/Do/Wo")]
        public string SODOWO { get; set; }  // S/o, D/o, W/o

        [Required(ErrorMessage = "D.O.B is required")]
        [DisplayName("D.O.B")]
        [DataType(DataType.Date)] // This ensures the input is a date
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Cell No is required")]
        public string CellNo { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [DisplayName("Choose Image")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }

        public virtual Owner Owner { get; set; }

    }

    public enum RelationType
    {
        Wife,
        Son,
        Daughter,
        Father,
        Mother,
        Brother,
        Sister,
        Relative,
        Friend,
        Other
    }


}