using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarehouseCrm.Module.SampleData.Areas.SampleData.ViewModels;

namespace WarehouseCrm.Module.SampleData.Areas.SampleData.Controllers
{
    [Area("SampleData")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SampleDataController : Controller
    {
   
        public SampleDataController( )
        {
           
        }

        public IActionResult Index()
        {
            return View();
        }

    

    }
}
