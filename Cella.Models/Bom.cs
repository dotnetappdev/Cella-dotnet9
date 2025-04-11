using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Models
{
    public class Bom
    {
        public int Id { get; set; }

        public int? SalesOrderId { get; set; }

        public int? ShoppingCartId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BomId { get; set; }



        public DateTime CreateDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
        [StringLength(30)]
        public string CreatedBy { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }
    }
}
