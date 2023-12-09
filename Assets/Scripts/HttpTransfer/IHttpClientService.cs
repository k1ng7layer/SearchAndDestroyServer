using System.Net.Http;
using UniRx.Async;

namespace HttpTransfer
{
    public interface IHttpClientService
    {
        UniTask<HttpResponseMessage> PostAsync(string url, string payload);
    }
}