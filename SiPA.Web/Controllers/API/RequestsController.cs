using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiPA.Prism.Models;
using SiPA.Web.Data;
using SiPA.Web.Data.Entities;
using SiPA.Web.Helpers;
using SiPA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Controllers.API
{
    [Route("api/[Controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class RequestsController : Controller
    {
        private readonly DataContext _context;
        //private readonly ICombosHelper _combosHelper;
        //private readonly IConverterHelper _converterHelper;


        public RequestsController(
            DataContext context
            //ICombosHelper combosHelper,
            //IConverterHelper converterHelper
            )
        {
            _context = context;
           // _combosHelper = combosHelper;
           // _converterHelper = converterHelper;
        }

        [HttpPost]        
        public async Task<IActionResult> PostRequest([FromBody] CertificateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parishioner = await _context.Parishioners.FindAsync(request.ParishionerId);
            if (parishioner == null)
            {
                return BadRequest("No es un usuario valido.");
            }

            var requestType = await _context.RequestTypes.FindAsync(request.RequestTypeId);
            if (requestType == null)
            {
                return BadRequest("No es un requerimiento valido.");
            }

            var req = new Request
            {
                RequestDate = request.RequestDate,
                RequestType = requestType,
                Parishioner = parishioner
            };

            _context.Requests.Add(req);
            await _context.SaveChangesAsync();
            return Ok(req);
        }
    }
}
