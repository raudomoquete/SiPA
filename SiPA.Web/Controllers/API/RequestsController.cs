using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiPA.Prism.Models;
using SiPA.Web.Data;
using SiPA.Web.Data.Entities;
using SiPA.Web.Helpers;
using System.Threading.Tasks;

namespace SiPA.Web.Controllers.API
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class RequestsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;


        public RequestsController(
            DataContext dataContext,
            IConverterHelper converterHelper)
        {
            _context = dataContext;
            _converterHelper = converterHelper;
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
                RequestDate = request.RequestDate.ToUniversalTime(),
                RequestType = requestType,
                Parishioner = parishioner
            };

            _context.Requests.Add(req);
            await _context.SaveChangesAsync();
            return Ok(_converterHelper.ToRequestResponse(req));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest([FromRoute] int id, [FromBody] CertificateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.Id)
            {
                return BadRequest();
            }

            var oldRequest = await _context.Requests.FindAsync(request.Id);
            if (oldRequest == null)
            {
                return BadRequest("Requerimiento no existe.");
            }

            var requestType = await _context.RequestTypes.FindAsync(request.RequestTypeId);
            if (requestType == null)
            {
                return BadRequest("No es un tipo de requerimiento valido");
            }

            oldRequest.RequestDate = request.RequestDate.ToUniversalTime();
            oldRequest.RequestType = requestType;

            _context.Requests.Update(oldRequest);
            await _context.SaveChangesAsync();
            return Ok(_converterHelper.ToRequestResponse(oldRequest));
        }
    }
}