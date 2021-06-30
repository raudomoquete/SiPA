using SiPA.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Helpers
{
    public interface ISacramentHelper
    {
        //Task UpdateSacramentAsync(Sacrament sacrament);

        Task<Sacrament> GetSacramentByNameAsync(string sacramentName);
        //Task<bool> DeleteSacramentAsync(string sacramentName);

    }
}
