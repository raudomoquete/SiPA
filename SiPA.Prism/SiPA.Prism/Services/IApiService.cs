using SiPA.Prism.Models;
using System.Threading.Tasks;

namespace SiPA.Prism.Services
{
    public interface IApiService
    {
        Task<Response<ParishionerResponse>> GetParishionerByEmailAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            string email);

        Task<Response<TokenResponse>> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request);

        Task<bool> CheckConnection(string url);

        //Task<Response> AddRequestAsync(
        //    string urlBase,
        //    string servicePrefix,
        //    string controller,
        //    RequestResponse requestResponse);
    }
}
