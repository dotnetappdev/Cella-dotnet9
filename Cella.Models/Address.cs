using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using System.Text;

namespace Cella.Models{
    public class Address {

        public enum AddressType
        {
            Customer=1,
            Shop=2,
            PrivateResident=3,
            Flats=4
            

        }

        public int? Id { get; set; }
        public string? CompanyName { get; set; }


        public string? UserId { get; set; }
        public Guid? StoreId { get; set; }


        public int? Type { get; set; }

        [StringLength(3)]
        public string? HouseNumber { get; set; }
        [StringLength(90)]
        public string? StreetName { get; set; }
        [StringLength(70)]
        public string? Address1 { get; set; }
        [StringLength(70)]
        public string? Address2 { get; set; }
        [StringLength(30)]
        public string? City { get; set; }
        public string? Town { get; set; }
        public int? StateProvinceId { get; set; }
        [StringLength(15)]
        public string? PostCode { get; set; }
        [Range(typeof(decimal), "10", "8")]
        [Column(TypeName = "decimal(10, 8)")]

        public decimal? Lat { get; set; }
        [Range(typeof(decimal), "11", "8")]
        [Column(TypeName = "decimal(11, 8)")]

        public decimal? Long { get; set; }

        public DateTime? ModfiedDate { get; set; }


        public Int32 WarehouseId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
        [StringLength(30)]
        public string CreatedBy { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }

    }

}
