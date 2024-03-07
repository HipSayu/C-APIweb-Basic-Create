using ApiWebBasicPlatFrom.Entites;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBasic.Entites
{
    public class StudentSubject
    {
        public int Id { get; set; }
       
        
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public float Point { get; set; }

        public Subject Subject { get; set; }

        public Student Student { get; set; }
    }
}
