using ApiBasic.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebBasicPlatFrom.Entites
{
    [Table("Students")]
    public class Student
    {   [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId {get; set;}
       
        [Required]
        [MaxLength(100, ErrorMessage ="Khong Nhap Qua 100 ky tu")]
        public string NameStudent {get ; set ;}
        public DateTime DateOfBirth {get; set ;}
        
        public string StudentCode {get; set;}
        public int Age {get; set ;}

        public ICollection<StudentClassroom> studentClassrooms {get; set;}
        public ICollection<StudentSubject> studentSubjects { get; set;}
    }
}