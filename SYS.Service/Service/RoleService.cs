using SYS.IService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SYS.DTO.DTO;

namespace SYS.Service.Service
{
    public class RoleService : IRoleService
    {
        public long AddNew(string roleName)
        {
            throw new NotImplementedException();
        }

        public void AddRoleIds(long adminUserId, long[] roleIds)
        {
            throw new NotImplementedException();
        }

        public RoleDTO[] GetAll()
        {
            throw new NotImplementedException();
        }

        public RoleDTO[] GetByAdminUserId(long adminUserId)
        {
            throw new NotImplementedException();
        }

        public RoleDTO GetById(long id)
        {
            throw new NotImplementedException();
        }

        public RoleDTO GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool MarkDeleted(long roleId)
        {
            throw new NotImplementedException();
        }

        public void Update(long roleId, string roleName)
        {
            throw new NotImplementedException();
        }

        public void UpdateRoleIds(long adminUserId, long[] roleIds)
        {
            throw new NotImplementedException();
        }
    }
}
