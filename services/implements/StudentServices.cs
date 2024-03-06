using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWebBasicPlatFrom.Context;
using ApiWebBasicPlatFrom.Dtos.Shared;
using ApiWebBasicPlatFrom.Dtos.Students;
using ApiWebBasicPlatFrom.Entites;
using ApiWebBasicPlatFrom.services.interfaces;
using ApiWebBasicPlatFrom.Utils;
using ApiWebCoin.Exceptions;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace ApiWebBasicPlatFrom.services.implements
{
    public class StudentServices : IStudentServices
    {
        private ApplicationDbContext _context ;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public StudentServices (ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)  
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public void Create(CreateStudentDto input)
        {
            
            _context.Students.Add(new Student {
                NameStudent = input.NameStudent,
                Age = input.Age,
                DateOfBirth = input.DateOfBirth,
                StudentCode = input.StudentCode
            });
            _context.SaveChanges();
        }

        public void DeleteStudentById(int StudentId)
        {
            var Student = _context.Students.SingleOrDefault(s => s.StudentId == StudentId);
            if(Student == null) 
            {

                throw new NotImplementedException($"Không tồn tại sinh viên nào có Id là {StudentId}");
            }
            _context.Students.Remove(Student);
            _context.SaveChanges();
        }

        public StudentDto GetById(int StudentId)
        {
            var Student = _context.Students.SingleOrDefault(s => s.StudentId == StudentId);
            if(Student == null) 
            {

                throw new NotImplementedException($"Không tồn tại sinh viên nào có Id là {StudentId}");
            }
            return new StudentDto {
                StudentId = Student.StudentId,
                NameStudent = Student.NameStudent,
                Age = Student.Age,
                DateOfBirth = Student.DateOfBirth,
            };
        }

        public PageResultDto<List<Student>> GetStudent(FilterDto input)
        {
            var StudentQuerry = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(input.Keyword)) {
                StudentQuerry = StudentQuerry.Where(s => s.NameStudent.Contains(input.Keyword));
            }
            int Total = StudentQuerry.Count();
            StudentQuerry = StudentQuerry.Skip(input.PageSize *( input.PageIndex - 1)).Take(input.PageSize);

            return new PageResultDto<List<Student>>
            {
                Items = StudentQuerry.ToList(),
                TotalItem = Total,
            };
        }

        public void UpdateStudent(UpdateStudentDto input)
        {
            var Student = _context.Students.SingleOrDefault(s => s.StudentId == input.StudentId);
            if(Student == null) 
            {

                throw new NotImplementedException($"Không tồn tại sinh viên nào có Id là {input.StudentId}");
            }
            
                Student.StudentId = input.StudentId ;
                Student.NameStudent = input.NameStudent ;
                Student.Age = input.Age ;
                Student.DateOfBirth = input.DateOfBirth ;
                _context.SaveChanges();
            
        }
        public List<StudentDto> GetStudentInClassroom (int ClassroomId)
        {
            var result = from student in _context.Students
                         join sc in _context.studentClassrooms on student.StudentId equals sc.StudentId
                         where sc.ClassroomId == ClassroomId
                         select new StudentDto{
                            NameStudent  = student.NameStudent,
                            Age = student.Age,
                            DateOfBirth = student.DateOfBirth,
                            StudentCode = student.StudentCode,
                            StudentId = student.StudentId,
                         };
            return result.ToList();
        }
        public List<StudentDto> GetStudentWithMaxAgeInClassroom(int ClassroomId)
        {
            var query = from student in _context.Students
                        join studentClassroom in _context.studentClassrooms
                        on student.StudentId equals studentClassroom.StudentId
                        where studentClassroom.ClassroomId == ClassroomId
                        select student;
            var maxAge = query.Max(x => x.Age);
            var result = from student in _context.Students
                         join studentClassroom in _context.studentClassrooms
                         on student.StudentId equals studentClassroom.StudentId
                         where studentClassroom.ClassroomId == ClassroomId && maxAge == student.Age
                         select new StudentDto
                         {
                             Age = maxAge,
                             NameStudent = student.NameStudent,
                             StudentCode = student.StudentCode,
                             DateOfBirth = student.DateOfBirth,
                             StudentId = student.StudentId,
                         };
            return result.ToList();

        }
    }
}