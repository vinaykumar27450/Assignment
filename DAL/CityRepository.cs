using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using DataModels;
namespace DAL
{
    interface ICityRepository
    {
        IEnumerable<City> getAllCity();
    }
    public class CityRepository : ICityRepository
    {
        WebAppDbContext db = new WebAppDbContext();

        public IEnumerable<City> getAllCity()
        {
            List<City> list = new List<City>();
            foreach(var x in db.tbl_City)
            {
                City city = new City();
                city.CityId = x.CityId;
                city.CityName = x.CityName;
                list.Add(city);
            }
            return list;
        }
    }
}
