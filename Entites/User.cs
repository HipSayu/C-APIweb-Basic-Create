using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebBasicPlatFrom.Entites
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser {get; set;}
        
        public string UserName {get; set;}
        
        public string Password {get; set;}

        public int UserType {get; set;}
    }
}