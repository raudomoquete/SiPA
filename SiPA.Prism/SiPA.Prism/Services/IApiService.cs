using SiPA.Prism.Models;
using System.Threading.Tasks;

namespace SiPA.Prism.Services
{
    public interface IApiService
    {
        Task<Response> GetParishionerByEmailAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            string email);

        Task<Response> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request);

        Task<Response> AddRequestAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            RequestResponse requestResponse);
    }
}
