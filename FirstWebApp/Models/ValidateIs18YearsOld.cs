using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstWebApp.Models
{
    public class ValidateIs18YearsOld : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if(customer.BirthDate == null)
            {
                return new ValidationResult("Date of Birth is required");
            }

            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success 
                : new ValidationResult("Customer needs to be 18 years old atleast for the selected membership type");
        }
    }
}