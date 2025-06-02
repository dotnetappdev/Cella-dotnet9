using System.Collections.Generic;

namespace Cella.Models
{
    public class SalesOrderLine
    {
        public int Id { get; set; }
        public int SalesOrderId { get; set; }
        public int StockItemId { get; set; }
        public StockItem StockItem { get; set; } // Navigation property for age restriction and other info
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? BillOfMaterialsId { get; set; }
        public BillOfMaterials BillOfMaterials { get; set; }
        public bool IsAgeRestricted { get; set; } // Indicates if this line is age-restricted
    }
}
