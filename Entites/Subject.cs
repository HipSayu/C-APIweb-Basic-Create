using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBasic.Entites
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public string SubjectCode { get; set; }
        [Required]
        public int NumberOfCredit { get; set; }

        public ICollection<StudentSubject> studentSubjects { get; set;}
    }
}
