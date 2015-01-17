using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }
    }
}