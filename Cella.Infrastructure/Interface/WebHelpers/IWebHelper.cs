using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Infrastructure.Interface
{
    public partial interface IWebHelper
    { /// <summary>
      /// Get the raw path and full query of request
      /// </summary>
      /// <param name="request">HTTP request</param>
      /// <returns>Raw URL</returns>
        string GetRawUrl(HttpRequest request);

        /// <summary>
        /// Gets current HTTP request protocol
        /// </summary>
        string GetCurrentRequestProtocol();
    }
}
