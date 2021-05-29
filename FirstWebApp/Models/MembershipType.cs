using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FirstWebApp.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public int SignupFee { get; set; }
        public int DurationInMonths { get; set; }
        public int Discount { get; set; }
        [Required]
        [StringLength(255)]
        public string MembershipTitle { get; set; }

        public static readonly int Unknown = 0;
        public static readonly int PayAsYouGo = 1;
    }
}