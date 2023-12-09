using System.Net.Http;
using Palmmedia.ReportGenerator.Core.Common;
using UniRx.Async;
using HttpClient = System.Net.Http.HttpClient;

namespace HttpTransfer.Impl
{
    public class HttpClientService : IHttpClientService
    {
        public UniTask<HttpResponseMessage> PostAsync(string url, string payload)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                
                using (var request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    request.Content = new StringContent(payload);
                    
                    return httpClient.SendAsync(request).AsUniTask();
                }
            }
        }
    }
}