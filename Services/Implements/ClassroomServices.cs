using ApiBasic.Services.Interfaces;
using ApiWebBasicPlatFrom.Context;
using ApiWebBasicPlatFrom.Dtos.Classroom;
using ApiWebBasicPlatFrom.Dtos.Shared;
using ApiWebBasicPlatFrom.Entites;
using ApiWebCoin.Exceptions;

namespace ApiBasic.Services.Implements
{
    public class ClassroomServices : IClassroomServices
    {
        private readonly ApplicationDbContext _context;
        public ClassroomServices(ApplicationDbContext context) 
        {
            _context = context;
        }

        public void Create(CreateClassroomDto input)
        {
            if (_context.Classrooms.Any(c => c.NameClassroom == input.NameClassroom))
            {
                throw new UserFriendlyExceptions($"{input.NameClassroom} đã tồn tại");
            }
            _context.Classrooms.Add(new Classroom
            {
                NameClassroom = input.NameClassroom,
            });
            _context.SaveChanges();
        }

        public void DeleteStudentById(int ClassroomId)
        {
            var classroom = _context.Classrooms.FirstOrDefault(c => c.ClassroomId == ClassroomId);
            if (classroom == null) 
            {
                throw new UserFriendlyExceptions($"không tìm thấy classroom nào có Id là{ClassroomId}");
            }
            _context.Classrooms.Remove(classroom);
            _context.SaveChanges();
        }

        public ClassroomDto GetById(int ClassroomId)
        {
            var classroom = _context.Classrooms.FirstOrDefault(c => c.ClassroomId == ClassroomId);
            if (classroom == null)
            {
                throw new UserFriendlyExceptions($"không tìm thấy classroom nào có Id là{ClassroomId}");
            }
            return new ClassroomDto
            {
                ClassroomId = classroom.ClassroomId,
                NameClassroom = classroom.NameClassroom,
            };
        }

        public PageResultDto<List<Classroom>> GetClassroom(FilterDto input)
        {
            var classrooms = _context.Classrooms.AsQueryable();
            if (input.Keyword != null)
            {
                classrooms = classrooms.Where(c => c.NameClassroom.ToLower().Contains(input.Keyword));
            }
            int total = classrooms.Count();
            classrooms = classrooms.Skip(input.PageSize *(input.PageIndex - 1)).Take(input.PageSize);

            return new PageResultDto<List<Classroom>> 
            {
                TotalItem = total,
                Items = classrooms.ToList(),
            };
        }

        public void UpdateClassroom(UpdateClassroomDto input)
        {
            var classroom = _context.Classrooms.FirstOrDefault(c => c.ClassroomId == input.ClassroomId);
            if (classroom == null)
            {
                throw new UserFriendlyExceptions($"không tìm thấy classroom nào có Id là{input.ClassroomId}");
            }
           classroom.NameClassroom = input.NameClassroom;
           _context.SaveChanges();
        }
    }
}
