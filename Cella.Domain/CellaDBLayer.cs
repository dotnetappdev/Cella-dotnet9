using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cella.Models;

using System.Threading;
namespace Cella.Domain
{
    public class CellaDBLayer {

        private CellaDBContext _context;
          


        public CellaDBLayer(CellaDBContext context)
    {
       
            _context = context;  
        }

      

    }
}
