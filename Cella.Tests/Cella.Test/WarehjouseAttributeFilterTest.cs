using NUnit.Framework;
using System.Collections.Generic;
using   Cella.Models;
using Cella.Models.Permissions;
using Moq;
using System.Linq;
using Cella.Models.ViewModels;
using Cella.BL;

namespace WareHouseCrm.Test
{
    public class Tests
    {
        private List<CellaUserPermmissions> permissionsList;
        WarehouseBL _warehouseBL;

        [SetUp]
        public void Setup()
        {
            _warehouseBL = new WarehouseBL();

            permissionsList = new List<CellaUserPermmissions>(){
        new CellaUserPermmissions {
            Name="Create",
            Action="Create",
            Controller="StockItems",            
            isAcitve=true            
            //populate other properties  
        }, new CellaUserPermmissions {
            Name="Update",
            Action="Update",
            Controller="StockItems",
            isAcitve=false            
            //populate other properties  
        },new CellaUserPermmissions {
            Name="Delete",
            Action="Delete",
            Controller="StockItems",
            isAcitve=true            
            //populate other properties  
        },
        new CellaUserPermmissions
          {
              Name = "Read",
              Action = "Read",
              Controller = "Test",
              isAcitve = true
              //populate other properties  
          }
         };
        }

    
        [TestCase("Create,Update", "StockItems", 1)]
        [TestCase("Delete,Update", "StockItems", 1)]
        [TestCase("Read,Update", "StockItems", 2)]
        [TestCase("Update", "StockItems", 1)]
        public void Vlaidate_Permissions_Returns_Corrrect_Errors(string permission,string controllerName,int expected)
        {
            
            CustomErrorViewModel hasValidPermissions = _warehouseBL.UserHasValidPermissions(permissionsList, permission, controllerName, "");
           // Assert.AreEqual(expected, hasValidPermissions.Errors.Count);
        }
    }
}