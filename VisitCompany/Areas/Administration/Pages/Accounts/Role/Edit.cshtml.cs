using AccountManagement.Application.Contracts.Role;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VisitCompany.Areas.Administration.Pages.Accounts.Role
{
  //  [Authorize]
    public class EditModel : PageModel
    {
       

        [TempData]
        public string ErrorMessageameEd { get; set; }

        [TempData]
        public string SuccessMessageameEd { get; set; }

        
        public List<SelectListItem> Permissions = new List<SelectListItem>();
        public EditRole Command {get; set; }

        private readonly IRoleAplication _roleAplication;
        private readonly IEnumerable<IPermissionExposer> _exposers;


        public EditModel(IRoleAplication roleAplication, IEnumerable<IPermissionExposer> exposers)
        {
            _roleAplication = roleAplication;
            _exposers = exposers;
        }

     //   [NeedsPermission(CompanyPermission.EditRoles)]
        public void OnGet(long id)
        {

            Command = _roleAplication.GetDetails(id);
            foreach (var exposer in _exposers)
            {
                var exposedPermissions = exposer.Expose();
                foreach (var (key, value) in exposedPermissions)
                {
                    var group = new SelectListGroup { Name = key };
                    foreach (var permission in value)
                    {
                        var item = new SelectListItem(permission.Name, permission.Code.ToString())
                        {
                            Group = group
                        };

                        if(Command.MappedPermissions.Any(x=> x.Code == permission.Code))
                            item.Selected =true;

                        Permissions.Add(item);

                    }
                }
            }
            

        }
       // [NeedsPermission(CompanyPermission.EditRoles)]
        public IActionResult  OnPostEdit(EditRole command)
        {
            var operationResult = _roleAplication.Edit(command);



            if (operationResult.IsSucceeded)

                SuccessMessageameEd = operationResult.Message;

            else

                ErrorMessageameEd = operationResult.Message;

            return RedirectToPage("./Index");

        }
    }
}
