using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiPA.Web.Data;
using SiPA.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SiPA.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

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
            return _context.RequestTypes.OrderBy(rt => rt.Name);
        }
    }
}
