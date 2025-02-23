using System.Collections.Generic;

namespace WarehouseCrm.Module.SampleData.Areas.SampleData.ViewModels
{
    public class SampleDataOption
    {
        public string Industry { get; set; }

        public IList<string> AvailableIndustries { get; set; } = new List<string>();
    }
}
