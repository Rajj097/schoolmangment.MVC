//custome lable like first name instead of fname
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace schoolmangment.MVC.Database;
    public class StudentMetaData
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string Fname { get; set; } = null!;
        [Display(Name = "Last Name")]
        public string Lname { get; set; } = null!;
        [Display(Name = "Birth Date")]
        public DateOnly? Dob { get; set; }
    }
[ModelMetadataType(typeof(StudentMetaData))]
public partial class Student { }

