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
        [Required]          //this will make "Name" not null in database
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }
        //above convention is followed as to store MembershipTypeId as forigen key 

    }
}