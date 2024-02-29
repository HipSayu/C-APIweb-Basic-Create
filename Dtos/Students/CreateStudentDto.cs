using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebBasicPlatFrom.Dtos.Students
{
    public class CreateStudentDto
    {
        
        private string _nameStudent ;

       
        [MinLength(2, ErrorMessage ="Nhập tối thiểu 2 ký tự")]
        public string NameStudent {
            get => _nameStudent; 
            set => _nameStudent?.Trim();}

        private string _studentCode ;
       
        [MinLength(10, ErrorMessage ="Nhập tối thiểu 2 ký tự")]
        public string StudentCode {
            get => _studentCode; 
            set => _studentCode?.Trim();}
        public DateTime DateOfBirth {get; set ;}
        public int Age {get; set ;}
    }
}