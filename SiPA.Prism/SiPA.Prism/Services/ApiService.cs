using Newtonsoft.Json;
using Plugin.Connectivity;
using SiPA.Prism.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SiPA.Prism.Services
{
    public class ApiService : IApiService
    {
        public async Task<Response<TokenResponse>> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request)
        {
            try
            {
                var requestString = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestString, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response<TokenResponse>
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var token = JsonConvert.DeserializeObject<TokenResponse>(result);
                return new Response<TokenResponse>
                {
                    IsSuccess = true,
                    Result = token
                };
            }
            catch (Exception ex)
            {
                return new Response<TokenResponse>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<ParishionerResponse>> GetParishionerByEmailAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            string email)
        {
            try
            {
                var request = new EmailRequest { Email = email };
                var requestString = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestString, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response<ParishionerResponse>
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var parishioner = JsonConvert.DeserializeObject<ParishionerResponse>(result);
                return new Response<ParishionerResponse>
                {
                    IsSuccess = true,
                    Result = parishioner
                };
            }
            catch (Exception ex)
            {
                return new Response<ParishionerResponse>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<bool> CheckConnection(string url)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return false;
            }

            return await CrossConnectivity.Current.IsRemoteReachable(url);
        }

        //public async Task<Response> AddRequestAsync(
        //    string urlBase,
        //    string servicePrefix,
        //    string controller,
        //    RequestResponse requestResponse)
        //{
        //    try
        //    {
        //        var request = JsonConvert.SerializeObject(requestResponse);
        //        var content = new StringContent(request, Encoding.UTF8, "application/json");
        //        var client = new HttpClient
        //        {
        //            BaseAddress = new Uri(urlBase)
        //        };

        //        var url = $"{servicePrefix}{controller}";
        //        var response = await client.PostAsync(url, content);
        //        var answer = await response.Content.ReadAsStringAsync();
        //        var obj = JsonConvert.DeserializeObject<Response>(answer);
        //        return obj;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response
        //        {
        //            IsSuccess = false,
        //            Message = ex.Message,
        //        };
        //    }
        //}
    }
}
