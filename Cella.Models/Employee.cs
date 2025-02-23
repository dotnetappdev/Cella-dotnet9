using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models{
   public class Employee {

        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime Dob { get; set; }
        [StringLength(50)]
        public string? Title { get; set; }

        public int? LineManger { get; set; }

        public DateTime LastMofied { get; set; }

        public DateTime StartDate { get; set; }

        public int? YearsOfService { get; set; }

        public bool? Active { get; set; }

        public DateTime JoinedDate { get; set; }
        [StringLength(50)]
        public string? NINumber { get; set; }
        public DateTime? LeftDate { get; set; }


    }
}
