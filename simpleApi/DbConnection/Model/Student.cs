using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbConnection.Model
{
    public class Student
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public int  age { get; set; }
        public virtual ICollection<Game> Game { get; set; }
    }
}
