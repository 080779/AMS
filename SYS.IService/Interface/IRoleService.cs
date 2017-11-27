using SYS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYS.IService.Interface
{
    /// <summary>
    /// 角色管理接口
    /// </summary>
    public interface IRoleService : IServiceSupport
    {
        long AddNew(string roleName);
        void Update(long roleId, string roleName);
        bool MarkDeleted(long roleId);
        RoleDTO GetById(long id);
        RoleDTO GetByName(string name);
        RoleDTO[] GetAll();
        void AddRoleIds(long adminUserId, long[] roleIds);
        void UpdateRoleIds(long adminUserId, long[] roleIds);
        RoleDTO[] GetByAdminUserId(long adminUserId);
    }
}
