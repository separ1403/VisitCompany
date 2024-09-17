﻿using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;
using Framework.Application;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleAplication
    {
        private readonly IRoleRepository _roleRepository;

        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public OperationResult Create(CreateRole command)
        {
            var operation = new OperationResult ();
            if(_roleRepository.Exists (x=>x.Name == command.Name))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
                return operation;
            }
            else
            {
                var role= new Role (command.Name, new List<Permission>());
                _roleRepository.Create (role);
                _roleRepository.SaveChanges ();
                operation.Succeeded("عملیات با موفقیت انجام گردید");
                return operation;
            }
        }

        public OperationResult Edit(EditRole command)
        {
            var operation = new OperationResult();
            var role = _roleRepository.Get(command.Id);
            if (role == null) 
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
                return operation;
            }
            if (_roleRepository.Exists(x => x.Name == command.Name &&x.Id != command.Id))
            {
                operation.Failed(ValidationMessages.DuplicatedRecord);
                return operation;
            }
                 var permissions = new List<Permission>();
                 command.Permissions.ForEach(code=> permissions.Add(new Permission(code)));
                 role.Edit(command.Name, permissions);
                _roleRepository.SaveChanges();
                operation.Succeeded(ApplicationMessages.SuccessMessage);
                return operation;
            
        }

        public EditRole GetDetails(long id)
        {
            return _roleRepository.GetDetails(id);
        }

        public List<int> GetPermissions(long id)
        {
          return _roleRepository.Get(id).Permissions.Select(x => x.Code).ToList();
        }

        public List<RoleViewModel> List()
        {
            return _roleRepository.list();
        }
    }
}
