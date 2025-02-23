using System;
using System.Collections.Generic;

using System.Text;

namespace Cella.Models{
   public  class EmploymentHistory  {

        
        public int Id { get; set; }

        public DateTime StarDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool isCurrentJob { get; set; }

        public int NotesId { get; set; }




    }
}
