﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Text;

namespace Cella.Models
{
    public class Customer
    {

        public int Id { get; set; }
        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }


        public virtual Address Address { get; set; }
        public string DailingCountryCode { get; set; }

        public string MobileNumber { get; set; }

        public bool isBusinessMobile { get; set; }

        public bool isPersonalMobile { get; set; }

        public bool canSms { get; set; }

        public bool canCall { get; set; }

         public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public DateTime LastModified { get; set; }

        public bool isOptOut { get; set; }

        public bool isGpdr { get; set; }
   public string CreatedBy { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }


    }
}
