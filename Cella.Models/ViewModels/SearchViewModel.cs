using System;
using System.Collections.Generic;
using System.Text;
 

namespace  Cella.Models.ViewModels {
   public  class SearchViewModel {

       public int Id {
           get;
           set;
       }
        public string Name{ get; set; }

       public string Age { get; set; }
       public DateTime DOB { get; set; }

       public string IMONumber { get; set; }
       public string FacialFeatures  { get; set; }
 
       public string SearchType { get; set; }
   

   }
}
