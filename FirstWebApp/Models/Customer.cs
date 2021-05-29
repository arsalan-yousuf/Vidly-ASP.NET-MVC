using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;    //for data annotation
using System.Linq;
using System.Web;

namespace FirstWebApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]          //this "Required" will make "Name" not null in database, "Error Message" property overides the default error messages 
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }
        
        [Required]
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
        //above convention is followed as to store MembershipTypeId as forigen key 
        [Display(Name = "Date of Birth")]       //just for displaying it in form as Date of Birth
        [ValidateIs18YearsOld]
        public DateTime? BirthDate { get; set; }

    }
}