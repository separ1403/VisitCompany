using System.Collections.Generic;
using Framework.Application;

namespace AccountManagement.Application.Contracts.Role
{
    public interface IRoleAplication
    {
        OperationResult Create(CreateRole command);
        OperationResult Edit(EditRole command);
        List<RoleViewModel> List();
        EditRole GetDetails(long id);
        List<int> GetPermissions(long id);

    }
}
