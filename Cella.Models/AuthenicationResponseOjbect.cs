
using System;
using System.Collections.Generic;
using System.Text;
namespace Cella.Models {
    public partial class AuthenicationResponseOjbect {
         public long Id { get; set; }


        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }
        public object FirstName { get; set; }

         public object LastName { get; set; }

         public string Username { get; set; }

         public string JwtToken { get; set; }
  
        public object RefreshToken { get; set; }
    }
}
