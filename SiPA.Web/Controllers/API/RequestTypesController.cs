using Microsoft.AspNetCore.Mvc;
using SiPA.Web.Data;
using SiPA.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Controllers.API
{
    public class RequestTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public RequestTypesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<RequestType> GetRequestTypes()
        {
            return _context.RequestTypes;
        }
    }
}
