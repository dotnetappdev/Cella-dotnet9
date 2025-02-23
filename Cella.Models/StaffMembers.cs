using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models{
    public  class StaffMembers {

        public int Id { get; set; }

        public Guid TeannatId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Departments { get; set; }
        public Guid StaffId { get; set; }


        public string CreatedBy { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }


    }
}
