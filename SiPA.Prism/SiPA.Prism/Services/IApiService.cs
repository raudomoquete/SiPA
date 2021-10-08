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

        Task<Response<object>> PutAsync<T>(
        string urlBase,
        string servicePrefix,
        string controller,
        T model,
        string tokenType,
        string accessToken);

        Task<Response<TokenResponse>> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request);

        Task<bool> CheckConnection(string url);

        Task<Response<object>> PostAsync<T>(
         string urlBase,
         string servicePrefix,
         string controller,
         T model,
         string tokenType,
         string accessToken);

        Task<Response<object>> PutAsync<T>(
         string urlBase,
         string servicePrefix,
         string controller,
         int id,
         T model,
         string tokenType,
         string accessToken);

        Task<Response<object>> AddRequestAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            RequestResponse requestResponse);

        Task<Response<object>> GetListAsync<T>(
        string urlBase,
        string servicePrefix,
        string controller,
        string tokenType,
        string accessToken);
    }
}
