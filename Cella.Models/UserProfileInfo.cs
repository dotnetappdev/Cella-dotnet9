using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models{
    public class UserProfileInfo {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /// <summary>
        /// this is differnt to roles 
        /// this is to allow more the agent
        /// to act as a customer 
        /// and place an order
        /// </summary>
        public enum UserTypeEnum
        {
            Customer = 1,
            Agent = 2,
            Manager = 3,
            Accounts = 4,
            Admin = 5

        }

        public int? UserType { get; set; }
    }
} 
 
