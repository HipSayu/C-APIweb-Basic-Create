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

        public string NameStudent {
            get => _nameStudent; 
            set => _nameStudent = value?.Trim();}

        private string _studentCode ;
       
        
        public string StudentCode {
            get => _studentCode; 
            set => _studentCode = value?.Trim();
        }
        
        public DateTime DateOfBirth {get; set ;}
        public int Age {get; set ;}
    }
}