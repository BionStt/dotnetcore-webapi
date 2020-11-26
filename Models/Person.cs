using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebApi.Models
{
    public class Person 
    {
        public long Id {get; set;}
        [MinLength(5)]
        [MaxLength(50)]
        public string FirstName {get; set;}
        [MinLength(5)]
        [MaxLength(50)]
        public string LastName {get; set;}
        [Required]
        public string SSN {get; set;}
        [Required]
        public DateTime DateOfBirth {get; set;}
        [Required]
        public Gender Gender {get; set;}
    }

    // Excludes the SSN for the DTO
    public class PersonDTO
    {
        public long Id {get; set;}
        [MinLength(5)]
        [MaxLength(50)]
        public string FirstName {get; set;}
        [MinLength(5)]
        [MaxLength(50)]
        public string LastName {get; set;}
        [Required]
        public DateTime DateOfBirth {get; set;}
        [Required]
        public Gender Gender {get; set;}
    }

    public enum Gender 
    {
        [EnumMember(Value = "Female" )]
        Female,
        
        [EnumMember(Value = "Male" )]
        Male
    }
}