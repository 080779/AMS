using SYS.IService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SYS.DTO.DTO;
using SYS.Service.Entities;

namespace SYS.Service.Service
{
    public class AdminUserService : IAdminUserService
    {
        public long AddAdminUser(string name, string phoneNum, string password, string email, long? cityId)
        {
            AdminUserEntity user = new AdminUserEntity();
            user.Name = name;
            user.PhoneNum = phoneNum;
            user.PasswordHash = password;
            user.PasswordSalt = password;
            user.LoginErrorTimes = 0;
            //user.LastLoginErrorTime = DateTime.Now;
            user.Email = email;
            user.CityId = cityId;
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminUserEntity> cs = new CommonService<AdminUserEntity>(dbc);
                bool exists= cs.GetAll().Any(a => a.PhoneNum == phoneNum);
                if(exists)
                {
                    throw new ArgumentException("手机号:" + phoneNum + "已经存在");
                }
                else
                {
                    dbc.AdminUsers.Add(user);
                    dbc.SaveChanges();
                    return user.Id;
                }
            }
        }

        public bool CheckLogin(string phoneNum, string password)
        {
            throw new NotImplementedException();
        }

        public AdminUserDTO[] GetAll()
        {
            throw new NotImplementedException();
        }
               
        public AdminUserDTO GetById(long id)
        {
            throw new NotImplementedException();
        }

        public AdminUserDTO GetByPhoneNum(string phoneNum)
        {
            throw new NotImplementedException();
        }

        public bool HasPermission(long adminUserId, string permissionName)
        {
            throw new NotImplementedException();
        }

        public bool MarkDeleted(long adminUserId)
        {
            throw new NotImplementedException();
        }

        public void RecordLoginError(long id)
        {
            throw new NotImplementedException();
        }

        public void ResetLoginError(long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAdminUser(long id, string name, string email, long? cityId)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePassword(long id, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
