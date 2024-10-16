using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD_Owners_RealState.Models
{
    public class Property
    {
        [Key]
        public int PropertyID { get; set; }

        [Required(ErrorMessage = "Plot No is required")]
        [DisplayName("Plot #")]
        public string PlotNo { get; set; }


        [DisplayName("Property Type")]
        [Required(ErrorMessage = "Property Type is required")]
        public PropertyType PropertyType { get; set; }
        
        [DisplayName("Property Status")]
        [Required(ErrorMessage = "Property status is required")]
        public PropertyStatus PropertyStatus { get; set; }

        public int? OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual Owner Owner { get; set; }


    }
}

public enum PropertyType { 
    Residential,
    Commercial,
    [Display( Name ="Semi-Commercial")]
    SemiCommercial
}

public enum PropertyStatus
{
    Sold,
    Available,
    Reserved
}
