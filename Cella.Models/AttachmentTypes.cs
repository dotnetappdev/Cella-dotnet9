using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models{
    public class AttachmentTypes {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }


        public DateTimeOffset CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public bool isAcitve { get; set; }

        public bool isDeleted { get; set; }
    }
}
