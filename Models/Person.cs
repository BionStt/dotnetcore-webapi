using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebApi.Models
{
    public class Person 
    {
        public long Id {get; set;}
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string FirstName {get; set;}
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string LastName {get; set;}
        [Required]
        public string SSN
        {
            private get;
            set;
        }
        [Required]
        public DateTime? DateOfBirth {get; set;}
        [Required]
        public Gender? Gender {get; set;}
    }

    public enum Gender 
    {
        [EnumMember(Value = "Female" )]
        Female,
        
        [EnumMember(Value = "Male" )]
        Male
    }
}