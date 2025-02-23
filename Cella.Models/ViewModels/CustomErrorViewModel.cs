using Cella.Models.Permissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models.ViewModels
{
    public class CustomErrorViewModel
    {
        public List<CutomError> Errors { get; set; }


        public List<CellaUserPermmissions> Permissions { get; set; }

        public bool Create { get; set; }

        public bool Read { get; set; }

        public bool Update { get; set; }

        public bool Delete { get; set; }

        public bool View { get; set; }
        public bool isAuthorized { get; set; }
    }
}
