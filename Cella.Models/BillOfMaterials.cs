using System.Collections.Generic;

namespace Cella.Models
{
    public class BillOfMaterials
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BillOfMaterialsItem> Items { get; set; } = new();
    }

    public class BillOfMaterialsItem
    {
        public int Id { get; set; }
        public string ComponentName { get; set; }
        public int Quantity { get; set; }
    }
}
