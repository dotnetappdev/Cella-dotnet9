using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Domain.Configuration
{
    public class AppSettings 
    {

        [Key]
        public string Key { get; set; }
        public string Value { get; set; }

        internal IDictionary<string, string> ToDictionary(Func<object, object> p1, Func<object, object> p2)
        {
            throw new NotImplementedException();
        }
    }
}
