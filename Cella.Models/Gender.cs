﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models{
   public  class Gender  {

        public int Id { get; set; }

        [StringLength(100)]
        public string Description { get; set; }


    }
}
