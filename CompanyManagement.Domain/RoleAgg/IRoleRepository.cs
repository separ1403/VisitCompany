using AccountManagement.Application.Contracts.Role;
using Framework.Domain;

namespace AccountManagement.Domain.RoleAgg
{
    public  interface IRoleRepository: IRepository<long,Role>
    {
        List<RoleViewModel> list();
        EditRole GetDetails(long id);
    }
}
