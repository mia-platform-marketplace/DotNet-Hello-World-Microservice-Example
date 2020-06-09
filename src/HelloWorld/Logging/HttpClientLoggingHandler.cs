using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace Mia.Logging
{
    public class HttpClientLoggingHandler : DelegatingHandler
    {
        public HttpClientLoggingHandler(HttpMessageHandler innerHandler): base(innerHandler)
        {}
    
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Log.Information("request {method} {url}", request.Method, request.RequestUri);
            if (request.Content != null)
            {
                Log.Debug("request {request} {payload}", request, await request.Content.ReadAsStringAsync());
            } else {
                Log.Debug("request {request}", request);
            }
    
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
    
            Log.Information("response {statusCode}", response.StatusCode);
            if (response.Content != null)
            {
                Log.Debug("response {response} {payload}", response, await response.Content.ReadAsStringAsync());
            } else {
                Log.Debug("response {response}", response);
            }
    
            return response;
        }
    }
}