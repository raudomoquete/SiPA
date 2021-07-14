using SiPA.Web.Data;
using SiPA.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SiPA.Web.Helpers
{
    public class SacramentHelper : ISacramentHelper
    {
        private readonly DataContext _dataContext;

        public SacramentHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //public async Task<Sacrament> AddChristeningAsync(Christening christening)
        //{
        //     return await _dataContext.SaveChangesAsync(christening);
        //}



        //public object GetSacramentByName<T>(T obj, string sacramentName)
        //{
        //    PropertyInfo propInfo = typeof(T).GetProperty(sacramentName);

        //    return propInfo.GetValue(obj);
        //}
    }
}
