using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiPA.Prism.Models;
using SiPA.Web.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ParishionersController : ControllerBase
    {
        private readonly DataContext _context;

        public ParishionersController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("GetParishionerByEmail")]
        public async Task<IActionResult> GetParishioner(EmailRequest emailRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var parishioner = await _context.Parishioners
                .Include(p => p.User)
                //.Include(p => p.Christenings)
                //.Include(p => p.FirstCommunions)
                //.Include(p => p.Confirmations)
                //.Include(p => p.Weddings)
                //.Include(p => p.Histories)
                .Include(p => p.Requests)
                .ThenInclude(r => r.RequestType)
                //.Include(p => p.Certificates)
                .FirstOrDefaultAsync(p => p.User.UserName.ToLower() == emailRequest.Email.ToLower());

            var response = new ParishionerResponse
            {
                Id = parishioner.Id,
                FirstName = parishioner.User.FirstName,
                LastName = parishioner.User.LastName,
                Address = parishioner.User.Address,
                Email = parishioner.User.Email,
                PhoneNumber = parishioner.User.PhoneNumber,
                Requests = parishioner.Requests.Select(p => new RequestResponse
                {
                    RequestDate = p.RequestDate,
                    Id = p.Id,
                    RequestType = p.RequestType.Name
                }).ToList()
            };

            return Ok(response);
        }
    }
}
