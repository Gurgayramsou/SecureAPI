using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection.Model
{
    public class Game
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public int studentid { get; set; }

        public virtual Student Student { get; set; }

    }
}
