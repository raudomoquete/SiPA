using SiPA.Web.Data;
using SiPA.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //public async Task<bool> DeleteSacramentAsync(string sacramentName)
        //{
        //    var sacrament = await GetSacramentByNameAsync(sacramentName);
        //    if (sacrament == null)
        //    {
        //        return true;
        //    }

        //    return await _dataContext.Remove(sacrament);
        //    //return response.Succeeded;
        //}

        public async Task<Sacrament> GetSacramentByNameAsync(string sacramentName)
        {
            return await _dataContext.FindAsync(sacramentName);
        }
    }
}
