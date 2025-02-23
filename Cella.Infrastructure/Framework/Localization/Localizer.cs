using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Infrastructure.Framework.Localization
{
    public delegate LocalizedString Localizer(string text, params object[] args);

}
