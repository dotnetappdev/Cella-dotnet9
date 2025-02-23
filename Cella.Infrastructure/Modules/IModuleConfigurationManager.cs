using System.Collections.Generic;
using Cella.Models;

namespace Cella.Infrastructure.Modules
{
    public interface IModuleConfigurationManager
    {
        IEnumerable<ModuleInfo> GetModules();
    }
}