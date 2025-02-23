using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace Cella.Models{
   public class Departments {

        public int Id { get; set; }

        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }
        public string Title { get; set; }

        public bool isAdmin { get; set; }


        public DateTimeOffset CreatedDate { get; set; }

        public string  CreatedBy { get; set; }

        public bool isAcitve { get; set; }

        public bool isDeleted { get; set; }

    }
}
