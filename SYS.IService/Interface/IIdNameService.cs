using SYS.DTO;
using SYS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYS.IService.Interface
{
    public interface IIdNameService:IServiceSupport
    {
        long AddNew(string typeName, string name, string imgUrl);
        IdNameDTO GetById(long id);
        IdNameDTO[] GetAllByTypeName(string typeName);
        IdNameSearchResult GetAllByTypeName(string typeName, int currentIndex, int pageIndex);
        //IdNameDTO[] GetAll();
    }
    public class IdNameSearchResult
    {
        public IdNameDTO[] IdNames { get; set; }
        public int Count { get; set; }
    }
}
