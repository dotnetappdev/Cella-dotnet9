using System;
using System.Collections.Generic;
using System.Linq;
using Cella.Domain;
using Cella.Models;
using Cella.Models.Permissions;
using Cella.Models.ViewModels;


namespace Cella.BL
{
    public class WarehouseBL
    {

        private CellaDBContext _context;
      
        public WarehouseBL()
        {
        }
        public CustomErrorViewModel UserHasValidPermissions(List<CellaUserPermmissions> permissionsList, string permission, string controllerName, string action)
        {
            bool isAuthorised = false;
            List<CutomError> _customError = new List<CutomError>();
            CustomErrorViewModel vm = new CustomErrorViewModel();
            string[] permissionValues = permission.Split(",");
            Dictionary<string, bool> dict = new Dictionary<string, bool>();

            List<CellaUserPermmissions> permissionResultList = new List<CellaUserPermmissions>();
            try
            {
                foreach (var item in permissionValues)
                {
                    var permissions = permissionsList.Any(w => w.Name == item && w.Controller == controllerName && w.isAcitve == true);
                    dict.Add(item, permissions);

                }
                foreach (var item in dict.Where(w => w.Value == true))
                {
                    if (item.Key == "Create" || item.Key == "Read" || item.Key == "Update" || item.Key == "Delete" && item.Value == true)
                    {
                        CellaUserPermmissions permissionResult = new CellaUserPermmissions();

                        isAuthorised = true;
                        permissionResult.Action = item.Key;
                        permissionResult.Authorized = true;
                        permissionResultList.Add(permissionResult);
                    }

                }
                foreach (var item in dict.Where(w => w.Value == false))
                {
                    _customError.Add(new CutomError() { Message = $"Uas has no {item.Key} permissions", ErrorCode = item.Key });
                    CellaUserPermmissions permissionResult = new CellaUserPermmissions();
                    permissionResult.Action = item.Key;
                    permissionResult.Authorized = false;
                    permissionResultList.Add(permissionResult);
                }
                vm.Errors = _customError;
                vm.isAuthorized = isAuthorised;
                vm.Permissions = permissionResultList;
            }
            catch (Exception ex)
            {

            }
            return vm;
        }

    }
}
