using SYS.IService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SYS.DTO.DTO;
using SYS.DTO;
using SYS.Service.Entities;

namespace SYS.Service.Service
{
    public class IdNameService : IIdNameService
    {
        public long AddNew(string typeName, string name, string imgUrl)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                IdNameEntity entity = new IdNameEntity();
                entity.TypeName = typeName;
                entity.Name = name;
                entity.ImgUrl = imgUrl;
                dbc.IdNames.Add(entity);
                dbc.SaveChanges();
                return entity.Id;
            }
        }

        //public IdNameDTO[] GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        public IdNameDTO[] GetAllByTypeName(string typeName)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<IdNameEntity> cs = new CommonService<IdNameEntity>(dbc);
                var entity = cs.GetAll().Where(i=>i.TypeName==typeName);
                if(entity==null)
                {
                    return null;
                }
                return entity.Select(i => new IdNameDTO { Id = i.Id, Name = i.Name, TypeName = i.TypeName, CreateDateTime = i.CreateDateTime, ImgUrl = i.ImgUrl }).ToArray();
            }
        }

        public IdNameSearchResult GetAllByTypeName(string typeName,int currentIndex,int pageIndex)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<IdNameEntity> cs = new CommonService<IdNameEntity>(dbc);
                var entity = cs.GetAll().Where(i => i.TypeName == typeName);
                if (entity == null)
                {
                    return null;
                }
                IdNameSearchResult result = new IdNameSearchResult();
                result.Count = entity.Count();
                result.IdNames= entity.OrderByDescending(i=>i.CreateDateTime).Skip(currentIndex).Take(pageIndex).Select(i => new IdNameDTO { Id = i.Id, Name = i.Name, TypeName = i.TypeName, CreateDateTime = i.CreateDateTime, ImgUrl = i.ImgUrl }).ToArray();
                return result;
            }
        }

        public IdNameDTO GetById(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<IdNameEntity> cs = new CommonService<IdNameEntity>(dbc);
                var entity = cs.GetAll().SingleOrDefault(i => i.Id == id);
                if(entity==null)
                {
                    return null;
                }
                return new IdNameDTO { Id = entity.Id, Name = entity.Name, TypeName = entity.TypeName, CreateDateTime = entity.CreateDateTime, ImgUrl = entity.ImgUrl };
            }
        }
    }
}
