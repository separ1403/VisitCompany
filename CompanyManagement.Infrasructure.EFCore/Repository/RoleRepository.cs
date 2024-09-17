using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;
using CompanyManagement.Infrasructure.EFCore;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public  class RoleRepository : RepositoryBase<long, Role>, IRoleRepository
    {
        public RoleRepository(CompanyContext context) : base(context)
        {
            _companyContext = context;
        }


        private readonly CompanyContext _companyContext;




        public List<RoleViewModel> list()
        {
            return _companyContext.Roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),


            }).ToList();

        }

        public EditRole GetDetails(long id)
        {
            var role = _companyContext.Roles.Select(x => new EditRole
            {
                Id = x.Id,
                Name = x.Name,
                MappedPermissions = MappPermisions(x.Permissions),


            }).AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
            role.Permissions = role.MappedPermissions.Select(x => x.Code).ToList();
            return role;
        }

        private static List<PermissionDto> MappPermisions(List<Permission> permissions)
        {
            return permissions.Select(x => new PermissionDto(x.Code, x.Name)).ToList();
        }
    }
}
