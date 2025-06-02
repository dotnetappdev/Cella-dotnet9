using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models
{
    public class GoogleAuthSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
    public class MicrosoftAuthSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
    public class AppSettings
    {
        public string JwtSecret { get; set; } = string.Empty;

        public string BaseAddress { get; set; }
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpirationInMinutes { get; set; } = 0;
        public Dictionary<string, string> ConnectionStrings { get; set; } = new();
  
        public GoogleAuthSettings GoogleAuth { get; set; }
        public MicrosoftAuthSettings MicrosoftAuth { get; set; }

        public string GetDefaultConnection()
        {
            return this.ConnectionStrings["DefaultConnection"];
        }
    }

}
