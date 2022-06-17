using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Program
{
    public class Programs
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
