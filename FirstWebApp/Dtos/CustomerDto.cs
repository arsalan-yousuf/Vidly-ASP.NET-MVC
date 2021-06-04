using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using FirstWebApp.Models;

namespace FirstWebApp.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]          //this "Required" will make "Name" not null in database, "Error Message" property overides the default error messages 
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Required]
        public int MembershipTypeId { get; set; }   
        public MembershipTypeDto MembershipType { get; set; }

        //[ValidateIs18YearsOld]
        public DateTime? BirthDate { get; set; }
    }
}