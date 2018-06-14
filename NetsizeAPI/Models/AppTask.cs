using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetsizeAPI.Models
{
    public class AppTask
    {
        public int Id { get; set; }

        public DateTime? CreationDate { get; set; }

        [Required]
        public String Title { get; set; }

        public string Description { get; set; }

        public bool Done { get; set; }


    }
}
