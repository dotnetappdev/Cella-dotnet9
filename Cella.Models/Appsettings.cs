using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models
{
    public class ApplicationSettings
    {


        public string Secret { get; set; }
    public string ConnectionStrings { get; set; }
    public string Store { get; set; }
      public string AllowedHosts { get; set; }

    public string ApiKey { get; set; }
    public string Theme { get; set; }
}

}
