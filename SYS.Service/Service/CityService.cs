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
    public class CityService : ICityService
    {
        public long AddNew(string cityName)
        {
            CityEntity city = new CityEntity();
            city.Name = cityName;
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<CityEntity> cs = new CommonService<CityEntity>(dbc);
                if(cs.GetAll().Any(c=>c.Name==cityName))
                {
                    return 0;
                }
                else
                {
                    dbc.Cities.Add(city);
                    dbc.SaveChanges();
                    return city.Id;
                }
            }
        }

        public CityDTO[] GetAll()
        {
            throw new NotImplementedException();
        }

        public CityDTO GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
