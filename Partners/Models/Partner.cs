using Partners.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Partners.Models
{
    //[Bind(Exclude = "ID")]
   
    public class Partner
    {
        public int ID { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name"), MinLength(2), MaxLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter last name"), MinLength(2), MaxLength(255)]
        [Display(Name = "Last Name *")]
        public string LastName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        
        [Required(ErrorMessage = "Please enter Partner number"), MinLength(20), MaxLength(20)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Partner number is not valid.")]
        [Display(Name = "Partner number (Enter max 20 number digits) *")]
        public string PartnerNumber { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Croatian PIN"), MinLength(11), MaxLength(11)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Croatian PIN is not valid.")]
        [Display(Name = "Croatian PIN (OIB) *")]
        public string CroatianPIN { get; set; }

        [Required(ErrorMessage = "Required select")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int PartnerTypeId { get; set; }

        public DateTime? CreatedAtUtc { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter Email"), MaxLength(255)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [Display(Name = "Create by user *")]
        public string CreateByUser { get; set; }


        [MustBeTrue(ErrorMessage = "You must accept the terms and conditions")]        
        [Display(Name = "Is Foreign *")]
        public bool IsForeign { get; set; }


        public string ExternalCode { get; set; }


        [Required(ErrorMessage = "Please select gender"), MinLength(1)]
        public string Gender { get; set; }


    }


}
