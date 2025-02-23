using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Domain
{
    public class SSOHelper
    {

        public void Login(string domain, string company, string domainController, string UserName, string Password)
        {
            string adPath = $"LDAP://{domain}/DC={company},DC={domainController}";

            DirectorySearcher mySearcher;
            SearchResult resEnt;

        }


    }
}