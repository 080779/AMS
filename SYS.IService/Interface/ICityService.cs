using SYS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYS.IService.Interface
{
    /// <summary>
    /// 城市服务接口
    /// </summary>
    public interface ICityService : IServiceSupport
    {
        long AddNew(string cityName);
        CityDTO GetById(long id);
        CityDTO[] GetAll();
    }
}
