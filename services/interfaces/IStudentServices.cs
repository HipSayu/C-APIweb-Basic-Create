using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWebBasicPlatFrom.Dtos.Shared;
using ApiWebBasicPlatFrom.Dtos.Students;
using ApiWebBasicPlatFrom.Entites;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiWebBasicPlatFrom.services.interfaces
{
    public interface IStudentServices
    {
        void Create (CreateStudentDto input) ;
        PageResultDto<List<Student>> GetStudent (FilterDto input);

        StudentDto GetById  (int StudentId) ;

        void UpdateStudent (UpdateStudentDto input);

        void DeleteStudentById (int StudentId);

        List<StudentDto> GetStudentInClassroom (int ClassroomId);

        List<StudentDto> GetStudentWithMaxAgeInClassroom (int ClassroomId);
    }
}